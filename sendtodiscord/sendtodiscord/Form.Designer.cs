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
            webhookUrlTextbox = new TextBox();
            danserBinaryLabel = new Label();
            danserBinaryPathTextbox = new TextBox();
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
            endTimeTextBox = new TextBox();
            startTimeTextBox = new TextBox();
            endTimeLabel = new Label();
            startTimeLabel = new Label();
            logTabControl = new TabControl();
            programLogTab = new TabPage();
            programLogTextBox = new RichTextBox();
            danserLogTab = new TabPage();
            danserLogTextBox = new RichTextBox();
            settingsTab = new TabPage();
            selectDanserSettingsButton = new Button();
            danserSettingsPathTextbox = new TextBox();
            danserSettingsLabel = new Label();
            deleteRenderedVideoCheckBox = new CheckBox();
            danserSettingsFileDialog = new OpenFileDialog();
            showDanserTerminalCheckBox = new CheckBox();
            mainTabControl.SuspendLayout();
            renderTab.SuspendLayout();
            logTabControl.SuspendLayout();
            programLogTab.SuspendLayout();
            danserLogTab.SuspendLayout();
            settingsTab.SuspendLayout();
            SuspendLayout();
            // 
            // webhookUrlTextbox
            // 
            webhookUrlTextbox.Location = new Point(94, 0);
            webhookUrlTextbox.Name = "webhookUrlTextbox";
            webhookUrlTextbox.PlaceholderText = "Webhook URL";
            webhookUrlTextbox.Size = new Size(685, 23);
            webhookUrlTextbox.TabIndex = 4;
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
            // danserBinaryPathTextbox
            // 
            danserBinaryPathTextbox.Location = new Point(94, 29);
            danserBinaryPathTextbox.Name = "danserBinaryPathTextbox";
            danserBinaryPathTextbox.Size = new Size(604, 23);
            danserBinaryPathTextbox.TabIndex = 11;
            // 
            // selectDanserBinaryButton
            // 
            selectDanserBinaryButton.Location = new Point(704, 29);
            selectDanserBinaryButton.Name = "selectDanserBinaryButton";
            selectDanserBinaryButton.Size = new Size(75, 23);
            selectDanserBinaryButton.TabIndex = 12;
            selectDanserBinaryButton.Text = "Select File";
            selectDanserBinaryButton.UseVisualStyleBackColor = true;
            selectDanserBinaryButton.Click += selectDanserBinaryButton_Click;
            // 
            // selectReplayFileButton
            // 
            selectReplayFileButton.Location = new Point(411, 0);
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
            replayFilePathTextBox.Size = new Size(330, 23);
            replayFilePathTextBox.TabIndex = 16;
            // 
            // renderAndUploadButton
            // 
            renderAndUploadButton.Location = new Point(370, 29);
            renderAndUploadButton.Name = "renderAndUploadButton";
            renderAndUploadButton.Size = new Size(116, 23);
            renderAndUploadButton.TabIndex = 17;
            renderAndUploadButton.Text = "Render and Upload";
            renderAndUploadButton.UseVisualStyleBackColor = true;
            renderAndUploadButton.Click += renderAndUploadButton_Click;
            // 
            // danserBinaryFileDialog
            // 
            danserBinaryFileDialog.FileName = "openFileDialog2";
            danserBinaryFileDialog.FileOk += danserBinaryFileDialog_FileOk;
            // 
            // replayFileDialog
            // 
            replayFileDialog.FileName = "openFileDialog2";
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
            renderTab.Controls.Add(endTimeTextBox);
            renderTab.Controls.Add(startTimeTextBox);
            renderTab.Controls.Add(endTimeLabel);
            renderTab.Controls.Add(startTimeLabel);
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
            // endTimeTextBox
            // 
            endTimeTextBox.Location = new Point(246, 29);
            endTimeTextBox.Name = "endTimeTextBox";
            endTimeTextBox.Size = new Size(100, 23);
            endTimeTextBox.TabIndex = 25;
            // 
            // startTimeTextBox
            // 
            startTimeTextBox.Location = new Point(75, 29);
            startTimeTextBox.Name = "startTimeTextBox";
            startTimeTextBox.Size = new Size(100, 23);
            startTimeTextBox.TabIndex = 24;
            // 
            // endTimeLabel
            // 
            endTimeLabel.AutoSize = true;
            endTimeLabel.Location = new Point(181, 33);
            endTimeLabel.Name = "endTimeLabel";
            endTimeLabel.Size = new Size(59, 15);
            endTimeLabel.TabIndex = 23;
            endTimeLabel.Text = "End Time:";
            // 
            // startTimeLabel
            // 
            startTimeLabel.AutoSize = true;
            startTimeLabel.Location = new Point(3, 33);
            startTimeLabel.Name = "startTimeLabel";
            startTimeLabel.Size = new Size(63, 15);
            startTimeLabel.TabIndex = 22;
            startTimeLabel.Text = "Start Time:";
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
            settingsTab.Controls.Add(showDanserTerminalCheckBox);
            settingsTab.Controls.Add(selectDanserSettingsButton);
            settingsTab.Controls.Add(danserSettingsPathTextbox);
            settingsTab.Controls.Add(danserSettingsLabel);
            settingsTab.Controls.Add(deleteRenderedVideoCheckBox);
            settingsTab.Controls.Add(webhookUrlLabel);
            settingsTab.Controls.Add(webhookUrlTextbox);
            settingsTab.Controls.Add(danserBinaryLabel);
            settingsTab.Controls.Add(danserBinaryPathTextbox);
            settingsTab.Controls.Add(selectDanserBinaryButton);
            settingsTab.Location = new Point(4, 24);
            settingsTab.Name = "settingsTab";
            settingsTab.Padding = new Padding(3);
            settingsTab.Size = new Size(794, 423);
            settingsTab.TabIndex = 1;
            settingsTab.Text = "Settings";
            settingsTab.UseVisualStyleBackColor = true;
            // 
            // selectDanserSettingsButton
            // 
            selectDanserSettingsButton.Location = new Point(704, 61);
            selectDanserSettingsButton.Name = "selectDanserSettingsButton";
            selectDanserSettingsButton.Size = new Size(75, 23);
            selectDanserSettingsButton.TabIndex = 23;
            selectDanserSettingsButton.Text = "Select File";
            selectDanserSettingsButton.UseVisualStyleBackColor = true;
            selectDanserSettingsButton.Click += selectDanserSettingsButton_Click;
            // 
            // danserSettingsPathTextbox
            // 
            danserSettingsPathTextbox.Location = new Point(94, 58);
            danserSettingsPathTextbox.Name = "danserSettingsPathTextbox";
            danserSettingsPathTextbox.Size = new Size(604, 23);
            danserSettingsPathTextbox.TabIndex = 22;
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
            deleteRenderedVideoCheckBox.Location = new Point(6, 87);
            deleteRenderedVideoCheckBox.Name = "deleteRenderedVideoCheckBox";
            deleteRenderedVideoCheckBox.Size = new Size(146, 19);
            deleteRenderedVideoCheckBox.TabIndex = 20;
            deleteRenderedVideoCheckBox.Text = "Delete rendered video?";
            deleteRenderedVideoCheckBox.UseVisualStyleBackColor = true;
            // 
            // danserSettingsFileDialog
            // 
            danserSettingsFileDialog.FileName = "openFileDialog2";
            danserSettingsFileDialog.FileOk += danserSettingsFileDialog_FileOk;
            // 
            // showDanserTerminalCheckBox
            // 
            showDanserTerminalCheckBox.AutoSize = true;
            showDanserTerminalCheckBox.Location = new Point(6, 112);
            showDanserTerminalCheckBox.Name = "showDanserTerminalCheckBox";
            showDanserTerminalCheckBox.Size = new Size(145, 19);
            showDanserTerminalCheckBox.TabIndex = 24;
            showDanserTerminalCheckBox.Text = "Show danser terminal?";
            showDanserTerminalCheckBox.UseVisualStyleBackColor = true;
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
        private TextBox webhookUrlTextbox;
        private Label danserBinaryLabel;
        private TextBox danserBinaryPathTextbox;
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
        private TextBox startTimeTextBox;
        private Label endTimeLabel;
        private Label startTimeLabel;
        private Button selectDanserSettingsButton;
        private TextBox danserSettingsPathTextbox;
        private Label danserSettingsLabel;
        private OpenFileDialog danserSettingsFileDialog;
        private CheckBox showDanserTerminalCheckBox;
    }
}
