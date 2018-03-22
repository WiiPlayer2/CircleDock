using BaseDockObjects;
using DockItemSettingsLoader;
using LanguageLoader;
using SettingsLoader;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CircleDock
{
	internal class DockItemProperties : Form
	{
		private IContainer components = null;

		private Button closeButton;

		private TextBox IconImageTextBox;

		private Button IconImageBrowseButton;

		private PictureBox IconImagePictureBox;

		private Label IconImageLabel;

		private TextBox NameTextBox;

		private Label NameLabel;

		private TextBox TargetTextBox;

		private Label TargetLabel;

		private TextBox StartInTextBox;

		private Label StartInLabel;

		private TextBox ArgumentsTextBox;

		private Label ArgumentsLabel;

		private Button TargetFileBrowse;

		private ComboBox RunComboBox;

		private Label RunLabel;

		private OpenFileDialog IconImageFileDialog;

		private FolderBrowserDialog TargetFolderBrowserDialog;

		private OpenFileDialog TargetOpenFileDialog;

		private Button TargetFolderBrowse;

		private DockItemObject ParentObject;

		private LanguageLoader.LanguageLoader Language;

		private SettingsLoader.SettingsLoader DockSettings;

		private DockItemSettingsLoader.DockItemSettingsLoader DockItemSettings;

		private bool Loaded = false;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.closeButton = new Button();
			this.IconImageTextBox = new TextBox();
			this.IconImageBrowseButton = new Button();
			this.IconImagePictureBox = new PictureBox();
			this.IconImageLabel = new Label();
			this.NameTextBox = new TextBox();
			this.NameLabel = new Label();
			this.TargetTextBox = new TextBox();
			this.TargetLabel = new Label();
			this.StartInTextBox = new TextBox();
			this.StartInLabel = new Label();
			this.ArgumentsTextBox = new TextBox();
			this.ArgumentsLabel = new Label();
			this.TargetFileBrowse = new Button();
			this.RunComboBox = new ComboBox();
			this.RunLabel = new Label();
			this.IconImageFileDialog = new OpenFileDialog();
			this.TargetFolderBrowserDialog = new FolderBrowserDialog();
			this.TargetOpenFileDialog = new OpenFileDialog();
			this.TargetFolderBrowse = new Button();
			((ISupportInitialize)this.IconImagePictureBox).BeginInit();
			base.SuspendLayout();
			this.closeButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.closeButton.AutoSize = true;
			this.closeButton.DialogResult = DialogResult.OK;
			this.closeButton.Location = new Point(424, 310);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new Size(75, 23);
			this.closeButton.TabIndex = 24;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new EventHandler(this.closeButton_Click);
			this.IconImageTextBox.Location = new Point(105, 40);
			this.IconImageTextBox.Name = "IconImageTextBox";
			this.IconImageTextBox.Size = new Size(300, 20);
			this.IconImageTextBox.TabIndex = 36;
			this.IconImageTextBox.Leave += new EventHandler(this.IconImageTextBox_Leave);
			this.IconImageTextBox.KeyPress += new KeyPressEventHandler(this.IconImageTextBox_KeyPress);
			this.IconImageBrowseButton.BackColor = SystemColors.Control;
			this.IconImageBrowseButton.FlatStyle = FlatStyle.System;
			this.IconImageBrowseButton.Location = new Point(410, 40);
			this.IconImageBrowseButton.Name = "IconImageBrowseButton";
			this.IconImageBrowseButton.Size = new Size(49, 20);
			this.IconImageBrowseButton.TabIndex = 35;
			this.IconImageBrowseButton.Text = ".....";
			this.IconImageBrowseButton.UseVisualStyleBackColor = false;
			this.IconImageBrowseButton.Click += new EventHandler(this.IconImageBrowseButton_Click);
			this.IconImagePictureBox.BorderStyle = BorderStyle.FixedSingle;
			this.IconImagePictureBox.Location = new Point(12, 8);
			this.IconImagePictureBox.Name = "IconImagePictureBox";
			this.IconImagePictureBox.Size = new Size(72, 72);
			this.IconImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.IconImagePictureBox.TabIndex = 34;
			this.IconImagePictureBox.TabStop = false;
			this.IconImageLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.IconImageLabel.Location = new Point(102, 20);
			this.IconImageLabel.Name = "IconImageLabel";
			this.IconImageLabel.Size = new Size(400, 16);
			this.IconImageLabel.TabIndex = 33;
			this.IconImageLabel.Text = "Icon Image";
			this.NameTextBox.Location = new Point(105, 92);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new Size(300, 20);
			this.NameTextBox.TabIndex = 38;
			this.NameTextBox.Leave += new EventHandler(this.NameTextBox_Leave);
			this.NameTextBox.KeyPress += new KeyPressEventHandler(this.NameTextBox_KeyPress);
			this.NameLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.NameLabel.Location = new Point(102, 72);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new Size(400, 16);
			this.NameLabel.TabIndex = 37;
			this.NameLabel.Text = "Name";
			this.TargetTextBox.Location = new Point(105, 151);
			this.TargetTextBox.Name = "TargetTextBox";
			this.TargetTextBox.Size = new Size(300, 20);
			this.TargetTextBox.TabIndex = 40;
			this.TargetTextBox.Leave += new EventHandler(this.TargetTextBox_Leave);
			this.TargetTextBox.KeyPress += new KeyPressEventHandler(this.TargetTextBox_KeyPress);
			this.TargetLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.TargetLabel.Location = new Point(102, 131);
			this.TargetLabel.Name = "TargetLabel";
			this.TargetLabel.Size = new Size(400, 16);
			this.TargetLabel.TabIndex = 39;
			this.TargetLabel.Text = "Target";
			this.StartInTextBox.Location = new Point(105, 409);
			this.StartInTextBox.Name = "StartInTextBox";
			this.StartInTextBox.Size = new Size(300, 20);
			this.StartInTextBox.TabIndex = 42;
			this.StartInTextBox.Visible = false;
			this.StartInLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.StartInLabel.Location = new Point(102, 389);
			this.StartInLabel.Name = "StartInLabel";
			this.StartInLabel.Size = new Size(400, 16);
			this.StartInLabel.TabIndex = 41;
			this.StartInLabel.Text = "Start In";
			this.StartInLabel.Visible = false;
			this.ArgumentsTextBox.Location = new Point(105, 248);
			this.ArgumentsTextBox.Name = "ArgumentsTextBox";
			this.ArgumentsTextBox.Size = new Size(300, 20);
			this.ArgumentsTextBox.TabIndex = 44;
			this.ArgumentsTextBox.Leave += new EventHandler(this.ArgumentsTextBox_Leave);
			this.ArgumentsTextBox.KeyPress += new KeyPressEventHandler(this.ArgumentsTextBox_KeyPress);
			this.ArgumentsLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ArgumentsLabel.Location = new Point(102, 228);
			this.ArgumentsLabel.Name = "ArgumentsLabel";
			this.ArgumentsLabel.Size = new Size(400, 16);
			this.ArgumentsLabel.TabIndex = 43;
			this.ArgumentsLabel.Text = "Arguments";
			this.TargetFileBrowse.AutoEllipsis = true;
			this.TargetFileBrowse.BackColor = SystemColors.Control;
			this.TargetFileBrowse.FlatStyle = FlatStyle.System;
			this.TargetFileBrowse.Location = new Point(261, 177);
			this.TargetFileBrowse.Name = "TargetFileBrowse";
			this.TargetFileBrowse.Size = new Size(150, 31);
			this.TargetFileBrowse.TabIndex = 45;
			this.TargetFileBrowse.Text = "File.....";
			this.TargetFileBrowse.UseVisualStyleBackColor = false;
			this.TargetFileBrowse.Click += new EventHandler(this.TargetFileBrowse_Click);
			this.RunComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.RunComboBox.Items.AddRange(new object[]
			{
				"Normal",
				"Minimized",
				"Maximized"
			});
			this.RunComboBox.Location = new Point(105, 301);
			this.RunComboBox.Name = "RunComboBox";
			this.RunComboBox.Size = new Size(207, 21);
			this.RunComboBox.TabIndex = 46;
			this.RunComboBox.SelectedIndexChanged += new EventHandler(this.RunComboBox_SelectedIndexChanged);
			this.RunLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.RunLabel.Location = new Point(102, 282);
			this.RunLabel.Name = "RunLabel";
			this.RunLabel.Size = new Size(400, 16);
			this.RunLabel.TabIndex = 47;
			this.RunLabel.Text = "Run";
			this.IconImageFileDialog.Filter = "PNG|*.png";
			this.IconImageFileDialog.FileOk += new CancelEventHandler(this.IconImageFileDialog_FileOk);
			this.TargetOpenFileDialog.FileOk += new CancelEventHandler(this.TargetOpenFileDialog_FileOk);
			this.TargetFolderBrowse.AutoEllipsis = true;
			this.TargetFolderBrowse.BackColor = SystemColors.Control;
			this.TargetFolderBrowse.FlatStyle = FlatStyle.System;
			this.TargetFolderBrowse.Location = new Point(105, 177);
			this.TargetFolderBrowse.Name = "TargetFolderBrowse";
			this.TargetFolderBrowse.Size = new Size(150, 31);
			this.TargetFolderBrowse.TabIndex = 48;
			this.TargetFolderBrowse.Text = "Folder.....";
			this.TargetFolderBrowse.UseVisualStyleBackColor = false;
			this.TargetFolderBrowse.Click += new EventHandler(this.TargetFolderBrowse_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.closeButton;
			base.ClientSize = new Size(511, 345);
			base.Controls.Add(this.closeButton);
			base.Controls.Add(this.TargetFolderBrowse);
			base.Controls.Add(this.RunLabel);
			base.Controls.Add(this.RunComboBox);
			base.Controls.Add(this.TargetFileBrowse);
			base.Controls.Add(this.ArgumentsTextBox);
			base.Controls.Add(this.ArgumentsLabel);
			base.Controls.Add(this.StartInTextBox);
			base.Controls.Add(this.StartInLabel);
			base.Controls.Add(this.TargetTextBox);
			base.Controls.Add(this.TargetLabel);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.NameLabel);
			base.Controls.Add(this.IconImageTextBox);
			base.Controls.Add(this.IconImageBrowseButton);
			base.Controls.Add(this.IconImagePictureBox);
			base.Controls.Add(this.IconImageLabel);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DockItemProperties";
			base.Padding = new Padding(9);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Dock Item Properties";
			base.TopMost = true;
			((ISupportInitialize)this.IconImagePictureBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public DockItemProperties(DockItemObject TheParent, LanguageLoader.LanguageLoader LanguageData, SettingsLoader.SettingsLoader SettingsData, DockItemSettingsLoader.DockItemSettingsLoader DockItemSettingsData, string SectionName)
		{
			this.ParentObject = TheParent;
			this.Language = LanguageData;
			this.DockSettings = SettingsData;
			this.DockItemSettings = DockItemSettingsData;
			this.Loaded = false;
			this.InitializeComponent();
			this.InitializeSettings();
		}

		public void InitializeSettings()
		{
			this.Text = this.Language.DockItemProperties.ItemSettings;
			this.IconImageLabel.Text = this.Language.DockItemProperties.IconImage;
			this.IconImageFileDialog.Title = this.Language.DockItemProperties.IconImage;
			this.IconImagePictureBox.Image = new Bitmap(this.ParentObject.ObjectBitmap);
			string entry = this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "ImagePath");
			if (entry != null)
			{
				this.IconImageTextBox.Text = entry;
			}
			else
			{
				this.IconImageTextBox.Text = "";
			}
			this.NameLabel.Text = this.Language.DockItemProperties.Name;
			string entry2 = this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "Name");
			if (entry2 != null && entry2.Length > 0)
			{
				this.NameTextBox.Text = entry2;
			}
			else
			{
				this.NameTextBox.Text = this.ParentObject.FileOperations.Name;
			}
			this.TargetLabel.Text = this.Language.DockItemProperties.Target;
			this.TargetOpenFileDialog.Title = this.Language.DockItemProperties.Target;
			this.TargetFolderBrowserDialog.Description = this.Language.DockItemProperties.Target;
			if (this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "Action") == "[dockfolder]")
			{
				this.TargetTextBox.Text = this.ParentObject.DockItemSectionName + "-";
				this.TargetTextBox.ReadOnly = true;
				this.TargetFileBrowse.Enabled = false;
				this.TargetFolderBrowse.Enabled = false;
			}
			else
			{
				this.TargetTextBox.Text = this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "Args");
			}
			this.TargetFileBrowse.Text = this.Language.DockItemProperties.File;
			this.TargetFolderBrowse.Text = this.Language.DockItemProperties.Folder;
			this.StartInLabel.Text = this.Language.DockItemProperties.StartIn;
			this.ArgumentsLabel.Text = this.Language.DockItemProperties.Arguments;
			string entry3 = this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "ArgsParams");
			if (entry3 == null)
			{
				this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "ArgsParams", "");
				this.ArgumentsTextBox.Text = "";
			}
			else
			{
				this.ArgumentsTextBox.Text = entry3;
			}
			this.RunLabel.Text = this.Language.DockItemProperties.Run;
			this.RunComboBox.Items.Clear();
			this.RunComboBox.Items.Add(this.Language.DockItemProperties.Normal);
			this.RunComboBox.Items.Add(this.Language.DockItemProperties.Minimized);
			this.RunComboBox.Items.Add(this.Language.DockItemProperties.Maximized);
			string entry4 = this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "RunAs");
			if (entry4 == null || (entry4 != "Normal" && entry4 != "Minimized" && entry4 != "Maximized"))
			{
				this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "RunAs", "Normal");
				this.RunComboBox.SelectedIndex = 0;
			}
			else if (entry4 == "Maximized")
			{
				this.RunComboBox.SelectedIndex = 2;
			}
			else if (entry4 == "Minimized")
			{
				this.RunComboBox.SelectedIndex = 1;
			}
			else
			{
				this.RunComboBox.SelectedIndex = 0;
			}
			this.closeButton.Text = this.Language.DockItemProperties.Close;
			this.Loaded = true;
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Select(true, true);
			base.Close();
		}

		private void IconImageTextBox_Leave(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (!(this.IconImageTextBox.Text == this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "ImagePath")))
				{
					string value;
					if (this.IconImageTextBox.Text.StartsWith(Application.StartupPath + "\\"))
					{
						value = "." + this.IconImageTextBox.Text.Substring(Application.StartupPath.Length, this.IconImageTextBox.Text.Length - Application.StartupPath.Length);
					}
					else
					{
						value = this.IconImageTextBox.Text;
					}
					if (this.ParentObject.DockItemSectionName != null && this.ParentObject.DockItemSectionName != "")
					{
						this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "ImagePath", value);
					}
					this.ParentObject.SetBitmapRedraw();
					this.IconImagePictureBox.Image = new Bitmap(this.ParentObject.ObjectBitmap);
				}
			}
		}

		private void IconImageTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.Loaded)
			{
				if (e.KeyChar == '\r')
				{
					this.Select(true, true);
				}
			}
		}

		private void IconImageBrowseButton_Click(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.IconImageFileDialog.InitialDirectory = Application.StartupPath + "\\System\\Icons";
				this.IconImageFileDialog.ShowDialog();
			}
		}

		private void IconImageFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			if (this.Loaded)
			{
				string text;
				if (this.IconImageFileDialog.FileName.StartsWith(Application.StartupPath + "\\"))
				{
					text = "." + this.IconImageFileDialog.FileName.Substring(Application.StartupPath.Length, this.IconImageFileDialog.FileName.Length - Application.StartupPath.Length);
				}
				else
				{
					text = this.IconImageFileDialog.FileName;
				}
				this.IconImageTextBox.Text = text;
				if (this.ParentObject.DockItemSectionName != null && this.ParentObject.DockItemSectionName != "")
				{
					this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "ImagePath", text);
				}
				this.ParentObject.SetBitmapRedraw();
				this.IconImagePictureBox.Image = new Bitmap(this.ParentObject.ObjectBitmap);
			}
		}

		private void TargetFolderBrowse_Click(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (this.TargetFolderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					string text;
					if (this.TargetFolderBrowserDialog.SelectedPath.StartsWith(Application.StartupPath + "\\"))
					{
						text = "." + this.TargetFolderBrowserDialog.SelectedPath.Substring(Application.StartupPath.Length, this.TargetFolderBrowserDialog.SelectedPath.Length - Application.StartupPath.Length);
						if (text == ".")
						{
							text = ".\\";
						}
					}
					else
					{
						text = this.TargetFolderBrowserDialog.SelectedPath;
					}
					this.TargetTextBox.Text = text;
					if (this.ParentObject.DockItemSectionName != null && this.ParentObject.DockItemSectionName != "")
					{
						this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "Args", text);
					}
					this.ParentObject.InitializeFileOps();
					this.ParentObject.SetBitmapRedraw();
					this.Loaded = false;
					this.InitializeSettings();
				}
			}
		}

		private void TargetFileBrowse_Click(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.TargetOpenFileDialog.ShowDialog();
			}
		}

		private void TargetOpenFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			if (this.Loaded)
			{
				string text;
				if (this.TargetOpenFileDialog.FileName.StartsWith(Application.StartupPath + "\\"))
				{
					text = "." + this.TargetOpenFileDialog.FileName.Substring(Application.StartupPath.Length, this.TargetOpenFileDialog.FileName.Length - Application.StartupPath.Length);
					if (text == ".")
					{
						text = ".\\";
					}
				}
				else
				{
					text = this.TargetOpenFileDialog.FileName;
				}
				this.TargetTextBox.Text = text;
				if (this.ParentObject.DockItemSectionName != null && this.ParentObject.DockItemSectionName != "")
				{
					this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "Args", text);
				}
				this.ParentObject.InitializeFileOps();
				this.ParentObject.SetBitmapRedraw();
				this.Loaded = false;
				this.InitializeSettings();
			}
		}

		private void TargetTextBox_Leave(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (!this.TargetTextBox.ReadOnly)
				{
					if (!(this.TargetTextBox.Text == this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "Args")))
					{
						if (this.ParentObject.DockItemSectionName != null && this.ParentObject.DockItemSectionName != "")
						{
							string text = this.TargetTextBox.Text;
							if (this.TargetTextBox.Text.StartsWith(Application.StartupPath + "\\"))
							{
								text = "." + this.TargetTextBox.Text.Substring(Application.StartupPath.Length, this.TargetTextBox.Text.Length - Application.StartupPath.Length);
								if (text == ".")
								{
									text = ".\\";
								}
							}
							this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "Args", text);
						}
						this.ParentObject.InitializeFileOps();
						this.ParentObject.SetBitmapRedraw();
						this.Loaded = false;
						this.InitializeSettings();
					}
				}
			}
		}

		private void TargetTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.Loaded)
			{
				if (e.KeyChar == '\r')
				{
					this.Select(true, true);
				}
			}
		}

		private void NameTextBox_Leave(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (!(this.NameTextBox.Text == this.DockItemSettings.GetEntry(this.ParentObject.DockItemSectionName, "Name")))
				{
					if (this.ParentObject.DockItemSectionName != null && this.ParentObject.DockItemSectionName != "")
					{
						this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "Name", this.NameTextBox.Text);
					}
					this.ParentObject.InitializeFileOps();
					if (this.NameTextBox.Text.Trim().Length == 0)
					{
						this.NameTextBox.Text = this.ParentObject.FileOperations.Name;
					}
				}
			}
		}

		private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.Loaded)
			{
				if (e.KeyChar == '\r')
				{
					if (this.NameTextBox.Text.Trim().Length == 0)
					{
						this.NameTextBox.Text = this.ParentObject.FileOperations.Name;
					}
					this.Select(true, true);
				}
			}
		}

		private void RunComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (this.RunComboBox.SelectedIndex == 2)
				{
					this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "RunAs", "Maximized");
				}
				else if (this.RunComboBox.SelectedIndex == 1)
				{
					this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "RunAs", "Minimized");
				}
				else
				{
					this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "RunAs", "Normal");
				}
			}
		}

		private void ArgumentsTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.Loaded)
			{
				if (e.KeyChar == '\r')
				{
					this.Select(true, true);
				}
			}
		}

		private void ArgumentsTextBox_Leave(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (this.ParentObject.DockItemSectionName != null && this.ParentObject.DockItemSectionName != "")
				{
					this.DockItemSettings.SetEntry(this.ParentObject.DockItemSectionName, "ArgsParams", this.ArgumentsTextBox.Text);
				}
			}
		}
	}
}
