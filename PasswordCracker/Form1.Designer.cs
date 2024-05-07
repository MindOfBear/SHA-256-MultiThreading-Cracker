namespace PasswordCracker
{
    partial class mainWindow
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
            cpuText = new Label();
            cpuName = new Label();
            cpuCores = new Label();
            cpuThreads = new Label();
            appTitle = new Label();
            label1 = new Label();
            passwordHash = new TextBox();
            passwordLenght = new TextBox();
            label2 = new Label();
            label3 = new Label();
            multiThreading = new CheckBox();
            usedMultithreadingLabel = new Label();
            timeLabel = new Label();
            passwordLabel = new Label();
            startBtn = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // cpuText
            // 
            cpuText.AutoSize = true;
            cpuText.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cpuText.Location = new Point(2, 294);
            cpuText.Name = "cpuText";
            cpuText.RightToLeft = RightToLeft.No;
            cpuText.Size = new Size(106, 15);
            cpuText.TabIndex = 0;
            cpuText.Text = "Your CPU specs";
            // 
            // cpuName
            // 
            cpuName.AutoSize = true;
            cpuName.Location = new Point(2, 309);
            cpuName.Name = "cpuName";
            cpuName.Size = new Size(39, 15);
            cpuName.TabIndex = 1;
            cpuName.Text = "Name";
            // 
            // cpuCores
            // 
            cpuCores.AutoSize = true;
            cpuCores.Location = new Point(2, 324);
            cpuCores.Name = "cpuCores";
            cpuCores.Size = new Size(37, 15);
            cpuCores.TabIndex = 2;
            cpuCores.Text = "Cores";
            // 
            // cpuThreads
            // 
            cpuThreads.AutoSize = true;
            cpuThreads.Location = new Point(2, 339);
            cpuThreads.Name = "cpuThreads";
            cpuThreads.Size = new Size(48, 15);
            cpuThreads.TabIndex = 3;
            cpuThreads.Text = "Threads";
            // 
            // appTitle
            // 
            appTitle.AutoSize = true;
            appTitle.Font = new Font("Microsoft JhengHei", 18F, FontStyle.Bold, GraphicsUnit.Point);
            appTitle.Location = new Point(186, 9);
            appTitle.Name = "appTitle";
            appTitle.Size = new Size(215, 31);
            appTitle.TabIndex = 4;
            appTitle.Text = "Password Cracker";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 79);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 5;
            label1.Text = "Enter SHA-256 hash code";
            // 
            // passwordHash
            // 
            passwordHash.Location = new Point(84, 97);
            passwordHash.Name = "passwordHash";
            passwordHash.Size = new Size(413, 23);
            passwordHash.TabIndex = 6;
            // 
            // passwordLenght
            // 
            passwordLenght.Location = new Point(84, 160);
            passwordLenght.Name = "passwordLenght";
            passwordLenght.Size = new Size(413, 23);
            passwordLenght.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 142);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 7;
            label2.Text = "Password Lenght";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 214);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 9;
            label3.Text = "Use MultiThreading";
            // 
            // multiThreading
            // 
            multiThreading.AutoSize = true;
            multiThreading.Location = new Point(287, 232);
            multiThreading.Name = "multiThreading";
            multiThreading.Size = new Size(15, 14);
            multiThreading.TabIndex = 10;
            multiThreading.UseVisualStyleBackColor = true;
            // 
            // usedMultithreadingLabel
            // 
            usedMultithreadingLabel.AutoSize = true;
            usedMultithreadingLabel.Location = new Point(477, 339);
            usedMultithreadingLabel.Name = "usedMultithreadingLabel";
            usedMultithreadingLabel.RightToLeft = RightToLeft.Yes;
            usedMultithreadingLabel.Size = new Size(86, 15);
            usedMultithreadingLabel.TabIndex = 14;
            usedMultithreadingLabel.Text = "Multithreading";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(477, 324);
            timeLabel.Name = "timeLabel";
            timeLabel.RightToLeft = RightToLeft.Yes;
            timeLabel.Size = new Size(33, 15);
            timeLabel.TabIndex = 13;
            timeLabel.Text = "Time";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(477, 309);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.RightToLeft = RightToLeft.Yes;
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 12;
            passwordLabel.Text = "Password";
            // 
            // startBtn
            // 
            startBtn.Location = new Point(231, 309);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(130, 30);
            startBtn.TabIndex = 15;
            startBtn.Text = "Start Cracking";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(477, 294);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(95, 15);
            label7.TabIndex = 11;
            label7.Text = "Cracking Info";
            // 
            // mainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(startBtn);
            Controls.Add(usedMultithreadingLabel);
            Controls.Add(timeLabel);
            Controls.Add(passwordLabel);
            Controls.Add(label7);
            Controls.Add(multiThreading);
            Controls.Add(label3);
            Controls.Add(passwordLenght);
            Controls.Add(label2);
            Controls.Add(passwordHash);
            Controls.Add(label1);
            Controls.Add(appTitle);
            Controls.Add(cpuThreads);
            Controls.Add(cpuCores);
            Controls.Add(cpuName);
            Controls.Add(cpuText);
            MaximizeBox = false;
            MaximumSize = new Size(600, 400);
            MinimumSize = new Size(600, 400);
            Name = "mainWindow";
            ShowIcon = false;
            Text = "Password Cracker - SHA-256";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cpuText;
        private Label cpuName;
        private Label cpuCores;
        private Label cpuThreads;
        private Label appTitle;
        private Label label1;
        private TextBox passwordHash;
        private TextBox passwordLenght;
        private Label label2;
        private Label label3;
        private CheckBox multiThreading;
        private Label usedMultithreadingLabel;
        private Label timeLabel;
        private Label passwordLabel;
        private Button startBtn;
        private Label label7;
    }
}