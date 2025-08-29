using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace sendtodiscord
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            loadUserSettings();

            // auto-save settings on close
            FormClosing += new FormClosingEventHandler(Form_FormClosing);

            var programName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var versionNumber = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = programName + " v." + versionNumber;
        }

        // file selection buttons

        private void selectReplayFileButton_Click(object sender, EventArgs e)
        {
            replayFileDialog.InitialDirectory = osuDirectoryTextBox.Text + @"\Replays";
            replayFileDialog.ShowDialog();
        }

        private void replayFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            replayFilePathTextBox.Text = replayFileDialog.FileName;
        }

        private void selectDanserBinaryButton_Click(object sender, EventArgs e)
        {
            danserBinaryFileDialog.InitialDirectory = Path.GetDirectoryName(danserBinaryPathTextBox.Text);
            danserBinaryFileDialog.ShowDialog();
        }

        private void danserBinaryFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            danserBinaryPathTextBox.Text = danserBinaryFileDialog.FileName;
        }

        private void selectDanserSettingsButton_Click(object sender, EventArgs e)
        {
            danserSettingsFileDialog.InitialDirectory = Path.GetDirectoryName(danserSettingsPathTextBox.Text);
            danserSettingsFileDialog.ShowDialog();
        }

        private void danserSettingsFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            danserSettingsPathTextBox.Text = danserSettingsFileDialog.FileName;
        }

        private void selectOsuDirectoryButton_Click(object sender, EventArgs e)
        {
            osuDirectoryFileDialog.ShowDialog();
        }

        private void osuDirectoryFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            osuDirectoryTextBox.Text = Path.GetDirectoryName(osuDirectoryFileDialog.FileName);
        }

        // other buttons

        private void openDanserGuiButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(danserBinaryPathTextBox.Text))
            {
                var danserExecutablePath = Path.GetDirectoryName(danserBinaryPathTextBox.Text) + "\\danser.exe";
                if (File.Exists(danserExecutablePath))
                {
                    Process.Start(danserExecutablePath);
                }
                else
                {
                    MessageBox.Show("selected danser binary path does not contain danser.exe",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void openDanserFolderButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(danserBinaryPathTextBox.Text))
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Path.GetDirectoryName(danserBinaryPathTextBox.Text),
                    UseShellExecute = true,
                    Verb = "open",
                });
            }
        }

        private async void renderAndUploadButton_Click(object? sender, EventArgs e)
        {
            renderAndUploadButton.Enabled = false;
            renderLatestReplayButton.Enabled = false;
            // prevent user from changing the danser path and invalidating the rendered video path
            danserBinaryPathTextBox.ReadOnly = true;
            selectDanserBinaryButton.Enabled = false;
            webhookUrlTextBox.ReadOnly = true;

            if (allPathsValid())
            {
                using var cancellationTokenSource = new CancellationTokenSource();
                var renderCancellationToken = cancellationTokenSource.Token;

                void cancelRender(object? sender, EventArgs e)
                {
                    renderAndUploadButton.Enabled = false;
                    renderAndUploadButton.Text = "Cancelling...";
                    cancellationTokenSource.Cancel();
                }

                renderAndUploadButton.Click -= renderAndUploadButton_Click;
                renderAndUploadButton.Text = "Cancel Render";
                renderAndUploadButton.Click += cancelRender;
                renderAndUploadButton.Enabled = true;

                logTabControl.SelectedTab = danserLogTab;
                danserLogTextBox.Clear();

                try
                {
                    string videoFileName = await danserRender(renderCancellationToken);

                    detailedLog(true, programLogTextBox, "Render complete.", true);
                    logTabControl.SelectedTab = programLogTab; // can be removed if render and upload are separated

                    var danserPath = Path.GetDirectoryName(danserBinaryPathTextBox.Text);
                    string videosPath = danserPath + @"\videos";
                    var matchingFiles = Directory.GetFiles(videosPath, videoFileName + ".*");
                    var videoFilePath = matchingFiles[0];

                    if (matchingFiles.Length == 0)
                    {
                        throw new Exception("No matching video file found!");
                    }
                    else
                    {
                        var videoBytes = new FileInfo(videoFilePath);
                        detailedLog(true, programLogTextBox, "Rendered video is "
                            + (float)videoBytes.Length / 1000000 + " MB ("
                            + (float)videoBytes.Length / 1048576 + " MiB)", true);

                        if (videoBytes.Length >= 1000000000) // 1 GB limit for Litterbox
                        {
                            detailedLog(true, programLogTextBox, "Rendered file is too large to upload.", true);
                        }
                        else
                        {
                            using var cancellationTokenSource2 = new CancellationTokenSource();
                            var uploadCancellationToken = cancellationTokenSource2.Token;

                            void cancelUpload(object? sender, EventArgs e)
                            {
                                renderAndUploadButton.Enabled = false;
                                cancellationTokenSource2.Cancel();
                            }

                            renderAndUploadButton.Click -= cancelRender;
                            renderAndUploadButton.Text = "Cancel Upload";
                            renderAndUploadButton.Click += cancelUpload;
                            renderAndUploadButton.Enabled = true;

                            try
                            {
                                await uploadRenderedVideo(videoFilePath, uploadCancellationToken);
                            }
                            catch (OperationCanceledException)
                            {
                                detailedLog(true, programLogTextBox, "Upload cancelled.", true);
                            }
                            catch
                            {
                                detailedLog(true, programLogTextBox, "Upload failed!", true); // already caught in other method but...
                            }
                            finally
                            {
                                renderAndUploadButton.Click -= cancelUpload;
                                cancellationTokenSource2.Dispose();
                            }
                        }

                        if (deleteRenderedVideoCheckBox.Checked)
                        {
                            File.Delete(videoFilePath);
                            detailedLog(true, programLogTextBox, "Deleted video file.", true);
                        }
                    }
                }

                catch (OperationCanceledException)
                {
                    detailedLog(true, programLogTextBox, "Render cancelled.", true);
                }
                catch (Exception ex) 
                {
                    detailedLog(true, programLogTextBox, ex.ToString(), true);
                    detailedLog(true, programLogTextBox, "danser render failed!", true);
                }
                finally
                {
                    renderAndUploadButton.Text = "Render and Upload";
                    renderAndUploadButton.Click -= cancelRender;
                    renderAndUploadButton.Click += renderAndUploadButton_Click;
                    renderAndUploadButton.Enabled = true;
                    renderLatestReplayButton.Enabled = true;
                    logTabControl.SelectedTab = programLogTab;
                    cancellationTokenSource.Dispose();
                }
            }
        }

        private void renderLatestReplayButton_Click(object sender, EventArgs e)
        {
            var replaysDirectory = osuDirectoryTextBox.Text + @"\Replays\";
            if (!Directory.Exists(replaysDirectory))
            {
                detailedLog(true, programLogTextBox, "osu! directory not set", true);
            }
            else
            {
                renderLatestReplayButton.Enabled = false;
                DirectoryInfo replaysDirectoryInfo = new(replaysDirectory);
                var replayFiles = replaysDirectoryInfo.GetFiles();
                Array.Sort(replayFiles, delegate (FileInfo file1, FileInfo f2)
                {
                    return f2.CreationTime.CompareTo(file1.CreationTime);
                });
                if (replayFiles.Length == 0)
                {
                    detailedLog(true, programLogTextBox, "No replay files found.", true);
                }
                else
                {
                    replayFilePathTextBox.Text = replayFiles[0].ToString();
                    renderAndUploadButton.PerformClick();
                }
            }
        }

        // event handlers

        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            saveUserSettings();
        }

        // helpers

        private void loadUserSettings()
        {
            webhookUrlTextBox.Text = Properties.Settings.Default.webhookUrl;
            danserBinaryPathTextBox.Text = Properties.Settings.Default.danserPath;
            danserSettingsPathTextBox.Text = Properties.Settings.Default.danserSettings;
            deleteRenderedVideoCheckBox.Checked = Properties.Settings.Default.deleteRenderedVideo;
            showDanserTerminalCheckBox.Checked = Properties.Settings.Default.showDanserTerminal;
            detectOsuDirectory();
            osuDirectoryTextBox.Text = Properties.Settings.Default.osuDirectory;
            danserArgumentsTextBox.Text = Properties.Settings.Default.danserArguments;
        }

        private static void detectOsuDirectory()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.osuDirectory)
                || string.IsNullOrWhiteSpace(Properties.Settings.Default.osuDirectory))
            {
                var osuDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\osu!";
                if (Directory.Exists(osuDirectory))
                {
                    Properties.Settings.Default.osuDirectory = osuDirectory;
                }
                else
                {
                    Properties.Settings.Default.osuDirectory = string.Empty;
                }
            }
        }

        private void saveUserSettings()
        {
            Properties.Settings.Default["webhookUrl"] = webhookUrlTextBox.Text;
            Properties.Settings.Default["danserPath"] = danserBinaryPathTextBox.Text;
            Properties.Settings.Default["deleteRenderedVideo"] = deleteRenderedVideoCheckBox.Checked;
            Properties.Settings.Default["danserSettings"] = danserSettingsPathTextBox.Text;
            Properties.Settings.Default["showDanserTerminal"] = showDanserTerminalCheckBox.Checked;
            Properties.Settings.Default["osuDirectory"] = osuDirectoryTextBox.Text;
            Properties.Settings.Default["danserArguments"] = danserArgumentsTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void detailedLog(bool includeTime, RichTextBox textBox, string message, bool newLine)
        {
            DateTime localTime = DateTime.Now;
            var toLog = (includeTime ? localTime.ToString("HH:mm:ss.ffff") : "") + " > " + message + (newLine ? Environment.NewLine : "");
            if (InvokeRequired)
            {
                textBox.Invoke((MethodInvoker)delegate
                {
                    textBox.AppendText(toLog);
                });
            }
            else
            {
                textBox.AppendText(toLog);
            }
        }

        // adapted from https://stackoverflow.com/a/68185849

        private void progressTracker(FileStream streamToTrack, ref bool keepTracking)
        {
            int prevPos = 0;
            while (keepTracking)
            {
                int pos = (int)Math.Round(100 * (streamToTrack.Position / (double)streamToTrack.Length));
                if (pos != prevPos)
                {
                    uploadProgressBar.Invoke((MethodInvoker)delegate
                    {
                        uploadProgressBar.Increment(pos - prevPos);
                    });
                }
                prevPos = pos;
                
                Thread.Sleep(500); //update every 500ms
            }
        }

        /// <summary>
        /// Check validity of webhook URL, replay file, and danser file.
        /// </summary>
        private bool allPathsValid()
        {
            // could implement more robust validity check
            if (string.IsNullOrEmpty(webhookUrlTextBox.Text)
                || string.IsNullOrWhiteSpace(webhookUrlTextBox.Text))
            {
                detailedLog(true, programLogTextBox, "Invalid webhook URL.", true);
                renderAndUploadButton.Enabled = true;
                return false;
            }
            else if (!File.Exists(replayFilePathTextBox.Text))
            {
                detailedLog(true, programLogTextBox, "Invalid replay file path.", true);
                renderAndUploadButton.Enabled = true;
                return false;
            }
            else if (!File.Exists(danserBinaryPathTextBox.Text))
            {
                detailedLog(true, programLogTextBox, "Invalid danser path.", true);
                renderAndUploadButton.Enabled = true;
                return false;
            }
            return true;
        }
    
        private Task<string> danserRender(CancellationToken cancellationToken)
        {
            string outputFileName = "danser_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string danserArguments = "-replay \"" + replayFilePathTextBox.Text + "\""
                                    + " -out " + outputFileName;

            // could also migrate danser settings to being passed through via argument
            if (File.Exists(danserSettingsPathTextBox.Text))
            {
                // danser uses relative pathing when loading config files
                danserArguments += " -settings " + Path.GetFileNameWithoutExtension(danserSettingsPathTextBox.Text);
            }
            else
            {
                detailedLog(true, programLogTextBox, "Using default danser settings...", true);
            }

            if (!string.IsNullOrEmpty(danserArgumentsTextBox.Text))
            {
                danserArguments += " " + danserArgumentsTextBox.Text + " ";
            }

            detailedLog(true, programLogTextBox, "Starting danser...", true);
            detailedLog(true, programLogTextBox, danserBinaryPathTextBox.Text + " " + danserArguments, true);

            Process danser = new()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = danserBinaryPathTextBox.Text,
                    Arguments = danserArguments,
                    RedirectStandardOutput = true,
                    CreateNoWindow = !showDanserTerminalCheckBox.Checked,
                }
            };

            return Task.Run(() =>
            {
                danser.Start();

                while (!danser.StandardOutput.EndOfStream)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        danser.Kill(true);
                        danser.WaitForExit();
                        var danserPath = Path.GetDirectoryName(danserBinaryPathTextBox.Text);
                        string videosPath = danserPath + @"\videos";
                        if (Directory.Exists(videosPath + @"\" + outputFileName + "_temp"))
                        {
                            Directory.Delete(videosPath + @"\" + outputFileName + "_temp", true);
                        }

                        danser.Dispose();
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    var nextLine = danser.StandardOutput.ReadLine();
                    if (!(nextLine == null)) // redundant check because not at end of stream; check to quell IntelliSense
                    {
                        detailedLog(false, danserLogTextBox, nextLine, true);
                    }
                }

                danser.Dispose();

                return outputFileName;
            }, cancellationToken);
        }
    
        private Task<bool> uploadRenderedVideo(string videoFilePath, CancellationToken cancellationToken)
        {
            FileInfo videoBytes = new(videoFilePath);
            HttpClient httpClient = new();

            FileStream fileStream = File.OpenRead(videoFilePath);
            HttpContent httpContent = new StreamContent(fileStream);

            bool trackingUpload = true;
            new Task(new Action(() => { progressTracker(fileStream, ref trackingUpload); })).Start();
            uploadProgressBar.Value = 0;

            if (videoBytes.Length >= 10485760) // 10 MiB, as per https://discord.com/developers/docs/reference#uploading-files
            {
                detailedLog(true, programLogTextBox, "Uploading to Litterbox...", true);

                return Task.Run(async () =>
                {
                    using var multipart = new MultipartFormDataContent
                    {
                        { new StringContent("fileupload"), "reqtype" },
                        { new StringContent("72h"), "time" },
                        { httpContent, "fileToUpload", Path.GetFileName(videoFilePath) }
                    };

                    // add try catch to catch discord down

                    try
                    {
                        using var response = await httpClient.PostAsync("https://litterbox.catbox.moe/resources/internals/api.php", multipart, cancellationToken);
                        if (response.IsSuccessStatusCode)
                        {
                            multipart.Dispose();
                            trackingUpload = false;

                            detailedLog(true, programLogTextBox, "OK", true);
                            detailedLog(true, programLogTextBox, "Uploading video link to Discord webhook...", true);

                            using var multipart2 = new MultipartFormDataContent
                            {
                                { new StringContent(await response.Content.ReadAsStringAsync()), "content" }
                            };

                            try
                            {
                                using var response2 = await httpClient.PostAsync(webhookUrlTextBox.Text, multipart2, cancellationToken);

                                if (response2.IsSuccessStatusCode)
                                {
                                    detailedLog(true, programLogTextBox, "OK", true);
                                }
                                else
                                {
                                    detailedLog(true, programLogTextBox, "Upload failed!", true);
                                }
                                return response2.IsSuccessStatusCode;
                            }
                            catch
                            {
                                detailedLog(true, programLogTextBox, "Could not connect to Discord!", true);
                                return false;
                            }
                            finally
                            {
                                multipart2.Dispose();
                                httpClient.Dispose();
                            }
                        }
                        else
                        {
                            detailedLog(true, programLogTextBox, "Upload failed!", true);
                            return false;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw new OperationCanceledException();
                    }
                    catch
                    {
                        detailedLog(true, programLogTextBox, "Could not connect to Litterbox!", true);
                        return false;
                    }
                    finally
                    {
                        httpClient.Dispose();
                        trackingUpload = false;
                    }
                }, cancellationToken);
            }
            else
            {

                detailedLog(true, programLogTextBox, "Uploading video to Discord webhook...", true);
                return Task.Run(async () =>
                {
                    using var multipart = new MultipartFormDataContent
                    {
                        { httpContent, "files[0]", Path.GetFileName(videoFilePath) }
                    };


                    using var response = await httpClient.PostAsync(webhookUrlTextBox.Text, multipart, cancellationToken);
                    if (response.IsSuccessStatusCode)
                    {
                        detailedLog(true, programLogTextBox, "OK", true);
                    }
                    else
                    {
                        detailedLog(true, programLogTextBox, "Upload failed", true);
                    }

                    multipart.Dispose();
                    httpClient.Dispose();
                    trackingUpload = false;

                    return response.IsSuccessStatusCode;
                });
            }
        }
    }
}
