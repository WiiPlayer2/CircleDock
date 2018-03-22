using CircleDock;
using DockItemSettingsLoader;
using FileOps;
using LanguageLoader;
using SettingsLoader;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SettingsPanel
{
	public class DockSetup : Form
	{
		private PictureBox ClosePictureBox;

		private PictureBox TitlePictureBox;

		private PictureBox pictureBox3;

		private Panel GeneralPanel;

		private Panel DockShapePanel;

		private Panel CentreButtonPanel;

		private Panel LabelsPanel;

		private Panel panel1;

		private Panel panel2;

		private Panel panel3;

		private Panel panel4;

		private PictureBox GeneralPicture;

		private PictureBox DockShapePicture;

		private PictureBox CentreButtonPicture;

		private PictureBox LabelsPicture;

		private PictureBox ItemPicture;

		private PictureBox ItemSelectedPicture;

		private Label GeneralLabel;

		private Label DockShapeLabel;

		private Label CentreButtonLabel;

		private Label LabelsLabel;

		private CheckBox CentreButtonShowStartMenuCB;

		private TrackBar CentreButtonNormalOpacityTB;

		private Label CentreButtonNormalOpacityValue;

		private Label CentreButtonNormalOpacityLabel;

		private PictureBox SavePictureBox;

		private Panel AboutPanel;

		private Panel panel6;

		private Label AboutLabel;

		private PictureBox AboutPicture;

		private PictureBox pictureBox1;

		private LinkLabel AboutHomepageLink;

		private LinkLabel AuthorLink;

		private Label VersionInfo;

		private Label VersionNameLabel;

		private Panel panel7;

		private Panel BackgroundPanel;

		private PictureBox BackgroundPicture;

		private Label BackgroundLabel;

		private Label AboutProjectName;

		private Label VersionInformationLabel;

		private Label AuthorLabel;

		private Label ConfigurationLabel;

		private Label ConfigurationDescriptionLabel;

		private Label AboutProjectDescriptionLabel;

		private Label DefaultCentreButtonLabel;

		private Label CentreButtonOtherSettingsLabel;

		private Panel HelpPanel;

		private Panel panel8;

		private Label HelpLabel;

		private PictureBox HelpPicture;

		private Panel AnimationPanel;

		private Panel panel9;

		private Label AnimationLabel;

		private PictureBox AnimationPicture;

		private Panel LocationPanel;

		private Panel panel10;

		private CheckBox CentreAroundCursorWhenShownCB;

		private Label LocationLabel;

		private PictureBox LocationPicture;

		private Panel TogglingPanel;

		private Panel panel11;

		private CheckBox ToggleVisibilityShiftCB;

		private CheckBox ToggleVisibilityAltCB;

		private CheckBox ToggleVisibilityCtrlCB;

		private Label ToggleVisibilityHotkeyLabel;

		private Label TogglingLabel;

		private PictureBox TogglingPicture;

		private Panel FileIconAssociationsPanel;

		private Panel panel12;

		private Label FileIconAssociationsLabel;

		private PictureBox FileIconAssociationsPicture;

		private Panel LanguagePanel;

		private Panel panel13;

		private Label LanguageLabel;

		private PictureBox LanguagePicture;

		private Panel DockItemsPanel;

		private Panel panel14;

		private Label DockItemsLabel;

		private PictureBox DockItemsPicture;

		private CheckBox ToggleVisibilityWinCB;

		private GroupBox groupBox1;

		private Label ToggleVisibilityHotkeyValid;

		private GroupBox groupBox4;

		private Label ToggleVisibilityMouseButtonLabel;

		private LinkLabel HelpWebForum;

		private LinkLabel HelpWebHelpFAQ;

		private Label HelpSupportLabel;

		private PictureBox pictureBox4;

		private CheckBox EnableDockRotationCB;

		private Label LanguageFileLocationLabel;

		private Label LanguageName;

		private Label LanguageNameTitleLabel;

		private ComboBox DockShapeComboBox;

		private RichTextBox richTextBox1;

		private Label LanguageFileVersion;

		private Label LanguageFileVersionTitleLabel;

		private Label LanguageFileAuthor;

		private Label LanguageFileAuthorTitleLabel;

		private Label LanguageIntendedVersion;

		private Label LanguageFileIntendedForTitle;

		private Label LanguageFileValidity;

		private DataGridView FileNameIconAssocationsTable;

		private Label FileNameIconAssociationsLabel;

		private Label FileIconAssociationsDescription;

		private Label FileExtensionIconAssociationsLabel;

		private Label FolderNameIconAssociationsLabel;

		private TextBox DockFolderDefaultImagePath;

		private PictureBox DockFolderDefaultImage;

		private Label DockFolderIconAssociationsLabel;

		private PictureBox DefaultCentreImagePictureBox;

		private TextBox DefaultCentreButtonImageTextBox;

		private LinkLabel LabelColorChangeLink;

		private LinkLabel LabelShadowColorChange;

		private PictureBox LabelColor;

		private PictureBox LabelShadowColor;

		private Label LabelShadowLabel;

		private LinkLabel LabelFontChangeLink;

		private Label LabelsFontName;

		private Label LabelsFontLabel;

		private Label LabelShadowSizeValue;

		private Label LabelShadowSizeLabel;

		private TrackBar LabelShadowSizeTB;

		private FontDialog LabelFontDialog;

		private ColorDialog LabelColorDialog;

		private ColorDialog LabelShadowColorDialog;

		private Label LabelShadowDarknessValue;

		private Label LabelShadowDarknessLabel;

		private TrackBar LabelShadowDarknessTB;

		private Label LabelNormalOpacityValue;

		private Label LabelNormalOpacityLabel;

		private TrackBar LabelNormalOpacityTB;

		private Label BackgroundNormalSizeValue;

		private Label BackgroundNormalSizeLabel;

		private TrackBar BackgroundNormalSizeTB;

		private Label BackgroundNormalOpacityValue;

		private Label BackgroundNormalOpacityLabel;

		private TrackBar BackgroundNormalOpacityTB;

		private TextBox BackgroundImageTextBox;

		private Button BackgroundImageBrowseButton;

		private PictureBox BackgroundImagePictureBox;

		private Label BackgroundImageLabel;

		private Label NumIconsPerCircleValue;

		private Label NumIconsPerCircleLabel;

		private TrackBar NumIconsPerCircleTB;

		private Label StartMenuResidueWarningLabel;

		private Label DockItemsRightClickMenuLabel;

		private CheckBox DockItemsShowExplorerContextMenusCB;

		private Label DockItemsNormalSizeValue;

		private Label DockItemsNormalSizeLabel;

		private TrackBar DockItemsNormalSizeTB;

		private Label DockItemsNormalOpacityValue;

		private Label DockItemsNormalOpacityLabel;

		private TrackBar DockItemsNormalOpacityTB;

		private Label ClickSensitivityValue;

		private Label SensitiveLabel;

		private Label ClickSensitivityLabel;

		private TrackBar ClickSensitivityTB;

		private Label GeneralFrameRateValue;

		private Label GeneralFrameRateLabel;

		private TrackBar GeneralFrameRateTB;

		private Label NotSensitiveLabel;

		private Label RotationAnimationDurationValue;

		private Label RotationAnimationDurationLabel;

		private TrackBar RotationAnimationDurationTB;

		private CheckBox DockItemsHideDockAfterExecutionCB;

		private Label DockItemsHideDockLabel;

		private DataGridView dataGridView2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewButtonColumn dataGridViewButtonColumn2;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;

		private DataGridViewImageColumn dataGridViewImageColumn2;

		private DataGridView dataGridView1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewButtonColumn dataGridViewButtonColumn1;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;

		private DataGridViewImageColumn dataGridViewImageColumn1;

		private DataGridViewTextBoxColumn FileName;

		private DataGridViewTextBoxColumn AssociatedDockIcon;

		private DataGridViewButtonColumn BrowseIconForFileName;

		private DataGridViewCheckBoxColumn StartsWith;

		private DataGridViewCheckBoxColumn EndsWith;

		private DataGridViewCheckBoxColumn ExactMatch;

		private DataGridViewImageColumn SampleIcon;

		private Label FadeInFadeOutDurationValue;

		private Label FadeInFadeOutDurationLabel;

		private TrackBar FadeInFadeOutDurationTB;

		private CheckBox PortabilityModeCB;

		private Label EdgeWidthHeightValue;

		private Label EdgeWidthHeightLabel;

		private TrackBar EdgeWidthHeightTB;

		private CheckBox ScreenBottomEdge;

		private CheckBox ScreenTopEdge;

		private CheckBox ScreenRightEdge;

		private CheckBox ScreenLeftEdge;

		private Label ShowDockWhenMouseMoveTo;

		private OpenFileDialog BackgroundImageFileDialog;

		private Label RotationSensitivityValue;

		private Label RotationSensitivityLabel;

		private TrackBar RotationSensitivityTB;

		private Label SeparationBetweenCirclesValue;

		private Label SeparationBetweenCirclesLabel;

		private TrackBar SeparationBetweenCirclesTB;

		private Label MinimumRadiusValue;

		private Label MinimumRadiusLabel;

		private TrackBar MinimumRadiusTB;

		private ComboBox ShapeFormatComboBox;

		private Label ShapeFormatLabel;

		private Label CentreButtonNormalSizeValue;

		private Label CentreButtonNormalSizeLabel;

		private TrackBar CentreButtonNormalSizeTB;

		private Button DefaultCentreButtonImageBrowse;

		private OpenFileDialog DefaultCentreButtonFileDialog;

		private Label ShowLabelsLabel;

		private CheckBox ShowLabelsMouseOverCB;

		private CheckBox ShowLabelsCB;

		private Label AboutWebsiteLabel;

		private LinkLabel AboutWebForum;

		private Button DockFolderDefaultImageBrowse;

		private Button LanguageFileLocationBrowse;

		private TextBox LanguageFileLocationTextBox;

		private Label LanguageProgramRestartRequired;

		private OpenFileDialog LanguageFileDialog;

		private OpenFileDialog DockFolderDefaultImageDialog;

		private CheckBox UseMemorySaveCB;

		private ComboBox ToggleVisiblityMouseButton;

		private ComboBox ToggleVisiblityKey1;

		private GroupBox groupBox7;

		private CheckBox UsePoofAnimationWhenDeletingCB;

		private ComboBox zLevelComboBox;

		private Label dwellTimeValue;

		private Label dwellTimeLabel;

		private TrackBar dwellTimeTrackBar;

		private Label zLevelLabel;

		private CheckBox lockDockPositionCheckBox;

		private NumericUpDown currentRotationValueNumericUpDown;

		private CheckBox useSameRotationValuesCB;

		private Label currentRotationValueLabel;

		private GroupBox generalRotationGroupBox;

		private Container components = null;

		private MainForm ParentObject;

		private LanguageLoader.LanguageLoader Language;

		private SettingsLoader.SettingsLoader DockSettings;

		private DockItemSettingsLoader.DockItemSettingsLoader DockItemSettings;

		public string DockItemSectionName;

		private bool Loaded = false;

		public FileOps.FileOps FileOperations;

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DockSetup));
			this.GeneralPanel = new Panel();
			this.panel2 = new Panel();
			this.NotSensitiveLabel = new Label();
			this.SensitiveLabel = new Label();
			this.generalRotationGroupBox = new GroupBox();
			this.currentRotationValueLabel = new Label();
			this.currentRotationValueNumericUpDown = new NumericUpDown();
			this.useSameRotationValuesCB = new CheckBox();
			this.RotationSensitivityValue = new Label();
			this.RotationSensitivityLabel = new Label();
			this.RotationSensitivityTB = new TrackBar();
			this.EnableDockRotationCB = new CheckBox();
			this.zLevelLabel = new Label();
			this.zLevelComboBox = new ComboBox();
			this.UseMemorySaveCB = new CheckBox();
			this.PortabilityModeCB = new CheckBox();
			this.ClickSensitivityValue = new Label();
			this.ClickSensitivityLabel = new Label();
			this.ClickSensitivityTB = new TrackBar();
			this.GeneralLabel = new Label();
			this.GeneralPicture = new PictureBox();
			this.ConfigurationLabel = new Label();
			this.DockShapePanel = new Panel();
			this.panel3 = new Panel();
			this.ShapeFormatComboBox = new ComboBox();
			this.ShapeFormatLabel = new Label();
			this.SeparationBetweenCirclesValue = new Label();
			this.SeparationBetweenCirclesLabel = new Label();
			this.SeparationBetweenCirclesTB = new TrackBar();
			this.MinimumRadiusValue = new Label();
			this.MinimumRadiusLabel = new Label();
			this.MinimumRadiusTB = new TrackBar();
			this.NumIconsPerCircleValue = new Label();
			this.NumIconsPerCircleLabel = new Label();
			this.NumIconsPerCircleTB = new TrackBar();
			this.DockShapeComboBox = new ComboBox();
			this.DockShapeLabel = new Label();
			this.DockShapePicture = new PictureBox();
			this.CentreButtonPanel = new Panel();
			this.panel4 = new Panel();
			this.CentreButtonNormalSizeValue = new Label();
			this.CentreButtonNormalSizeLabel = new Label();
			this.CentreButtonNormalSizeTB = new TrackBar();
			this.DefaultCentreButtonImageBrowse = new Button();
			this.DefaultCentreButtonImageTextBox = new TextBox();
			this.DefaultCentreImagePictureBox = new PictureBox();
			this.CentreButtonShowStartMenuCB = new CheckBox();
			this.CentreButtonOtherSettingsLabel = new Label();
			this.CentreButtonNormalOpacityValue = new Label();
			this.CentreButtonNormalOpacityLabel = new Label();
			this.DefaultCentreButtonLabel = new Label();
			this.CentreButtonNormalOpacityTB = new TrackBar();
			this.StartMenuResidueWarningLabel = new Label();
			this.CentreButtonLabel = new Label();
			this.CentreButtonPicture = new PictureBox();
			this.LabelsPanel = new Panel();
			this.panel1 = new Panel();
			this.ShowLabelsLabel = new Label();
			this.ShowLabelsMouseOverCB = new CheckBox();
			this.ShowLabelsCB = new CheckBox();
			this.LabelNormalOpacityValue = new Label();
			this.LabelNormalOpacityLabel = new Label();
			this.LabelNormalOpacityTB = new TrackBar();
			this.LabelShadowDarknessValue = new Label();
			this.LabelShadowDarknessLabel = new Label();
			this.LabelShadowDarknessTB = new TrackBar();
			this.LabelShadowSizeValue = new Label();
			this.LabelShadowSizeLabel = new Label();
			this.LabelShadowSizeTB = new TrackBar();
			this.LabelColorChangeLink = new LinkLabel();
			this.LabelShadowColorChange = new LinkLabel();
			this.LabelColor = new PictureBox();
			this.LabelShadowColor = new PictureBox();
			this.LabelShadowLabel = new Label();
			this.LabelFontChangeLink = new LinkLabel();
			this.LabelsFontName = new Label();
			this.LabelsFontLabel = new Label();
			this.LabelsLabel = new Label();
			this.LabelsPicture = new PictureBox();
			this.ConfigurationDescriptionLabel = new Label();
			this.AboutPanel = new Panel();
			this.panel6 = new Panel();
			this.AboutWebsiteLabel = new Label();
			this.AboutWebForum = new LinkLabel();
			this.richTextBox1 = new RichTextBox();
			this.VersionNameLabel = new Label();
			this.VersionInfo = new Label();
			this.VersionInformationLabel = new Label();
			this.AuthorLink = new LinkLabel();
			this.AboutHomepageLink = new LinkLabel();
			this.AuthorLabel = new Label();
			this.AboutProjectDescriptionLabel = new Label();
			this.AboutProjectName = new Label();
			this.pictureBox1 = new PictureBox();
			this.AboutLabel = new Label();
			this.AboutPicture = new PictureBox();
			this.BackgroundPanel = new Panel();
			this.panel7 = new Panel();
			this.BackgroundNormalOpacityValue = new Label();
			this.BackgroundNormalSizeValue = new Label();
			this.BackgroundNormalSizeLabel = new Label();
			this.BackgroundNormalSizeTB = new TrackBar();
			this.BackgroundNormalOpacityLabel = new Label();
			this.BackgroundNormalOpacityTB = new TrackBar();
			this.BackgroundImageTextBox = new TextBox();
			this.BackgroundImageBrowseButton = new Button();
			this.BackgroundImagePictureBox = new PictureBox();
			this.BackgroundImageLabel = new Label();
			this.BackgroundLabel = new Label();
			this.BackgroundPicture = new PictureBox();
			this.HelpPanel = new Panel();
			this.panel8 = new Panel();
			this.pictureBox4 = new PictureBox();
			this.HelpWebForum = new LinkLabel();
			this.HelpWebHelpFAQ = new LinkLabel();
			this.HelpSupportLabel = new Label();
			this.HelpLabel = new Label();
			this.HelpPicture = new PictureBox();
			this.AnimationPanel = new Panel();
			this.panel9 = new Panel();
			this.UsePoofAnimationWhenDeletingCB = new CheckBox();
			this.FadeInFadeOutDurationValue = new Label();
			this.FadeInFadeOutDurationLabel = new Label();
			this.FadeInFadeOutDurationTB = new TrackBar();
			this.RotationAnimationDurationValue = new Label();
			this.RotationAnimationDurationLabel = new Label();
			this.RotationAnimationDurationTB = new TrackBar();
			this.GeneralFrameRateValue = new Label();
			this.GeneralFrameRateLabel = new Label();
			this.GeneralFrameRateTB = new TrackBar();
			this.AnimationLabel = new Label();
			this.AnimationPicture = new PictureBox();
			this.LocationPanel = new Panel();
			this.panel10 = new Panel();
			this.CentreAroundCursorWhenShownCB = new CheckBox();
			this.lockDockPositionCheckBox = new CheckBox();
			this.LocationLabel = new Label();
			this.LocationPicture = new PictureBox();
			this.TogglingPanel = new Panel();
			this.panel11 = new Panel();
			this.groupBox7 = new GroupBox();
			this.dwellTimeValue = new Label();
			this.dwellTimeLabel = new Label();
			this.dwellTimeTrackBar = new TrackBar();
			this.EdgeWidthHeightValue = new Label();
			this.EdgeWidthHeightLabel = new Label();
			this.EdgeWidthHeightTB = new TrackBar();
			this.ScreenBottomEdge = new CheckBox();
			this.ScreenTopEdge = new CheckBox();
			this.ScreenRightEdge = new CheckBox();
			this.ScreenLeftEdge = new CheckBox();
			this.ShowDockWhenMouseMoveTo = new Label();
			this.groupBox4 = new GroupBox();
			this.ToggleVisiblityMouseButton = new ComboBox();
			this.ToggleVisibilityMouseButtonLabel = new Label();
			this.groupBox1 = new GroupBox();
			this.ToggleVisibilityHotkeyLabel = new Label();
			this.ToggleVisiblityKey1 = new ComboBox();
			this.ToggleVisibilityHotkeyValid = new Label();
			this.ToggleVisibilityWinCB = new CheckBox();
			this.ToggleVisibilityShiftCB = new CheckBox();
			this.ToggleVisibilityCtrlCB = new CheckBox();
			this.ToggleVisibilityAltCB = new CheckBox();
			this.TogglingLabel = new Label();
			this.TogglingPicture = new PictureBox();
			this.FileIconAssociationsPanel = new Panel();
			this.panel12 = new Panel();
			this.DockFolderDefaultImageBrowse = new Button();
			this.DockFolderDefaultImagePath = new TextBox();
			this.DockFolderDefaultImage = new PictureBox();
			this.DockFolderIconAssociationsLabel = new Label();
			this.dataGridView2 = new DataGridView();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
			this.dataGridViewCheckBoxColumn4 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn5 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn6 = new DataGridViewCheckBoxColumn();
			this.dataGridViewImageColumn2 = new DataGridViewImageColumn();
			this.dataGridView1 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
			this.dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
			this.dataGridViewImageColumn1 = new DataGridViewImageColumn();
			this.FileIconAssociationsDescription = new Label();
			this.FileExtensionIconAssociationsLabel = new Label();
			this.FolderNameIconAssociationsLabel = new Label();
			this.FileNameIconAssociationsLabel = new Label();
			this.FileNameIconAssocationsTable = new DataGridView();
			this.FileName = new DataGridViewTextBoxColumn();
			this.AssociatedDockIcon = new DataGridViewTextBoxColumn();
			this.BrowseIconForFileName = new DataGridViewButtonColumn();
			this.StartsWith = new DataGridViewCheckBoxColumn();
			this.EndsWith = new DataGridViewCheckBoxColumn();
			this.ExactMatch = new DataGridViewCheckBoxColumn();
			this.SampleIcon = new DataGridViewImageColumn();
			this.FileIconAssociationsLabel = new Label();
			this.FileIconAssociationsPicture = new PictureBox();
			this.LanguagePanel = new Panel();
			this.panel13 = new Panel();
			this.LanguageProgramRestartRequired = new Label();
			this.LanguageFileLocationBrowse = new Button();
			this.LanguageFileLocationTextBox = new TextBox();
			this.LanguageFileValidity = new Label();
			this.LanguageIntendedVersion = new Label();
			this.LanguageFileIntendedForTitle = new Label();
			this.LanguageFileVersion = new Label();
			this.LanguageFileVersionTitleLabel = new Label();
			this.LanguageFileAuthor = new Label();
			this.LanguageFileAuthorTitleLabel = new Label();
			this.LanguageName = new Label();
			this.LanguageNameTitleLabel = new Label();
			this.LanguageFileLocationLabel = new Label();
			this.LanguageLabel = new Label();
			this.LanguagePicture = new PictureBox();
			this.DockItemsPanel = new Panel();
			this.panel14 = new Panel();
			this.DockItemsHideDockAfterExecutionCB = new CheckBox();
			this.DockItemsHideDockLabel = new Label();
			this.DockItemsRightClickMenuLabel = new Label();
			this.DockItemsShowExplorerContextMenusCB = new CheckBox();
			this.DockItemsNormalSizeValue = new Label();
			this.DockItemsNormalSizeLabel = new Label();
			this.DockItemsNormalSizeTB = new TrackBar();
			this.DockItemsNormalOpacityValue = new Label();
			this.DockItemsNormalOpacityLabel = new Label();
			this.DockItemsNormalOpacityTB = new TrackBar();
			this.DockItemsLabel = new Label();
			this.DockItemsPicture = new PictureBox();
			this.SavePictureBox = new PictureBox();
			this.ItemSelectedPicture = new PictureBox();
			this.ItemPicture = new PictureBox();
			this.pictureBox3 = new PictureBox();
			this.ClosePictureBox = new PictureBox();
			this.TitlePictureBox = new PictureBox();
			this.LabelFontDialog = new FontDialog();
			this.LabelColorDialog = new ColorDialog();
			this.LabelShadowColorDialog = new ColorDialog();
			this.BackgroundImageFileDialog = new OpenFileDialog();
			this.DefaultCentreButtonFileDialog = new OpenFileDialog();
			this.LanguageFileDialog = new OpenFileDialog();
			this.DockFolderDefaultImageDialog = new OpenFileDialog();
			this.GeneralPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.generalRotationGroupBox.SuspendLayout();
			((ISupportInitialize)this.currentRotationValueNumericUpDown).BeginInit();
			((ISupportInitialize)this.RotationSensitivityTB).BeginInit();
			((ISupportInitialize)this.ClickSensitivityTB).BeginInit();
			((ISupportInitialize)this.GeneralPicture).BeginInit();
			this.DockShapePanel.SuspendLayout();
			this.panel3.SuspendLayout();
			((ISupportInitialize)this.SeparationBetweenCirclesTB).BeginInit();
			((ISupportInitialize)this.MinimumRadiusTB).BeginInit();
			((ISupportInitialize)this.NumIconsPerCircleTB).BeginInit();
			((ISupportInitialize)this.DockShapePicture).BeginInit();
			this.CentreButtonPanel.SuspendLayout();
			this.panel4.SuspendLayout();
			((ISupportInitialize)this.CentreButtonNormalSizeTB).BeginInit();
			((ISupportInitialize)this.DefaultCentreImagePictureBox).BeginInit();
			((ISupportInitialize)this.CentreButtonNormalOpacityTB).BeginInit();
			((ISupportInitialize)this.CentreButtonPicture).BeginInit();
			this.LabelsPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.LabelNormalOpacityTB).BeginInit();
			((ISupportInitialize)this.LabelShadowDarknessTB).BeginInit();
			((ISupportInitialize)this.LabelShadowSizeTB).BeginInit();
			((ISupportInitialize)this.LabelColor).BeginInit();
			((ISupportInitialize)this.LabelShadowColor).BeginInit();
			((ISupportInitialize)this.LabelsPicture).BeginInit();
			this.AboutPanel.SuspendLayout();
			this.panel6.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			((ISupportInitialize)this.AboutPicture).BeginInit();
			this.BackgroundPanel.SuspendLayout();
			this.panel7.SuspendLayout();
			((ISupportInitialize)this.BackgroundNormalSizeTB).BeginInit();
			((ISupportInitialize)this.BackgroundNormalOpacityTB).BeginInit();
			((ISupportInitialize)this.BackgroundImagePictureBox).BeginInit();
			((ISupportInitialize)this.BackgroundPicture).BeginInit();
			this.HelpPanel.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.pictureBox4).BeginInit();
			((ISupportInitialize)this.HelpPicture).BeginInit();
			this.AnimationPanel.SuspendLayout();
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.FadeInFadeOutDurationTB).BeginInit();
			((ISupportInitialize)this.RotationAnimationDurationTB).BeginInit();
			((ISupportInitialize)this.GeneralFrameRateTB).BeginInit();
			((ISupportInitialize)this.AnimationPicture).BeginInit();
			this.LocationPanel.SuspendLayout();
			this.panel10.SuspendLayout();
			((ISupportInitialize)this.LocationPicture).BeginInit();
			this.TogglingPanel.SuspendLayout();
			this.panel11.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((ISupportInitialize)this.dwellTimeTrackBar).BeginInit();
			((ISupportInitialize)this.EdgeWidthHeightTB).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.TogglingPicture).BeginInit();
			this.FileIconAssociationsPanel.SuspendLayout();
			this.panel12.SuspendLayout();
			((ISupportInitialize)this.DockFolderDefaultImage).BeginInit();
			((ISupportInitialize)this.dataGridView2).BeginInit();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			((ISupportInitialize)this.FileNameIconAssocationsTable).BeginInit();
			((ISupportInitialize)this.FileIconAssociationsPicture).BeginInit();
			this.LanguagePanel.SuspendLayout();
			this.panel13.SuspendLayout();
			((ISupportInitialize)this.LanguagePicture).BeginInit();
			this.DockItemsPanel.SuspendLayout();
			this.panel14.SuspendLayout();
			((ISupportInitialize)this.DockItemsNormalSizeTB).BeginInit();
			((ISupportInitialize)this.DockItemsNormalOpacityTB).BeginInit();
			((ISupportInitialize)this.DockItemsPicture).BeginInit();
			((ISupportInitialize)this.SavePictureBox).BeginInit();
			((ISupportInitialize)this.ItemSelectedPicture).BeginInit();
			((ISupportInitialize)this.ItemPicture).BeginInit();
			((ISupportInitialize)this.pictureBox3).BeginInit();
			((ISupportInitialize)this.ClosePictureBox).BeginInit();
			((ISupportInitialize)this.TitlePictureBox).BeginInit();
			base.SuspendLayout();
			this.GeneralPanel.BackColor = SystemColors.Control;
			this.GeneralPanel.Controls.Add(this.panel2);
			this.GeneralPanel.Controls.Add(this.GeneralLabel);
			this.GeneralPanel.Controls.Add(this.GeneralPicture);
			this.GeneralPanel.ForeColor = Color.Black;
			this.GeneralPanel.Location = new Point(29, 64);
			this.GeneralPanel.Name = "GeneralPanel";
			this.GeneralPanel.Size = new Size(596, 339);
			this.GeneralPanel.TabIndex = 0;
			this.GeneralPanel.Tag = "340";
			this.panel2.BackColor = Color.White;
			this.panel2.Controls.Add(this.NotSensitiveLabel);
			this.panel2.Controls.Add(this.SensitiveLabel);
			this.panel2.Controls.Add(this.generalRotationGroupBox);
			this.panel2.Controls.Add(this.zLevelLabel);
			this.panel2.Controls.Add(this.zLevelComboBox);
			this.panel2.Controls.Add(this.UseMemorySaveCB);
			this.panel2.Controls.Add(this.PortabilityModeCB);
			this.panel2.Controls.Add(this.ClickSensitivityValue);
			this.panel2.Controls.Add(this.ClickSensitivityLabel);
			this.panel2.Controls.Add(this.ClickSensitivityTB);
			this.panel2.Location = new Point(4, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(588, 312);
			this.panel2.TabIndex = 2;
			this.NotSensitiveLabel.BackColor = Color.Transparent;
			this.NotSensitiveLabel.Location = new Point(467, 169);
			this.NotSensitiveLabel.Name = "NotSensitiveLabel";
			this.NotSensitiveLabel.Size = new Size(115, 36);
			this.NotSensitiveLabel.TabIndex = 43;
			this.NotSensitiveLabel.Text = "Not Sensitive";
			this.NotSensitiveLabel.TextAlign = ContentAlignment.TopCenter;
			this.SensitiveLabel.BackColor = Color.Transparent;
			this.SensitiveLabel.Location = new Point(299, 168);
			this.SensitiveLabel.Name = "SensitiveLabel";
			this.SensitiveLabel.Size = new Size(119, 37);
			this.SensitiveLabel.TabIndex = 42;
			this.SensitiveLabel.Text = "Sensitive";
			this.SensitiveLabel.TextAlign = ContentAlignment.TopCenter;
			this.generalRotationGroupBox.Controls.Add(this.currentRotationValueLabel);
			this.generalRotationGroupBox.Controls.Add(this.currentRotationValueNumericUpDown);
			this.generalRotationGroupBox.Controls.Add(this.useSameRotationValuesCB);
			this.generalRotationGroupBox.Controls.Add(this.RotationSensitivityValue);
			this.generalRotationGroupBox.Controls.Add(this.RotationSensitivityLabel);
			this.generalRotationGroupBox.Controls.Add(this.RotationSensitivityTB);
			this.generalRotationGroupBox.Controls.Add(this.EnableDockRotationCB);
			this.generalRotationGroupBox.Location = new Point(9, 6);
			this.generalRotationGroupBox.Name = "generalRotationGroupBox";
			this.generalRotationGroupBox.Size = new Size(288, 294);
			this.generalRotationGroupBox.TabIndex = 55;
			this.generalRotationGroupBox.TabStop = false;
			this.currentRotationValueLabel.BackColor = Color.Transparent;
			this.currentRotationValueLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.currentRotationValueLabel.Location = new Point(10, 216);
			this.currentRotationValueLabel.Name = "currentRotationValueLabel";
			this.currentRotationValueLabel.Size = new Size(267, 38);
			this.currentRotationValueLabel.TabIndex = 54;
			this.currentRotationValueLabel.Text = "Set Rotation (Radians)";
			this.currentRotationValueLabel.TextAlign = ContentAlignment.BottomCenter;
			this.currentRotationValueNumericUpDown.DecimalPlaces = 2;
			this.currentRotationValueNumericUpDown.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.currentRotationValueNumericUpDown.Location = new Point(86, 257);
			NumericUpDown arg_135A_0 = this.currentRotationValueNumericUpDown;
			int[] array = new int[4];
			array[0] = 1000;
			arg_135A_0.Maximum = new decimal(array);
			this.currentRotationValueNumericUpDown.Minimum = new decimal(new int[]
			{
				1000,
				0,
				0,
				-2147483648
			});
			this.currentRotationValueNumericUpDown.Name = "currentRotationValueNumericUpDown";
			this.currentRotationValueNumericUpDown.Size = new Size(126, 21);
			this.currentRotationValueNumericUpDown.TabIndex = 53;
			this.currentRotationValueNumericUpDown.ValueChanged += new EventHandler(this.currentRotationValueNumericUpDown_ValueChanged);
			this.useSameRotationValuesCB.FlatStyle = FlatStyle.System;
			this.useSameRotationValuesCB.Location = new Point(16, 48);
			this.useSameRotationValuesCB.Name = "useSameRotationValuesCB";
			this.useSameRotationValuesCB.Size = new Size(246, 33);
			this.useSameRotationValuesCB.TabIndex = 52;
			this.useSameRotationValuesCB.Text = "Use Same Rotation Values for All Dock Levels";
			this.useSameRotationValuesCB.CheckedChanged += new EventHandler(this.useSameRotationValuesCB_CheckedChanged);
			this.RotationSensitivityValue.Location = new Point(82, 183);
			this.RotationSensitivityValue.Name = "RotationSensitivityValue";
			this.RotationSensitivityValue.Size = new Size(123, 16);
			this.RotationSensitivityValue.TabIndex = 48;
			this.RotationSensitivityValue.Text = "250";
			this.RotationSensitivityValue.TextAlign = ContentAlignment.TopCenter;
			this.RotationSensitivityLabel.BackColor = Color.Transparent;
			this.RotationSensitivityLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.RotationSensitivityLabel.Location = new Point(6, 84);
			this.RotationSensitivityLabel.Name = "RotationSensitivityLabel";
			this.RotationSensitivityLabel.Size = new Size(275, 58);
			this.RotationSensitivityLabel.TabIndex = 47;
			this.RotationSensitivityLabel.Text = "Key Presses / Mouse Wheel Scrolls Per Rotation";
			this.RotationSensitivityLabel.TextAlign = ContentAlignment.BottomCenter;
			this.RotationSensitivityTB.Location = new Point(30, 145);
			this.RotationSensitivityTB.Maximum = 50;
			this.RotationSensitivityTB.Minimum = 1;
			this.RotationSensitivityTB.Name = "RotationSensitivityTB";
			this.RotationSensitivityTB.Size = new Size(220, 45);
			this.RotationSensitivityTB.TabIndex = 46;
			this.RotationSensitivityTB.TickFrequency = 10;
			this.RotationSensitivityTB.Value = 1;
			this.RotationSensitivityTB.Scroll += new EventHandler(this.RotationSensitivityTB_Scroll);
			this.EnableDockRotationCB.FlatStyle = FlatStyle.System;
			this.EnableDockRotationCB.Location = new Point(16, 17);
			this.EnableDockRotationCB.Name = "EnableDockRotationCB";
			this.EnableDockRotationCB.Size = new Size(272, 25);
			this.EnableDockRotationCB.TabIndex = 5;
			this.EnableDockRotationCB.Text = "Enable Dock Rotation";
			this.EnableDockRotationCB.CheckedChanged += new EventHandler(this.EnableDockRotationCB_CheckedChanged);
			this.zLevelLabel.BackColor = Color.Transparent;
			this.zLevelLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.zLevelLabel.Location = new Point(308, 202);
			this.zLevelLabel.Name = "zLevelLabel";
			this.zLevelLabel.Size = new Size(274, 38);
			this.zLevelLabel.TabIndex = 51;
			this.zLevelLabel.Text = "Z-Level";
			this.zLevelLabel.TextAlign = ContentAlignment.BottomCenter;
			this.zLevelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.zLevelComboBox.Items.AddRange(new object[]
			{
				"Topmost",
				"Normal",
				"Always On Bottom"
			});
			this.zLevelComboBox.Location = new Point(329, 243);
			this.zLevelComboBox.Name = "zLevelComboBox";
			this.zLevelComboBox.Size = new Size(244, 21);
			this.zLevelComboBox.TabIndex = 50;
			this.zLevelComboBox.SelectedIndexChanged += new EventHandler(this.zLevelComboBox_SelectedIndexChanged);
			this.UseMemorySaveCB.FlatStyle = FlatStyle.System;
			this.UseMemorySaveCB.Location = new Point(337, 46);
			this.UseMemorySaveCB.Name = "UseMemorySaveCB";
			this.UseMemorySaveCB.Size = new Size(246, 33);
			this.UseMemorySaveCB.TabIndex = 49;
			this.UseMemorySaveCB.Text = "Use Memory Saver";
			this.UseMemorySaveCB.CheckedChanged += new EventHandler(this.UseMemorySaveCB_CheckedChanged);
			this.PortabilityModeCB.FlatStyle = FlatStyle.System;
			this.PortabilityModeCB.Location = new Point(337, 15);
			this.PortabilityModeCB.Name = "PortabilityModeCB";
			this.PortabilityModeCB.Size = new Size(248, 25);
			this.PortabilityModeCB.TabIndex = 45;
			this.PortabilityModeCB.Text = "Enable Portability Mode";
			this.PortabilityModeCB.CheckedChanged += new EventHandler(this.PortabilityModeCB_CheckedChanged);
			this.ClickSensitivityValue.BackColor = Color.Transparent;
			this.ClickSensitivityValue.Location = new Point(376, 170);
			this.ClickSensitivityValue.Name = "ClickSensitivityValue";
			this.ClickSensitivityValue.Size = new Size(123, 16);
			this.ClickSensitivityValue.TabIndex = 41;
			this.ClickSensitivityValue.Text = "250";
			this.ClickSensitivityValue.TextAlign = ContentAlignment.TopCenter;
			this.ClickSensitivityLabel.BackColor = Color.Transparent;
			this.ClickSensitivityLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ClickSensitivityLabel.Location = new Point(326, 91);
			this.ClickSensitivityLabel.Name = "ClickSensitivityLabel";
			this.ClickSensitivityLabel.Size = new Size(242, 37);
			this.ClickSensitivityLabel.TabIndex = 40;
			this.ClickSensitivityLabel.Text = "Click Sensitivity";
			this.ClickSensitivityLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.ClickSensitivityTB.Location = new Point(341, 131);
			this.ClickSensitivityTB.Maximum = 100;
			this.ClickSensitivityTB.Name = "ClickSensitivityTB";
			this.ClickSensitivityTB.Size = new Size(220, 45);
			this.ClickSensitivityTB.TabIndex = 39;
			this.ClickSensitivityTB.TickFrequency = 10;
			this.ClickSensitivityTB.Value = 1;
			this.ClickSensitivityTB.Scroll += new EventHandler(this.ClickSensitivityTB_Scroll);
			this.GeneralLabel.BackColor = Color.Transparent;
			this.GeneralLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.GeneralLabel.ForeColor = SystemColors.WindowText;
			this.GeneralLabel.Location = new Point(28, 4);
			this.GeneralLabel.Name = "GeneralLabel";
			this.GeneralLabel.Size = new Size(552, 16);
			this.GeneralLabel.TabIndex = 1;
			this.GeneralLabel.Text = "General";
			this.GeneralLabel.Click += new EventHandler(this.GeneralPicture_Click);
			this.GeneralPicture.BackColor = SystemColors.Control;
			this.GeneralPicture.Location = new Point(4, 0);
			this.GeneralPicture.Name = "GeneralPicture";
			this.GeneralPicture.Size = new Size(588, 24);
			this.GeneralPicture.TabIndex = 0;
			this.GeneralPicture.TabStop = false;
			this.GeneralPicture.Click += new EventHandler(this.GeneralPicture_Click);
			this.ConfigurationLabel.BackColor = Color.White;
			this.ConfigurationLabel.Font = new Font("Tahoma", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ConfigurationLabel.Location = new Point(81, 6);
			this.ConfigurationLabel.Name = "ConfigurationLabel";
			this.ConfigurationLabel.Size = new Size(476, 32);
			this.ConfigurationLabel.TabIndex = 3;
			this.ConfigurationLabel.Text = "Circle Dock Configuration";
			this.DockShapePanel.BackColor = SystemColors.Control;
			this.DockShapePanel.Controls.Add(this.panel3);
			this.DockShapePanel.Controls.Add(this.DockShapeLabel);
			this.DockShapePanel.Controls.Add(this.DockShapePicture);
			this.DockShapePanel.ForeColor = Color.Black;
			this.DockShapePanel.Location = new Point(29, 409);
			this.DockShapePanel.Name = "DockShapePanel";
			this.DockShapePanel.Size = new Size(596, 292);
			this.DockShapePanel.TabIndex = 1;
			this.DockShapePanel.Tag = "267";
			this.panel3.BackColor = Color.White;
			this.panel3.Controls.Add(this.ShapeFormatComboBox);
			this.panel3.Controls.Add(this.ShapeFormatLabel);
			this.panel3.Controls.Add(this.SeparationBetweenCirclesValue);
			this.panel3.Controls.Add(this.SeparationBetweenCirclesLabel);
			this.panel3.Controls.Add(this.SeparationBetweenCirclesTB);
			this.panel3.Controls.Add(this.MinimumRadiusValue);
			this.panel3.Controls.Add(this.MinimumRadiusLabel);
			this.panel3.Controls.Add(this.MinimumRadiusTB);
			this.panel3.Controls.Add(this.NumIconsPerCircleValue);
			this.panel3.Controls.Add(this.NumIconsPerCircleLabel);
			this.panel3.Controls.Add(this.NumIconsPerCircleTB);
			this.panel3.Controls.Add(this.DockShapeComboBox);
			this.panel3.Location = new Point(3, 32);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(588, 239);
			this.panel3.TabIndex = 2;
			this.ShapeFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ShapeFormatComboBox.Items.AddRange(new object[]
			{
				"Constant Number of Items Per Circle"
			});
			this.ShapeFormatComboBox.Location = new Point(300, 165);
			this.ShapeFormatComboBox.Name = "ShapeFormatComboBox";
			this.ShapeFormatComboBox.Size = new Size(250, 21);
			this.ShapeFormatComboBox.TabIndex = 46;
			this.ShapeFormatComboBox.SelectedIndexChanged += new EventHandler(this.ShapeFormatComboBox_SelectedIndexChanged);
			this.ShapeFormatLabel.BackColor = Color.Transparent;
			this.ShapeFormatLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ShapeFormatLabel.Location = new Point(270, 142);
			this.ShapeFormatLabel.Name = "ShapeFormatLabel";
			this.ShapeFormatLabel.Size = new Size(312, 16);
			this.ShapeFormatLabel.TabIndex = 45;
			this.ShapeFormatLabel.Text = "Format";
			this.ShapeFormatLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.SeparationBetweenCirclesValue.Location = new Point(57, 194);
			this.SeparationBetweenCirclesValue.Name = "SeparationBetweenCirclesValue";
			this.SeparationBetweenCirclesValue.Size = new Size(220, 16);
			this.SeparationBetweenCirclesValue.TabIndex = 44;
			this.SeparationBetweenCirclesValue.Text = "250";
			this.SeparationBetweenCirclesValue.TextAlign = ContentAlignment.TopCenter;
			this.SeparationBetweenCirclesLabel.BackColor = Color.Transparent;
			this.SeparationBetweenCirclesLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.SeparationBetweenCirclesLabel.Location = new Point(10, 142);
			this.SeparationBetweenCirclesLabel.Name = "SeparationBetweenCirclesLabel";
			this.SeparationBetweenCirclesLabel.Size = new Size(312, 16);
			this.SeparationBetweenCirclesLabel.TabIndex = 43;
			this.SeparationBetweenCirclesLabel.Text = "Separation Between Circles";
			this.SeparationBetweenCirclesLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.SeparationBetweenCirclesTB.LargeChange = 10;
			this.SeparationBetweenCirclesTB.Location = new Point(57, 159);
			this.SeparationBetweenCirclesTB.Maximum = 500;
			this.SeparationBetweenCirclesTB.Name = "SeparationBetweenCirclesTB";
			this.SeparationBetweenCirclesTB.Size = new Size(220, 45);
			this.SeparationBetweenCirclesTB.TabIndex = 42;
			this.SeparationBetweenCirclesTB.TickFrequency = 20;
			this.SeparationBetweenCirclesTB.Value = 1;
			this.SeparationBetweenCirclesTB.Scroll += new EventHandler(this.SeparationBetweenCirclesTB_Scroll);
			this.MinimumRadiusValue.Location = new Point(317, 119);
			this.MinimumRadiusValue.Name = "MinimumRadiusValue";
			this.MinimumRadiusValue.Size = new Size(220, 16);
			this.MinimumRadiusValue.TabIndex = 41;
			this.MinimumRadiusValue.Text = "250";
			this.MinimumRadiusValue.TextAlign = ContentAlignment.TopCenter;
			this.MinimumRadiusLabel.BackColor = Color.Transparent;
			this.MinimumRadiusLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.MinimumRadiusLabel.Location = new Point(270, 67);
			this.MinimumRadiusLabel.Name = "MinimumRadiusLabel";
			this.MinimumRadiusLabel.Size = new Size(312, 16);
			this.MinimumRadiusLabel.TabIndex = 40;
			this.MinimumRadiusLabel.Text = "Minimum Radius";
			this.MinimumRadiusLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.MinimumRadiusTB.LargeChange = 10;
			this.MinimumRadiusTB.Location = new Point(317, 84);
			this.MinimumRadiusTB.Maximum = 500;
			this.MinimumRadiusTB.Name = "MinimumRadiusTB";
			this.MinimumRadiusTB.Size = new Size(220, 45);
			this.MinimumRadiusTB.TabIndex = 39;
			this.MinimumRadiusTB.TickFrequency = 20;
			this.MinimumRadiusTB.Value = 1;
			this.MinimumRadiusTB.Scroll += new EventHandler(this.MinimumRadiusTB_Scroll);
			this.NumIconsPerCircleValue.Location = new Point(56, 119);
			this.NumIconsPerCircleValue.Name = "NumIconsPerCircleValue";
			this.NumIconsPerCircleValue.Size = new Size(220, 16);
			this.NumIconsPerCircleValue.TabIndex = 38;
			this.NumIconsPerCircleValue.Text = "250";
			this.NumIconsPerCircleValue.TextAlign = ContentAlignment.TopCenter;
			this.NumIconsPerCircleLabel.BackColor = Color.Transparent;
			this.NumIconsPerCircleLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.NumIconsPerCircleLabel.Location = new Point(9, 67);
			this.NumIconsPerCircleLabel.Name = "NumIconsPerCircleLabel";
			this.NumIconsPerCircleLabel.Size = new Size(312, 16);
			this.NumIconsPerCircleLabel.TabIndex = 37;
			this.NumIconsPerCircleLabel.Text = "Number of Icons Per Circle";
			this.NumIconsPerCircleLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.NumIconsPerCircleTB.LargeChange = 10;
			this.NumIconsPerCircleTB.Location = new Point(56, 84);
			this.NumIconsPerCircleTB.Maximum = 50;
			this.NumIconsPerCircleTB.Minimum = 1;
			this.NumIconsPerCircleTB.Name = "NumIconsPerCircleTB";
			this.NumIconsPerCircleTB.Size = new Size(220, 45);
			this.NumIconsPerCircleTB.TabIndex = 36;
			this.NumIconsPerCircleTB.TickFrequency = 5;
			this.NumIconsPerCircleTB.Value = 1;
			this.NumIconsPerCircleTB.Scroll += new EventHandler(this.NumIconsPerCircleTB_Scroll);
			this.DockShapeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DockShapeComboBox.Items.AddRange(new object[]
			{
				"Circle"
			});
			this.DockShapeComboBox.Location = new Point(174, 13);
			this.DockShapeComboBox.Name = "DockShapeComboBox";
			this.DockShapeComboBox.Size = new Size(250, 21);
			this.DockShapeComboBox.TabIndex = 8;
			this.DockShapeComboBox.SelectedIndexChanged += new EventHandler(this.DockShapeComboBox_SelectedIndexChanged);
			this.DockShapeLabel.BackColor = Color.Transparent;
			this.DockShapeLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DockShapeLabel.ForeColor = SystemColors.WindowText;
			this.DockShapeLabel.Location = new Point(29, 4);
			this.DockShapeLabel.Name = "DockShapeLabel";
			this.DockShapeLabel.Size = new Size(552, 16);
			this.DockShapeLabel.TabIndex = 1;
			this.DockShapeLabel.Text = "Dock Shape";
			this.DockShapeLabel.Click += new EventHandler(this.DockShapePicture_Click);
			this.DockShapePicture.BackColor = SystemColors.Control;
			this.DockShapePicture.Location = new Point(4, 0);
			this.DockShapePicture.Name = "DockShapePicture";
			this.DockShapePicture.Size = new Size(588, 24);
			this.DockShapePicture.TabIndex = 0;
			this.DockShapePicture.TabStop = false;
			this.DockShapePicture.Click += new EventHandler(this.DockShapePicture_Click);
			this.CentreButtonPanel.BackColor = SystemColors.Control;
			this.CentreButtonPanel.Controls.Add(this.panel4);
			this.CentreButtonPanel.Controls.Add(this.CentreButtonLabel);
			this.CentreButtonPanel.Controls.Add(this.CentreButtonPicture);
			this.CentreButtonPanel.ForeColor = Color.Black;
			this.CentreButtonPanel.Location = new Point(29, 980);
			this.CentreButtonPanel.Name = "CentreButtonPanel";
			this.CentreButtonPanel.Size = new Size(596, 317);
			this.CentreButtonPanel.TabIndex = 3;
			this.CentreButtonPanel.Tag = "318";
			this.panel4.BackColor = Color.White;
			this.panel4.Controls.Add(this.CentreButtonNormalSizeValue);
			this.panel4.Controls.Add(this.CentreButtonNormalSizeLabel);
			this.panel4.Controls.Add(this.CentreButtonNormalSizeTB);
			this.panel4.Controls.Add(this.DefaultCentreButtonImageBrowse);
			this.panel4.Controls.Add(this.DefaultCentreButtonImageTextBox);
			this.panel4.Controls.Add(this.DefaultCentreImagePictureBox);
			this.panel4.Controls.Add(this.CentreButtonShowStartMenuCB);
			this.panel4.Controls.Add(this.CentreButtonOtherSettingsLabel);
			this.panel4.Controls.Add(this.CentreButtonNormalOpacityValue);
			this.panel4.Controls.Add(this.CentreButtonNormalOpacityLabel);
			this.panel4.Controls.Add(this.DefaultCentreButtonLabel);
			this.panel4.Controls.Add(this.CentreButtonNormalOpacityTB);
			this.panel4.Controls.Add(this.StartMenuResidueWarningLabel);
			this.panel4.Location = new Point(4, 24);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(588, 290);
			this.panel4.TabIndex = 2;
			this.CentreButtonNormalSizeValue.Location = new Point(192, 268);
			this.CentreButtonNormalSizeValue.Name = "CentreButtonNormalSizeValue";
			this.CentreButtonNormalSizeValue.Size = new Size(220, 16);
			this.CentreButtonNormalSizeValue.TabIndex = 41;
			this.CentreButtonNormalSizeValue.Text = "250";
			this.CentreButtonNormalSizeValue.TextAlign = ContentAlignment.TopCenter;
			this.CentreButtonNormalSizeLabel.BackColor = Color.Transparent;
			this.CentreButtonNormalSizeLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.CentreButtonNormalSizeLabel.Location = new Point(145, 216);
			this.CentreButtonNormalSizeLabel.Name = "CentreButtonNormalSizeLabel";
			this.CentreButtonNormalSizeLabel.Size = new Size(312, 16);
			this.CentreButtonNormalSizeLabel.TabIndex = 40;
			this.CentreButtonNormalSizeLabel.Text = "Normal Size";
			this.CentreButtonNormalSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.CentreButtonNormalSizeTB.LargeChange = 10;
			this.CentreButtonNormalSizeTB.Location = new Point(16, 235);
			this.CentreButtonNormalSizeTB.Maximum = 500;
			this.CentreButtonNormalSizeTB.Minimum = 1;
			this.CentreButtonNormalSizeTB.Name = "CentreButtonNormalSizeTB";
			this.CentreButtonNormalSizeTB.Size = new Size(559, 45);
			this.CentreButtonNormalSizeTB.TabIndex = 39;
			this.CentreButtonNormalSizeTB.TickFrequency = 20;
			this.CentreButtonNormalSizeTB.Value = 1;
			this.CentreButtonNormalSizeTB.Scroll += new EventHandler(this.CentreButtonNormalSizeTB_Scroll);
			this.DefaultCentreButtonImageBrowse.BackColor = SystemColors.Control;
			this.DefaultCentreButtonImageBrowse.FlatStyle = FlatStyle.System;
			this.DefaultCentreButtonImageBrowse.Location = new Point(337, 38);
			this.DefaultCentreButtonImageBrowse.Name = "DefaultCentreButtonImageBrowse";
			this.DefaultCentreButtonImageBrowse.Size = new Size(49, 20);
			this.DefaultCentreButtonImageBrowse.TabIndex = 32;
			this.DefaultCentreButtonImageBrowse.Text = ".....";
			this.DefaultCentreButtonImageBrowse.UseVisualStyleBackColor = false;
			this.DefaultCentreButtonImageBrowse.Click += new EventHandler(this.DefaultCentreButtonImageBrowse_Click);
			this.DefaultCentreButtonImageTextBox.Location = new Point(88, 37);
			this.DefaultCentreButtonImageTextBox.Name = "DefaultCentreButtonImageTextBox";
			this.DefaultCentreButtonImageTextBox.ReadOnly = true;
			this.DefaultCentreButtonImageTextBox.Size = new Size(243, 21);
			this.DefaultCentreButtonImageTextBox.TabIndex = 22;
			this.DefaultCentreImagePictureBox.BorderStyle = BorderStyle.FixedSingle;
			this.DefaultCentreImagePictureBox.Location = new Point(7, 6);
			this.DefaultCentreImagePictureBox.Name = "DefaultCentreImagePictureBox";
			this.DefaultCentreImagePictureBox.Size = new Size(72, 72);
			this.DefaultCentreImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.DefaultCentreImagePictureBox.TabIndex = 19;
			this.DefaultCentreImagePictureBox.TabStop = false;
			this.CentreButtonShowStartMenuCB.BackColor = Color.Transparent;
			this.CentreButtonShowStartMenuCB.FlatStyle = FlatStyle.System;
			this.CentreButtonShowStartMenuCB.Location = new Point(317, 114);
			this.CentreButtonShowStartMenuCB.Name = "CentreButtonShowStartMenuCB";
			this.CentreButtonShowStartMenuCB.Size = new Size(256, 16);
			this.CentreButtonShowStartMenuCB.TabIndex = 8;
			this.CentreButtonShowStartMenuCB.Text = "Show Start Menu when Clicked";
			this.CentreButtonShowStartMenuCB.UseVisualStyleBackColor = false;
			this.CentreButtonShowStartMenuCB.CheckedChanged += new EventHandler(this.CentreButtonShowStartMenuCB_CheckedChanged);
			this.CentreButtonOtherSettingsLabel.BackColor = Color.Transparent;
			this.CentreButtonOtherSettingsLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.CentreButtonOtherSettingsLabel.Location = new Point(313, 98);
			this.CentreButtonOtherSettingsLabel.Name = "CentreButtonOtherSettingsLabel";
			this.CentreButtonOtherSettingsLabel.Size = new Size(260, 16);
			this.CentreButtonOtherSettingsLabel.TabIndex = 10;
			this.CentreButtonOtherSettingsLabel.Text = "Other Settings";
			this.CentreButtonNormalOpacityValue.Location = new Point(61, 181);
			this.CentreButtonNormalOpacityValue.Name = "CentreButtonNormalOpacityValue";
			this.CentreButtonNormalOpacityValue.Size = new Size(220, 16);
			this.CentreButtonNormalOpacityValue.TabIndex = 9;
			this.CentreButtonNormalOpacityValue.Text = "250";
			this.CentreButtonNormalOpacityValue.TextAlign = ContentAlignment.TopCenter;
			this.CentreButtonNormalOpacityLabel.BackColor = Color.Transparent;
			this.CentreButtonNormalOpacityLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.CentreButtonNormalOpacityLabel.Location = new Point(20, 115);
			this.CentreButtonNormalOpacityLabel.Name = "CentreButtonNormalOpacityLabel";
			this.CentreButtonNormalOpacityLabel.Size = new Size(283, 28);
			this.CentreButtonNormalOpacityLabel.TabIndex = 8;
			this.CentreButtonNormalOpacityLabel.Text = "Normal Opacity";
			this.CentreButtonNormalOpacityLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.DefaultCentreButtonLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DefaultCentreButtonLabel.Location = new Point(85, 6);
			this.DefaultCentreButtonLabel.Name = "DefaultCentreButtonLabel";
			this.DefaultCentreButtonLabel.Size = new Size(260, 27);
			this.DefaultCentreButtonLabel.TabIndex = 1;
			this.DefaultCentreButtonLabel.Text = "Default Centre Button";
			this.DefaultCentreButtonLabel.TextAlign = ContentAlignment.BottomLeft;
			this.CentreButtonNormalOpacityTB.LargeChange = 10;
			this.CentreButtonNormalOpacityTB.Location = new Point(61, 146);
			this.CentreButtonNormalOpacityTB.Maximum = 255;
			this.CentreButtonNormalOpacityTB.Name = "CentreButtonNormalOpacityTB";
			this.CentreButtonNormalOpacityTB.Size = new Size(220, 45);
			this.CentreButtonNormalOpacityTB.TabIndex = 7;
			this.CentreButtonNormalOpacityTB.TickFrequency = 10;
			this.CentreButtonNormalOpacityTB.Scroll += new EventHandler(this.CentreButtonNormalOpacityTB_Scroll);
			this.StartMenuResidueWarningLabel.BackColor = Color.Transparent;
			this.StartMenuResidueWarningLabel.Font = new Font("Tahoma", 8.25f);
			this.StartMenuResidueWarningLabel.Location = new Point(315, 133);
			this.StartMenuResidueWarningLabel.Name = "StartMenuResidueWarningLabel";
			this.StartMenuResidueWarningLabel.Size = new Size(265, 81);
			this.StartMenuResidueWarningLabel.TabIndex = 26;
			this.StartMenuResidueWarningLabel.Text = "Note: You must turn off \"Show shadow under menus\" in your Windows visual style settings or you will get residual shadows.";
			this.CentreButtonLabel.BackColor = Color.Transparent;
			this.CentreButtonLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.CentreButtonLabel.ForeColor = SystemColors.WindowText;
			this.CentreButtonLabel.Location = new Point(28, 4);
			this.CentreButtonLabel.Name = "CentreButtonLabel";
			this.CentreButtonLabel.Size = new Size(552, 16);
			this.CentreButtonLabel.TabIndex = 1;
			this.CentreButtonLabel.Text = "Centre Button";
			this.CentreButtonLabel.Click += new EventHandler(this.CentreButtonPicture_Click);
			this.CentreButtonPicture.BackColor = SystemColors.Control;
			this.CentreButtonPicture.Location = new Point(4, 0);
			this.CentreButtonPicture.Name = "CentreButtonPicture";
			this.CentreButtonPicture.Size = new Size(588, 24);
			this.CentreButtonPicture.TabIndex = 0;
			this.CentreButtonPicture.TabStop = false;
			this.CentreButtonPicture.Click += new EventHandler(this.CentreButtonPicture_Click);
			this.LabelsPanel.BackColor = SystemColors.Control;
			this.LabelsPanel.Controls.Add(this.panel1);
			this.LabelsPanel.Controls.Add(this.LabelsLabel);
			this.LabelsPanel.Controls.Add(this.LabelsPicture);
			this.LabelsPanel.ForeColor = Color.Black;
			this.LabelsPanel.Location = new Point(29, 1553);
			this.LabelsPanel.Name = "LabelsPanel";
			this.LabelsPanel.Size = new Size(596, 326);
			this.LabelsPanel.TabIndex = 4;
			this.LabelsPanel.Tag = "316";
			this.panel1.BackColor = Color.White;
			this.panel1.Controls.Add(this.ShowLabelsLabel);
			this.panel1.Controls.Add(this.ShowLabelsMouseOverCB);
			this.panel1.Controls.Add(this.ShowLabelsCB);
			this.panel1.Controls.Add(this.LabelNormalOpacityValue);
			this.panel1.Controls.Add(this.LabelNormalOpacityLabel);
			this.panel1.Controls.Add(this.LabelNormalOpacityTB);
			this.panel1.Controls.Add(this.LabelShadowDarknessValue);
			this.panel1.Controls.Add(this.LabelShadowDarknessLabel);
			this.panel1.Controls.Add(this.LabelShadowDarknessTB);
			this.panel1.Controls.Add(this.LabelShadowSizeValue);
			this.panel1.Controls.Add(this.LabelShadowSizeLabel);
			this.panel1.Controls.Add(this.LabelShadowSizeTB);
			this.panel1.Controls.Add(this.LabelColorChangeLink);
			this.panel1.Controls.Add(this.LabelShadowColorChange);
			this.panel1.Controls.Add(this.LabelColor);
			this.panel1.Controls.Add(this.LabelShadowColor);
			this.panel1.Controls.Add(this.LabelShadowLabel);
			this.panel1.Controls.Add(this.LabelFontChangeLink);
			this.panel1.Controls.Add(this.LabelsFontName);
			this.panel1.Controls.Add(this.LabelsFontLabel);
			this.panel1.Location = new Point(4, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(588, 288);
			this.panel1.TabIndex = 2;
			this.ShowLabelsLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ShowLabelsLabel.Location = new Point(14, 207);
			this.ShowLabelsLabel.Name = "ShowLabelsLabel";
			this.ShowLabelsLabel.Size = new Size(228, 16);
			this.ShowLabelsLabel.TabIndex = 41;
			this.ShowLabelsLabel.Text = "Show Labels";
			this.ShowLabelsMouseOverCB.Enabled = false;
			this.ShowLabelsMouseOverCB.FlatStyle = FlatStyle.System;
			this.ShowLabelsMouseOverCB.Location = new Point(59, 248);
			this.ShowLabelsMouseOverCB.Name = "ShowLabelsMouseOverCB";
			this.ShowLabelsMouseOverCB.Size = new Size(384, 20);
			this.ShowLabelsMouseOverCB.TabIndex = 40;
			this.ShowLabelsMouseOverCB.Text = "Show Labels on Mouseover Only";
			this.ShowLabelsMouseOverCB.Visible = false;
			this.ShowLabelsMouseOverCB.CheckedChanged += new EventHandler(this.ShowLabelsMouseOverCB_CheckedChanged);
			this.ShowLabelsCB.FlatStyle = FlatStyle.System;
			this.ShowLabelsCB.Location = new Point(25, 226);
			this.ShowLabelsCB.Name = "ShowLabelsCB";
			this.ShowLabelsCB.Size = new Size(272, 16);
			this.ShowLabelsCB.TabIndex = 39;
			this.ShowLabelsCB.Text = "Show Labels";
			this.ShowLabelsCB.CheckedChanged += new EventHandler(this.ShowLabelsCB_CheckedChanged);
			this.LabelNormalOpacityValue.Location = new Point(13, 160);
			this.LabelNormalOpacityValue.Name = "LabelNormalOpacityValue";
			this.LabelNormalOpacityValue.Size = new Size(220, 16);
			this.LabelNormalOpacityValue.TabIndex = 38;
			this.LabelNormalOpacityValue.Text = "250";
			this.LabelNormalOpacityValue.TextAlign = ContentAlignment.TopCenter;
			this.LabelNormalOpacityLabel.BackColor = Color.Transparent;
			this.LabelNormalOpacityLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LabelNormalOpacityLabel.Location = new Point(-36, 109);
			this.LabelNormalOpacityLabel.Name = "LabelNormalOpacityLabel";
			this.LabelNormalOpacityLabel.Size = new Size(312, 16);
			this.LabelNormalOpacityLabel.TabIndex = 37;
			this.LabelNormalOpacityLabel.Text = "Normal Opacity";
			this.LabelNormalOpacityLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.LabelNormalOpacityTB.LargeChange = 10;
			this.LabelNormalOpacityTB.Location = new Point(13, 124);
			this.LabelNormalOpacityTB.Maximum = 255;
			this.LabelNormalOpacityTB.Name = "LabelNormalOpacityTB";
			this.LabelNormalOpacityTB.Size = new Size(220, 45);
			this.LabelNormalOpacityTB.TabIndex = 36;
			this.LabelNormalOpacityTB.TickFrequency = 10;
			this.LabelNormalOpacityTB.Scroll += new EventHandler(this.LabelNormalOpacityTB_Scroll);
			this.LabelShadowDarknessValue.Location = new Point(290, 186);
			this.LabelShadowDarknessValue.Name = "LabelShadowDarknessValue";
			this.LabelShadowDarknessValue.Size = new Size(220, 16);
			this.LabelShadowDarknessValue.TabIndex = 35;
			this.LabelShadowDarknessValue.Text = "250";
			this.LabelShadowDarknessValue.TextAlign = ContentAlignment.TopCenter;
			this.LabelShadowDarknessLabel.BackColor = Color.Transparent;
			this.LabelShadowDarknessLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LabelShadowDarknessLabel.Location = new Point(241, 135);
			this.LabelShadowDarknessLabel.Name = "LabelShadowDarknessLabel";
			this.LabelShadowDarknessLabel.Size = new Size(312, 16);
			this.LabelShadowDarknessLabel.TabIndex = 34;
			this.LabelShadowDarknessLabel.Text = "Shadow Darkness Factor";
			this.LabelShadowDarknessLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.LabelShadowDarknessTB.LargeChange = 2;
			this.LabelShadowDarknessTB.Location = new Point(290, 150);
			this.LabelShadowDarknessTB.Maximum = 25;
			this.LabelShadowDarknessTB.Name = "LabelShadowDarknessTB";
			this.LabelShadowDarknessTB.Size = new Size(220, 45);
			this.LabelShadowDarknessTB.TabIndex = 33;
			this.LabelShadowDarknessTB.Scroll += new EventHandler(this.LabelShadowDarknessTB_Scroll);
			this.LabelShadowSizeValue.Location = new Point(290, 119);
			this.LabelShadowSizeValue.Name = "LabelShadowSizeValue";
			this.LabelShadowSizeValue.Size = new Size(220, 16);
			this.LabelShadowSizeValue.TabIndex = 32;
			this.LabelShadowSizeValue.Text = "250";
			this.LabelShadowSizeValue.TextAlign = ContentAlignment.TopCenter;
			this.LabelShadowSizeLabel.BackColor = Color.Transparent;
			this.LabelShadowSizeLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LabelShadowSizeLabel.Location = new Point(239, 67);
			this.LabelShadowSizeLabel.Name = "LabelShadowSizeLabel";
			this.LabelShadowSizeLabel.Size = new Size(312, 16);
			this.LabelShadowSizeLabel.TabIndex = 31;
			this.LabelShadowSizeLabel.Text = "Shadow Size";
			this.LabelShadowSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.LabelShadowSizeTB.LargeChange = 2;
			this.LabelShadowSizeTB.Location = new Point(290, 81);
			this.LabelShadowSizeTB.Maximum = 15;
			this.LabelShadowSizeTB.Name = "LabelShadowSizeTB";
			this.LabelShadowSizeTB.Size = new Size(220, 45);
			this.LabelShadowSizeTB.TabIndex = 30;
			this.LabelShadowSizeTB.TickFrequency = 2;
			this.LabelShadowSizeTB.Scroll += new EventHandler(this.LabelShadowSizeTB_Scroll);
			this.LabelColorChangeLink.LinkColor = Color.FromArgb(0, 0, 192);
			this.LabelColorChangeLink.Location = new Point(19, 83);
			this.LabelColorChangeLink.Name = "LabelColorChangeLink";
			this.LabelColorChangeLink.Size = new Size(228, 16);
			this.LabelColorChangeLink.TabIndex = 23;
			this.LabelColorChangeLink.TabStop = true;
			this.LabelColorChangeLink.Text = "Change color...";
			this.LabelColorChangeLink.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.LabelColorChangeLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LabelColorChangeLink_LinkClicked);
			this.LabelShadowColorChange.LinkColor = Color.FromArgb(0, 0, 192);
			this.LabelShadowColorChange.Location = new Point(295, 47);
			this.LabelShadowColorChange.Name = "LabelShadowColorChange";
			this.LabelShadowColorChange.Size = new Size(228, 16);
			this.LabelShadowColorChange.TabIndex = 22;
			this.LabelShadowColorChange.TabStop = true;
			this.LabelShadowColorChange.Text = "Change color...";
			this.LabelShadowColorChange.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.LabelShadowColorChange.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LabelShadowColorChange_LinkClicked);
			this.LabelColor.BackColor = Color.Black;
			this.LabelColor.BorderStyle = BorderStyle.FixedSingle;
			this.LabelColor.Location = new Point(22, 64);
			this.LabelColor.Name = "LabelColor";
			this.LabelColor.Size = new Size(28, 16);
			this.LabelColor.TabIndex = 29;
			this.LabelColor.TabStop = false;
			this.LabelShadowColor.BorderStyle = BorderStyle.FixedSingle;
			this.LabelShadowColor.Location = new Point(295, 28);
			this.LabelShadowColor.Name = "LabelShadowColor";
			this.LabelShadowColor.Size = new Size(28, 16);
			this.LabelShadowColor.TabIndex = 28;
			this.LabelShadowColor.TabStop = false;
			this.LabelShadowLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LabelShadowLabel.Location = new Point(280, 12);
			this.LabelShadowLabel.Name = "LabelShadowLabel";
			this.LabelShadowLabel.Size = new Size(212, 16);
			this.LabelShadowLabel.TabIndex = 24;
			this.LabelShadowLabel.Text = "Shadow";
			this.LabelFontChangeLink.LinkColor = Color.FromArgb(0, 0, 192);
			this.LabelFontChangeLink.Location = new Point(19, 44);
			this.LabelFontChangeLink.Name = "LabelFontChangeLink";
			this.LabelFontChangeLink.Size = new Size(224, 16);
			this.LabelFontChangeLink.TabIndex = 19;
			this.LabelFontChangeLink.TabStop = true;
			this.LabelFontChangeLink.Text = "Change font...";
			this.LabelFontChangeLink.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.LabelFontChangeLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LabelFontChangeLink_LinkClicked);
			this.LabelsFontName.Location = new Point(18, 28);
			this.LabelsFontName.Name = "LabelsFontName";
			this.LabelsFontName.Size = new Size(224, 16);
			this.LabelsFontName.TabIndex = 21;
			this.LabelsFontName.Text = "Tahoma, 15";
			this.LabelsFontLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LabelsFontLabel.Location = new Point(8, 12);
			this.LabelsFontLabel.Name = "LabelsFontLabel";
			this.LabelsFontLabel.Size = new Size(228, 16);
			this.LabelsFontLabel.TabIndex = 20;
			this.LabelsFontLabel.Text = "Font";
			this.LabelsLabel.BackColor = Color.Transparent;
			this.LabelsLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LabelsLabel.ForeColor = SystemColors.WindowText;
			this.LabelsLabel.Location = new Point(28, 4);
			this.LabelsLabel.Name = "LabelsLabel";
			this.LabelsLabel.Size = new Size(552, 16);
			this.LabelsLabel.TabIndex = 1;
			this.LabelsLabel.Text = "Labels";
			this.LabelsLabel.Click += new EventHandler(this.LabelsPicture_Click);
			this.LabelsPicture.BackColor = SystemColors.Control;
			this.LabelsPicture.Location = new Point(4, 0);
			this.LabelsPicture.Name = "LabelsPicture";
			this.LabelsPicture.Size = new Size(588, 24);
			this.LabelsPicture.TabIndex = 0;
			this.LabelsPicture.TabStop = false;
			this.LabelsPicture.Click += new EventHandler(this.LabelsPicture_Click);
			this.ConfigurationDescriptionLabel.BackColor = Color.White;
			this.ConfigurationDescriptionLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.ConfigurationDescriptionLabel.Location = new Point(85, 38);
			this.ConfigurationDescriptionLabel.Name = "ConfigurationDescriptionLabel";
			this.ConfigurationDescriptionLabel.Size = new Size(472, 16);
			this.ConfigurationDescriptionLabel.TabIndex = 8;
			this.ConfigurationDescriptionLabel.Text = "Customize the way that Circle Dock shows up on your screen";
			this.AboutPanel.BackColor = SystemColors.Control;
			this.AboutPanel.Controls.Add(this.panel6);
			this.AboutPanel.Controls.Add(this.AboutLabel);
			this.AboutPanel.Controls.Add(this.AboutPicture);
			this.AboutPanel.ForeColor = Color.Black;
			this.AboutPanel.Location = new Point(30, 4335);
			this.AboutPanel.Name = "AboutPanel";
			this.AboutPanel.Size = new Size(596, 415);
			this.AboutPanel.TabIndex = 5;
			this.AboutPanel.Tag = "416";
			this.panel6.BackColor = Color.White;
			this.panel6.Controls.Add(this.AboutWebsiteLabel);
			this.panel6.Controls.Add(this.AboutWebForum);
			this.panel6.Controls.Add(this.richTextBox1);
			this.panel6.Controls.Add(this.VersionNameLabel);
			this.panel6.Controls.Add(this.VersionInfo);
			this.panel6.Controls.Add(this.VersionInformationLabel);
			this.panel6.Controls.Add(this.AuthorLink);
			this.panel6.Controls.Add(this.AboutHomepageLink);
			this.panel6.Controls.Add(this.AuthorLabel);
			this.panel6.Controls.Add(this.AboutProjectDescriptionLabel);
			this.panel6.Controls.Add(this.AboutProjectName);
			this.panel6.Controls.Add(this.pictureBox1);
			this.panel6.Location = new Point(4, 24);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(588, 388);
			this.panel6.TabIndex = 2;
			this.AboutWebsiteLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.AboutWebsiteLabel.Location = new Point(241, 53);
			this.AboutWebsiteLabel.Name = "AboutWebsiteLabel";
			this.AboutWebsiteLabel.Size = new Size(132, 16);
			this.AboutWebsiteLabel.TabIndex = 15;
			this.AboutWebsiteLabel.Text = "Website";
			this.AboutWebForum.LinkColor = Color.FromArgb(0, 0, 192);
			this.AboutWebForum.Location = new Point(250, 86);
			this.AboutWebForum.Name = "AboutWebForum";
			this.AboutWebForum.Size = new Size(200, 16);
			this.AboutWebForum.TabIndex = 14;
			this.AboutWebForum.TabStop = true;
			this.AboutWebForum.Text = "Official Web Forum";
			this.AboutWebForum.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.AboutWebForum.LinkClicked += new LinkLabelLinkClickedEventHandler(this.AboutWebForum_LinkClicked);
			this.richTextBox1.Location = new Point(10, 117);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new Size(571, 258);
			this.richTextBox1.TabIndex = 13;
			this.richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
			this.VersionNameLabel.Location = new Point(376, 20);
			this.VersionNameLabel.Name = "VersionNameLabel";
			this.VersionNameLabel.Size = new Size(104, 56);
			this.VersionNameLabel.TabIndex = 12;
			this.VersionNameLabel.Text = "CircleDock.exe:\n";
			this.VersionInfo.Location = new Point(480, 20);
			this.VersionInfo.Name = "VersionInfo";
			this.VersionInfo.Size = new Size(96, 56);
			this.VersionInfo.TabIndex = 11;
			this.VersionInfo.Text = "Not present";
			this.VersionInformationLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.VersionInformationLabel.Location = new Point(372, 4);
			this.VersionInformationLabel.Name = "VersionInformationLabel";
			this.VersionInformationLabel.Size = new Size(168, 16);
			this.VersionInformationLabel.TabIndex = 10;
			this.VersionInformationLabel.Text = "Version Information";
			this.AuthorLink.LinkColor = Color.FromArgb(0, 0, 192);
			this.AuthorLink.Location = new Point(109, 68);
			this.AuthorLink.Name = "AuthorLink";
			this.AuthorLink.Size = new Size(112, 16);
			this.AuthorLink.TabIndex = 0;
			this.AuthorLink.TabStop = true;
			this.AuthorLink.Text = "Eric Wong";
			this.AuthorLink.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.AuthorLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.AuthorLink_LinkClicked);
			this.AboutHomepageLink.LinkColor = Color.FromArgb(0, 0, 192);
			this.AboutHomepageLink.Location = new Point(250, 68);
			this.AboutHomepageLink.Name = "AboutHomepageLink";
			this.AboutHomepageLink.Size = new Size(200, 16);
			this.AboutHomepageLink.TabIndex = 1;
			this.AboutHomepageLink.TabStop = true;
			this.AboutHomepageLink.Text = "Official Homepage";
			this.AboutHomepageLink.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.AboutHomepageLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.HomepageLink_LinkClicked);
			this.AuthorLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.AuthorLabel.Location = new Point(105, 52);
			this.AuthorLabel.Name = "AuthorLabel";
			this.AuthorLabel.Size = new Size(132, 16);
			this.AuthorLabel.TabIndex = 3;
			this.AuthorLabel.Text = "Author";
			this.AboutProjectDescriptionLabel.Location = new Point(105, 32);
			this.AboutProjectDescriptionLabel.Name = "AboutProjectDescriptionLabel";
			this.AboutProjectDescriptionLabel.Size = new Size(312, 16);
			this.AboutProjectDescriptionLabel.TabIndex = 2;
			this.AboutProjectDescriptionLabel.Text = "The premiere circular dock for Windows";
			this.AboutProjectName.Font = new Font("Tahoma", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.AboutProjectName.Location = new Point(101, 0);
			this.AboutProjectName.Name = "AboutProjectName";
			this.AboutProjectName.Size = new Size(316, 32);
			this.AboutProjectName.TabIndex = 1;
			this.AboutProjectName.Text = "Circle Dock";
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(96, 96);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.AboutLabel.BackColor = Color.Transparent;
			this.AboutLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.AboutLabel.ForeColor = SystemColors.WindowText;
			this.AboutLabel.Location = new Point(28, 4);
			this.AboutLabel.Name = "AboutLabel";
			this.AboutLabel.Size = new Size(552, 16);
			this.AboutLabel.TabIndex = 1;
			this.AboutLabel.Text = "About";
			this.AboutLabel.Click += new EventHandler(this.AboutPicture_Click);
			this.AboutPicture.BackColor = SystemColors.Control;
			this.AboutPicture.Location = new Point(4, 0);
			this.AboutPicture.Name = "AboutPicture";
			this.AboutPicture.Size = new Size(588, 24);
			this.AboutPicture.TabIndex = 0;
			this.AboutPicture.TabStop = false;
			this.AboutPicture.Click += new EventHandler(this.AboutPicture_Click);
			this.BackgroundPanel.BackColor = SystemColors.Control;
			this.BackgroundPanel.Controls.Add(this.panel7);
			this.BackgroundPanel.Controls.Add(this.BackgroundLabel);
			this.BackgroundPanel.Controls.Add(this.BackgroundPicture);
			this.BackgroundPanel.ForeColor = Color.Black;
			this.BackgroundPanel.Location = new Point(29, 707);
			this.BackgroundPanel.Name = "BackgroundPanel";
			this.BackgroundPanel.Size = new Size(596, 267);
			this.BackgroundPanel.TabIndex = 2;
			this.BackgroundPanel.Tag = "252";
			this.panel7.BackColor = Color.White;
			this.panel7.Controls.Add(this.BackgroundNormalOpacityValue);
			this.panel7.Controls.Add(this.BackgroundNormalSizeValue);
			this.panel7.Controls.Add(this.BackgroundNormalSizeLabel);
			this.panel7.Controls.Add(this.BackgroundNormalSizeTB);
			this.panel7.Controls.Add(this.BackgroundNormalOpacityLabel);
			this.panel7.Controls.Add(this.BackgroundNormalOpacityTB);
			this.panel7.Controls.Add(this.BackgroundImageTextBox);
			this.panel7.Controls.Add(this.BackgroundImageBrowseButton);
			this.panel7.Controls.Add(this.BackgroundImagePictureBox);
			this.panel7.Controls.Add(this.BackgroundImageLabel);
			this.panel7.Location = new Point(4, 24);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(588, 224);
			this.panel7.TabIndex = 2;
			this.BackgroundNormalOpacityValue.BackColor = Color.Transparent;
			this.BackgroundNormalOpacityValue.Location = new Point(182, 123);
			this.BackgroundNormalOpacityValue.Name = "BackgroundNormalOpacityValue";
			this.BackgroundNormalOpacityValue.Size = new Size(220, 16);
			this.BackgroundNormalOpacityValue.TabIndex = 35;
			this.BackgroundNormalOpacityValue.Text = "250";
			this.BackgroundNormalOpacityValue.TextAlign = ContentAlignment.TopCenter;
			this.BackgroundNormalSizeValue.Location = new Point(185, 204);
			this.BackgroundNormalSizeValue.Name = "BackgroundNormalSizeValue";
			this.BackgroundNormalSizeValue.Size = new Size(220, 16);
			this.BackgroundNormalSizeValue.TabIndex = 38;
			this.BackgroundNormalSizeValue.Text = "250";
			this.BackgroundNormalSizeValue.TextAlign = ContentAlignment.TopCenter;
			this.BackgroundNormalSizeLabel.BackColor = Color.Transparent;
			this.BackgroundNormalSizeLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.BackgroundNormalSizeLabel.Location = new Point(138, 152);
			this.BackgroundNormalSizeLabel.Name = "BackgroundNormalSizeLabel";
			this.BackgroundNormalSizeLabel.Size = new Size(312, 16);
			this.BackgroundNormalSizeLabel.TabIndex = 37;
			this.BackgroundNormalSizeLabel.Text = "Normal Size";
			this.BackgroundNormalSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.BackgroundNormalSizeTB.Location = new Point(9, 171);
			this.BackgroundNormalSizeTB.Maximum = 2000;
			this.BackgroundNormalSizeTB.Minimum = 1;
			this.BackgroundNormalSizeTB.Name = "BackgroundNormalSizeTB";
			this.BackgroundNormalSizeTB.Size = new Size(559, 45);
			this.BackgroundNormalSizeTB.TabIndex = 36;
			this.BackgroundNormalSizeTB.TickFrequency = 50;
			this.BackgroundNormalSizeTB.Value = 1;
			this.BackgroundNormalSizeTB.Scroll += new EventHandler(this.BackgroundNormalSizeTB_Scroll);
			this.BackgroundNormalOpacityLabel.BackColor = Color.Transparent;
			this.BackgroundNormalOpacityLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.BackgroundNormalOpacityLabel.Location = new Point(135, 71);
			this.BackgroundNormalOpacityLabel.Name = "BackgroundNormalOpacityLabel";
			this.BackgroundNormalOpacityLabel.Size = new Size(312, 16);
			this.BackgroundNormalOpacityLabel.TabIndex = 34;
			this.BackgroundNormalOpacityLabel.Text = "Normal Opacity";
			this.BackgroundNormalOpacityLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.BackgroundNormalOpacityTB.LargeChange = 10;
			this.BackgroundNormalOpacityTB.Location = new Point(182, 89);
			this.BackgroundNormalOpacityTB.Maximum = 255;
			this.BackgroundNormalOpacityTB.Name = "BackgroundNormalOpacityTB";
			this.BackgroundNormalOpacityTB.Size = new Size(220, 45);
			this.BackgroundNormalOpacityTB.TabIndex = 33;
			this.BackgroundNormalOpacityTB.TickFrequency = 10;
			this.BackgroundNormalOpacityTB.Scroll += new EventHandler(this.BackgroundNormalOpacityTB_Scroll);
			this.BackgroundImageTextBox.Location = new Point(89, 37);
			this.BackgroundImageTextBox.Name = "BackgroundImageTextBox";
			this.BackgroundImageTextBox.ReadOnly = true;
			this.BackgroundImageTextBox.Size = new Size(243, 21);
			this.BackgroundImageTextBox.TabIndex = 32;
			this.BackgroundImageBrowseButton.BackColor = SystemColors.Control;
			this.BackgroundImageBrowseButton.FlatStyle = FlatStyle.System;
			this.BackgroundImageBrowseButton.Location = new Point(339, 36);
			this.BackgroundImageBrowseButton.Name = "BackgroundImageBrowseButton";
			this.BackgroundImageBrowseButton.Size = new Size(49, 20);
			this.BackgroundImageBrowseButton.TabIndex = 31;
			this.BackgroundImageBrowseButton.Text = ".....";
			this.BackgroundImageBrowseButton.UseVisualStyleBackColor = false;
			this.BackgroundImageBrowseButton.Click += new EventHandler(this.BackgroundImageBrowseButton_Click);
			this.BackgroundImagePictureBox.BorderStyle = BorderStyle.FixedSingle;
			this.BackgroundImagePictureBox.Location = new Point(8, 6);
			this.BackgroundImagePictureBox.Name = "BackgroundImagePictureBox";
			this.BackgroundImagePictureBox.Size = new Size(72, 72);
			this.BackgroundImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.BackgroundImagePictureBox.TabIndex = 30;
			this.BackgroundImagePictureBox.TabStop = false;
			this.BackgroundImageLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.BackgroundImageLabel.Location = new Point(86, 6);
			this.BackgroundImageLabel.Name = "BackgroundImageLabel";
			this.BackgroundImageLabel.Size = new Size(260, 27);
			this.BackgroundImageLabel.TabIndex = 26;
			this.BackgroundImageLabel.Text = "Background Image";
			this.BackgroundImageLabel.TextAlign = ContentAlignment.BottomLeft;
			this.BackgroundLabel.BackColor = Color.Transparent;
			this.BackgroundLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.BackgroundLabel.ForeColor = SystemColors.WindowText;
			this.BackgroundLabel.Location = new Point(28, 4);
			this.BackgroundLabel.Name = "BackgroundLabel";
			this.BackgroundLabel.Size = new Size(552, 16);
			this.BackgroundLabel.TabIndex = 1;
			this.BackgroundLabel.Text = "Background";
			this.BackgroundLabel.Click += new EventHandler(this.BackgroundPicture_Click);
			this.BackgroundPicture.BackColor = SystemColors.Control;
			this.BackgroundPicture.Location = new Point(4, 0);
			this.BackgroundPicture.Name = "BackgroundPicture";
			this.BackgroundPicture.Size = new Size(588, 24);
			this.BackgroundPicture.TabIndex = 0;
			this.BackgroundPicture.TabStop = false;
			this.BackgroundPicture.Click += new EventHandler(this.BackgroundPicture_Click);
			this.HelpPanel.BackColor = SystemColors.Control;
			this.HelpPanel.Controls.Add(this.panel8);
			this.HelpPanel.Controls.Add(this.HelpLabel);
			this.HelpPanel.Controls.Add(this.HelpPicture);
			this.HelpPanel.ForeColor = Color.Black;
			this.HelpPanel.Location = new Point(30, 4756);
			this.HelpPanel.Name = "HelpPanel";
			this.HelpPanel.Size = new Size(596, 130);
			this.HelpPanel.TabIndex = 12;
			this.HelpPanel.Tag = "132";
			this.panel8.BackColor = Color.White;
			this.panel8.Controls.Add(this.pictureBox4);
			this.panel8.Controls.Add(this.HelpWebForum);
			this.panel8.Controls.Add(this.HelpWebHelpFAQ);
			this.panel8.Controls.Add(this.HelpSupportLabel);
			this.panel8.Location = new Point(4, 24);
			this.panel8.Name = "panel8";
			this.panel8.Size = new Size(588, 104);
			this.panel8.TabIndex = 2;
			this.pictureBox4.Image = (Image)componentResourceManager.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new Point(4, 4);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new Size(96, 96);
			this.pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 14;
			this.pictureBox4.TabStop = false;
			this.HelpWebForum.LinkColor = Color.FromArgb(0, 0, 192);
			this.HelpWebForum.Location = new Point(119, 43);
			this.HelpWebForum.Name = "HelpWebForum";
			this.HelpWebForum.Size = new Size(112, 16);
			this.HelpWebForum.TabIndex = 8;
			this.HelpWebForum.TabStop = true;
			this.HelpWebForum.Text = "Official Web Forum";
			this.HelpWebForum.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.HelpWebForum.LinkClicked += new LinkLabelLinkClickedEventHandler(this.HelpWebForum_LinkClicked);
			this.HelpWebHelpFAQ.LinkColor = Color.FromArgb(0, 0, 192);
			this.HelpWebHelpFAQ.Location = new Point(119, 59);
			this.HelpWebHelpFAQ.Name = "HelpWebHelpFAQ";
			this.HelpWebHelpFAQ.Size = new Size(132, 16);
			this.HelpWebHelpFAQ.TabIndex = 9;
			this.HelpWebHelpFAQ.TabStop = true;
			this.HelpWebHelpFAQ.Text = "Official Web Help/FAQ";
			this.HelpWebHelpFAQ.VisitedLinkColor = Color.FromArgb(0, 0, 192);
			this.HelpWebHelpFAQ.LinkClicked += new LinkLabelLinkClickedEventHandler(this.HelpWebHelpFAQ_LinkClicked);
			this.HelpSupportLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.HelpSupportLabel.Location = new Point(115, 27);
			this.HelpSupportLabel.Name = "HelpSupportLabel";
			this.HelpSupportLabel.Size = new Size(132, 16);
			this.HelpSupportLabel.TabIndex = 12;
			this.HelpSupportLabel.Text = "Support";
			this.HelpLabel.BackColor = Color.Transparent;
			this.HelpLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.HelpLabel.ForeColor = SystemColors.WindowText;
			this.HelpLabel.Location = new Point(28, 4);
			this.HelpLabel.Name = "HelpLabel";
			this.HelpLabel.Size = new Size(552, 16);
			this.HelpLabel.TabIndex = 1;
			this.HelpLabel.Text = "Help";
			this.HelpLabel.Click += new EventHandler(this.HelpPicture_Click);
			this.HelpPicture.BackColor = SystemColors.Control;
			this.HelpPicture.Location = new Point(4, 0);
			this.HelpPicture.Name = "HelpPicture";
			this.HelpPicture.Size = new Size(588, 24);
			this.HelpPicture.TabIndex = 0;
			this.HelpPicture.TabStop = false;
			this.HelpPicture.Click += new EventHandler(this.HelpPicture_Click);
			this.AnimationPanel.BackColor = SystemColors.Control;
			this.AnimationPanel.Controls.Add(this.panel9);
			this.AnimationPanel.Controls.Add(this.AnimationLabel);
			this.AnimationPanel.Controls.Add(this.AnimationPicture);
			this.AnimationPanel.ForeColor = Color.Black;
			this.AnimationPanel.Location = new Point(29, 1894);
			this.AnimationPanel.Name = "AnimationPanel";
			this.AnimationPanel.Size = new Size(596, 314);
			this.AnimationPanel.TabIndex = 13;
			this.AnimationPanel.Tag = "309";
			this.panel9.BackColor = Color.White;
			this.panel9.Controls.Add(this.UsePoofAnimationWhenDeletingCB);
			this.panel9.Controls.Add(this.FadeInFadeOutDurationValue);
			this.panel9.Controls.Add(this.FadeInFadeOutDurationLabel);
			this.panel9.Controls.Add(this.FadeInFadeOutDurationTB);
			this.panel9.Controls.Add(this.RotationAnimationDurationValue);
			this.panel9.Controls.Add(this.RotationAnimationDurationLabel);
			this.panel9.Controls.Add(this.RotationAnimationDurationTB);
			this.panel9.Controls.Add(this.GeneralFrameRateValue);
			this.panel9.Controls.Add(this.GeneralFrameRateLabel);
			this.panel9.Controls.Add(this.GeneralFrameRateTB);
			this.panel9.Location = new Point(4, 24);
			this.panel9.Name = "panel9";
			this.panel9.Size = new Size(588, 281);
			this.panel9.TabIndex = 2;
			this.UsePoofAnimationWhenDeletingCB.FlatStyle = FlatStyle.System;
			this.UsePoofAnimationWhenDeletingCB.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.UsePoofAnimationWhenDeletingCB.Location = new Point(293, 6);
			this.UsePoofAnimationWhenDeletingCB.Name = "UsePoofAnimationWhenDeletingCB";
			this.UsePoofAnimationWhenDeletingCB.Size = new Size(287, 60);
			this.UsePoofAnimationWhenDeletingCB.TabIndex = 45;
			this.UsePoofAnimationWhenDeletingCB.Text = "Use Poof Animation When Deleting";
			this.UsePoofAnimationWhenDeletingCB.CheckedChanged += new EventHandler(this.UsePoofAnimationWhenDeletingCB_CheckedChanged);
			this.FadeInFadeOutDurationValue.Location = new Point(189, 238);
			this.FadeInFadeOutDurationValue.Name = "FadeInFadeOutDurationValue";
			this.FadeInFadeOutDurationValue.Size = new Size(220, 16);
			this.FadeInFadeOutDurationValue.TabIndex = 44;
			this.FadeInFadeOutDurationValue.Text = "250";
			this.FadeInFadeOutDurationValue.TextAlign = ContentAlignment.TopCenter;
			this.FadeInFadeOutDurationLabel.BackColor = Color.Transparent;
			this.FadeInFadeOutDurationLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.FadeInFadeOutDurationLabel.Location = new Point(-17, 185);
			this.FadeInFadeOutDurationLabel.Name = "FadeInFadeOutDurationLabel";
			this.FadeInFadeOutDurationLabel.Size = new Size(312, 16);
			this.FadeInFadeOutDurationLabel.TabIndex = 43;
			this.FadeInFadeOutDurationLabel.Text = "Fade In / Fade Out Duration (ms)";
			this.FadeInFadeOutDurationLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.FadeInFadeOutDurationTB.LargeChange = 50;
			this.FadeInFadeOutDurationTB.Location = new Point(16, 200);
			this.FadeInFadeOutDurationTB.Maximum = 1000;
			this.FadeInFadeOutDurationTB.Minimum = 1;
			this.FadeInFadeOutDurationTB.Name = "FadeInFadeOutDurationTB";
			this.FadeInFadeOutDurationTB.Size = new Size(567, 45);
			this.FadeInFadeOutDurationTB.SmallChange = 10;
			this.FadeInFadeOutDurationTB.TabIndex = 42;
			this.FadeInFadeOutDurationTB.TickFrequency = 50;
			this.FadeInFadeOutDurationTB.Value = 15;
			this.FadeInFadeOutDurationTB.Scroll += new EventHandler(this.FadeInFadeOutDurationTB_Scroll);
			this.RotationAnimationDurationValue.Location = new Point(189, 149);
			this.RotationAnimationDurationValue.Name = "RotationAnimationDurationValue";
			this.RotationAnimationDurationValue.Size = new Size(220, 16);
			this.RotationAnimationDurationValue.TabIndex = 41;
			this.RotationAnimationDurationValue.Text = "250";
			this.RotationAnimationDurationValue.TextAlign = ContentAlignment.TopCenter;
			this.RotationAnimationDurationLabel.BackColor = Color.Transparent;
			this.RotationAnimationDurationLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.RotationAnimationDurationLabel.Location = new Point(-16, 94);
			this.RotationAnimationDurationLabel.Name = "RotationAnimationDurationLabel";
			this.RotationAnimationDurationLabel.Size = new Size(312, 16);
			this.RotationAnimationDurationLabel.TabIndex = 40;
			this.RotationAnimationDurationLabel.Text = "Rotation Animation Duration (ms)";
			this.RotationAnimationDurationLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.RotationAnimationDurationTB.LargeChange = 50;
			this.RotationAnimationDurationTB.Location = new Point(14, 110);
			this.RotationAnimationDurationTB.Maximum = 4000;
			this.RotationAnimationDurationTB.Minimum = 1;
			this.RotationAnimationDurationTB.Name = "RotationAnimationDurationTB";
			this.RotationAnimationDurationTB.Size = new Size(567, 45);
			this.RotationAnimationDurationTB.SmallChange = 10;
			this.RotationAnimationDurationTB.TabIndex = 39;
			this.RotationAnimationDurationTB.TickFrequency = 50;
			this.RotationAnimationDurationTB.Value = 15;
			this.RotationAnimationDurationTB.Scroll += new EventHandler(this.RotationAnimationDurationTB_Scroll);
			this.GeneralFrameRateValue.Location = new Point(14, 62);
			this.GeneralFrameRateValue.Name = "GeneralFrameRateValue";
			this.GeneralFrameRateValue.Size = new Size(220, 16);
			this.GeneralFrameRateValue.TabIndex = 38;
			this.GeneralFrameRateValue.Text = "250";
			this.GeneralFrameRateValue.TextAlign = ContentAlignment.TopCenter;
			this.GeneralFrameRateLabel.BackColor = Color.Transparent;
			this.GeneralFrameRateLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.GeneralFrameRateLabel.Location = new Point(-35, 11);
			this.GeneralFrameRateLabel.Name = "GeneralFrameRateLabel";
			this.GeneralFrameRateLabel.Size = new Size(312, 16);
			this.GeneralFrameRateLabel.TabIndex = 37;
			this.GeneralFrameRateLabel.Text = "General Frame Rate (FPS)";
			this.GeneralFrameRateLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.GeneralFrameRateTB.LargeChange = 2;
			this.GeneralFrameRateTB.Location = new Point(14, 26);
			this.GeneralFrameRateTB.Maximum = 100;
			this.GeneralFrameRateTB.Minimum = 15;
			this.GeneralFrameRateTB.Name = "GeneralFrameRateTB";
			this.GeneralFrameRateTB.Size = new Size(220, 45);
			this.GeneralFrameRateTB.TabIndex = 36;
			this.GeneralFrameRateTB.TickFrequency = 5;
			this.GeneralFrameRateTB.Value = 15;
			this.GeneralFrameRateTB.Scroll += new EventHandler(this.GeneralFrameRateTB_Scroll);
			this.AnimationLabel.BackColor = Color.Transparent;
			this.AnimationLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.AnimationLabel.ForeColor = SystemColors.WindowText;
			this.AnimationLabel.Location = new Point(28, 4);
			this.AnimationLabel.Name = "AnimationLabel";
			this.AnimationLabel.Size = new Size(552, 16);
			this.AnimationLabel.TabIndex = 1;
			this.AnimationLabel.Text = "Animation";
			this.AnimationLabel.Click += new EventHandler(this.AnimationPicture_Click);
			this.AnimationPicture.BackColor = SystemColors.Control;
			this.AnimationPicture.Location = new Point(4, 0);
			this.AnimationPicture.Name = "AnimationPicture";
			this.AnimationPicture.Size = new Size(588, 24);
			this.AnimationPicture.TabIndex = 0;
			this.AnimationPicture.TabStop = false;
			this.AnimationPicture.Click += new EventHandler(this.AnimationPicture_Click);
			this.LocationPanel.BackColor = SystemColors.Control;
			this.LocationPanel.Controls.Add(this.panel10);
			this.LocationPanel.Controls.Add(this.LocationLabel);
			this.LocationPanel.Controls.Add(this.LocationPicture);
			this.LocationPanel.ForeColor = Color.Black;
			this.LocationPanel.Location = new Point(29, 2245);
			this.LocationPanel.Name = "LocationPanel";
			this.LocationPanel.Size = new Size(596, 240);
			this.LocationPanel.TabIndex = 14;
			this.LocationPanel.Tag = "136";
			this.panel10.BackColor = Color.White;
			this.panel10.Controls.Add(this.CentreAroundCursorWhenShownCB);
			this.panel10.Controls.Add(this.lockDockPositionCheckBox);
			this.panel10.Location = new Point(4, 24);
			this.panel10.Name = "panel10";
			this.panel10.Size = new Size(588, 108);
			this.panel10.TabIndex = 2;
			this.CentreAroundCursorWhenShownCB.FlatStyle = FlatStyle.System;
			this.CentreAroundCursorWhenShownCB.Location = new Point(17, 17);
			this.CentreAroundCursorWhenShownCB.Name = "CentreAroundCursorWhenShownCB";
			this.CentreAroundCursorWhenShownCB.Size = new Size(272, 32);
			this.CentreAroundCursorWhenShownCB.TabIndex = 0;
			this.CentreAroundCursorWhenShownCB.Text = "Centre Around Cursor When Shown";
			this.CentreAroundCursorWhenShownCB.CheckedChanged += new EventHandler(this.CentreAroundCursorWhenShownCB_CheckedChanged);
			this.lockDockPositionCheckBox.FlatStyle = FlatStyle.System;
			this.lockDockPositionCheckBox.Location = new Point(17, 55);
			this.lockDockPositionCheckBox.Name = "lockDockPositionCheckBox";
			this.lockDockPositionCheckBox.Size = new Size(286, 32);
			this.lockDockPositionCheckBox.TabIndex = 1;
			this.lockDockPositionCheckBox.Text = "Lock Dock to Current Position";
			this.lockDockPositionCheckBox.CheckedChanged += new EventHandler(this.lockDockPositionCheckBox_CheckedChanged);
			this.LocationLabel.BackColor = Color.Transparent;
			this.LocationLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LocationLabel.ForeColor = SystemColors.WindowText;
			this.LocationLabel.Location = new Point(28, 4);
			this.LocationLabel.Name = "LocationLabel";
			this.LocationLabel.Size = new Size(552, 16);
			this.LocationLabel.TabIndex = 1;
			this.LocationLabel.Text = "Location";
			this.LocationLabel.Click += new EventHandler(this.LocationPicture_Click);
			this.LocationPicture.BackColor = SystemColors.Control;
			this.LocationPicture.Location = new Point(4, 0);
			this.LocationPicture.Name = "LocationPicture";
			this.LocationPicture.Size = new Size(588, 24);
			this.LocationPicture.TabIndex = 0;
			this.LocationPicture.TabStop = false;
			this.LocationPicture.Click += new EventHandler(this.LocationPicture_Click);
			this.TogglingPanel.BackColor = SystemColors.Control;
			this.TogglingPanel.Controls.Add(this.panel11);
			this.TogglingPanel.Controls.Add(this.TogglingLabel);
			this.TogglingPanel.Controls.Add(this.TogglingPicture);
			this.TogglingPanel.ForeColor = Color.Black;
			this.TogglingPanel.Location = new Point(29, 2491);
			this.TogglingPanel.Name = "TogglingPanel";
			this.TogglingPanel.Size = new Size(596, 504);
			this.TogglingPanel.TabIndex = 15;
			this.TogglingPanel.Tag = "464";
			this.panel11.BackColor = Color.White;
			this.panel11.Controls.Add(this.groupBox7);
			this.panel11.Controls.Add(this.groupBox4);
			this.panel11.Controls.Add(this.groupBox1);
			this.panel11.Location = new Point(4, 24);
			this.panel11.Name = "panel11";
			this.panel11.Size = new Size(588, 436);
			this.panel11.TabIndex = 2;
			this.groupBox7.Controls.Add(this.dwellTimeValue);
			this.groupBox7.Controls.Add(this.dwellTimeLabel);
			this.groupBox7.Controls.Add(this.dwellTimeTrackBar);
			this.groupBox7.Controls.Add(this.EdgeWidthHeightValue);
			this.groupBox7.Controls.Add(this.EdgeWidthHeightLabel);
			this.groupBox7.Controls.Add(this.EdgeWidthHeightTB);
			this.groupBox7.Controls.Add(this.ScreenBottomEdge);
			this.groupBox7.Controls.Add(this.ScreenTopEdge);
			this.groupBox7.Controls.Add(this.ScreenRightEdge);
			this.groupBox7.Controls.Add(this.ScreenLeftEdge);
			this.groupBox7.Controls.Add(this.ShowDockWhenMouseMoveTo);
			this.groupBox7.Location = new Point(34, 219);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new Size(529, 197);
			this.groupBox7.TabIndex = 27;
			this.groupBox7.TabStop = false;
			this.dwellTimeValue.Location = new Point(274, 179);
			this.dwellTimeValue.Name = "dwellTimeValue";
			this.dwellTimeValue.Size = new Size(220, 16);
			this.dwellTimeValue.TabIndex = 29;
			this.dwellTimeValue.Text = "250";
			this.dwellTimeValue.TextAlign = ContentAlignment.TopCenter;
			this.dwellTimeLabel.BackColor = Color.Transparent;
			this.dwellTimeLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.dwellTimeLabel.Location = new Point(282, 103);
			this.dwellTimeLabel.Name = "dwellTimeLabel";
			this.dwellTimeLabel.Size = new Size(241, 35);
			this.dwellTimeLabel.TabIndex = 28;
			this.dwellTimeLabel.Text = "Dwell Time (ms)";
			this.dwellTimeLabel.TextAlign = ContentAlignment.MiddleLeft;
			this.dwellTimeTrackBar.LargeChange = 10;
			this.dwellTimeTrackBar.Location = new Point(274, 141);
			this.dwellTimeTrackBar.Maximum = 1000;
			this.dwellTimeTrackBar.Name = "dwellTimeTrackBar";
			this.dwellTimeTrackBar.Size = new Size(220, 45);
			this.dwellTimeTrackBar.TabIndex = 27;
			this.dwellTimeTrackBar.TickFrequency = 50;
			this.dwellTimeTrackBar.Value = 1;
			this.dwellTimeTrackBar.Scroll += new EventHandler(this.dwellTimeTrackBar_Scroll);
			this.EdgeWidthHeightValue.Location = new Point(274, 86);
			this.EdgeWidthHeightValue.Name = "EdgeWidthHeightValue";
			this.EdgeWidthHeightValue.Size = new Size(220, 16);
			this.EdgeWidthHeightValue.TabIndex = 26;
			this.EdgeWidthHeightValue.Text = "250";
			this.EdgeWidthHeightValue.TextAlign = ContentAlignment.TopCenter;
			this.EdgeWidthHeightLabel.BackColor = Color.Transparent;
			this.EdgeWidthHeightLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.EdgeWidthHeightLabel.Location = new Point(282, 14);
			this.EdgeWidthHeightLabel.Name = "EdgeWidthHeightLabel";
			this.EdgeWidthHeightLabel.Size = new Size(235, 34);
			this.EdgeWidthHeightLabel.TabIndex = 25;
			this.EdgeWidthHeightLabel.Text = "Edge Width/Height";
			this.EdgeWidthHeightLabel.TextAlign = ContentAlignment.MiddleLeft;
			this.EdgeWidthHeightTB.LargeChange = 1;
			this.EdgeWidthHeightTB.Location = new Point(274, 48);
			this.EdgeWidthHeightTB.Minimum = 1;
			this.EdgeWidthHeightTB.Name = "EdgeWidthHeightTB";
			this.EdgeWidthHeightTB.Size = new Size(220, 45);
			this.EdgeWidthHeightTB.TabIndex = 24;
			this.EdgeWidthHeightTB.Value = 1;
			this.EdgeWidthHeightTB.Scroll += new EventHandler(this.EdgeWidthHeightTB_Scroll);
			this.ScreenBottomEdge.BackColor = Color.Transparent;
			this.ScreenBottomEdge.FlatStyle = FlatStyle.System;
			this.ScreenBottomEdge.Location = new Point(26, 134);
			this.ScreenBottomEdge.Name = "ScreenBottomEdge";
			this.ScreenBottomEdge.Size = new Size(272, 16);
			this.ScreenBottomEdge.TabIndex = 23;
			this.ScreenBottomEdge.Text = "Screen Bottom Edge";
			this.ScreenBottomEdge.UseVisualStyleBackColor = false;
			this.ScreenBottomEdge.CheckedChanged += new EventHandler(this.ScreenBottomEdge_CheckedChanged);
			this.ScreenTopEdge.BackColor = Color.Transparent;
			this.ScreenTopEdge.FlatStyle = FlatStyle.System;
			this.ScreenTopEdge.Location = new Point(26, 112);
			this.ScreenTopEdge.Name = "ScreenTopEdge";
			this.ScreenTopEdge.Size = new Size(272, 16);
			this.ScreenTopEdge.TabIndex = 22;
			this.ScreenTopEdge.Text = "Screen Top Edge";
			this.ScreenTopEdge.UseVisualStyleBackColor = false;
			this.ScreenTopEdge.CheckedChanged += new EventHandler(this.ScreenTopEdge_CheckedChanged);
			this.ScreenRightEdge.BackColor = Color.Transparent;
			this.ScreenRightEdge.FlatStyle = FlatStyle.System;
			this.ScreenRightEdge.Location = new Point(25, 90);
			this.ScreenRightEdge.Name = "ScreenRightEdge";
			this.ScreenRightEdge.Size = new Size(272, 16);
			this.ScreenRightEdge.TabIndex = 21;
			this.ScreenRightEdge.Text = "Screen Right Edge";
			this.ScreenRightEdge.UseVisualStyleBackColor = false;
			this.ScreenRightEdge.CheckedChanged += new EventHandler(this.ScreenRightEdge_CheckedChanged);
			this.ScreenLeftEdge.BackColor = Color.Transparent;
			this.ScreenLeftEdge.FlatStyle = FlatStyle.System;
			this.ScreenLeftEdge.Location = new Point(26, 68);
			this.ScreenLeftEdge.Name = "ScreenLeftEdge";
			this.ScreenLeftEdge.Size = new Size(272, 16);
			this.ScreenLeftEdge.TabIndex = 20;
			this.ScreenLeftEdge.Text = "Screen Left Edge";
			this.ScreenLeftEdge.UseVisualStyleBackColor = false;
			this.ScreenLeftEdge.CheckedChanged += new EventHandler(this.ScreenLeftEdge_CheckedChanged);
			this.ShowDockWhenMouseMoveTo.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ShowDockWhenMouseMoveTo.Location = new Point(17, 20);
			this.ShowDockWhenMouseMoveTo.Name = "ShowDockWhenMouseMoveTo";
			this.ShowDockWhenMouseMoveTo.Size = new Size(239, 45);
			this.ShowDockWhenMouseMoveTo.TabIndex = 18;
			this.ShowDockWhenMouseMoveTo.Text = "Show Dock When I Move My Mouse to....";
			this.ShowDockWhenMouseMoveTo.TextAlign = ContentAlignment.BottomCenter;
			this.groupBox4.Controls.Add(this.ToggleVisiblityMouseButton);
			this.groupBox4.Controls.Add(this.ToggleVisibilityMouseButtonLabel);
			this.groupBox4.Location = new Point(337, 63);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(217, 99);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.ToggleVisiblityMouseButton.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ToggleVisiblityMouseButton.Location = new Point(34, 64);
			this.ToggleVisiblityMouseButton.Name = "ToggleVisiblityMouseButton";
			this.ToggleVisiblityMouseButton.Size = new Size(150, 21);
			this.ToggleVisiblityMouseButton.TabIndex = 8;
			this.ToggleVisiblityMouseButton.SelectedIndexChanged += new EventHandler(this.ToggleVisiblityMouseButton_SelectedIndexChanged);
			this.ToggleVisibilityMouseButtonLabel.BackColor = Color.Transparent;
			this.ToggleVisibilityMouseButtonLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ToggleVisibilityMouseButtonLabel.Location = new Point(8, 18);
			this.ToggleVisibilityMouseButtonLabel.Name = "ToggleVisibilityMouseButtonLabel";
			this.ToggleVisibilityMouseButtonLabel.Size = new Size(203, 37);
			this.ToggleVisibilityMouseButtonLabel.TabIndex = 0;
			this.ToggleVisibilityMouseButtonLabel.Text = "Toggle Visibility Mouse Button";
			this.ToggleVisibilityMouseButtonLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.groupBox1.Controls.Add(this.ToggleVisibilityHotkeyLabel);
			this.groupBox1.Controls.Add(this.ToggleVisiblityKey1);
			this.groupBox1.Controls.Add(this.ToggleVisibilityHotkeyValid);
			this.groupBox1.Controls.Add(this.ToggleVisibilityWinCB);
			this.groupBox1.Controls.Add(this.ToggleVisibilityShiftCB);
			this.groupBox1.Controls.Add(this.ToggleVisibilityCtrlCB);
			this.groupBox1.Controls.Add(this.ToggleVisibilityAltCB);
			this.groupBox1.Location = new Point(39, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(267, 189);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.ToggleVisibilityHotkeyLabel.BackColor = Color.Transparent;
			this.ToggleVisibilityHotkeyLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ToggleVisibilityHotkeyLabel.Location = new Point(2, 13);
			this.ToggleVisibilityHotkeyLabel.Name = "ToggleVisibilityHotkeyLabel";
			this.ToggleVisibilityHotkeyLabel.Size = new Size(256, 36);
			this.ToggleVisibilityHotkeyLabel.TabIndex = 0;
			this.ToggleVisibilityHotkeyLabel.Text = "Toggle Visibility Hotkey";
			this.ToggleVisibilityHotkeyLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.ToggleVisiblityKey1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ToggleVisiblityKey1.Location = new Point(49, 122);
			this.ToggleVisiblityKey1.Name = "ToggleVisiblityKey1";
			this.ToggleVisiblityKey1.Size = new Size(150, 21);
			this.ToggleVisiblityKey1.TabIndex = 27;
			this.ToggleVisiblityKey1.SelectedIndexChanged += new EventHandler(this.ToggleVisiblityKey1_SelectedIndexChanged);
			this.ToggleVisibilityHotkeyValid.BackColor = Color.Transparent;
			this.ToggleVisibilityHotkeyValid.Font = new Font("Tahoma", 8.25f);
			this.ToggleVisibilityHotkeyValid.Location = new Point(42, 146);
			this.ToggleVisibilityHotkeyValid.Name = "ToggleVisibilityHotkeyValid";
			this.ToggleVisibilityHotkeyValid.Size = new Size(156, 29);
			this.ToggleVisibilityHotkeyValid.TabIndex = 12;
			this.ToggleVisibilityHotkeyValid.Text = "Valid/Invalid";
			this.ToggleVisibilityWinCB.BackColor = Color.Transparent;
			this.ToggleVisibilityWinCB.FlatStyle = FlatStyle.System;
			this.ToggleVisibilityWinCB.Location = new Point(94, 100);
			this.ToggleVisibilityWinCB.Name = "ToggleVisibilityWinCB";
			this.ToggleVisibilityWinCB.Size = new Size(272, 16);
			this.ToggleVisibilityWinCB.TabIndex = 10;
			this.ToggleVisibilityWinCB.Text = "Win";
			this.ToggleVisibilityWinCB.UseVisualStyleBackColor = false;
			this.ToggleVisibilityWinCB.CheckedChanged += new EventHandler(this.ToggleVisibilityWinCB_CheckedChanged);
			this.ToggleVisibilityShiftCB.BackColor = Color.Transparent;
			this.ToggleVisibilityShiftCB.FlatStyle = FlatStyle.System;
			this.ToggleVisibilityShiftCB.Location = new Point(94, 84);
			this.ToggleVisibilityShiftCB.Name = "ToggleVisibilityShiftCB";
			this.ToggleVisibilityShiftCB.Size = new Size(272, 16);
			this.ToggleVisibilityShiftCB.TabIndex = 2;
			this.ToggleVisibilityShiftCB.Text = "Shift";
			this.ToggleVisibilityShiftCB.UseVisualStyleBackColor = false;
			this.ToggleVisibilityShiftCB.CheckedChanged += new EventHandler(this.ToggleVisibilityShiftCB_CheckedChanged);
			this.ToggleVisibilityCtrlCB.BackColor = Color.Transparent;
			this.ToggleVisibilityCtrlCB.FlatStyle = FlatStyle.System;
			this.ToggleVisibilityCtrlCB.Location = new Point(94, 52);
			this.ToggleVisibilityCtrlCB.Name = "ToggleVisibilityCtrlCB";
			this.ToggleVisibilityCtrlCB.Size = new Size(272, 16);
			this.ToggleVisibilityCtrlCB.TabIndex = 0;
			this.ToggleVisibilityCtrlCB.Text = "Ctrl";
			this.ToggleVisibilityCtrlCB.UseVisualStyleBackColor = false;
			this.ToggleVisibilityCtrlCB.CheckedChanged += new EventHandler(this.ToggleVisibilityCtrlCB_CheckedChanged);
			this.ToggleVisibilityAltCB.BackColor = Color.Transparent;
			this.ToggleVisibilityAltCB.FlatStyle = FlatStyle.System;
			this.ToggleVisibilityAltCB.Location = new Point(94, 68);
			this.ToggleVisibilityAltCB.Name = "ToggleVisibilityAltCB";
			this.ToggleVisibilityAltCB.Size = new Size(272, 16);
			this.ToggleVisibilityAltCB.TabIndex = 1;
			this.ToggleVisibilityAltCB.Text = "Alt";
			this.ToggleVisibilityAltCB.UseVisualStyleBackColor = false;
			this.ToggleVisibilityAltCB.CheckedChanged += new EventHandler(this.ToggleVisibilityAltCB_CheckedChanged);
			this.TogglingLabel.BackColor = Color.Transparent;
			this.TogglingLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.TogglingLabel.ForeColor = SystemColors.WindowText;
			this.TogglingLabel.Location = new Point(28, 4);
			this.TogglingLabel.Name = "TogglingLabel";
			this.TogglingLabel.Size = new Size(552, 16);
			this.TogglingLabel.TabIndex = 1;
			this.TogglingLabel.Text = "Toggling";
			this.TogglingLabel.Click += new EventHandler(this.TogglingPicture_Click);
			this.TogglingPicture.BackColor = SystemColors.Control;
			this.TogglingPicture.Location = new Point(4, 0);
			this.TogglingPicture.Name = "TogglingPicture";
			this.TogglingPicture.Size = new Size(588, 24);
			this.TogglingPicture.TabIndex = 0;
			this.TogglingPicture.TabStop = false;
			this.TogglingPicture.Click += new EventHandler(this.TogglingPicture_Click);
			this.FileIconAssociationsPanel.BackColor = SystemColors.Control;
			this.FileIconAssociationsPanel.Controls.Add(this.panel12);
			this.FileIconAssociationsPanel.Controls.Add(this.FileIconAssociationsLabel);
			this.FileIconAssociationsPanel.Controls.Add(this.FileIconAssociationsPicture);
			this.FileIconAssociationsPanel.ForeColor = Color.Black;
			this.FileIconAssociationsPanel.Location = new Point(30, 3001);
			this.FileIconAssociationsPanel.Name = "FileIconAssociationsPanel";
			this.FileIconAssociationsPanel.Size = new Size(596, 982);
			this.FileIconAssociationsPanel.TabIndex = 16;
			this.FileIconAssociationsPanel.Tag = "159";
			this.panel12.BackColor = Color.White;
			this.panel12.Controls.Add(this.DockFolderDefaultImageBrowse);
			this.panel12.Controls.Add(this.DockFolderDefaultImagePath);
			this.panel12.Controls.Add(this.DockFolderDefaultImage);
			this.panel12.Controls.Add(this.DockFolderIconAssociationsLabel);
			this.panel12.Controls.Add(this.dataGridView2);
			this.panel12.Controls.Add(this.dataGridView1);
			this.panel12.Controls.Add(this.FileIconAssociationsDescription);
			this.panel12.Controls.Add(this.FileExtensionIconAssociationsLabel);
			this.panel12.Controls.Add(this.FolderNameIconAssociationsLabel);
			this.panel12.Controls.Add(this.FileNameIconAssociationsLabel);
			this.panel12.Controls.Add(this.FileNameIconAssocationsTable);
			this.panel12.Location = new Point(4, 24);
			this.panel12.Name = "panel12";
			this.panel12.Size = new Size(588, 131);
			this.panel12.TabIndex = 2;
			this.DockFolderDefaultImageBrowse.BackColor = SystemColors.Control;
			this.DockFolderDefaultImageBrowse.FlatStyle = FlatStyle.System;
			this.DockFolderDefaultImageBrowse.Location = new Point(513, 37);
			this.DockFolderDefaultImageBrowse.Name = "DockFolderDefaultImageBrowse";
			this.DockFolderDefaultImageBrowse.Size = new Size(49, 20);
			this.DockFolderDefaultImageBrowse.TabIndex = 33;
			this.DockFolderDefaultImageBrowse.Text = ".....";
			this.DockFolderDefaultImageBrowse.UseVisualStyleBackColor = false;
			this.DockFolderDefaultImageBrowse.Click += new EventHandler(this.DockFolderDefaultImageBrowse_Click);
			this.DockFolderDefaultImagePath.Location = new Point(150, 38);
			this.DockFolderDefaultImagePath.Name = "DockFolderDefaultImagePath";
			this.DockFolderDefaultImagePath.ReadOnly = true;
			this.DockFolderDefaultImagePath.Size = new Size(348, 21);
			this.DockFolderDefaultImagePath.TabIndex = 20;
			this.DockFolderDefaultImage.BorderStyle = BorderStyle.FixedSingle;
			this.DockFolderDefaultImage.Location = new Point(43, 34);
			this.DockFolderDefaultImage.Name = "DockFolderDefaultImage";
			this.DockFolderDefaultImage.Size = new Size(72, 72);
			this.DockFolderDefaultImage.SizeMode = PictureBoxSizeMode.StretchImage;
			this.DockFolderDefaultImage.TabIndex = 19;
			this.DockFolderDefaultImage.TabStop = false;
			this.DockFolderIconAssociationsLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DockFolderIconAssociationsLabel.Location = new Point(40, 14);
			this.DockFolderIconAssociationsLabel.Name = "DockFolderIconAssociationsLabel";
			this.DockFolderIconAssociationsLabel.Size = new Size(500, 16);
			this.DockFolderIconAssociationsLabel.TabIndex = 11;
			this.DockFolderIconAssociationsLabel.Text = "Dock Folder -> Icon Association";
			this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn3,
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewButtonColumn2,
				this.dataGridViewCheckBoxColumn4,
				this.dataGridViewCheckBoxColumn5,
				this.dataGridViewCheckBoxColumn6,
				this.dataGridViewImageColumn2
			});
			this.dataGridView2.Enabled = false;
			this.dataGridView2.Location = new Point(10, 566);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new Size(571, 219);
			this.dataGridView2.TabIndex = 22;
			this.dataGridView2.Visible = false;
			this.dataGridViewTextBoxColumn3.HeaderText = "File Name";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 125;
			this.dataGridViewTextBoxColumn4.HeaderText = "Associated Dock Icon";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 150;
			this.dataGridViewButtonColumn2.HeaderText = "Browse";
			this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
			this.dataGridViewButtonColumn2.Text = "";
			this.dataGridViewButtonColumn2.Width = 50;
			this.dataGridViewCheckBoxColumn4.HeaderText = "Starts With";
			this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
			this.dataGridViewCheckBoxColumn4.Width = 50;
			this.dataGridViewCheckBoxColumn5.HeaderText = "Ends With";
			this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
			this.dataGridViewCheckBoxColumn5.Width = 50;
			this.dataGridViewCheckBoxColumn6.HeaderText = "Exact";
			this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
			this.dataGridViewCheckBoxColumn6.Width = 50;
			this.dataGridViewImageColumn2.HeaderText = "Sample";
			this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
			this.dataGridViewImageColumn2.ReadOnly = true;
			this.dataGridViewImageColumn2.Width = 50;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewButtonColumn1,
				this.dataGridViewCheckBoxColumn1,
				this.dataGridViewCheckBoxColumn2,
				this.dataGridViewCheckBoxColumn3,
				this.dataGridViewImageColumn1
			});
			this.dataGridView1.Enabled = false;
			this.dataGridView1.Location = new Point(9, 310);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new Size(571, 219);
			this.dataGridView1.TabIndex = 21;
			this.dataGridView1.Visible = false;
			this.dataGridViewTextBoxColumn1.HeaderText = "File Name";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 125;
			this.dataGridViewTextBoxColumn2.HeaderText = "Associated Dock Icon";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 150;
			this.dataGridViewButtonColumn1.HeaderText = "Browse";
			this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			this.dataGridViewButtonColumn1.Text = "";
			this.dataGridViewButtonColumn1.Width = 50;
			this.dataGridViewCheckBoxColumn1.HeaderText = "Starts With";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.Width = 50;
			this.dataGridViewCheckBoxColumn2.HeaderText = "Ends With";
			this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
			this.dataGridViewCheckBoxColumn2.Width = 50;
			this.dataGridViewCheckBoxColumn3.HeaderText = "Exact";
			this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
			this.dataGridViewCheckBoxColumn3.Width = 50;
			this.dataGridViewImageColumn1.HeaderText = "Sample";
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.ReadOnly = true;
			this.dataGridViewImageColumn1.Width = 50;
			this.FileIconAssociationsDescription.Font = new Font("Tahoma", 9f, FontStyle.Bold);
			this.FileIconAssociationsDescription.Location = new Point(11, 5);
			this.FileIconAssociationsDescription.Name = "FileIconAssociationsDescription";
			this.FileIconAssociationsDescription.Size = new Size(569, 31);
			this.FileIconAssociationsDescription.TabIndex = 10;
			this.FileIconAssociationsDescription.Text = "Default Icons Used When Adding Files/Folders to the Dock";
			this.FileIconAssociationsDescription.TextAlign = ContentAlignment.MiddleCenter;
			this.FileIconAssociationsDescription.Visible = false;
			this.FileExtensionIconAssociationsLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.FileExtensionIconAssociationsLabel.Location = new Point(14, 547);
			this.FileExtensionIconAssociationsLabel.Name = "FileExtensionIconAssociationsLabel";
			this.FileExtensionIconAssociationsLabel.Size = new Size(500, 16);
			this.FileExtensionIconAssociationsLabel.TabIndex = 9;
			this.FileExtensionIconAssociationsLabel.Text = "File Extension -> Icon Associations";
			this.FileExtensionIconAssociationsLabel.Visible = false;
			this.FolderNameIconAssociationsLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.FolderNameIconAssociationsLabel.Location = new Point(14, 291);
			this.FolderNameIconAssociationsLabel.Name = "FolderNameIconAssociationsLabel";
			this.FolderNameIconAssociationsLabel.Size = new Size(500, 16);
			this.FolderNameIconAssociationsLabel.TabIndex = 7;
			this.FolderNameIconAssociationsLabel.Text = "Folder Name -> Icon Associations";
			this.FolderNameIconAssociationsLabel.Visible = false;
			this.FileNameIconAssociationsLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.FileNameIconAssociationsLabel.Location = new Point(14, 36);
			this.FileNameIconAssociationsLabel.Name = "FileNameIconAssociationsLabel";
			this.FileNameIconAssociationsLabel.Size = new Size(500, 16);
			this.FileNameIconAssociationsLabel.TabIndex = 5;
			this.FileNameIconAssociationsLabel.Text = "File Name -> Icon Associations";
			this.FileNameIconAssociationsLabel.Visible = false;
			this.FileNameIconAssocationsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FileNameIconAssocationsTable.Columns.AddRange(new DataGridViewColumn[]
			{
				this.FileName,
				this.AssociatedDockIcon,
				this.BrowseIconForFileName,
				this.StartsWith,
				this.EndsWith,
				this.ExactMatch,
				this.SampleIcon
			});
			this.FileNameIconAssocationsTable.Enabled = false;
			this.FileNameIconAssocationsTable.Location = new Point(9, 55);
			this.FileNameIconAssocationsTable.Name = "FileNameIconAssocationsTable";
			this.FileNameIconAssocationsTable.Size = new Size(571, 219);
			this.FileNameIconAssocationsTable.TabIndex = 0;
			this.FileNameIconAssocationsTable.Visible = false;
			this.FileName.HeaderText = "File Name";
			this.FileName.Name = "FileName";
			this.FileName.Width = 125;
			this.AssociatedDockIcon.HeaderText = "Associated Dock Icon";
			this.AssociatedDockIcon.Name = "AssociatedDockIcon";
			this.AssociatedDockIcon.Width = 150;
			this.BrowseIconForFileName.HeaderText = "Browse";
			this.BrowseIconForFileName.Name = "BrowseIconForFileName";
			this.BrowseIconForFileName.Text = "";
			this.BrowseIconForFileName.Width = 50;
			this.StartsWith.HeaderText = "Starts With";
			this.StartsWith.Name = "StartsWith";
			this.StartsWith.Width = 50;
			this.EndsWith.HeaderText = "Ends With";
			this.EndsWith.Name = "EndsWith";
			this.EndsWith.Width = 50;
			this.ExactMatch.HeaderText = "Exact";
			this.ExactMatch.Name = "ExactMatch";
			this.ExactMatch.Width = 50;
			this.SampleIcon.HeaderText = "Sample";
			this.SampleIcon.Name = "SampleIcon";
			this.SampleIcon.ReadOnly = true;
			this.SampleIcon.Width = 50;
			this.FileIconAssociationsLabel.BackColor = Color.Transparent;
			this.FileIconAssociationsLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.FileIconAssociationsLabel.ForeColor = SystemColors.WindowText;
			this.FileIconAssociationsLabel.Location = new Point(28, 4);
			this.FileIconAssociationsLabel.Name = "FileIconAssociationsLabel";
			this.FileIconAssociationsLabel.Size = new Size(552, 16);
			this.FileIconAssociationsLabel.TabIndex = 1;
			this.FileIconAssociationsLabel.Text = "File -> Icon Associations";
			this.FileIconAssociationsLabel.Click += new EventHandler(this.FileIconAssociationsPicture_Click);
			this.FileIconAssociationsPicture.BackColor = SystemColors.Control;
			this.FileIconAssociationsPicture.Location = new Point(4, 0);
			this.FileIconAssociationsPicture.Name = "FileIconAssociationsPicture";
			this.FileIconAssociationsPicture.Size = new Size(588, 24);
			this.FileIconAssociationsPicture.TabIndex = 0;
			this.FileIconAssociationsPicture.TabStop = false;
			this.FileIconAssociationsPicture.Click += new EventHandler(this.FileIconAssociationsPicture_Click);
			this.LanguagePanel.BackColor = SystemColors.Control;
			this.LanguagePanel.Controls.Add(this.panel13);
			this.LanguagePanel.Controls.Add(this.LanguageLabel);
			this.LanguagePanel.Controls.Add(this.LanguagePicture);
			this.LanguagePanel.ForeColor = Color.Black;
			this.LanguagePanel.Location = new Point(30, 4084);
			this.LanguagePanel.Name = "LanguagePanel";
			this.LanguagePanel.Size = new Size(596, 237);
			this.LanguagePanel.TabIndex = 17;
			this.LanguagePanel.Tag = "232";
			this.panel13.BackColor = Color.White;
			this.panel13.Controls.Add(this.LanguageProgramRestartRequired);
			this.panel13.Controls.Add(this.LanguageFileLocationBrowse);
			this.panel13.Controls.Add(this.LanguageFileLocationTextBox);
			this.panel13.Controls.Add(this.LanguageFileValidity);
			this.panel13.Controls.Add(this.LanguageIntendedVersion);
			this.panel13.Controls.Add(this.LanguageFileIntendedForTitle);
			this.panel13.Controls.Add(this.LanguageFileVersion);
			this.panel13.Controls.Add(this.LanguageFileVersionTitleLabel);
			this.panel13.Controls.Add(this.LanguageFileAuthor);
			this.panel13.Controls.Add(this.LanguageFileAuthorTitleLabel);
			this.panel13.Controls.Add(this.LanguageName);
			this.panel13.Controls.Add(this.LanguageNameTitleLabel);
			this.panel13.Controls.Add(this.LanguageFileLocationLabel);
			this.panel13.Location = new Point(4, 24);
			this.panel13.Name = "panel13";
			this.panel13.Size = new Size(588, 204);
			this.panel13.TabIndex = 2;
			this.LanguageProgramRestartRequired.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LanguageProgramRestartRequired.Location = new Point(208, 159);
			this.LanguageProgramRestartRequired.Name = "LanguageProgramRestartRequired";
			this.LanguageProgramRestartRequired.Size = new Size(365, 36);
			this.LanguageProgramRestartRequired.TabIndex = 34;
			this.LanguageProgramRestartRequired.Text = "***Program Restart Required to Fully Change Language***";
			this.LanguageProgramRestartRequired.TextAlign = ContentAlignment.MiddleCenter;
			this.LanguageFileLocationBrowse.BackColor = SystemColors.Control;
			this.LanguageFileLocationBrowse.FlatStyle = FlatStyle.System;
			this.LanguageFileLocationBrowse.Location = new Point(379, 33);
			this.LanguageFileLocationBrowse.Name = "LanguageFileLocationBrowse";
			this.LanguageFileLocationBrowse.Size = new Size(49, 20);
			this.LanguageFileLocationBrowse.TabIndex = 33;
			this.LanguageFileLocationBrowse.Text = ".....";
			this.LanguageFileLocationBrowse.UseVisualStyleBackColor = false;
			this.LanguageFileLocationBrowse.Click += new EventHandler(this.LanguageFileLocationBrowse_Click);
			this.LanguageFileLocationTextBox.Location = new Point(14, 32);
			this.LanguageFileLocationTextBox.Name = "LanguageFileLocationTextBox";
			this.LanguageFileLocationTextBox.ReadOnly = true;
			this.LanguageFileLocationTextBox.Size = new Size(348, 21);
			this.LanguageFileLocationTextBox.TabIndex = 22;
			this.LanguageFileValidity.BackColor = Color.Transparent;
			this.LanguageFileValidity.Location = new Point(244, 128);
			this.LanguageFileValidity.Name = "LanguageFileValidity";
			this.LanguageFileValidity.Size = new Size(336, 31);
			this.LanguageFileValidity.TabIndex = 16;
			this.LanguageFileValidity.Text = "Language File is Valid/Current";
			this.LanguageIntendedVersion.BackColor = Color.Transparent;
			this.LanguageIntendedVersion.Location = new Point(244, 103);
			this.LanguageIntendedVersion.Name = "LanguageIntendedVersion";
			this.LanguageIntendedVersion.Size = new Size(320, 23);
			this.LanguageIntendedVersion.TabIndex = 15;
			this.LanguageIntendedVersion.Text = "0.9.2 Alpha 7";
			this.LanguageFileIntendedForTitle.BackColor = Color.Transparent;
			this.LanguageFileIntendedForTitle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LanguageFileIntendedForTitle.Location = new Point(215, 65);
			this.LanguageFileIntendedForTitle.Name = "LanguageFileIntendedForTitle";
			this.LanguageFileIntendedForTitle.Size = new Size(290, 36);
			this.LanguageFileIntendedForTitle.TabIndex = 14;
			this.LanguageFileIntendedForTitle.Text = "Language File Originally Intended For Circle Dock Version:";
			this.LanguageFileVersion.Location = new Point(9, 179);
			this.LanguageFileVersion.Name = "LanguageFileVersion";
			this.LanguageFileVersion.Size = new Size(544, 16);
			this.LanguageFileVersion.TabIndex = 13;
			this.LanguageFileVersion.Text = "0.1";
			this.LanguageFileVersionTitleLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LanguageFileVersionTitleLabel.Location = new Point(5, 159);
			this.LanguageFileVersionTitleLabel.Name = "LanguageFileVersionTitleLabel";
			this.LanguageFileVersionTitleLabel.Size = new Size(196, 20);
			this.LanguageFileVersionTitleLabel.TabIndex = 12;
			this.LanguageFileVersionTitleLabel.Text = "Language File Version";
			this.LanguageFileAuthor.Location = new Point(9, 130);
			this.LanguageFileAuthor.Name = "LanguageFileAuthor";
			this.LanguageFileAuthor.Size = new Size(544, 16);
			this.LanguageFileAuthor.TabIndex = 11;
			this.LanguageFileAuthor.Text = "Eric Wong";
			this.LanguageFileAuthorTitleLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LanguageFileAuthorTitleLabel.Location = new Point(5, 110);
			this.LanguageFileAuthorTitleLabel.Name = "LanguageFileAuthorTitleLabel";
			this.LanguageFileAuthorTitleLabel.Size = new Size(576, 16);
			this.LanguageFileAuthorTitleLabel.TabIndex = 10;
			this.LanguageFileAuthorTitleLabel.Text = "Language File Author";
			this.LanguageName.Location = new Point(9, 85);
			this.LanguageName.Name = "LanguageName";
			this.LanguageName.Size = new Size(544, 16);
			this.LanguageName.TabIndex = 9;
			this.LanguageName.Text = "English";
			this.LanguageNameTitleLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LanguageNameTitleLabel.Location = new Point(5, 65);
			this.LanguageNameTitleLabel.Name = "LanguageNameTitleLabel";
			this.LanguageNameTitleLabel.Size = new Size(576, 16);
			this.LanguageNameTitleLabel.TabIndex = 8;
			this.LanguageNameTitleLabel.Text = "Language Name";
			this.LanguageFileLocationLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LanguageFileLocationLabel.Location = new Point(5, 13);
			this.LanguageFileLocationLabel.Name = "LanguageFileLocationLabel";
			this.LanguageFileLocationLabel.Size = new Size(576, 16);
			this.LanguageFileLocationLabel.TabIndex = 5;
			this.LanguageFileLocationLabel.Text = "Language File Location";
			this.LanguageLabel.BackColor = Color.Transparent;
			this.LanguageLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LanguageLabel.ForeColor = SystemColors.WindowText;
			this.LanguageLabel.Location = new Point(28, 4);
			this.LanguageLabel.Name = "LanguageLabel";
			this.LanguageLabel.Size = new Size(552, 16);
			this.LanguageLabel.TabIndex = 1;
			this.LanguageLabel.Text = "Language";
			this.LanguageLabel.Click += new EventHandler(this.LanguagePicture_Click);
			this.LanguagePicture.BackColor = SystemColors.Control;
			this.LanguagePicture.Location = new Point(4, 0);
			this.LanguagePicture.Name = "LanguagePicture";
			this.LanguagePicture.Size = new Size(588, 24);
			this.LanguagePicture.TabIndex = 0;
			this.LanguagePicture.TabStop = false;
			this.LanguagePicture.Click += new EventHandler(this.LanguagePicture_Click);
			this.DockItemsPanel.BackColor = SystemColors.Control;
			this.DockItemsPanel.Controls.Add(this.panel14);
			this.DockItemsPanel.Controls.Add(this.DockItemsLabel);
			this.DockItemsPanel.Controls.Add(this.DockItemsPicture);
			this.DockItemsPanel.ForeColor = Color.Black;
			this.DockItemsPanel.Location = new Point(29, 1303);
			this.DockItemsPanel.Name = "DockItemsPanel";
			this.DockItemsPanel.Size = new Size(596, 234);
			this.DockItemsPanel.TabIndex = 18;
			this.DockItemsPanel.Tag = "232";
			this.panel14.BackColor = Color.White;
			this.panel14.Controls.Add(this.DockItemsHideDockAfterExecutionCB);
			this.panel14.Controls.Add(this.DockItemsHideDockLabel);
			this.panel14.Controls.Add(this.DockItemsRightClickMenuLabel);
			this.panel14.Controls.Add(this.DockItemsShowExplorerContextMenusCB);
			this.panel14.Controls.Add(this.DockItemsNormalSizeValue);
			this.panel14.Controls.Add(this.DockItemsNormalSizeLabel);
			this.panel14.Controls.Add(this.DockItemsNormalSizeTB);
			this.panel14.Controls.Add(this.DockItemsNormalOpacityValue);
			this.panel14.Controls.Add(this.DockItemsNormalOpacityLabel);
			this.panel14.Controls.Add(this.DockItemsNormalOpacityTB);
			this.panel14.Location = new Point(4, 24);
			this.panel14.Name = "panel14";
			this.panel14.Size = new Size(588, 204);
			this.panel14.TabIndex = 2;
			this.DockItemsHideDockAfterExecutionCB.FlatStyle = FlatStyle.System;
			this.DockItemsHideDockAfterExecutionCB.Location = new Point(293, 32);
			this.DockItemsHideDockAfterExecutionCB.Name = "DockItemsHideDockAfterExecutionCB";
			this.DockItemsHideDockAfterExecutionCB.Size = new Size(272, 53);
			this.DockItemsHideDockAfterExecutionCB.TabIndex = 35;
			this.DockItemsHideDockAfterExecutionCB.Text = "Hide Dock After Opening Files/Folders";
			this.DockItemsHideDockAfterExecutionCB.TextAlign = ContentAlignment.TopLeft;
			this.DockItemsHideDockAfterExecutionCB.CheckedChanged += new EventHandler(this.DockItemsHideDockAfterExecutionCB_CheckedChanged);
			this.DockItemsHideDockLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DockItemsHideDockLabel.Location = new Point(278, 13);
			this.DockItemsHideDockLabel.Name = "DockItemsHideDockLabel";
			this.DockItemsHideDockLabel.Size = new Size(228, 16);
			this.DockItemsHideDockLabel.TabIndex = 34;
			this.DockItemsHideDockLabel.Text = "Hide Dock";
			this.DockItemsRightClickMenuLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DockItemsRightClickMenuLabel.Location = new Point(9, 13);
			this.DockItemsRightClickMenuLabel.Name = "DockItemsRightClickMenuLabel";
			this.DockItemsRightClickMenuLabel.Size = new Size(228, 16);
			this.DockItemsRightClickMenuLabel.TabIndex = 33;
			this.DockItemsRightClickMenuLabel.Text = "Right-Click Menu";
			this.DockItemsShowExplorerContextMenusCB.FlatStyle = FlatStyle.System;
			this.DockItemsShowExplorerContextMenusCB.Location = new Point(22, 32);
			this.DockItemsShowExplorerContextMenusCB.Name = "DockItemsShowExplorerContextMenusCB";
			this.DockItemsShowExplorerContextMenusCB.Size = new Size(272, 53);
			this.DockItemsShowExplorerContextMenusCB.TabIndex = 32;
			this.DockItemsShowExplorerContextMenusCB.Text = "Show Windows File/Folder Menus";
			this.DockItemsShowExplorerContextMenusCB.TextAlign = ContentAlignment.TopLeft;
			this.DockItemsShowExplorerContextMenusCB.CheckedChanged += new EventHandler(this.DockItemsShowExplorerContextMenusCB_CheckedChanged);
			this.DockItemsNormalSizeValue.Location = new Point(52, 160);
			this.DockItemsNormalSizeValue.Name = "DockItemsNormalSizeValue";
			this.DockItemsNormalSizeValue.Size = new Size(220, 16);
			this.DockItemsNormalSizeValue.TabIndex = 31;
			this.DockItemsNormalSizeValue.Text = "250";
			this.DockItemsNormalSizeValue.TextAlign = ContentAlignment.TopCenter;
			this.DockItemsNormalSizeLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DockItemsNormalSizeLabel.Location = new Point(18, 88);
			this.DockItemsNormalSizeLabel.Name = "DockItemsNormalSizeLabel";
			this.DockItemsNormalSizeLabel.Size = new Size(312, 33);
			this.DockItemsNormalSizeLabel.TabIndex = 30;
			this.DockItemsNormalSizeLabel.Text = "Normal Size";
			this.DockItemsNormalSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.DockItemsNormalSizeTB.Location = new Point(8, 125);
			this.DockItemsNormalSizeTB.Maximum = 300;
			this.DockItemsNormalSizeTB.Minimum = 1;
			this.DockItemsNormalSizeTB.Name = "DockItemsNormalSizeTB";
			this.DockItemsNormalSizeTB.Size = new Size(334, 45);
			this.DockItemsNormalSizeTB.TabIndex = 29;
			this.DockItemsNormalSizeTB.TickFrequency = 10;
			this.DockItemsNormalSizeTB.Value = 1;
			this.DockItemsNormalSizeTB.Scroll += new EventHandler(this.DockItemsNormalSizeTB_Scroll);
			this.DockItemsNormalOpacityValue.Location = new Point(355, 163);
			this.DockItemsNormalOpacityValue.Name = "DockItemsNormalOpacityValue";
			this.DockItemsNormalOpacityValue.Size = new Size(220, 16);
			this.DockItemsNormalOpacityValue.TabIndex = 28;
			this.DockItemsNormalOpacityValue.Text = "250";
			this.DockItemsNormalOpacityValue.TextAlign = ContentAlignment.TopCenter;
			this.DockItemsNormalOpacityLabel.BackColor = Color.Transparent;
			this.DockItemsNormalOpacityLabel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DockItemsNormalOpacityLabel.Location = new Point(358, 88);
			this.DockItemsNormalOpacityLabel.Name = "DockItemsNormalOpacityLabel";
			this.DockItemsNormalOpacityLabel.Size = new Size(218, 34);
			this.DockItemsNormalOpacityLabel.TabIndex = 27;
			this.DockItemsNormalOpacityLabel.Text = "Normal Opacity";
			this.DockItemsNormalOpacityLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.DockItemsNormalOpacityTB.LargeChange = 10;
			this.DockItemsNormalOpacityTB.Location = new Point(355, 125);
			this.DockItemsNormalOpacityTB.Maximum = 255;
			this.DockItemsNormalOpacityTB.Name = "DockItemsNormalOpacityTB";
			this.DockItemsNormalOpacityTB.Size = new Size(220, 45);
			this.DockItemsNormalOpacityTB.TabIndex = 26;
			this.DockItemsNormalOpacityTB.TickFrequency = 10;
			this.DockItemsNormalOpacityTB.Scroll += new EventHandler(this.DockItemsNormalOpacityTB_Scroll);
			this.DockItemsLabel.BackColor = Color.Transparent;
			this.DockItemsLabel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.DockItemsLabel.ForeColor = SystemColors.WindowText;
			this.DockItemsLabel.Location = new Point(28, 4);
			this.DockItemsLabel.Name = "DockItemsLabel";
			this.DockItemsLabel.Size = new Size(552, 16);
			this.DockItemsLabel.TabIndex = 1;
			this.DockItemsLabel.Text = "Dock Items";
			this.DockItemsLabel.Click += new EventHandler(this.DockItemsPicture_Click);
			this.DockItemsPicture.BackColor = SystemColors.Control;
			this.DockItemsPicture.Location = new Point(4, 0);
			this.DockItemsPicture.Name = "DockItemsPicture";
			this.DockItemsPicture.Size = new Size(588, 24);
			this.DockItemsPicture.TabIndex = 0;
			this.DockItemsPicture.TabStop = false;
			this.DockItemsPicture.Click += new EventHandler(this.DockItemsPicture_Click);
			this.SavePictureBox.BackColor = Color.White;
			this.SavePictureBox.Image = (Image)componentResourceManager.GetObject("SavePictureBox.Image");
			this.SavePictureBox.Location = new Point(533, 6);
			this.SavePictureBox.Name = "SavePictureBox";
			this.SavePictureBox.Size = new Size(24, 24);
			this.SavePictureBox.TabIndex = 11;
			this.SavePictureBox.TabStop = false;
			this.SavePictureBox.Visible = false;
			this.ItemSelectedPicture.Image = (Image)componentResourceManager.GetObject("ItemSelectedPicture.Image");
			this.ItemSelectedPicture.Location = new Point(577, 6);
			this.ItemSelectedPicture.Name = "ItemSelectedPicture";
			this.ItemSelectedPicture.Size = new Size(24, 24);
			this.ItemSelectedPicture.TabIndex = 10;
			this.ItemSelectedPicture.TabStop = false;
			this.ItemSelectedPicture.Visible = false;
			this.ItemSelectedPicture.Click += new EventHandler(this.ItemSelectedPicture_Click);
			this.ItemPicture.Image = (Image)componentResourceManager.GetObject("ItemPicture.Image");
			this.ItemPicture.Location = new Point(479, 6);
			this.ItemPicture.Name = "ItemPicture";
			this.ItemPicture.Size = new Size(24, 24);
			this.ItemPicture.TabIndex = 9;
			this.ItemPicture.TabStop = false;
			this.ItemPicture.Visible = false;
			this.pictureBox3.BackColor = Color.White;
			this.pictureBox3.BorderStyle = BorderStyle.FixedSingle;
			this.pictureBox3.Image = (Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new Point(33, 6);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new Size(48, 48);
			this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 4;
			this.pictureBox3.TabStop = false;
			this.ClosePictureBox.BackColor = Color.White;
			this.ClosePictureBox.Image = (Image)componentResourceManager.GetObject("ClosePictureBox.Image");
			this.ClosePictureBox.Location = new Point(606, 6);
			this.ClosePictureBox.Name = "ClosePictureBox";
			this.ClosePictureBox.Size = new Size(24, 24);
			this.ClosePictureBox.TabIndex = 1;
			this.ClosePictureBox.TabStop = false;
			this.ClosePictureBox.Click += new EventHandler(this.ClosePictureBox_Click);
			this.TitlePictureBox.BackColor = Color.White;
			this.TitlePictureBox.Location = new Point(29, 2);
			this.TitlePictureBox.Name = "TitlePictureBox";
			this.TitlePictureBox.Size = new Size(608, 56);
			this.TitlePictureBox.TabIndex = 2;
			this.TitlePictureBox.TabStop = false;
			this.LabelColorDialog.AnyColor = true;
			this.LabelColorDialog.FullOpen = true;
			this.LabelShadowColorDialog.AnyColor = true;
			this.LabelShadowColorDialog.FullOpen = true;
			this.BackgroundImageFileDialog.Filter = "PNG|*.png";
			this.BackgroundImageFileDialog.Title = "Circle Dock";
			this.BackgroundImageFileDialog.FileOk += new CancelEventHandler(this.BackgroundImageFileDialog_FileOk);
			this.DefaultCentreButtonFileDialog.Filter = "PNG|*.png";
			this.DefaultCentreButtonFileDialog.FileOk += new CancelEventHandler(this.DefaultCentreButtonFileDialog_FileOk);
			this.LanguageFileDialog.Filter = "INI|*.ini";
			this.LanguageFileDialog.FileOk += new CancelEventHandler(this.LanguageFileDialog_FileOk);
			this.DockFolderDefaultImageDialog.Filter = "PNG|*.png";
			this.DockFolderDefaultImageDialog.FileOk += new CancelEventHandler(this.DockFolderDefaultImageDialog_FileOk);
			this.AutoScroll = true;
			this.BackColor = Color.White;
			base.ClientSize = new Size(644, 591);
			base.Controls.Add(this.LanguagePanel);
			base.Controls.Add(this.LocationPanel);
			base.Controls.Add(this.TogglingPanel);
			base.Controls.Add(this.DockItemsPanel);
			base.Controls.Add(this.FileIconAssociationsPanel);
			base.Controls.Add(this.AnimationPanel);
			base.Controls.Add(this.HelpPanel);
			base.Controls.Add(this.DockShapePanel);
			base.Controls.Add(this.BackgroundPanel);
			base.Controls.Add(this.CentreButtonPanel);
			base.Controls.Add(this.LabelsPanel);
			base.Controls.Add(this.SavePictureBox);
			base.Controls.Add(this.ItemSelectedPicture);
			base.Controls.Add(this.ItemPicture);
			base.Controls.Add(this.ConfigurationDescriptionLabel);
			base.Controls.Add(this.pictureBox3);
			base.Controls.Add(this.ConfigurationLabel);
			base.Controls.Add(this.ClosePictureBox);
			base.Controls.Add(this.TitlePictureBox);
			base.Controls.Add(this.AboutPanel);
			base.Controls.Add(this.GeneralPanel);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "DockSetup";
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Circle Dock Configuration";
			base.TopMost = true;
			base.Deactivate += new EventHandler(this.DockSetup_Deactivate);
			base.Load += new EventHandler(this.DockSetup_Load);
			this.GeneralPanel.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.generalRotationGroupBox.ResumeLayout(false);
			this.generalRotationGroupBox.PerformLayout();
			((ISupportInitialize)this.currentRotationValueNumericUpDown).EndInit();
			((ISupportInitialize)this.RotationSensitivityTB).EndInit();
			((ISupportInitialize)this.ClickSensitivityTB).EndInit();
			((ISupportInitialize)this.GeneralPicture).EndInit();
			this.DockShapePanel.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((ISupportInitialize)this.SeparationBetweenCirclesTB).EndInit();
			((ISupportInitialize)this.MinimumRadiusTB).EndInit();
			((ISupportInitialize)this.NumIconsPerCircleTB).EndInit();
			((ISupportInitialize)this.DockShapePicture).EndInit();
			this.CentreButtonPanel.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((ISupportInitialize)this.CentreButtonNormalSizeTB).EndInit();
			((ISupportInitialize)this.DefaultCentreImagePictureBox).EndInit();
			((ISupportInitialize)this.CentreButtonNormalOpacityTB).EndInit();
			((ISupportInitialize)this.CentreButtonPicture).EndInit();
			this.LabelsPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((ISupportInitialize)this.LabelNormalOpacityTB).EndInit();
			((ISupportInitialize)this.LabelShadowDarknessTB).EndInit();
			((ISupportInitialize)this.LabelShadowSizeTB).EndInit();
			((ISupportInitialize)this.LabelColor).EndInit();
			((ISupportInitialize)this.LabelShadowColor).EndInit();
			((ISupportInitialize)this.LabelsPicture).EndInit();
			this.AboutPanel.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox1).EndInit();
			((ISupportInitialize)this.AboutPicture).EndInit();
			this.BackgroundPanel.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			((ISupportInitialize)this.BackgroundNormalSizeTB).EndInit();
			((ISupportInitialize)this.BackgroundNormalOpacityTB).EndInit();
			((ISupportInitialize)this.BackgroundImagePictureBox).EndInit();
			((ISupportInitialize)this.BackgroundPicture).EndInit();
			this.HelpPanel.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox4).EndInit();
			((ISupportInitialize)this.HelpPicture).EndInit();
			this.AnimationPanel.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.FadeInFadeOutDurationTB).EndInit();
			((ISupportInitialize)this.RotationAnimationDurationTB).EndInit();
			((ISupportInitialize)this.GeneralFrameRateTB).EndInit();
			((ISupportInitialize)this.AnimationPicture).EndInit();
			this.LocationPanel.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			((ISupportInitialize)this.LocationPicture).EndInit();
			this.TogglingPanel.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((ISupportInitialize)this.dwellTimeTrackBar).EndInit();
			((ISupportInitialize)this.EdgeWidthHeightTB).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.TogglingPicture).EndInit();
			this.FileIconAssociationsPanel.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel12.PerformLayout();
			((ISupportInitialize)this.DockFolderDefaultImage).EndInit();
			((ISupportInitialize)this.dataGridView2).EndInit();
			((ISupportInitialize)this.dataGridView1).EndInit();
			((ISupportInitialize)this.FileNameIconAssocationsTable).EndInit();
			((ISupportInitialize)this.FileIconAssociationsPicture).EndInit();
			this.LanguagePanel.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			((ISupportInitialize)this.LanguagePicture).EndInit();
			this.DockItemsPanel.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			((ISupportInitialize)this.DockItemsNormalSizeTB).EndInit();
			((ISupportInitialize)this.DockItemsNormalOpacityTB).EndInit();
			((ISupportInitialize)this.DockItemsPicture).EndInit();
			((ISupportInitialize)this.SavePictureBox).EndInit();
			((ISupportInitialize)this.ItemSelectedPicture).EndInit();
			((ISupportInitialize)this.ItemPicture).EndInit();
			((ISupportInitialize)this.pictureBox3).EndInit();
			((ISupportInitialize)this.ClosePictureBox).EndInit();
			((ISupportInitialize)this.TitlePictureBox).EndInit();
			base.ResumeLayout(false);
		}

		public DockSetup(MainForm TheParent, LanguageLoader.LanguageLoader LanguageData, SettingsLoader.SettingsLoader SettingsData, DockItemSettingsLoader.DockItemSettingsLoader DockItemSettingsData)
		{
			this.ParentObject = TheParent;
			this.Language = LanguageData;
			this.DockSettings = SettingsData;
			this.DockItemSettings = DockItemSettingsData;
			this.Loaded = false;
			this.FileOperations = new FileOps.FileOps(IntPtr.Zero, this.Language, SettingsData);
			this.InitializeComponent();
			base.Size = new Size(base.Size.Width, (int)((double)SystemInformation.PrimaryMonitorSize.Height * 0.9));
			this.InitializeSettings();
		}

		public void InitializeSettings()
		{
			this.Text = this.Language.SettingsPanel.Name;
			this.ConfigurationLabel.Text = this.Language.SettingsPanel.Name;
			this.ConfigurationDescriptionLabel.Text = this.Language.SettingsPanel.ConfigurationDescriptionLabel;
			this.GeneralLabel.Text = this.Language.SettingsPanel.General;
			this.EnableDockRotationCB.Text = this.Language.SettingsPanel.EnableDockRotation;
			this.EnableDockRotationCB.Checked = this.DockSettings.General.EnableDockRotation;
			this.RotationSensitivityLabel.Text = this.Language.General.RotationSensitivity;
			if (this.DockSettings.General.KeyPressesPerRevolution > this.RotationSensitivityTB.Maximum)
			{
				this.RotationSensitivityTB.Value = this.RotationSensitivityTB.Maximum;
			}
			else if (this.DockSettings.General.KeyPressesPerRevolution < this.RotationSensitivityTB.Minimum)
			{
				this.RotationSensitivityTB.Value = this.RotationSensitivityTB.Minimum;
			}
			else
			{
				this.RotationSensitivityTB.Value = this.DockSettings.General.KeyPressesPerRevolution;
			}
			this.RotationSensitivityValue.Text = this.DockSettings.General.KeyPressesPerRevolution.ToString();
			this.zLevelLabel.Text = this.Language.General.zLevel;
			this.zLevelComboBox.Items.Clear();
			this.zLevelComboBox.Items.Add(this.Language.General.topmost);
			this.zLevelComboBox.Items.Add(this.Language.General.normal);
			this.zLevelComboBox.Items.Add(this.Language.General.alwaysOnBottom);
			if (this.DockSettings.General.zLevel == "Always On Bottom")
			{
				this.zLevelComboBox.SelectedIndex = 2;
			}
			else if (this.DockSettings.General.zLevel == "Normal")
			{
				this.zLevelComboBox.SelectedIndex = 1;
			}
			else
			{
				this.zLevelComboBox.SelectedIndex = 0;
			}
			this.ClickSensitivityLabel.Text = this.Language.SettingsPanel.ClickSensitivity;
			this.SensitiveLabel.Text = this.Language.SettingsPanel.Sensitive;
			this.NotSensitiveLabel.Text = this.Language.SettingsPanel.NotSensitive;
			if (this.DockSettings.General.ClickSensitivity > this.ClickSensitivityTB.Maximum)
			{
				this.ClickSensitivityTB.Value = this.ClickSensitivityTB.Maximum;
			}
			else if (this.DockSettings.General.ClickSensitivity < this.ClickSensitivityTB.Minimum)
			{
				this.ClickSensitivityTB.Value = this.ClickSensitivityTB.Minimum;
			}
			else
			{
				this.ClickSensitivityTB.Value = this.DockSettings.General.ClickSensitivity;
			}
			this.ClickSensitivityValue.Text = this.DockSettings.General.ClickSensitivity.ToString();
			this.PortabilityModeCB.Text = this.Language.SettingsPanel.EnablePortabilityMode;
			this.PortabilityModeCB.Checked = this.DockSettings.General.EnablePortabilityMode;
			this.UseMemorySaveCB.Text = this.Language.SettingsPanel.UseMemorySaver;
			this.UseMemorySaveCB.Checked = this.DockSettings.General.UseMemorySaver;
			this.useSameRotationValuesCB.Text = this.Language.SettingsPanel.useSameRotationValueAllLevels;
			this.useSameRotationValuesCB.Checked = this.DockSettings.General.useSameRotationValues;
			this.currentRotationValueLabel.Text = this.Language.SettingsPanel.currentRotationValue;
			try
			{
				if ((decimal)this.ParentObject.RotationValue > this.currentRotationValueNumericUpDown.Maximum)
				{
					this.currentRotationValueNumericUpDown.Value = this.currentRotationValueNumericUpDown.Maximum;
				}
				else if ((decimal)this.ParentObject.RotationValue < this.currentRotationValueNumericUpDown.Minimum)
				{
					this.currentRotationValueNumericUpDown.Value = this.currentRotationValueNumericUpDown.Minimum;
				}
				else
				{
					this.currentRotationValueNumericUpDown.Value = (decimal)this.ParentObject.RotationValue;
				}
			}
			catch (Exception)
			{
				this.currentRotationValueNumericUpDown.Value = 0m;
			}
			this.DockShapeLabel.Text = this.Language.SettingsPanel.DockShape;
			this.DockShapeComboBox.Items.Clear();
			this.DockShapeComboBox.Items.Add(this.Language.SettingsPanel.CircleWord);
			this.DockShapeComboBox.SelectedItem = this.DockShapeComboBox.Items[0];
			this.NumIconsPerCircleLabel.Text = this.Language.SettingsPanel.NumberOfIconsPerCircle;
			if (this.DockSettings.CircleParams.ConstNumItemsPerCircle > this.NumIconsPerCircleTB.Maximum)
			{
				this.NumIconsPerCircleTB.Value = this.NumIconsPerCircleTB.Maximum;
			}
			else if (this.DockSettings.CircleParams.ConstNumItemsPerCircle < this.NumIconsPerCircleTB.Minimum)
			{
				this.NumIconsPerCircleTB.Value = this.NumIconsPerCircleTB.Minimum;
			}
			else
			{
				this.NumIconsPerCircleTB.Value = this.DockSettings.CircleParams.ConstNumItemsPerCircle;
			}
			this.NumIconsPerCircleValue.Text = this.DockSettings.CircleParams.ConstNumItemsPerCircle.ToString();
			this.MinimumRadiusLabel.Text = this.Language.SettingsPanel.MinimumRadius;
			if (this.DockSettings.CircleParams.MinRadius > this.MinimumRadiusTB.Maximum)
			{
				this.MinimumRadiusTB.Value = this.MinimumRadiusTB.Maximum;
			}
			else if (this.DockSettings.CircleParams.MinRadius < this.MinimumRadiusTB.Minimum)
			{
				this.MinimumRadiusTB.Value = this.MinimumRadiusTB.Minimum;
			}
			else
			{
				this.MinimumRadiusTB.Value = this.DockSettings.CircleParams.MinRadius;
			}
			this.MinimumRadiusValue.Text = this.DockSettings.CircleParams.MinRadius.ToString();
			this.SeparationBetweenCirclesLabel.Text = this.Language.SettingsPanel.SeparationBetweenCircles;
			if (this.DockSettings.CircleParams.CircleSeparation > this.SeparationBetweenCirclesTB.Maximum)
			{
				this.SeparationBetweenCirclesTB.Value = this.SeparationBetweenCirclesTB.Maximum;
			}
			else if (this.DockSettings.CircleParams.CircleSeparation < this.SeparationBetweenCirclesTB.Minimum)
			{
				this.SeparationBetweenCirclesTB.Value = this.SeparationBetweenCirclesTB.Minimum;
			}
			else
			{
				this.SeparationBetweenCirclesTB.Value = this.DockSettings.CircleParams.CircleSeparation;
			}
			this.SeparationBetweenCirclesValue.Text = this.DockSettings.CircleParams.CircleSeparation.ToString();
			this.ShapeFormatLabel.Text = this.Language.SettingsPanel.FormatWord;
			this.ShapeFormatComboBox.Items.Clear();
			this.ShapeFormatComboBox.Items.Add(this.Language.SettingsPanel.ConstantNumberOfItemsPerCircle);
			this.ShapeFormatComboBox.Items.Add(this.Language.SettingsPanel.maximumNumberOfItemsPerCircle);
			if (this.DockSettings.CircleParams.Format == "Constant Number of Items Per Circle")
			{
				this.ShapeFormatComboBox.SelectedIndex = 0;
			}
			else
			{
				this.ShapeFormatComboBox.SelectedIndex = 1;
			}
			this.BackgroundLabel.Text = this.Language.SettingsPanel.Background;
			this.BackgroundImageLabel.Text = this.Language.SettingsPanel.BackgroundImage;
			this.BackgroundNormalSizeLabel.Text = this.Language.SettingsPanel.NormalSize;
			this.BackgroundNormalSizeValue.Text = this.DockSettings.Background.DefaultWidth.ToString();
			if (this.DockSettings.Background.DefaultWidth > this.BackgroundNormalSizeTB.Maximum)
			{
				this.BackgroundNormalSizeTB.Value = this.BackgroundNormalSizeTB.Maximum;
			}
			else if (this.DockSettings.Background.DefaultWidth < this.BackgroundNormalSizeTB.Minimum)
			{
				this.BackgroundNormalSizeTB.Value = this.BackgroundNormalSizeTB.Minimum;
			}
			else
			{
				this.BackgroundNormalSizeTB.Value = this.DockSettings.Background.DefaultWidth;
			}
			this.BackgroundNormalOpacityLabel.Text = this.Language.SettingsPanel.NormalOpacity;
			this.BackgroundNormalOpacityValue.Text = this.DockSettings.Background.DefaultOpacity.ToString();
			this.BackgroundNormalOpacityTB.Value = this.DockSettings.Background.DefaultOpacity;
			if (this.DockSettings.Background.DefaultOpacity > this.BackgroundNormalOpacityTB.Maximum)
			{
				this.BackgroundNormalOpacityTB.Value = this.BackgroundNormalOpacityTB.Maximum;
			}
			else if (this.DockSettings.Background.DefaultOpacity < this.BackgroundNormalOpacityTB.Minimum)
			{
				this.BackgroundNormalOpacityTB.Value = this.BackgroundNormalOpacityTB.Minimum;
			}
			else
			{
				this.BackgroundNormalOpacityTB.Value = this.DockSettings.Background.DefaultOpacity;
			}
			this.BackgroundImagePictureBox.Image = new Bitmap(this.ParentObject.BackgroundObject.ObjectBitmap);
			this.BackgroundImageTextBox.Text = this.DockSettings.Background.Path;
			this.BackgroundImageFileDialog.InitialDirectory = Application.StartupPath + "\\System\\Background";
			this.CentreButtonLabel.Text = this.Language.SettingsPanel.CentreButton;
			this.DefaultCentreButtonLabel.Text = this.Language.SettingsPanel.DefaultCentreButton;
			this.DefaultCentreImagePictureBox.Image = new Bitmap(this.ParentObject.CentreObject.ObjectBitmap);
			this.DefaultCentreButtonImageTextBox.Text = this.DockSettings.CentreImage.Path;
			this.DefaultCentreButtonFileDialog.InitialDirectory = Application.StartupPath + "\\System\\Background";
			this.CentreButtonNormalSizeLabel.Text = this.Language.SettingsPanel.NormalSize;
			this.CentreButtonNormalSizeValue.Text = this.DockSettings.CentreImage.DefaultWidth.ToString();
			if (this.DockSettings.CentreImage.DefaultWidth > this.CentreButtonNormalSizeTB.Maximum)
			{
				this.CentreButtonNormalSizeTB.Value = this.CentreButtonNormalSizeTB.Maximum;
			}
			else if (this.DockSettings.CentreImage.DefaultWidth < this.CentreButtonNormalSizeTB.Minimum)
			{
				this.CentreButtonNormalSizeTB.Value = this.CentreButtonNormalSizeTB.Minimum;
			}
			else
			{
				this.CentreButtonNormalSizeTB.Value = this.DockSettings.CentreImage.DefaultWidth;
			}
			this.CentreButtonNormalOpacityLabel.Text = this.Language.SettingsPanel.NormalOpacity;
			this.CentreButtonNormalOpacityValue.Text = this.DockSettings.CentreImage.DefaultOpacity.ToString();
			this.CentreButtonNormalOpacityTB.Value = this.DockSettings.CentreImage.DefaultOpacity;
			if (this.DockSettings.CentreImage.DefaultOpacity > this.CentreButtonNormalOpacityTB.Maximum)
			{
				this.CentreButtonNormalOpacityTB.Value = this.CentreButtonNormalOpacityTB.Maximum;
			}
			else if (this.DockSettings.CentreImage.DefaultOpacity < this.CentreButtonNormalOpacityTB.Minimum)
			{
				this.CentreButtonNormalOpacityTB.Value = this.CentreButtonNormalOpacityTB.Minimum;
			}
			else
			{
				this.CentreButtonNormalOpacityTB.Value = this.DockSettings.CentreImage.DefaultOpacity;
			}
			this.CentreButtonOtherSettingsLabel.Text = this.Language.SettingsPanel.OtherSettings;
			this.CentreButtonShowStartMenuCB.Text = this.Language.SettingsPanel.ShowStartMenuWhenClicked;
			this.CentreButtonShowStartMenuCB.Checked = this.DockSettings.CentreImage.ShowStartMenuWhenClicked;
			this.StartMenuResidueWarningLabel.Text = this.Language.SettingsPanel.StartMenuResidueWarning;
			this.DockItemsLabel.Text = this.Language.SettingsPanel.DockItems;
			this.DefaultCentreButtonLabel.Text = this.Language.SettingsPanel.DefaultCentreButton;
			this.DockItemsRightClickMenuLabel.Text = this.Language.SettingsPanel.RightClickMenu;
			this.DockItemsShowExplorerContextMenusCB.Text = this.Language.SettingsPanel.ShowWindowsFileFolderMenus;
			this.DockItemsShowExplorerContextMenusCB.Checked = this.DockSettings.DockItems.ShowExplorerContextMenus;
			this.DockItemsHideDockLabel.Text = this.Language.SettingsPanel.HideDock;
			this.DockItemsHideDockAfterExecutionCB.Text = this.Language.SettingsPanel.HideDockAfterFileExecution;
			this.DockItemsHideDockAfterExecutionCB.Checked = this.DockSettings.DockItems.HideDockAfterExecution;
			this.DockItemsNormalSizeLabel.Text = this.Language.SettingsPanel.NormalSize;
			this.DockItemsNormalSizeValue.Text = this.DockSettings.DockItems.DefaultWidth.ToString();
			if (this.DockSettings.DockItems.DefaultWidth > this.DockItemsNormalSizeTB.Maximum)
			{
				this.DockItemsNormalSizeTB.Value = this.DockItemsNormalSizeTB.Maximum;
			}
			else if (this.DockSettings.DockItems.DefaultWidth < this.DockItemsNormalSizeTB.Minimum)
			{
				this.DockItemsNormalSizeTB.Value = this.DockItemsNormalSizeTB.Minimum;
			}
			else
			{
				this.DockItemsNormalSizeTB.Value = this.DockSettings.DockItems.DefaultWidth;
			}
			this.DockItemsNormalOpacityLabel.Text = this.Language.SettingsPanel.NormalOpacity;
			this.DockItemsNormalOpacityValue.Text = this.DockSettings.DockItems.DefaultOpacity.ToString();
			this.DockItemsNormalOpacityTB.Value = this.DockSettings.DockItems.DefaultOpacity;
			if (this.DockSettings.DockItems.DefaultOpacity > this.DockItemsNormalOpacityTB.Maximum)
			{
				this.DockItemsNormalOpacityTB.Value = this.DockItemsNormalOpacityTB.Maximum;
			}
			else if (this.DockSettings.DockItems.DefaultOpacity < this.DockItemsNormalOpacityTB.Minimum)
			{
				this.DockItemsNormalOpacityTB.Value = this.DockItemsNormalOpacityTB.Minimum;
			}
			else
			{
				this.DockItemsNormalOpacityTB.Value = this.DockSettings.DockItems.DefaultOpacity;
			}
			this.LabelsLabel.Text = this.Language.SettingsPanel.Labels;
			this.LabelsFontLabel.Text = this.Language.SettingsPanel.FontWord;
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
			this.LabelsFontName.Text = converter.ConvertToString(this.DockSettings.Labels.FontName);
			this.LabelFontChangeLink.Text = this.Language.SettingsPanel.ChangeFont;
			this.LabelColor.BackColor = this.DockSettings.Labels.FontColor;
			this.LabelColorChangeLink.Text = this.Language.SettingsPanel.ChangeColor;
			this.LabelNormalOpacityLabel.Text = this.Language.SettingsPanel.NormalOpacity;
			this.LabelNormalOpacityValue.Text = this.DockSettings.Labels.DefaultOpacity.ToString();
			this.LabelNormalOpacityTB.Value = this.DockSettings.DockItems.DefaultOpacity;
			if (this.DockSettings.Labels.DefaultOpacity > this.LabelNormalOpacityTB.Maximum)
			{
				this.LabelNormalOpacityTB.Value = this.LabelNormalOpacityTB.Maximum;
			}
			else if (this.DockSettings.Labels.DefaultOpacity < this.LabelNormalOpacityTB.Minimum)
			{
				this.LabelNormalOpacityTB.Value = this.LabelNormalOpacityTB.Minimum;
			}
			else
			{
				this.LabelNormalOpacityTB.Value = this.DockSettings.Labels.DefaultOpacity;
			}
			this.LabelShadowLabel.Text = this.Language.SettingsPanel.ShadowWord;
			this.LabelShadowColor.BackColor = this.DockSettings.Labels.ShadowColor;
			this.LabelShadowColorChange.Text = this.Language.SettingsPanel.ChangeColor;
			this.LabelShadowSizeLabel.Text = this.Language.SettingsPanel.ShadowSize;
			this.LabelShadowSizeValue.Text = this.DockSettings.Labels.ShadowSize.ToString();
			this.LabelShadowSizeTB.Value = this.DockSettings.Labels.ShadowSize;
			if (this.DockSettings.Labels.ShadowSize > this.LabelShadowSizeTB.Maximum)
			{
				this.LabelShadowSizeTB.Value = this.LabelShadowSizeTB.Maximum;
			}
			else if (this.DockSettings.Labels.ShadowSize < this.LabelShadowSizeTB.Minimum)
			{
				this.LabelShadowSizeTB.Value = this.LabelShadowSizeTB.Minimum;
			}
			else
			{
				this.LabelShadowSizeTB.Value = this.DockSettings.Labels.ShadowSize;
			}
			this.LabelShadowDarknessLabel.Text = this.Language.SettingsPanel.ShadowDarknessFactor;
			this.LabelShadowDarknessTB.Value = this.DockSettings.Labels.ShadowDarkness;
			this.LabelShadowDarknessValue.Text = this.DockSettings.Labels.ShadowDarkness.ToString();
			if (this.DockSettings.Labels.ShadowDarkness > this.LabelShadowDarknessTB.Maximum)
			{
				this.LabelShadowDarknessTB.Value = this.LabelShadowDarknessTB.Maximum;
			}
			else if (this.DockSettings.Labels.ShadowDarkness < this.LabelShadowDarknessTB.Minimum)
			{
				this.LabelShadowDarknessTB.Value = this.LabelShadowDarknessTB.Minimum;
			}
			else
			{
				this.LabelShadowDarknessTB.Value = this.DockSettings.Labels.ShadowDarkness;
			}
			this.ShowLabelsLabel.Text = this.Language.SettingsPanel.ShowLabels;
			this.ShowLabelsCB.Text = this.Language.SettingsPanel.ShowLabels;
			this.ShowLabelsCB.Checked = this.DockSettings.Labels.ShowLabels;
			this.ShowLabelsMouseOverCB.Text = this.Language.SettingsPanel.ShowLabelsOnMouseoverOnly;
			this.ShowLabelsMouseOverCB.Checked = this.DockSettings.Labels.ShowLabelsOnMouseOverOnly;
			this.AnimationLabel.Text = this.Language.SettingsPanel.AnimationWord;
			this.GeneralFrameRateLabel.Text = this.Language.SettingsPanel.GeneralFrameRate;
			int num = 1000 / this.DockSettings.General.AnimationInterval;
			this.GeneralFrameRateValue.Text = num.ToString();
			if (num > this.GeneralFrameRateTB.Maximum)
			{
				this.GeneralFrameRateTB.Value = this.GeneralFrameRateTB.Maximum;
			}
			else if (num < this.GeneralFrameRateTB.Minimum)
			{
				this.GeneralFrameRateTB.Value = this.GeneralFrameRateTB.Minimum;
			}
			else
			{
				this.GeneralFrameRateTB.Value = num;
			}
			this.FadeInFadeOutDurationLabel.Text = this.Language.SettingsPanel.FadeInFadeOutDuration;
			this.FadeInFadeOutDurationValue.Text = this.DockSettings.GeneralAnimation.FadeInFadeOutDuration.ToString();
			if (this.DockSettings.GeneralAnimation.FadeInFadeOutDuration > this.FadeInFadeOutDurationTB.Maximum)
			{
				this.FadeInFadeOutDurationTB.Value = this.FadeInFadeOutDurationTB.Maximum;
			}
			else if (this.DockSettings.GeneralAnimation.FadeInFadeOutDuration < this.FadeInFadeOutDurationTB.Minimum)
			{
				this.FadeInFadeOutDurationTB.Value = this.FadeInFadeOutDurationTB.Minimum;
			}
			else
			{
				this.FadeInFadeOutDurationTB.Value = this.DockSettings.GeneralAnimation.FadeInFadeOutDuration;
			}
			this.RotationAnimationDurationLabel.Text = this.Language.SettingsPanel.RotationAnimationDuration;
			this.RotationAnimationDurationValue.Text = this.DockSettings.GeneralAnimation.RotationAnimationDuration.ToString();
			if (this.DockSettings.GeneralAnimation.RotationAnimationDuration > this.RotationAnimationDurationTB.Maximum)
			{
				this.RotationAnimationDurationTB.Value = this.RotationAnimationDurationTB.Maximum;
			}
			else if (this.DockSettings.GeneralAnimation.RotationAnimationDuration < this.RotationAnimationDurationTB.Minimum)
			{
				this.RotationAnimationDurationTB.Value = this.RotationAnimationDurationTB.Minimum;
			}
			else
			{
				this.RotationAnimationDurationTB.Value = this.DockSettings.GeneralAnimation.RotationAnimationDuration;
			}
			this.UsePoofAnimationWhenDeletingCB.Text = this.Language.SettingsPanel.UsePoofAnimationWhenDeleting;
			this.UsePoofAnimationWhenDeletingCB.Checked = this.DockSettings.PoofAnimation.UsePoof;
			this.AboutLabel.Text = this.Language.SettingsPanel.AboutWord;
			this.AboutProjectName.Text = this.Language.General.CircleDockName;
			this.AboutProjectDescriptionLabel.Text = this.Language.SettingsPanel.ThePremiereCircularDockForWindows;
			this.AuthorLabel.Text = this.Language.General.AuthorWord;
			this.AboutWebsiteLabel.Text = this.Language.SettingsPanel.WebsiteWord;
			this.AboutHomepageLink.Text = this.Language.SettingsPanel.OfficialHomepage;
			this.AboutWebForum.Text = this.Language.SettingsPanel.OfficalWebForum;
			this.VersionInformationLabel.Text = this.Language.SettingsPanel.VersionInformation;
			this.VersionNameLabel.Text = Application.ProductName + ":";
			this.VersionInfo.Text = this.ParentObject.CircleDockVersion;
			this.HelpLabel.Text = this.Language.SettingsPanel.HelpWord;
			this.HelpSupportLabel.Text = this.Language.SettingsPanel.SupportWord;
			this.HelpWebForum.Text = this.Language.SettingsPanel.OfficalWebForum;
			this.HelpWebHelpFAQ.Text = this.Language.SettingsPanel.OfficialWebHelpFAQ;
			this.LocationLabel.Text = this.Language.SettingsPanel.LocationWord;
			this.CentreAroundCursorWhenShownCB.Text = this.Language.SettingsPanel.CentreAroundCursorWhenShown;
			this.CentreAroundCursorWhenShownCB.Checked = this.DockSettings.General.CentreAroundCursor;
			this.lockDockPositionCheckBox.Text = this.Language.SettingsPanel.lockDockAtCurrentPosition;
			this.lockDockPositionCheckBox.Checked = this.DockSettings.General.lockDockPosition;
			this.CentreAroundCursorWhenShownCB.Enabled = !this.lockDockPositionCheckBox.Checked;
			this.LanguageLabel.Text = this.Language.SettingsPanel.LanguageWord;
			this.LanguageFileLocationLabel.Text = this.Language.SettingsPanel.LanguageFileLocation;
			this.LanguageFileLocationTextBox.Text = this.DockSettings.Language.path;
			this.LanguageNameTitleLabel.Text = this.Language.SettingsPanel.LanguageName;
			this.LanguageName.Text = this.Language.LanguageFile.LanguageName;
			this.LanguageFileAuthorTitleLabel.Text = this.Language.SettingsPanel.LanguageFileAuthor;
			this.LanguageFileAuthor.Text = this.Language.LanguageFile.FileAuthor;
			this.LanguageFileVersionTitleLabel.Text = this.Language.SettingsPanel.LanguageFileVersion;
			this.LanguageFileVersion.Text = this.Language.LanguageFile.LanguageFileVersion;
			this.LanguageFileIntendedForTitle.Text = this.Language.SettingsPanel.LanguageFileOriginallyIntendedFor;
			this.LanguageIntendedVersion.Text = this.Language.LanguageFile.CircleDockVersion;
			if (this.ParentObject.LanguageFileIsValid())
			{
				this.LanguageFileValidity.Text = this.Language.SettingsPanel.LanguageFileValidCurrent;
			}
			else
			{
				this.LanguageFileValidity.Text = this.Language.SettingsPanel.LanguageFileInvalidOutofDate;
			}
			this.LanguageProgramRestartRequired.Text = this.Language.SettingsPanel.LanguageFileProgramRestartRequired;
			this.FileIconAssociationsLabel.Text = this.Language.SettingsPanel.FileDockIconAssociations;
			this.FileIconAssociationsDescription.Text = this.Language.SettingsPanel.FileIconAssocationsDescription;
			this.FileNameIconAssociationsLabel.Text = this.Language.SettingsPanel.FileNameIconAssociations;
			this.FileName.HeaderText = this.Language.SettingsPanel.fileName;
			this.AssociatedDockIcon.HeaderText = this.Language.SettingsPanel.associatedDockIcon;
			this.BrowseIconForFileName.HeaderText = this.Language.SettingsPanel.browse;
			this.StartsWith.HeaderText = this.Language.SettingsPanel.startsWith;
			this.EndsWith.HeaderText = this.Language.SettingsPanel.endsWith;
			this.ExactMatch.HeaderText = this.Language.SettingsPanel.exactMatch;
			this.SampleIcon.HeaderText = this.Language.SettingsPanel.sample;
			this.FolderNameIconAssociationsLabel.Text = this.Language.SettingsPanel.FolderNameIconAssociations;
			this.FileExtensionIconAssociationsLabel.Text = this.Language.SettingsPanel.FileExtensionIconAssociations;
			this.DockFolderIconAssociationsLabel.Text = this.Language.SettingsPanel.DockFolderIconAssociation;
			this.DockFolderDefaultImagePath.Text = this.DockSettings.Folders.DockFolderImagePath;
			try
			{
				string dockFolderImagePath = this.DockSettings.Folders.DockFolderImagePath;
				Bitmap image;
				if (dockFolderImagePath.StartsWith(".\\"))
				{
					image = new Bitmap(Application.StartupPath + dockFolderImagePath.Substring(1, dockFolderImagePath.Length - 1));
				}
				else
				{
					image = new Bitmap(dockFolderImagePath);
				}
				this.DockFolderDefaultImage.Image = image;
			}
			catch (Exception)
			{
				this.DockFolderDefaultImage.Image = ImageResources.MissingIcon;
			}
			this.TogglingLabel.Text = this.Language.SettingsPanel.TogglingWord;
			this.ToggleVisibilityHotkeyLabel.Text = this.Language.SettingsPanel.ToggleVisibilityHotKey;
			this.ToggleVisibilityCtrlCB.Text = this.Language.SettingsPanel.CtrlWordAbbreviation;
			this.ToggleVisibilityCtrlCB.Checked = this.DockSettings.Toggling.VisibilityCtrl;
			this.ToggleVisibilityAltCB.Text = this.Language.SettingsPanel.AltWordAbbreviation;
			this.ToggleVisibilityAltCB.Checked = this.DockSettings.Toggling.VisibilityAlt;
			this.ToggleVisibilityShiftCB.Text = this.Language.SettingsPanel.ShiftWordAbbreviation;
			this.ToggleVisibilityShiftCB.Checked = this.DockSettings.Toggling.VisibilityShift;
			this.ToggleVisibilityWinCB.Text = this.Language.SettingsPanel.WindowsKeyWordAbbreviation;
			this.ToggleVisibilityWinCB.Checked = this.DockSettings.Toggling.VisibilityWin;
			this.ToggleVisiblityKey1.Items.Clear();
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.None);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Space);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Left);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Right);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Down);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Up);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Divide);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Multiply);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Subtract);
			this.ToggleVisiblityKey1.Items.Add(" " + Keys.Add);
			for (int i = 65; i < 91; i++)
			{
				this.ToggleVisiblityKey1.Items.Add(" " + (Keys)i);
			}
			for (int i = 48; i < 58; i++)
			{
				this.ToggleVisiblityKey1.Items.Add(" " + (Keys)i);
			}
			for (int i = 96; i <= 105; i++)
			{
				this.ToggleVisiblityKey1.Items.Add(" " + (Keys)i);
			}
			for (int i = 112; i <= 135; i++)
			{
				this.ToggleVisiblityKey1.Items.Add(" " + (Keys)i);
			}
			Keys visibilityKey = (Keys)this.DockSettings.Toggling.VisibilityKey1;
			string b = visibilityKey.ToString();
			for (int i = 0; i < this.ToggleVisiblityKey1.Items.Count; i++)
			{
				if (this.ToggleVisiblityKey1.Items[i].ToString().Trim() == b)
				{
					this.ToggleVisiblityKey1.SelectedIndex = i;
					break;
				}
			}
			if (this.ParentObject.ToggleDockHotKeyStatus)
			{
				this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.ValidHotkeyCombination;
			}
			else
			{
				this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.InvalidHotKeyCombination;
			}
			this.ToggleVisibilityMouseButtonLabel.Text = this.Language.SettingsPanel.ToggleVisibilityMouseButton;
			this.ToggleVisiblityMouseButton.Items.Clear();
			this.ToggleVisiblityMouseButton.Items.Add(" " + Keys.None);
			this.ToggleVisiblityMouseButton.Items.Add(" " + Keys.MButton);
			this.ToggleVisiblityMouseButton.Items.Add(" " + Keys.XButton1);
			this.ToggleVisiblityMouseButton.Items.Add(" " + Keys.XButton2);
			KeysConverter keysConverter = new KeysConverter();
			switch ((Keys)keysConverter.ConvertFromString(this.DockSettings.Toggling.VisibilityMouseButton))
			{
			case Keys.None:
				this.ToggleVisiblityMouseButton.SelectedIndex = 0;
				goto IL_2362;
			case Keys.MButton:
				this.ToggleVisiblityMouseButton.SelectedIndex = 1;
				goto IL_2362;
			case Keys.XButton1:
				this.ToggleVisiblityMouseButton.SelectedIndex = 2;
				goto IL_2362;
			case Keys.XButton2:
				this.ToggleVisiblityMouseButton.SelectedIndex = 3;
				goto IL_2362;
			}
			this.ToggleVisiblityMouseButton.SelectedIndex = 0;
			IL_2362:
			this.ShowDockWhenMouseMoveTo.Text = this.Language.SettingsPanel.ShowDockWhenIMoveMyMouseTo;
			this.ScreenLeftEdge.Text = this.Language.SettingsPanel.ScreenLeftEdge;
			this.ScreenLeftEdge.Checked = this.DockSettings.Toggling.ScreenLeftEdgeShow;
			this.ScreenRightEdge.Text = this.Language.SettingsPanel.ScreenRightEdge;
			this.ScreenRightEdge.Checked = this.DockSettings.Toggling.ScreenRightEdgeShow;
			this.ScreenTopEdge.Text = this.Language.SettingsPanel.ScreenTopEdge;
			this.ScreenTopEdge.Checked = this.DockSettings.Toggling.ScreenTopEdgeShow;
			this.ScreenBottomEdge.Text = this.Language.SettingsPanel.ScreenBottomEdge;
			this.ScreenBottomEdge.Checked = this.DockSettings.Toggling.ScreenBottomEdgeShow;
			this.EdgeWidthHeightLabel.Text = this.Language.SettingsPanel.EdgeWidthHeight;
			this.EdgeWidthHeightValue.Text = this.DockSettings.Toggling.EdgeWidthHeight.ToString();
			if (this.DockSettings.Toggling.EdgeWidthHeight > this.EdgeWidthHeightTB.Maximum)
			{
				this.EdgeWidthHeightTB.Value = this.EdgeWidthHeightTB.Maximum;
			}
			else if (this.DockSettings.Toggling.EdgeWidthHeight < this.EdgeWidthHeightTB.Minimum)
			{
				this.EdgeWidthHeightTB.Value = this.EdgeWidthHeightTB.Minimum;
			}
			else
			{
				this.EdgeWidthHeightTB.Value = this.DockSettings.Toggling.EdgeWidthHeight;
			}
			this.dwellTimeLabel.Text = this.Language.SettingsPanel.dwellTime;
			this.dwellTimeTrackBar.Value = this.DockSettings.Toggling.dwellTime;
			this.dwellTimeValue.Text = this.DockSettings.Toggling.dwellTime.ToString();
			this.Loaded = true;
		}

		private void DockSetup_Load(object sender, EventArgs e)
		{
			this.GeneralPicture.Image = this.ItemPicture.Image;
			this.DockShapePicture.Image = this.ItemPicture.Image;
			this.BackgroundPicture.Image = this.ItemPicture.Image;
			this.CentreButtonPicture.Image = this.ItemPicture.Image;
			this.DockItemsPicture.Image = this.ItemPicture.Image;
			this.LabelsPicture.Image = this.ItemPicture.Image;
			this.AnimationPicture.Image = this.ItemPicture.Image;
			this.LocationPicture.Image = this.ItemPicture.Image;
			this.TogglingPicture.Image = this.ItemPicture.Image;
			this.FileIconAssociationsPicture.Image = this.ItemPicture.Image;
			this.LanguagePicture.Image = this.ItemPicture.Image;
			this.AboutPicture.Image = this.ItemPicture.Image;
			this.HelpPicture.Image = this.ItemPicture.Image;
			this.ShowPanel(this.AboutPanel);
			this.ShowPanel(this.AboutPanel);
			this.AboutPicture.Image = this.ItemSelectedPicture.Image;
		}

		private void ClosePictureBox_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void GeneralPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.GeneralPanel);
			if (this.GeneralPanel.Height != 24)
			{
				this.GeneralPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void DockShapePicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.DockShapePanel);
			if (this.DockShapePanel.Height != 24)
			{
				this.DockShapePicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void BackgroundPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.BackgroundPanel);
			if (this.BackgroundPanel.Height != 24)
			{
				this.BackgroundPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void CentreButtonPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.CentreButtonPanel);
			if (this.CentreButtonPanel.Height != 24)
			{
				this.CentreButtonPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void DockItemsPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.DockItemsPanel);
			if (this.DockItemsPanel.Height != 24)
			{
				this.DockItemsPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void LabelsPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.LabelsPanel);
			if (this.LabelsPanel.Height != 24)
			{
				this.LabelsPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void AnimationPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.AnimationPanel);
			if (this.AnimationPanel.Height != 24)
			{
				this.AnimationPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void LocationPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.LocationPanel);
			if (this.LocationPanel.Height != 24)
			{
				this.LocationPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void TogglingPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.TogglingPanel);
			if (this.TogglingPanel.Height != 24)
			{
				this.TogglingPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void FileIconAssociationsPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.FileIconAssociationsPanel);
			if (this.FileIconAssociationsPanel.Height != 24)
			{
				this.FileIconAssociationsPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void LanguagePicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.LanguagePanel);
			if (this.LanguagePanel.Height != 24)
			{
				this.LanguagePicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void AboutPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.AboutPanel);
			if (this.AboutPanel.Height != 24)
			{
				this.AboutPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void HelpPicture_Click(object sender, EventArgs e)
		{
			this.ShowPanel(this.HelpPanel);
			if (this.HelpPanel.Height != 24)
			{
				this.HelpPicture.Image = this.ItemSelectedPicture.Image;
			}
		}

		private void ItemSelectedPicture_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void ShowPanel(object PanelToShow)
		{
			int height = ((Panel)PanelToShow).Height;
			this.GeneralPicture.Image = this.ItemPicture.Image;
			this.DockShapePicture.Image = this.ItemPicture.Image;
			this.BackgroundPicture.Image = this.ItemPicture.Image;
			this.CentreButtonPicture.Image = this.ItemPicture.Image;
			this.DockItemsPicture.Image = this.ItemPicture.Image;
			this.LabelsPicture.Image = this.ItemPicture.Image;
			this.AnimationPicture.Image = this.ItemPicture.Image;
			this.LocationPicture.Image = this.ItemPicture.Image;
			this.TogglingPicture.Image = this.ItemPicture.Image;
			this.FileIconAssociationsPicture.Image = this.ItemPicture.Image;
			this.LanguagePicture.Image = this.ItemPicture.Image;
			this.AboutPicture.Image = this.ItemPicture.Image;
			this.HelpPicture.Image = this.ItemPicture.Image;
			this.GeneralPanel.Height = 24;
			this.DockShapePanel.Height = 24;
			this.BackgroundPanel.Height = 24;
			this.CentreButtonPanel.Height = 24;
			this.DockItemsPanel.Height = 24;
			this.LabelsPanel.Height = 24;
			this.AnimationPanel.Height = 24;
			this.LocationPanel.Height = 24;
			this.TogglingPanel.Height = 24;
			this.FileIconAssociationsPanel.Height = 24;
			this.LanguagePanel.Height = 24;
			this.AboutPanel.Height = 24;
			this.HelpPanel.Height = 24;
			this.GeneralPanel.Location = new Point(this.GeneralPanel.Location.X, this.TitlePictureBox.Location.Y + 60);
			this.DockShapePanel.Top = this.GeneralPanel.Top + 28;
			this.BackgroundPanel.Top = this.DockShapePanel.Top + 28;
			this.CentreButtonPanel.Top = this.BackgroundPanel.Top + 28;
			this.DockItemsPanel.Top = this.CentreButtonPanel.Top + 28;
			this.LabelsPanel.Top = this.DockItemsPanel.Top + 28;
			this.AnimationPanel.Top = this.LabelsPanel.Top + 28;
			this.LocationPanel.Top = this.AnimationPanel.Top + 28;
			this.TogglingPanel.Top = this.LocationPanel.Top + 28;
			this.FileIconAssociationsPanel.Top = this.TogglingPanel.Top + 28;
			this.LanguagePanel.Top = this.FileIconAssociationsPanel.Top + 28;
			this.AboutPanel.Top = this.LanguagePanel.Top + 28;
			this.HelpPanel.Top = this.AboutPanel.Top + 28;
			if (height == 24)
			{
				((Panel)PanelToShow).Height = Convert.ToInt32(((Panel)PanelToShow).Tag);
				string text = ((Panel)PanelToShow).Name.ToLower();
				switch (text)
				{
				case "generalpanel":
					this.DockShapePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.BackgroundPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.CentreButtonPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.DockItemsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LabelsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AnimationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LocationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "dockshapepanel":
					this.BackgroundPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.CentreButtonPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.DockItemsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LabelsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AnimationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LocationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "backgroundpanel":
					this.CentreButtonPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.DockItemsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LabelsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AnimationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LocationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "centrebuttonpanel":
					this.DockItemsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LabelsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AnimationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LocationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "dockitemspanel":
					this.LabelsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AnimationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LocationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "labelspanel":
					this.AnimationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LocationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "animationpanel":
					this.LocationPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "locationpanel":
					this.TogglingPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "togglingpanel":
					this.FileIconAssociationsPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "fileiconassociationspanel":
					this.LanguagePanel.Top += ((Panel)PanelToShow).Height - 24;
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "languagepanel":
					this.AboutPanel.Top += ((Panel)PanelToShow).Height - 24;
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				case "aboutpanel":
					this.HelpPanel.Top += ((Panel)PanelToShow).Height - 24;
					break;
				}
			}
		}

		private void EnableDockRotationCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.General.EnableDockRotation = this.EnableDockRotationCB.Checked;
				this.DockSettings.SetEntry("General", "EnableDockRotation", this.EnableDockRotationCB.Checked.ToString());
			}
		}

		private void RotationSensitivityTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.RotationSensitivityValue.Text = this.RotationSensitivityTB.Value.ToString();
				this.DockSettings.General.KeyPressesPerRevolution = this.RotationSensitivityTB.Value;
				this.DockSettings.SetEntry("General", "KeyPressesPerRevolution", this.RotationSensitivityTB.Value.ToString());
			}
		}

		private void PortabilityModeCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.General.EnablePortabilityMode = this.PortabilityModeCB.Checked;
				this.DockSettings.SetEntry("General", "EnablePortabilityMode", this.PortabilityModeCB.Checked.ToString());
				this.ParentObject.RefreshPortabilityMode();
			}
		}

		private void ClickSensitivityTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.ClickSensitivityValue.Text = this.ClickSensitivityTB.Value.ToString();
				this.DockSettings.General.ClickSensitivity = this.ClickSensitivityTB.Value;
				this.DockSettings.SetEntry("General", "ClickSensitivity", this.ClickSensitivityTB.Value.ToString());
			}
		}

		private void UseMemorySaveCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.General.UseMemorySaver = this.UseMemorySaveCB.Checked;
				this.DockSettings.SetEntry("General", "UseMemorySaver", this.UseMemorySaveCB.Checked.ToString());
				this.ParentObject.ToggleMemorySaver(this.DockSettings.General.UseMemorySaver);
			}
		}

		private void BackgroundNormalSizeTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.BackgroundNormalSizeValue.Text = this.BackgroundNormalSizeTB.Value.ToString();
				this.DockSettings.Background.DefaultWidth = this.BackgroundNormalSizeTB.Value;
				this.DockSettings.Background.DefaultHeight = this.BackgroundNormalSizeTB.Value;
				this.DockSettings.SetEntry("Background", "DefaultWidth", this.BackgroundNormalSizeTB.Value.ToString());
				this.DockSettings.SetEntry("Background", "DefaultHeight", this.BackgroundNormalSizeTB.Value.ToString());
				this.ParentObject.ResizeBackground(this.DockSettings.Background.DefaultWidth, this.DockSettings.Background.DefaultHeight);
			}
		}

		private void BackgroundNormalOpacityTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.BackgroundNormalOpacityValue.Text = this.BackgroundNormalOpacityTB.Value.ToString();
				this.DockSettings.Background.DefaultOpacity = this.BackgroundNormalOpacityTB.Value;
				this.DockSettings.SetEntry("Background", "DefaultOpacity", this.BackgroundNormalOpacityTB.Value.ToString());
				Size objectSize = this.ParentObject.BackgroundObject.ObjectSize;
				this.ParentObject.BackgroundObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, this.DockSettings.Background.DefaultOpacity);
			}
		}

		private void BackgroundImageBrowseButton_Click(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.BackgroundImageFileDialog.InitialDirectory = Application.StartupPath + "\\System\\Background";
				this.BackgroundImageFileDialog.ShowDialog();
			}
		}

		private void BackgroundImageFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			string text;
			if (this.BackgroundImageFileDialog.FileName.StartsWith(Application.StartupPath + "\\"))
			{
				text = "." + this.BackgroundImageFileDialog.FileName.Substring(Application.StartupPath.Length, this.BackgroundImageFileDialog.FileName.Length - Application.StartupPath.Length);
			}
			else
			{
				text = this.BackgroundImageFileDialog.FileName;
			}
			this.BackgroundImageTextBox.Text = text;
			this.DockSettings.SetEntry("Background", "Path", text);
			this.DockSettings.Background.Path = text;
			this.ParentObject.BackgroundObject.SetBitmap();
			Size objectSize = this.ParentObject.BackgroundObject.ObjectSize;
			this.ParentObject.BackgroundObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
			try
			{
				this.BackgroundImagePictureBox.Image = this.ParentObject.BackgroundObject.ObjectBitmap;
			}
			catch (Exception)
			{
				this.BackgroundImagePictureBox.Image = ImageResources.MissingIcon;
			}
		}

		private void NumIconsPerCircleTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.NumIconsPerCircleValue.Text = this.NumIconsPerCircleTB.Value.ToString();
				this.DockSettings.CircleParams.ConstNumItemsPerCircle = this.NumIconsPerCircleTB.Value;
				this.DockSettings.SetEntry("CircleParams", "ConstNumItemsPerCircle", this.NumIconsPerCircleTB.Value.ToString());
				this.ParentObject.PositionCurrentLevel();
			}
		}

		private void MinimumRadiusTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.MinimumRadiusValue.Text = this.MinimumRadiusTB.Value.ToString();
				this.DockSettings.CircleParams.MinRadius = this.MinimumRadiusTB.Value;
				this.DockSettings.SetEntry("CircleParams", "MinRadius", this.MinimumRadiusTB.Value.ToString());
				this.ParentObject.PositionCurrentLevel();
			}
		}

		private void SeparationBetweenCirclesTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.SeparationBetweenCirclesValue.Text = this.SeparationBetweenCirclesTB.Value.ToString();
				this.DockSettings.CircleParams.CircleSeparation = this.SeparationBetweenCirclesTB.Value;
				this.DockSettings.SetEntry("CircleParams", "CircleSeparation", this.SeparationBetweenCirclesTB.Value.ToString());
				this.ParentObject.PositionCurrentLevel();
			}
		}

		private void DockShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.Select(true, true);
			}
		}

		private void ShapeFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (this.ShapeFormatComboBox.SelectedIndex == 0)
				{
					this.DockSettings.CircleParams.Format = "Constant Number of Items Per Circle";
				}
				else
				{
					this.DockSettings.CircleParams.Format = "Maximum Number of Items Per Circle";
				}
				this.DockSettings.SetEntry("CircleParams", "Format", this.DockSettings.CircleParams.Format);
				this.ParentObject.PositionCurrentLevel();
				this.Select(true, true);
			}
		}

		private void DefaultCentreButtonImageBrowse_Click(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DefaultCentreButtonFileDialog.InitialDirectory = Application.StartupPath + "\\System\\Icons";
				this.DefaultCentreButtonFileDialog.ShowDialog();
			}
		}

		private void CentreButtonNormalOpacityTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.CentreButtonNormalOpacityValue.Text = this.CentreButtonNormalOpacityTB.Value.ToString();
				this.DockSettings.CentreImage.DefaultOpacity = this.CentreButtonNormalOpacityTB.Value;
				this.DockSettings.SetEntry("CentreImage", "DefaultOpacity", this.CentreButtonNormalOpacityTB.Value.ToString());
				Size objectSize = this.ParentObject.CentreObject.ObjectSize;
				this.ParentObject.CentreObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, this.DockSettings.CentreImage.DefaultOpacity);
			}
		}

		private void CentreButtonNormalSizeTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.CentreButtonNormalSizeValue.Text = this.CentreButtonNormalSizeTB.Value.ToString();
				this.DockSettings.CentreImage.DefaultWidth = this.CentreButtonNormalSizeTB.Value;
				this.DockSettings.CentreImage.DefaultHeight = this.CentreButtonNormalSizeTB.Value;
				this.DockSettings.SetEntry("CentreImage", "DefaultWidth", this.CentreButtonNormalSizeTB.Value.ToString());
				this.DockSettings.SetEntry("CentreImage", "DefaultHeight", this.CentreButtonNormalSizeTB.Value.ToString());
				this.ParentObject.ResizeCentreObject(this.DockSettings.CentreImage.DefaultWidth, this.DockSettings.CentreImage.DefaultHeight);
			}
		}

		private void DefaultCentreButtonFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			string text;
			if (this.DefaultCentreButtonFileDialog.FileName.StartsWith(Application.StartupPath + "\\"))
			{
				text = "." + this.DefaultCentreButtonFileDialog.FileName.Substring(Application.StartupPath.Length, this.DefaultCentreButtonFileDialog.FileName.Length - Application.StartupPath.Length);
			}
			else
			{
				text = this.DefaultCentreButtonFileDialog.FileName;
			}
			this.DefaultCentreButtonImageTextBox.Text = text;
			this.DockSettings.SetEntry("CentreImage", "Path", text);
			this.DockSettings.CentreImage.Path = text;
			this.ParentObject.CentreObject.SetBitmap();
			Size objectSize = this.ParentObject.CentreObject.ObjectSize;
			this.ParentObject.CentreObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
			try
			{
				this.DefaultCentreImagePictureBox.Image = this.ParentObject.CentreObject.ObjectBitmap;
			}
			catch (Exception)
			{
				this.DefaultCentreImagePictureBox.Image = ImageResources.MissingIcon;
			}
		}

		private void CentreButtonShowStartMenuCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.CentreImage.ShowStartMenuWhenClicked = this.CentreButtonShowStartMenuCB.Checked;
				this.DockSettings.SetEntry("CentreImage", "ShowStartMenuWhenClicked", this.CentreButtonShowStartMenuCB.Checked.ToString());
			}
		}

		private void DockItemsShowExplorerContextMenusCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.DockItems.ShowExplorerContextMenus = this.DockItemsShowExplorerContextMenusCB.Checked;
				this.DockSettings.SetEntry("DockItems", "ShowExplorerContextMenus", this.DockItemsShowExplorerContextMenusCB.Checked.ToString());
			}
		}

		private void DockItemsHideDockAfterExecutionCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.DockItems.HideDockAfterExecution = this.DockItemsHideDockAfterExecutionCB.Checked;
				this.DockSettings.SetEntry("DockItems", "HideDockAfterExecution", this.DockItemsHideDockAfterExecutionCB.Checked.ToString());
			}
		}

		private void DockItemsNormalSizeTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockItemsNormalSizeValue.Text = this.DockItemsNormalSizeTB.Value.ToString();
				this.DockSettings.DockItems.DefaultWidth = this.DockItemsNormalSizeTB.Value;
				this.DockSettings.DockItems.DefaultHeight = this.DockItemsNormalSizeTB.Value;
				this.DockSettings.SetEntry("DockItems", "DefaultWidth", this.DockItemsNormalSizeTB.Value.ToString());
				this.DockSettings.SetEntry("DockItems", "DefaultHeight", this.DockItemsNormalSizeTB.Value.ToString());
				this.ParentObject.ResizeDockItems(this.DockSettings.DockItems.DefaultWidth, this.DockSettings.DockItems.DefaultHeight);
			}
		}

		private void DockItemsNormalOpacityTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockItemsNormalOpacityValue.Text = this.DockItemsNormalOpacityTB.Value.ToString();
				this.DockSettings.DockItems.DefaultOpacity = this.DockItemsNormalOpacityTB.Value;
				this.DockSettings.SetEntry("DockItems", "DefaultOpacity", this.DockItemsNormalOpacityTB.Value.ToString());
				this.ParentObject.UpdateDockItemOpacity(this.DockSettings.DockItems.DefaultOpacity);
			}
		}

		private void LabelFontChangeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				this.LabelFontDialog.Font = this.DockSettings.Labels.FontName;
				if (this.LabelFontDialog.ShowDialog() != DialogResult.Cancel)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
					string text = converter.ConvertToString(this.LabelFontDialog.Font);
					this.LabelsFontName.Text = text;
					this.DockSettings.Labels.FontName = this.LabelFontDialog.Font;
					this.DockSettings.SetEntry("Labels", "FontName", text);
					this.ParentObject.RedrawDockItemLabels();
				}
			}
		}

		private void LabelColorChangeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				if (this.LabelColorDialog.ShowDialog() != DialogResult.Cancel)
				{
					this.LabelColor.BackColor = this.LabelColorDialog.Color;
					this.DockSettings.Labels.FontColor = this.LabelColorDialog.Color;
					this.DockSettings.SetEntry("Labels", "FontColor", this.LabelColorDialog.Color.ToArgb().ToString());
					this.ParentObject.RedrawDockItemLabels();
				}
			}
		}

		private void LabelShadowColorChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				if (this.LabelShadowColorDialog.ShowDialog() != DialogResult.Cancel)
				{
					this.LabelShadowColor.BackColor = this.LabelShadowColorDialog.Color;
					this.DockSettings.Labels.ShadowColor = this.LabelShadowColorDialog.Color;
					this.DockSettings.SetEntry("Labels", "ShadowColor", this.LabelShadowColorDialog.Color.ToArgb().ToString());
					this.ParentObject.RedrawDockItemLabels();
				}
			}
		}

		private void LabelNormalOpacityTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.LabelNormalOpacityValue.Text = this.LabelNormalOpacityTB.Value.ToString();
				this.DockSettings.Labels.DefaultOpacity = this.LabelNormalOpacityTB.Value;
				this.DockSettings.SetEntry("Labels", "DefaultOpacity", this.LabelNormalOpacityTB.Value.ToString());
				this.ParentObject.RedrawDockItemLabels();
			}
		}

		private void LabelShadowSizeTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.LabelShadowSizeValue.Text = this.LabelShadowSizeTB.Value.ToString();
				this.DockSettings.Labels.ShadowSize = this.LabelShadowSizeTB.Value;
				this.DockSettings.SetEntry("Labels", "ShadowSize", this.LabelShadowSizeTB.Value.ToString());
				this.ParentObject.RedrawDockItemLabels();
			}
		}

		private void LabelShadowDarknessTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.LabelShadowDarknessValue.Text = this.LabelShadowDarknessTB.Value.ToString();
				this.DockSettings.Labels.ShadowDarkness = this.LabelShadowDarknessTB.Value;
				this.DockSettings.SetEntry("Labels", "ShadowDarkness", this.LabelShadowDarknessTB.Value.ToString());
				this.ParentObject.RedrawDockItemLabels();
			}
		}

		private void ShowLabelsCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Labels.ShowLabels = this.ShowLabelsCB.Checked;
				this.DockSettings.SetEntry("Labels", "ShowLabels", this.ShowLabelsCB.Checked.ToString());
				if (!this.ShowLabelsCB.Checked)
				{
					this.ParentObject.resetDockLabels();
				}
			}
		}

		private void ShowLabelsMouseOverCB_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.Loaded)
			{
			}
		}

		private void RotationAnimationDurationTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.RotationAnimationDurationValue.Text = this.RotationAnimationDurationTB.Value.ToString();
				this.DockSettings.GeneralAnimation.RotationAnimationDuration = this.RotationAnimationDurationTB.Value;
				this.DockSettings.SetEntry("GeneralAnimation", "RotationAnimationDuration", this.RotationAnimationDurationTB.Value.ToString());
			}
		}

		private void GeneralFrameRateTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				int num = 1000 / this.GeneralFrameRateTB.Value;
				this.GeneralFrameRateValue.Text = this.GeneralFrameRateTB.Value.ToString();
				this.DockSettings.General.AnimationInterval = num;
				this.DockSettings.SetEntry("GeneralAnimation", "AnimationInterval", num.ToString());
				this.ParentObject.UpdateAnimationIntervals(num);
			}
		}

		private void FadeInFadeOutDurationTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.FadeInFadeOutDurationValue.Text = this.FadeInFadeOutDurationTB.Value.ToString();
				this.DockSettings.GeneralAnimation.FadeInFadeOutDuration = this.FadeInFadeOutDurationTB.Value;
				this.DockSettings.SetEntry("GeneralAnimation", "FadeInFadeOutDuration", this.FadeInFadeOutDurationTB.Value.ToString());
			}
		}

		private void UsePoofAnimationWhenDeletingCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.PoofAnimation.UsePoof = this.UsePoofAnimationWhenDeletingCB.Checked;
				this.DockSettings.SetEntry("PoofAnimation", "UsePoof", this.UsePoofAnimationWhenDeletingCB.Checked.ToString());
			}
		}

		private void AuthorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				Process.Start("mailto:VideoInPicture@gmail.com");
			}
		}

		private void HomepageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				Process.Start("http://circledock.wikidot.com");
			}
		}

		private void AboutWebForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				Process.Start("http://www.donationcoder.com/Forums/bb/index.php?board=240.0");
			}
		}

		private void HelpWebForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				Process.Start("http://www.donationcoder.com/Forums/bb/index.php?board=240.0");
			}
		}

		private void HelpWebHelpFAQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.Loaded)
			{
				Process.Start("http://circledock.wikidot.com/help-faq");
			}
		}

		private void CentreAroundCursorWhenShownCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.General.CentreAroundCursor = this.CentreAroundCursorWhenShownCB.Checked;
				this.DockSettings.SetEntry("General", "CentreAroundCursor", this.CentreAroundCursorWhenShownCB.Checked.ToString());
			}
		}

		private void LanguageFileLocationBrowse_Click(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.LanguageFileDialog.InitialDirectory = Application.StartupPath + "\\System\\Languages";
				this.LanguageFileDialog.ShowDialog();
			}
		}

		private void LanguageFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			string text;
			if (this.LanguageFileDialog.FileName.StartsWith(Application.StartupPath + "\\"))
			{
				text = "." + this.LanguageFileDialog.FileName.Substring(Application.StartupPath.Length, this.LanguageFileDialog.FileName.Length - Application.StartupPath.Length);
			}
			else
			{
				text = this.LanguageFileDialog.FileName;
			}
			this.LanguageFileLocationTextBox.Text = text;
			this.DockSettings.SetEntry("Language", "Path", text);
			this.DockSettings.Language.path = text;
			this.Language.LoadLanguageDataFromNewFile(this.LanguageFileDialog.FileName);
			this.Loaded = false;
			this.InitializeSettings();
		}

		private void DockFolderDefaultImageBrowse_Click(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockFolderDefaultImageDialog.InitialDirectory = Application.StartupPath + "\\System\\Icons";
				this.DockFolderDefaultImageDialog.ShowDialog();
			}
		}

		private void DockFolderDefaultImageDialog_FileOk(object sender, CancelEventArgs e)
		{
			if (this.Loaded)
			{
				string text;
				if (this.DockFolderDefaultImageDialog.FileName.StartsWith(Application.StartupPath + "\\"))
				{
					text = "." + this.DockFolderDefaultImageDialog.FileName.Substring(Application.StartupPath.Length, this.DockFolderDefaultImageDialog.FileName.Length - Application.StartupPath.Length);
				}
				else
				{
					text = this.DockFolderDefaultImageDialog.FileName;
				}
				this.DockFolderDefaultImagePath.Text = text;
				this.DockSettings.SetEntry("Folders", "DockFolderImagePath", text);
				this.DockSettings.Folders.DockFolderImagePath = text;
				try
				{
					string dockFolderImagePath = this.DockSettings.Folders.DockFolderImagePath;
					Bitmap image;
					if (dockFolderImagePath.StartsWith(".\\"))
					{
						image = new Bitmap(Application.StartupPath + dockFolderImagePath.Substring(1, dockFolderImagePath.Length - 1));
					}
					else
					{
						image = new Bitmap(dockFolderImagePath);
					}
					this.DockFolderDefaultImage.Image = image;
				}
				catch (Exception)
				{
					this.DockFolderDefaultImage.Image = ImageResources.MissingIcon;
				}
			}
		}

		private void ToggleVisibilityCtrlCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.VisibilityCtrl = this.ToggleVisibilityCtrlCB.Checked;
				this.DockSettings.SetEntry("Toggling", "VisibilityCtrl", this.ToggleVisibilityCtrlCB.Checked.ToString());
				this.ParentObject.RegisterHotKeyToggleDock();
				if (this.ParentObject.ToggleDockHotKeyStatus)
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.ValidHotkeyCombination;
				}
				else
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.InvalidHotKeyCombination;
				}
			}
		}

		private void ToggleVisibilityAltCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.VisibilityAlt = this.ToggleVisibilityAltCB.Checked;
				this.DockSettings.SetEntry("Toggling", "VisibilityAlt", this.ToggleVisibilityAltCB.Checked.ToString());
				this.ParentObject.RegisterHotKeyToggleDock();
				if (this.ParentObject.ToggleDockHotKeyStatus)
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.ValidHotkeyCombination;
				}
				else
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.InvalidHotKeyCombination;
				}
			}
		}

		private void ToggleVisibilityShiftCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.VisibilityShift = this.ToggleVisibilityShiftCB.Checked;
				this.DockSettings.SetEntry("Toggling", "VisibilityShift", this.ToggleVisibilityShiftCB.Checked.ToString());
				this.ParentObject.RegisterHotKeyToggleDock();
				if (this.ParentObject.ToggleDockHotKeyStatus)
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.ValidHotkeyCombination;
				}
				else
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.InvalidHotKeyCombination;
				}
			}
		}

		private void ToggleVisibilityWinCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.VisibilityWin = this.ToggleVisibilityWinCB.Checked;
				this.DockSettings.SetEntry("Toggling", "VisibilityWin", this.ToggleVisibilityWinCB.Checked.ToString());
				this.ParentObject.RegisterHotKeyToggleDock();
				if (this.ParentObject.ToggleDockHotKeyStatus)
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.ValidHotkeyCombination;
				}
				else
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.InvalidHotKeyCombination;
				}
			}
		}

		private void ToggleVisiblityKey1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				KeysConverter keysConverter = new KeysConverter();
				Keys keys = (Keys)keysConverter.ConvertFromString(this.ToggleVisiblityKey1.SelectedItem.ToString());
				this.DockSettings.Toggling.VisibilityKey1 = (int)keys;
				SettingsLoader.SettingsLoader arg_5C_0 = this.DockSettings;
				string arg_5C_1 = "Toggling";
				string arg_5C_2 = "VisibilityKey1";
				int num = (int)keys;
				arg_5C_0.SetEntry(arg_5C_1, arg_5C_2, num.ToString());
				this.ParentObject.RegisterHotKeyToggleDock();
				if (this.ParentObject.ToggleDockHotKeyStatus)
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.ValidHotkeyCombination;
				}
				else
				{
					this.ToggleVisibilityHotkeyValid.Text = this.Language.SettingsPanel.InvalidHotKeyCombination;
				}
				this.Select(true, true);
			}
		}

		private void ToggleVisiblityMouseButton_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.VisibilityMouseButton = this.ToggleVisiblityMouseButton.Items[this.ToggleVisiblityMouseButton.SelectedIndex].ToString();
				this.DockSettings.SetEntry("Toggling", "VisibilityMouseButton", this.ToggleVisiblityMouseButton.Items[this.ToggleVisiblityMouseButton.SelectedIndex].ToString());
				this.ParentObject.SetMouseKeys();
				this.Select(true, true);
			}
		}

		private void EdgeWidthHeightTB_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.EdgeWidthHeightValue.Text = this.EdgeWidthHeightTB.Value.ToString();
				this.DockSettings.Toggling.EdgeWidthHeight = this.EdgeWidthHeightTB.Value;
				this.DockSettings.SetEntry("Toggling", "EdgeWidthHeight", this.EdgeWidthHeightTB.Value.ToString());
			}
		}

		private void ScreenLeftEdge_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.ScreenLeftEdgeShow = this.ScreenLeftEdge.Checked;
				this.DockSettings.SetEntry("Toggling", "ScreenLeftEdgeShow", this.ScreenLeftEdge.Checked.ToString());
			}
		}

		private void ScreenRightEdge_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.ScreenRightEdgeShow = this.ScreenRightEdge.Checked;
				this.DockSettings.SetEntry("Toggling", "ScreenRightEdgeShow", this.ScreenRightEdge.Checked.ToString());
			}
		}

		private void ScreenTopEdge_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.ScreenTopEdgeShow = this.ScreenTopEdge.Checked;
				this.DockSettings.SetEntry("Toggling", "ScreenTopEdgeShow", this.ScreenTopEdge.Checked.ToString());
			}
		}

		private void ScreenBottomEdge_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.ScreenBottomEdgeShow = this.ScreenBottomEdge.Checked;
				this.DockSettings.SetEntry("Toggling", "ScreenBottomEdgeShow", this.ScreenBottomEdge.Checked.ToString());
			}
		}

		private void zLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				if (this.zLevelComboBox.SelectedIndex == 2)
				{
					this.DockSettings.General.zLevel = "Always On Bottom";
					this.DockSettings.SetEntry("General", "zLevel", this.DockSettings.General.zLevel);
					Application.Restart();
				}
				else if (this.zLevelComboBox.SelectedIndex == 1)
				{
					this.DockSettings.General.zLevel = "Normal";
					this.DockSettings.SetEntry("General", "zLevel", this.DockSettings.General.zLevel);
				}
				else
				{
					this.DockSettings.General.zLevel = "Topmost";
					this.DockSettings.SetEntry("General", "zLevel", this.DockSettings.General.zLevel);
				}
				this.ParentObject.setZLevels();
			}
		}

		private void dwellTimeTrackBar_Scroll(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.Toggling.dwellTime = this.dwellTimeTrackBar.Value;
				this.DockSettings.SetEntry("Toggling", "dwellTime", this.dwellTimeTrackBar.Value.ToString());
				this.dwellTimeValue.Text = this.DockSettings.Toggling.dwellTime.ToString();
			}
		}

		private void DockSetup_Deactivate(object sender, EventArgs e)
		{
		}

		private void lockDockPositionCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(Point));
				this.CentreAroundCursorWhenShownCB.Enabled = !this.lockDockPositionCheckBox.Checked;
				this.DockSettings.General.lockDockPosition = this.lockDockPositionCheckBox.Checked;
				this.DockSettings.SetEntry("General", "lockDockPosition", this.lockDockPositionCheckBox.Checked.ToString());
				if (this.DockSettings.General.lockDockPosition)
				{
					this.DockSettings.General.lockedPosition = this.ParentObject.BackgroundObject.Location;
					this.DockSettings.SetEntry("General", "lockedPosition", converter.ConvertToString(this.ParentObject.BackgroundObject.Location));
				}
			}
		}

		private void useSameRotationValuesCB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DockSettings.General.useSameRotationValues = this.useSameRotationValuesCB.Checked;
				this.DockSettings.SetEntry("General", "useSameRotationValues", this.DockSettings.General.useSameRotationValues.ToString());
				this.ParentObject.loadRotationValue();
				this.ParentObject.PositionCurrentLevel();
			}
		}

		private void currentRotationValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.ParentObject.RotationValue = (double)this.currentRotationValueNumericUpDown.Value;
				this.ParentObject.TargetRotationValue = (double)this.currentRotationValueNumericUpDown.Value;
				this.ParentObject.saveRotationValue();
				this.ParentObject.loadRotationValue();
				this.ParentObject.PositionCurrentLevel();
			}
		}
	}
}
