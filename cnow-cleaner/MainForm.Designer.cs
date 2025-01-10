namespace cnow_cleaner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            技术测试常见问题ToolStripMenuItem = new ToolStripMenuItem();
            工具主页ToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            CbxGameRegion = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            BtnCleanTempFiles = new Button();
            BtnCleanRegedit = new Button();
            BtnCleanProcesses = new Button();
            groupBox3 = new GroupBox();
            BtnOneKeyRun = new Button();
            LabelVersionInfo = new Label();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 技术测试常见问题ToolStripMenuItem, 工具主页ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(394, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 技术测试常见问题ToolStripMenuItem
            // 
            技术测试常见问题ToolStripMenuItem.Name = "技术测试常见问题ToolStripMenuItem";
            技术测试常见问题ToolStripMenuItem.Size = new Size(170, 25);
            技术测试常见问题ToolStripMenuItem.Text = "技术测试常见问题";
            技术测试常见问题ToolStripMenuItem.Click += 技术测试常见问题ToolStripMenuItem_Click;
            // 
            // 工具主页ToolStripMenuItem
            // 
            工具主页ToolStripMenuItem.Name = "工具主页ToolStripMenuItem";
            工具主页ToolStripMenuItem.Size = new Size(98, 25);
            工具主页ToolStripMenuItem.Text = "工具主页";
            工具主页ToolStripMenuItem.Click += 工具主页ToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(CbxGameRegion);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(370, 63);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "配置";
            // 
            // CbxGameRegion
            // 
            CbxGameRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            CbxGameRegion.FormattingEnabled = true;
            CbxGameRegion.Items.AddRange(new object[] { "台服", "美服", "韩服" });
            CbxGameRegion.Location = new Point(112, 22);
            CbxGameRegion.Name = "CbxGameRegion";
            CbxGameRegion.Size = new Size(229, 29);
            CbxGameRegion.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 25);
            label1.Name = "label1";
            label1.Size = new Size(82, 21);
            label1.TabIndex = 0;
            label1.Text = "外服类型";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(BtnCleanTempFiles);
            groupBox2.Controls.Add(BtnCleanRegedit);
            groupBox2.Controls.Add(BtnCleanProcesses);
            groupBox2.Location = new Point(12, 101);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(370, 263);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "主要功能";
            // 
            // BtnCleanTempFiles
            // 
            BtnCleanTempFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnCleanTempFiles.Location = new Point(24, 176);
            BtnCleanTempFiles.Name = "BtnCleanTempFiles";
            BtnCleanTempFiles.Size = new Size(317, 68);
            BtnCleanTempFiles.TabIndex = 2;
            BtnCleanTempFiles.Text = "清理国服临时文件";
            BtnCleanTempFiles.UseVisualStyleBackColor = true;
            BtnCleanTempFiles.Click += BtnCleanTempFiles_Click;
            // 
            // BtnCleanRegedit
            // 
            BtnCleanRegedit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnCleanRegedit.Location = new Point(24, 102);
            BtnCleanRegedit.Name = "BtnCleanRegedit";
            BtnCleanRegedit.Size = new Size(317, 68);
            BtnCleanRegedit.TabIndex = 1;
            BtnCleanRegedit.Text = "清理注册表(外服商城修复)";
            BtnCleanRegedit.UseVisualStyleBackColor = true;
            BtnCleanRegedit.Click += BtnCleanRegedit_Click;
            // 
            // BtnCleanProcesses
            // 
            BtnCleanProcesses.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnCleanProcesses.Location = new Point(24, 28);
            BtnCleanProcesses.Name = "BtnCleanProcesses";
            BtnCleanProcesses.Size = new Size(317, 68);
            BtnCleanProcesses.TabIndex = 0;
            BtnCleanProcesses.Text = "关闭OW与NEAC进程";
            BtnCleanProcesses.UseVisualStyleBackColor = true;
            BtnCleanProcesses.Click += BtnCleanProcesses_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(BtnOneKeyRun);
            groupBox3.Location = new Point(12, 370);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(370, 115);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "快捷操作";
            // 
            // BtnOneKeyRun
            // 
            BtnOneKeyRun.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnOneKeyRun.Location = new Point(24, 28);
            BtnOneKeyRun.Name = "BtnOneKeyRun";
            BtnOneKeyRun.Size = new Size(317, 68);
            BtnOneKeyRun.TabIndex = 1;
            BtnOneKeyRun.Text = "一键回外服";
            BtnOneKeyRun.UseVisualStyleBackColor = true;
            BtnOneKeyRun.Click += BtnOneKeyRun_Click;
            // 
            // LabelVersionInfo
            // 
            LabelVersionInfo.AutoSize = true;
            LabelVersionInfo.Location = new Point(12, 497);
            LabelVersionInfo.Name = "LabelVersionInfo";
            LabelVersionInfo.Size = new Size(101, 21);
            LabelVersionInfo.TabIndex = 4;
            LabelVersionInfo.Text = "Version: ???";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 527);
            Controls.Add(LabelVersionInfo);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "国服守望先锋清理工具";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 技术测试常见问题ToolStripMenuItem;
        private ToolStripMenuItem 工具主页ToolStripMenuItem;
        private GroupBox groupBox1;
        private ComboBox CbxGameRegion;
        private Label label1;
        private GroupBox groupBox2;
        private Button BtnCleanTempFiles;
        private Button BtnCleanRegedit;
        private Button BtnCleanProcesses;
        private GroupBox groupBox3;
        private Button BtnOneKeyRun;
        private Label LabelVersionInfo;
    }
}