using System.Diagnostics;

namespace sendtodiscord
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            // todo figure out where config is saved
            webhookUrlTextbox.Text = Properties.Settings.Default.webhookUrl;
            danserBinaryPathTextbox.Text = Properties.Settings.Default.danserPath;
            deleteRenderedVideoCheckBox.Checked = Properties.Settings.Default.deleteRenderedVideo;
            danserSettingsPathTextbox.Text = Properties.Settings.Default.danserSettings;
            showDanserTerminalCheckBox.Checked = Properties.Settings.Default.showDanserTerminal;
            FormClosing += new FormClosingEventHandler(Form_FormClosing);
            var programName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var versionNumber = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = programName + " v." + versionNumber;
        }

        private void selectReplayFileButton_Click(object sender, EventArgs e)
        {
            replayFileDialog.ShowDialog();
        }

        private void replayFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            replayFilePathTextBox.Text = replayFileDialog.FileName;
        }

        private async void renderAndUploadButton_Click(object sender, EventArgs e)
        {
            renderAndUploadButton.Enabled = false;
            if (!File.Exists(replayFilePathTextBox.Text))
            {
                detailedLog(programLogTextBox, "Invalid replay file path.", true);
            }
            else
            {
                if (!File.Exists(danserBinaryPathTextbox.Text))
                {
                    detailedLog(programLogTextBox, "Invalid danser path.", true);
                }
                else
                {
                    // todo add custom arguments in settings
                    var fileName = "danser_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    var danserArguments = "-replay \"" + replayFilePathTextBox.Text + "\" -quickstart -out " + fileName;

                    if (!string.IsNullOrEmpty(danserSettingsPathTextbox.Text))
                    {
                        danserArguments += " -settings " + Path.GetFileNameWithoutExtension(danserSettingsPathTextbox.Text);
                    } else
                    {
                        detailedLog(programLogTextBox, "Using default danser settings...", true);
                    }

                    if (!string.IsNullOrEmpty(startTimeTextBox.Text))
                    {
                        danserArguments += " -start " + startTimeTextBox.Text;
                    }

                    if (!string.IsNullOrEmpty(endTimeTextBox.Text))
                    {
                        danserArguments += " -end " + endTimeTextBox.Text;
                    }

                    detailedLog(programLogTextBox, "Starting danser...", true);
                    detailedLog(programLogTextBox, danserBinaryPathTextbox.Text + " " + danserArguments, true);
                    Process danser = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = danserBinaryPathTextbox.Text,
                            Arguments = danserArguments,
                            RedirectStandardOutput = true,
                            CreateNoWindow = !showDanserTerminalCheckBox.Checked,
                        }
                    };

                    logTabControl.SelectedTab = danserLogTab;
                    danser.Start();

                    while (!danser.StandardOutput.EndOfStream)
                    {
                        danserLogTextBox.AppendText(danser.StandardOutput.ReadLine());
                        danserLogTextBox.AppendText(Environment.NewLine);
                    }


                    logTabControl.SelectedTab = programLogTab;

                    string danserPath = Path.GetDirectoryName(danserBinaryPathTextbox.Text);
                    string videosPath = danserPath + "\\videos";
                    var matchingFiles = Directory.GetFiles(videosPath, fileName + ".*");

                    if (matchingFiles.Length == 0)
                    {
                        detailedLog(programLogTextBox, "danser render failed!", true);
                    }
                    else
                    {
                        // todo add upload progress
                        var videoPath = matchingFiles[0];
                        var hc = new HttpClient();
                        using var multipart = new MultipartFormDataContent();
                        var bytes = File.ReadAllBytes(videoPath);
                        multipart.Add(new ByteArrayContent(bytes, 0, bytes.Length), "files[0]", Path.GetFileName(videoPath));
                        // todo upload to embeddable video hosting service if over 10 mb
                        detailedLog(programLogTextBox, "Uploading to Discord webhook...", true);
                        using var resp = await hc.PostAsync(webhookUrlTextbox.Text, multipart);
                        detailedLog(programLogTextBox, resp.StatusCode.ToString(), true);
                        if (deleteRenderedVideoCheckBox.Checked)
                        {
                            File.Delete(videoPath);
                            detailedLog(programLogTextBox, "Deleted video file.", true);
                        }
                    }
                }
            }
            renderAndUploadButton.Enabled = true;
        }

        private void selectDanserBinaryButton_Click(object sender, EventArgs e)
        {
            danserBinaryFileDialog.ShowDialog();
        }

        private void danserBinaryFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            danserBinaryPathTextbox.Text = danserBinaryFileDialog.FileName;
        }

        private void selectDanserSettingsButton_Click(object sender, EventArgs e)
        {
            danserSettingsFileDialog.ShowDialog();
        }

        private void danserSettingsFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            danserSettingsPathTextbox.Text = danserSettingsFileDialog.FileName;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["webhookUrl"] = webhookUrlTextbox.Text;
            Properties.Settings.Default["danserPath"] = danserBinaryPathTextbox.Text;
            Properties.Settings.Default["deleteRenderedVideo"] = deleteRenderedVideoCheckBox.Checked;
            Properties.Settings.Default["danserSettings"] = danserSettingsPathTextbox.Text;
            Properties.Settings.Default["showDanserTerminal"] = showDanserTerminalCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void detailedLog(RichTextBox textBox, string message, bool newLine)
        {
            DateTime localTime = DateTime.Now;
            textBox.AppendText(localTime.ToString("HH:mm:ss.ffff") + " > " + message);
            if (newLine)
            {
                textBox.AppendText(Environment.NewLine);
            }
        }
    }
}
