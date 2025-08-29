namespace sendtodiscord
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            webhookUrlTextBox = new TextBox();
            danserBinaryLabel = new Label();
            danserBinaryPathTextBox = new TextBox();
            selectDanserBinaryButton = new Button();
            selectReplayFileButton = new Button();
            replayFileLabel = new Label();
            replayFilePathTextBox = new TextBox();
            renderAndUploadButton = new Button();
            danserBinaryFileDialog = new OpenFileDialog();
            replayFileDialog = new OpenFileDialog();
            webhookUrlLabel = new Label();
            mainTabControl = new TabControl();
            renderTab = new TabPage();
            uploadProgressLabel = new Label();
            uploadProgressBar = new ProgressBar();
            renderLatestReplayButton = new Button();
            danserArgumentsTextBox = new TextBox();
            logTabControl = new TabControl();
            programLogTab = new TabPage();
            programLogTextBox = new RichTextBox();
            danserLogTab = new TabPage();
            danserLogTextBox = new RichTextBox();
            settingsTab = new TabPage();
            selectOsuDirectoryButton = new Button();
            osuDirectoryTextBox = new TextBox();
            osuDirectoryLabel = new Label();
            openDanserFolderButton = new Button();
            openDanserGuiButton = new Button();
            showDanserTerminalCheckBox = new CheckBox();
            selectDanserSettingsButton = new Button();
            danserSettingsPathTextBox = new TextBox();
            danserSettingsLabel = new Label();
            deleteRenderedVideoCheckBox = new CheckBox();
            danserSettingsFileDialog = new OpenFileDialog();
            osuDirectoryFileDialog = new OpenFileDialog();
            danserArgumentsLabel = new Label();
            mainTabControl.SuspendLayout();
            renderTab.SuspendLayout();
            logTabControl.SuspendLayout();
            programLogTab.SuspendLayout();
            danserLogTab.SuspendLayout();
            settingsTab.SuspendLayout();
            SuspendLayout();
            // 
            // webhookUrlTextBox
            // 
            webhookUrlTextBox.Location = new Point(94, 0);
            webhookUrlTextBox.Name = "webhookUrlTextBox";
            webhookUrlTextBox.PlaceholderText = "Webhook URL";
            webhookUrlTextBox.Size = new Size(690, 23);
            webhookUrlTextBox.TabIndex = 4;
            // 
            // danserBinaryLabel
            // 
            danserBinaryLabel.AutoSize = true;
            danserBinaryLabel.Location = new Point(3, 32);
            danserBinaryLabel.Name = "danserBinaryLabel";
            danserBinaryLabel.Size = new Size(81, 15);
            danserBinaryLabel.TabIndex = 10;
            danserBinaryLabel.Text = "danser binary:";
            // 
            // danserBinaryPathTextBox
            // 
            danserBinaryPathTextBox.Location = new Point(94, 29);
            danserBinaryPathTextBox.Name = "danserBinaryPathTextBox";
            danserBinaryPathTextBox.Size = new Size(363, 23);
            danserBinaryPathTextBox.TabIndex = 11;
            // 
            // selectDanserBinaryButton
            // 
            selectDanserBinaryButton.Location = new Point(463, 28);
            selectDanserBinaryButton.Name = "selectDanserBinaryButton";
            selectDanserBinaryButton.Size = new Size(75, 23);
            selectDanserBinaryButton.TabIndex = 12;
            selectDanserBinaryButton.Text = "Select File";
            selectDanserBinaryButton.UseVisualStyleBackColor = true;
            selectDanserBinaryButton.Click += selectDanserBinaryButton_Click;
            // 
            // selectReplayFileButton
            // 
            selectReplayFileButton.Location = new Point(597, -1);
            selectReplayFileButton.Name = "selectReplayFileButton";
            selectReplayFileButton.Size = new Size(75, 23);
            selectReplayFileButton.TabIndex = 13;
            selectReplayFileButton.Text = "Select File";
            selectReplayFileButton.UseVisualStyleBackColor = true;
            selectReplayFileButton.Click += selectReplayFileButton_Click;
            // 
            // replayFileLabel
            // 
            replayFileLabel.AutoSize = true;
            replayFileLabel.Location = new Point(3, 3);
            replayFileLabel.Name = "replayFileLabel";
            replayFileLabel.Size = new Size(66, 15);
            replayFileLabel.TabIndex = 15;
            replayFileLabel.Text = "Replay File:";
            // 
            // replayFilePathTextBox
            // 
            replayFilePathTextBox.Location = new Point(75, 0);
            replayFilePathTextBox.Name = "replayFilePathTextBox";
            replayFilePathTextBox.Size = new Size(516, 23);
            replayFilePathTextBox.TabIndex = 16;
            // 
            // renderAndUploadButton
            // 
            renderAndUploadButton.Location = new Point(678, -1);
            renderAndUploadButton.Name = "renderAndUploadButton";
            renderAndUploadButton.Size = new Size(116, 23);
            renderAndUploadButton.TabIndex = 17;
            renderAndUploadButton.Text = "Render and Upload";
            renderAndUploadButton.UseVisualStyleBackColor = true;
            renderAndUploadButton.Click += renderAndUploadButton_Click;
            // 
            // danserBinaryFileDialog
            // 
            danserBinaryFileDialog.Filter = "danser binary (*.exe)|*.exe";
            danserBinaryFileDialog.RestoreDirectory = true;
            danserBinaryFileDialog.Title = "Select a danser binary (danser-cli.exe)";
            danserBinaryFileDialog.FileOk += danserBinaryFileDialog_FileOk;
            // 
            // replayFileDialog
            // 
            replayFileDialog.Filter = "osu! replay file (*.osr)|*.osr";
            replayFileDialog.Title = "Select an osu! replay file";
            replayFileDialog.FileOk += replayFileDialog_FileOk;
            // 
            // webhookUrlLabel
            // 
            webhookUrlLabel.AutoSize = true;
            webhookUrlLabel.Location = new Point(3, 3);
            webhookUrlLabel.Name = "webhookUrlLabel";
            webhookUrlLabel.Size = new Size(85, 15);
            webhookUrlLabel.TabIndex = 5;
            webhookUrlLabel.Text = "Webhook URL:";
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(renderTab);
            mainTabControl.Controls.Add(settingsTab);
            mainTabControl.Location = new Point(0, 2);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(802, 451);
            mainTabControl.TabIndex = 18;
            // 
            // renderTab
            // 
            renderTab.Controls.Add(danserArgumentsLabel);
            renderTab.Controls.Add(uploadProgressLabel);
            renderTab.Controls.Add(uploadProgressBar);
            renderTab.Controls.Add(renderLatestReplayButton);
            renderTab.Controls.Add(danserArgumentsTextBox);
            renderTab.Controls.Add(logTabControl);
            renderTab.Controls.Add(replayFileLabel);
            renderTab.Controls.Add(renderAndUploadButton);
            renderTab.Controls.Add(replayFilePathTextBox);
            renderTab.Controls.Add(selectReplayFileButton);
            renderTab.Location = new Point(4, 24);
            renderTab.Name = "renderTab";
            renderTab.Padding = new Padding(3);
            renderTab.Size = new Size(794, 423);
            renderTab.TabIndex = 0;
            renderTab.Text = "Render";
            renderTab.UseVisualStyleBackColor = true;
            // 
            // uploadProgressLabel
            // 
            uploadProgressLabel.AutoSize = true;
            uploadProgressLabel.Location = new Point(272, 33);
            uploadProgressLabel.Name = "uploadProgressLabel";
            uploadProgressLabel.Size = new Size(96, 15);
            uploadProgressLabel.TabIndex = 28;
            uploadProgressLabel.Text = "Upload Progress:";
            // 
            // uploadProgressBar
            // 
            uploadProgressBar.Location = new Point(374, 28);
            uploadProgressBar.Name = "uploadProgressBar";
            uploadProgressBar.Size = new Size(290, 23);
            uploadProgressBar.TabIndex = 27;
            // 
            // renderLatestReplayButton
            // 
            renderLatestReplayButton.Location = new Point(670, 28);
            renderLatestReplayButton.Name = "renderLatestReplayButton";
            renderLatestReplayButton.Size = new Size(124, 23);
            renderLatestReplayButton.TabIndex = 26;
            renderLatestReplayButton.Text = "Render Latest Replay";
            renderLatestReplayButton.UseVisualStyleBackColor = true;
            renderLatestReplayButton.Click += renderLatestReplayButton_Click;
            // 
            // danserArgumentsTextBox
            // 
            danserArgumentsTextBox.Location = new Point(114, 28);
            danserArgumentsTextBox.Name = "danserArgumentsTextBox";
            danserArgumentsTextBox.Size = new Size(152, 23);
            danserArgumentsTextBox.TabIndex = 24;
            // 
            // logTabControl
            // 
            logTabControl.Controls.Add(programLogTab);
            logTabControl.Controls.Add(danserLogTab);
            logTabControl.Location = new Point(0, 58);
            logTabControl.Name = "logTabControl";
            logTabControl.SelectedIndex = 0;
            logTabControl.Size = new Size(794, 365);
            logTabControl.TabIndex = 21;
            // 
            // programLogTab
            // 
            programLogTab.Controls.Add(programLogTextBox);
            programLogTab.Location = new Point(4, 24);
            programLogTab.Name = "programLogTab";
            programLogTab.Padding = new Padding(3);
            programLogTab.Size = new Size(786, 337);
            programLogTab.TabIndex = 0;
            programLogTab.Text = "Program Log";
            programLogTab.UseVisualStyleBackColor = true;
            // 
            // programLogTextBox
            // 
            programLogTextBox.Location = new Point(0, 0);
            programLogTextBox.Name = "programLogTextBox";
            programLogTextBox.ReadOnly = true;
            programLogTextBox.Size = new Size(786, 337);
            programLogTextBox.TabIndex = 19;
            programLogTextBox.Text = "";
            // 
            // danserLogTab
            // 
            danserLogTab.Controls.Add(danserLogTextBox);
            danserLogTab.Location = new Point(4, 24);
            danserLogTab.Name = "danserLogTab";
            danserLogTab.Padding = new Padding(3);
            danserLogTab.Size = new Size(786, 337);
            danserLogTab.TabIndex = 1;
            danserLogTab.Text = "danser Log";
            danserLogTab.UseVisualStyleBackColor = true;
            // 
            // danserLogTextBox
            // 
            danserLogTextBox.Location = new Point(0, 0);
            danserLogTextBox.Name = "danserLogTextBox";
            danserLogTextBox.ReadOnly = true;
            danserLogTextBox.Size = new Size(786, 337);
            danserLogTextBox.TabIndex = 0;
            danserLogTextBox.Text = "";
            // 
            // settingsTab
            // 
            settingsTab.Controls.Add(selectOsuDirectoryButton);
            settingsTab.Controls.Add(osuDirectoryTextBox);
            settingsTab.Controls.Add(osuDirectoryLabel);
            settingsTab.Controls.Add(openDanserFolderButton);
            settingsTab.Controls.Add(openDanserGuiButton);
            settingsTab.Controls.Add(showDanserTerminalCheckBox);
            settingsTab.Controls.Add(selectDanserSettingsButton);
            settingsTab.Controls.Add(danserSettingsPathTextBox);
            settingsTab.Controls.Add(danserSettingsLabel);
            settingsTab.Controls.Add(deleteRenderedVideoCheckBox);
            settingsTab.Controls.Add(webhookUrlLabel);
            settingsTab.Controls.Add(webhookUrlTextBox);
            settingsTab.Controls.Add(danserBinaryLabel);
            settingsTab.Controls.Add(danserBinaryPathTextBox);
            settingsTab.Controls.Add(selectDanserBinaryButton);
            settingsTab.Location = new Point(4, 24);
            settingsTab.Name = "settingsTab";
            settingsTab.Padding = new Padding(3);
            settingsTab.Size = new Size(794, 423);
            settingsTab.TabIndex = 1;
            settingsTab.Text = "Settings";
            settingsTab.UseVisualStyleBackColor = true;
            // 
            // selectOsuDirectoryButton
            // 
            selectOsuDirectoryButton.Location = new Point(687, 85);
            selectOsuDirectoryButton.Name = "selectOsuDirectoryButton";
            selectOsuDirectoryButton.Size = new Size(97, 23);
            selectOsuDirectoryButton.TabIndex = 29;
            selectOsuDirectoryButton.Text = "Select Directory";
            selectOsuDirectoryButton.UseVisualStyleBackColor = true;
            selectOsuDirectoryButton.Click += selectOsuDirectoryButton_Click;
            // 
            // osuDirectoryTextBox
            // 
            osuDirectoryTextBox.Location = new Point(94, 86);
            osuDirectoryTextBox.Name = "osuDirectoryTextBox";
            osuDirectoryTextBox.Size = new Size(587, 23);
            osuDirectoryTextBox.TabIndex = 28;
            // 
            // osuDirectoryLabel
            // 
            osuDirectoryLabel.AutoSize = true;
            osuDirectoryLabel.Location = new Point(3, 89);
            osuDirectoryLabel.Name = "osuDirectoryLabel";
            osuDirectoryLabel.Size = new Size(82, 15);
            osuDirectoryLabel.TabIndex = 27;
            osuDirectoryLabel.Text = "osu! directory:";
            // 
            // openDanserFolderButton
            // 
            openDanserFolderButton.Location = new Point(667, 28);
            openDanserFolderButton.Name = "openDanserFolderButton";
            openDanserFolderButton.Size = new Size(117, 23);
            openDanserFolderButton.TabIndex = 26;
            openDanserFolderButton.Text = "Open danser folder";
            openDanserFolderButton.UseVisualStyleBackColor = true;
            openDanserFolderButton.Click += openDanserFolderButton_Click;
            // 
            // openDanserGuiButton
            // 
            openDanserGuiButton.Location = new Point(544, 28);
            openDanserGuiButton.Name = "openDanserGuiButton";
            openDanserGuiButton.Size = new Size(117, 23);
            openDanserGuiButton.TabIndex = 25;
            openDanserGuiButton.Text = "Open danser GUI";
            openDanserGuiButton.UseVisualStyleBackColor = true;
            openDanserGuiButton.Click += openDanserGuiButton_Click;
            // 
            // showDanserTerminalCheckBox
            // 
            showDanserTerminalCheckBox.AutoSize = true;
            showDanserTerminalCheckBox.Location = new Point(6, 140);
            showDanserTerminalCheckBox.Name = "showDanserTerminalCheckBox";
            showDanserTerminalCheckBox.Size = new Size(145, 19);
            showDanserTerminalCheckBox.TabIndex = 24;
            showDanserTerminalCheckBox.Text = "Show danser terminal?";
            showDanserTerminalCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectDanserSettingsButton
            // 
            selectDanserSettingsButton.Location = new Point(709, 57);
            selectDanserSettingsButton.Name = "selectDanserSettingsButton";
            selectDanserSettingsButton.Size = new Size(75, 23);
            selectDanserSettingsButton.TabIndex = 23;
            selectDanserSettingsButton.Text = "Select File";
            selectDanserSettingsButton.UseVisualStyleBackColor = true;
            selectDanserSettingsButton.Click += selectDanserSettingsButton_Click;
            // 
            // danserSettingsPathTextBox
            // 
            danserSettingsPathTextBox.Location = new Point(94, 58);
            danserSettingsPathTextBox.Name = "danserSettingsPathTextBox";
            danserSettingsPathTextBox.Size = new Size(609, 23);
            danserSettingsPathTextBox.TabIndex = 22;
            // 
            // danserSettingsLabel
            // 
            danserSettingsLabel.AutoSize = true;
            danserSettingsLabel.Location = new Point(3, 61);
            danserSettingsLabel.Name = "danserSettingsLabel";
            danserSettingsLabel.Size = new Size(89, 15);
            danserSettingsLabel.TabIndex = 21;
            danserSettingsLabel.Text = "danser settings:";
            // 
            // deleteRenderedVideoCheckBox
            // 
            deleteRenderedVideoCheckBox.AutoSize = true;
            deleteRenderedVideoCheckBox.Location = new Point(6, 115);
            deleteRenderedVideoCheckBox.Name = "deleteRenderedVideoCheckBox";
            deleteRenderedVideoCheckBox.Size = new Size(146, 19);
            deleteRenderedVideoCheckBox.TabIndex = 20;
            deleteRenderedVideoCheckBox.Text = "Delete rendered video?";
            deleteRenderedVideoCheckBox.UseVisualStyleBackColor = true;
            // 
            // danserSettingsFileDialog
            // 
            danserSettingsFileDialog.Filter = "danser settings file (*.json)|*.json";
            danserSettingsFileDialog.RestoreDirectory = true;
            danserSettingsFileDialog.Title = "Select a danser settings file";
            danserSettingsFileDialog.FileOk += danserSettingsFileDialog_FileOk;
            // 
            // osuDirectoryFileDialog
            // 
            osuDirectoryFileDialog.FileName = "osuDirectoryFileDialog";
            osuDirectoryFileDialog.Filter = "osu! binary (*.exe)|*.exe";
            osuDirectoryFileDialog.Title = "Select osu!.exe";
            osuDirectoryFileDialog.FileOk += osuDirectoryFileDialog_FileOk;
            // 
            // danserArgumentsLabel
            // 
            danserArgumentsLabel.AutoSize = true;
            danserArgumentsLabel.Location = new Point(3, 31);
            danserArgumentsLabel.Name = "danserArgumentsLabel";
            danserArgumentsLabel.Size = new Size(105, 15);
            danserArgumentsLabel.TabIndex = 29;
            danserArgumentsLabel.Text = "danser arguments:";
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainTabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form";
            Text = "sendtodiscord";
            mainTabControl.ResumeLayout(false);
            renderTab.ResumeLayout(false);
            renderTab.PerformLayout();
            logTabControl.ResumeLayout(false);
            programLogTab.ResumeLayout(false);
            danserLogTab.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            settingsTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox webhookUrlTextBox;
        private Label danserBinaryLabel;
        private TextBox danserBinaryPathTextBox;
        private Button selectDanserBinaryButton;
        private Button selectReplayFileButton;
        private Label replayFileLabel;
        private TextBox replayFilePathTextBox;
        private Button renderAndUploadButton;
        private OpenFileDialog danserBinaryFileDialog;
        private OpenFileDialog replayFileDialog;
        private Label webhookUrlLabel;
        private TabControl mainTabControl;
        private TabPage renderTab;
        private TabPage settingsTab;
        private TabControl logTabControl;
        private TabPage programLogTab;
        private TabPage danserLogTab;
        private RichTextBox programLogTextBox;
        private RichTextBox danserLogTextBox;
        private CheckBox deleteRenderedVideoCheckBox;
        private TextBox endTimeTextBox;
        private TextBox danserArgumentsTextBox;
        private Button selectDanserSettingsButton;
        private TextBox danserSettingsPathTextBox;
        private Label danserSettingsLabel;
        private OpenFileDialog danserSettingsFileDialog;
        private CheckBox showDanserTerminalCheckBox;
        private Button openDanserGuiButton;
        private Button openDanserFolderButton;
        private Button selectOsuDirectoryButton;
        private TextBox osuDirectoryTextBox;
        private Label osuDirectoryLabel;
        private OpenFileDialog osuDirectoryFileDialog;
        private Button renderLatestReplayButton;
        private ProgressBar uploadProgressBar;
        private Label uploadProgressLabel;
        private Label danserArgumentsLabel;
    }
}
