namespace CircleDock
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainFormContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormContextMenuStrip
            // 
            this.MainFormContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.MainFormContextMenuStrip.Name = LanguageWords.General.CircleDockName;
            this.MainFormContextMenuStrip.Size = new System.Drawing.Size(98, 26);
            this.MainFormContextMenuStrip.Text = LanguageWords.General.CircleDockName;
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = LanguageWords.MainContextMenu.QuitWord;
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // MainFormTrayIcon
            // 
            this.MainFormTrayIcon.ContextMenuStrip = this.MainFormContextMenuStrip;
            this.MainFormTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainFormTrayIcon.Icon")));
            this.MainFormTrayIcon.Text = LanguageWords.General.CircleDockName;
            this.MainFormTrayIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Name = "MainForm";
            this.Text = LanguageWords.General.CircleDockName;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MainFormContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MainFormContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon MainFormTrayIcon;
    }
}