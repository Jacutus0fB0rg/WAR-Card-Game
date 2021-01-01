
namespace WAR_Card_Game
{
    partial class MainFormWAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormWAR));
            this.lblWAR = new System.Windows.Forms.Label();
            this.lblGameStartTime = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.timerCurrentTime = new System.Windows.Forms.Timer(this.components);
            this.lblOutput = new System.Windows.Forms.Label();
            this.imgLstPlayingCardFaces = new System.Windows.Forms.ImageList(this.components);
            this.cntxtMnStrpCardControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gatherDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatherFirstHalfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatherSecondHalfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spreadDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spreadFirstHalfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spreadSecondHalfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuffleDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuffleFirstHalfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuffleSecondHalfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identifySelectedCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identifySelectedGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWARCardGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitManualGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPlayGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPlayThroughToEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPlayUntilWARLevel1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPlayUntilWARLevel2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPlayUntilWARLevel3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAutoPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitAutoPlayGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTopPlayer = new System.Windows.Forms.Label();
            this.lblBottomPlayer = new System.Windows.Forms.Label();
            this.lblGameDuration = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.lblCommentary = new System.Windows.Forms.Label();
            this.lblGameStopTime = new System.Windows.Forms.Label();
            this.autoPlayUntilWARLevel4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPlayUntilWARLevel5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWinnerBanner = new System.Windows.Forms.Label();
            this.cntxtMnStrpCardControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWAR
            // 
            this.lblWAR.AutoSize = true;
            this.lblWAR.BackColor = System.Drawing.Color.Red;
            this.lblWAR.Enabled = false;
            this.lblWAR.Font = new System.Drawing.Font("Stencil", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWAR.Location = new System.Drawing.Point(535, 298);
            this.lblWAR.Name = "lblWAR";
            this.lblWAR.Size = new System.Drawing.Size(355, 114);
            this.lblWAR.TabIndex = 0;
            this.lblWAR.Text = "WAR!!!";
            this.lblWAR.Visible = false;
            // 
            // lblGameStartTime
            // 
            this.lblGameStartTime.AutoSize = true;
            this.lblGameStartTime.Enabled = false;
            this.lblGameStartTime.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStartTime.Location = new System.Drawing.Point(12, 679);
            this.lblGameStartTime.Name = "lblGameStartTime";
            this.lblGameStartTime.Size = new System.Drawing.Size(184, 22);
            this.lblGameStartTime.TabIndex = 2;
            this.lblGameStartTime.Text = "Game Start Time: ";
            this.lblGameStartTime.Visible = false;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.Location = new System.Drawing.Point(12, 621);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(156, 22);
            this.lblCurrentTime.TabIndex = 3;
            this.lblCurrentTime.Text = "Current Time: ";
            // 
            // timerCurrentTime
            // 
            this.timerCurrentTime.Enabled = true;
            this.timerCurrentTime.Interval = 500;
            this.timerCurrentTime.Tick += new System.EventHandler(this.TimerTick);
            // 
            // lblOutput
            // 
            this.lblOutput.BackColor = System.Drawing.Color.Yellow;
            this.lblOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutput.Enabled = false;
            this.lblOutput.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(12, 567);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(621, 45);
            this.lblOutput.TabIndex = 4;
            this.lblOutput.Text = "Instructions: Right click and select the \"Start WAR Card Game\" option!";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgLstPlayingCardFaces
            // 
            this.imgLstPlayingCardFaces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstPlayingCardFaces.ImageStream")));
            this.imgLstPlayingCardFaces.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstPlayingCardFaces.Images.SetKeyName(0, "Backface_Blue.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(1, "2_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(2, "3_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(3, "4_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(4, "5_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(5, "6_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(6, "7_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(7, "8_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(8, "9_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(9, "10_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(10, "Jack_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(11, "Queen_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(12, "King_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(13, "Ace_Spades.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(14, "2_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(15, "3_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(16, "4_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(17, "5_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(18, "6_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(19, "7_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(20, "8_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(21, "9_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(22, "10_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(23, "Jack_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(24, "Queen_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(25, "King_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(26, "Ace_Diamonds.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(27, "2_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(28, "3_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(29, "4_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(30, "5_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(31, "6_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(32, "7_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(33, "8_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(34, "9_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(35, "10_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(36, "Jack_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(37, "Queen_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(38, "King_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(39, "Ace_Clubs.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(40, "2_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(41, "3_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(42, "4_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(43, "5_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(44, "6_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(45, "7_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(46, "8_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(47, "9_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(48, "10_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(49, "Jack_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(50, "Queen_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(51, "King_Hearts.jpg");
            this.imgLstPlayingCardFaces.Images.SetKeyName(52, "Ace_Hearts.jpg");
            // 
            // cntxtMnStrpCardControl
            // 
            this.cntxtMnStrpCardControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gatherDeckToolStripMenuItem,
            this.spreadDeckToolStripMenuItem,
            this.shuffleDeckToolStripMenuItem,
            this.identifySelectedCardToolStripMenuItem,
            this.identifySelectedGroupToolStripMenuItem,
            this.splitDeckToolStripMenuItem,
            this.joinDeckToolStripMenuItem,
            this.startWARCardGameToolStripMenuItem,
            this.autoPlayGameToolStripMenuItem,
            this.resetGameToolStripMenuItem,
            this.stopAutoPlayToolStripMenuItem,
            this.quitAutoPlayGameToolStripMenuItem,
            this.exitProgramToolStripMenuItem});
            this.cntxtMnStrpCardControl.Name = "cntxtMnStrpCardControl";
            this.cntxtMnStrpCardControl.Size = new System.Drawing.Size(235, 290);
            // 
            // gatherDeckToolStripMenuItem
            // 
            this.gatherDeckToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gatherFirstHalfToolStripMenuItem,
            this.gatherSecondHalfToolStripMenuItem});
            this.gatherDeckToolStripMenuItem.Enabled = false;
            this.gatherDeckToolStripMenuItem.Name = "gatherDeckToolStripMenuItem";
            this.gatherDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.gatherDeckToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.gatherDeckToolStripMenuItem.Text = "Gather Deck";
            this.gatherDeckToolStripMenuItem.Visible = false;
            this.gatherDeckToolStripMenuItem.Click += new System.EventHandler(this.GatherTheDeck);
            // 
            // gatherFirstHalfToolStripMenuItem
            // 
            this.gatherFirstHalfToolStripMenuItem.Enabled = false;
            this.gatherFirstHalfToolStripMenuItem.Name = "gatherFirstHalfToolStripMenuItem";
            this.gatherFirstHalfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.gatherFirstHalfToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.gatherFirstHalfToolStripMenuItem.Text = "First Half";
            this.gatherFirstHalfToolStripMenuItem.Visible = false;
            this.gatherFirstHalfToolStripMenuItem.Click += new System.EventHandler(this.GatherTheFirstHalfOfDeck);
            // 
            // gatherSecondHalfToolStripMenuItem
            // 
            this.gatherSecondHalfToolStripMenuItem.Enabled = false;
            this.gatherSecondHalfToolStripMenuItem.Name = "gatherSecondHalfToolStripMenuItem";
            this.gatherSecondHalfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.G)));
            this.gatherSecondHalfToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.gatherSecondHalfToolStripMenuItem.Text = "Second Half";
            this.gatherSecondHalfToolStripMenuItem.Visible = false;
            this.gatherSecondHalfToolStripMenuItem.Click += new System.EventHandler(this.GatherTheSecondHalfOfDeck);
            // 
            // spreadDeckToolStripMenuItem
            // 
            this.spreadDeckToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spreadFirstHalfToolStripMenuItem,
            this.spreadSecondHalfToolStripMenuItem});
            this.spreadDeckToolStripMenuItem.Enabled = false;
            this.spreadDeckToolStripMenuItem.Name = "spreadDeckToolStripMenuItem";
            this.spreadDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.spreadDeckToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.spreadDeckToolStripMenuItem.Text = "Spread Deck";
            this.spreadDeckToolStripMenuItem.Visible = false;
            this.spreadDeckToolStripMenuItem.Click += new System.EventHandler(this.SpreadTheDeck);
            // 
            // spreadFirstHalfToolStripMenuItem
            // 
            this.spreadFirstHalfToolStripMenuItem.Enabled = false;
            this.spreadFirstHalfToolStripMenuItem.Name = "spreadFirstHalfToolStripMenuItem";
            this.spreadFirstHalfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.spreadFirstHalfToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.spreadFirstHalfToolStripMenuItem.Text = "First Half";
            this.spreadFirstHalfToolStripMenuItem.Visible = false;
            this.spreadFirstHalfToolStripMenuItem.Click += new System.EventHandler(this.SpreadTheFirstHalfOfDeck);
            // 
            // spreadSecondHalfToolStripMenuItem
            // 
            this.spreadSecondHalfToolStripMenuItem.Enabled = false;
            this.spreadSecondHalfToolStripMenuItem.Name = "spreadSecondHalfToolStripMenuItem";
            this.spreadSecondHalfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.spreadSecondHalfToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.spreadSecondHalfToolStripMenuItem.Text = "Second Half";
            this.spreadSecondHalfToolStripMenuItem.Visible = false;
            this.spreadSecondHalfToolStripMenuItem.Click += new System.EventHandler(this.SpreadTheSecondHalfOfDeck);
            // 
            // shuffleDeckToolStripMenuItem
            // 
            this.shuffleDeckToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shuffleFirstHalfToolStripMenuItem,
            this.shuffleSecondHalfToolStripMenuItem});
            this.shuffleDeckToolStripMenuItem.Enabled = false;
            this.shuffleDeckToolStripMenuItem.Name = "shuffleDeckToolStripMenuItem";
            this.shuffleDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.shuffleDeckToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.shuffleDeckToolStripMenuItem.Text = "Shuffle Deck";
            this.shuffleDeckToolStripMenuItem.Visible = false;
            this.shuffleDeckToolStripMenuItem.Click += new System.EventHandler(this.ShuffleTheDeck);
            // 
            // shuffleFirstHalfToolStripMenuItem
            // 
            this.shuffleFirstHalfToolStripMenuItem.Enabled = false;
            this.shuffleFirstHalfToolStripMenuItem.Name = "shuffleFirstHalfToolStripMenuItem";
            this.shuffleFirstHalfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.shuffleFirstHalfToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.shuffleFirstHalfToolStripMenuItem.Text = "First Half";
            this.shuffleFirstHalfToolStripMenuItem.Visible = false;
            this.shuffleFirstHalfToolStripMenuItem.Click += new System.EventHandler(this.ShuffleTheFirstHalfOfDeck);
            // 
            // shuffleSecondHalfToolStripMenuItem
            // 
            this.shuffleSecondHalfToolStripMenuItem.Enabled = false;
            this.shuffleSecondHalfToolStripMenuItem.Name = "shuffleSecondHalfToolStripMenuItem";
            this.shuffleSecondHalfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.H)));
            this.shuffleSecondHalfToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.shuffleSecondHalfToolStripMenuItem.Text = "Second Half";
            this.shuffleSecondHalfToolStripMenuItem.Visible = false;
            this.shuffleSecondHalfToolStripMenuItem.Click += new System.EventHandler(this.ShuffleTheSecondHalfOfDeck);
            // 
            // identifySelectedCardToolStripMenuItem
            // 
            this.identifySelectedCardToolStripMenuItem.Enabled = false;
            this.identifySelectedCardToolStripMenuItem.Name = "identifySelectedCardToolStripMenuItem";
            this.identifySelectedCardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.identifySelectedCardToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.identifySelectedCardToolStripMenuItem.Text = "Identify Selected Card";
            this.identifySelectedCardToolStripMenuItem.Visible = false;
            this.identifySelectedCardToolStripMenuItem.Click += new System.EventHandler(this.IdentifySelectedCard);
            // 
            // identifySelectedGroupToolStripMenuItem
            // 
            this.identifySelectedGroupToolStripMenuItem.Enabled = false;
            this.identifySelectedGroupToolStripMenuItem.Name = "identifySelectedGroupToolStripMenuItem";
            this.identifySelectedGroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.identifySelectedGroupToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.identifySelectedGroupToolStripMenuItem.Text = "Identify Selected Group";
            this.identifySelectedGroupToolStripMenuItem.Visible = false;
            this.identifySelectedGroupToolStripMenuItem.Click += new System.EventHandler(this.IdentifySelectedGroup);
            // 
            // splitDeckToolStripMenuItem
            // 
            this.splitDeckToolStripMenuItem.Enabled = false;
            this.splitDeckToolStripMenuItem.Name = "splitDeckToolStripMenuItem";
            this.splitDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.splitDeckToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.splitDeckToolStripMenuItem.Text = "Split Deck";
            this.splitDeckToolStripMenuItem.Visible = false;
            this.splitDeckToolStripMenuItem.Click += new System.EventHandler(this.SplitTheDeck);
            // 
            // joinDeckToolStripMenuItem
            // 
            this.joinDeckToolStripMenuItem.Enabled = false;
            this.joinDeckToolStripMenuItem.Name = "joinDeckToolStripMenuItem";
            this.joinDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.J)));
            this.joinDeckToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.joinDeckToolStripMenuItem.Text = "Join Deck";
            this.joinDeckToolStripMenuItem.Visible = false;
            this.joinDeckToolStripMenuItem.Click += new System.EventHandler(this.JoinTheDeck);
            // 
            // startWARCardGameToolStripMenuItem
            // 
            this.startWARCardGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dealCardsToolStripMenuItem,
            this.compareCardsToolStripMenuItem,
            this.quitManualGameToolStripMenuItem});
            this.startWARCardGameToolStripMenuItem.Name = "startWARCardGameToolStripMenuItem";
            this.startWARCardGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.startWARCardGameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.startWARCardGameToolStripMenuItem.Text = "Start WAR Card Game";
            this.startWARCardGameToolStripMenuItem.Click += new System.EventHandler(this.PlayWAR);
            // 
            // dealCardsToolStripMenuItem
            // 
            this.dealCardsToolStripMenuItem.Enabled = false;
            this.dealCardsToolStripMenuItem.Name = "dealCardsToolStripMenuItem";
            this.dealCardsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.dealCardsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.dealCardsToolStripMenuItem.Text = "Deal Cards";
            this.dealCardsToolStripMenuItem.Visible = false;
            this.dealCardsToolStripMenuItem.Click += new System.EventHandler(this.DealTheCards);
            // 
            // compareCardsToolStripMenuItem
            // 
            this.compareCardsToolStripMenuItem.Enabled = false;
            this.compareCardsToolStripMenuItem.Name = "compareCardsToolStripMenuItem";
            this.compareCardsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.compareCardsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.compareCardsToolStripMenuItem.Text = "Compare Cards";
            this.compareCardsToolStripMenuItem.Visible = false;
            this.compareCardsToolStripMenuItem.Click += new System.EventHandler(this.CompareTheCards);
            // 
            // quitManualGameToolStripMenuItem
            // 
            this.quitManualGameToolStripMenuItem.Enabled = false;
            this.quitManualGameToolStripMenuItem.Name = "quitManualGameToolStripMenuItem";
            this.quitManualGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.quitManualGameToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.quitManualGameToolStripMenuItem.Text = "Quit Manual Game";
            this.quitManualGameToolStripMenuItem.Visible = false;
            this.quitManualGameToolStripMenuItem.Click += new System.EventHandler(this.QuitManualGame);
            // 
            // autoPlayGameToolStripMenuItem
            // 
            this.autoPlayGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoPlayThroughToEndToolStripMenuItem,
            this.autoPlayUntilWARLevel1ToolStripMenuItem,
            this.autoPlayUntilWARLevel2ToolStripMenuItem,
            this.autoPlayUntilWARLevel3ToolStripMenuItem,
            this.autoPlayUntilWARLevel4ToolStripMenuItem,
            this.autoPlayUntilWARLevel5ToolStripMenuItem});
            this.autoPlayGameToolStripMenuItem.Name = "autoPlayGameToolStripMenuItem";
            this.autoPlayGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.autoPlayGameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.autoPlayGameToolStripMenuItem.Text = "AutoPlay Game";
            // 
            // autoPlayThroughToEndToolStripMenuItem
            // 
            this.autoPlayThroughToEndToolStripMenuItem.Name = "autoPlayThroughToEndToolStripMenuItem";
            this.autoPlayThroughToEndToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.autoPlayThroughToEndToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.autoPlayThroughToEndToolStripMenuItem.Text = "AutoPlay Through to End";
            this.autoPlayThroughToEndToolStripMenuItem.Click += new System.EventHandler(this.AutoPlayThroughToEnd);
            // 
            // autoPlayUntilWARLevel1ToolStripMenuItem
            // 
            this.autoPlayUntilWARLevel1ToolStripMenuItem.Name = "autoPlayUntilWARLevel1ToolStripMenuItem";
            this.autoPlayUntilWARLevel1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.autoPlayUntilWARLevel1ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.autoPlayUntilWARLevel1ToolStripMenuItem.Text = "AutoPlay until WAR level 1";
            this.autoPlayUntilWARLevel1ToolStripMenuItem.Click += new System.EventHandler(this.AutoPlayUntilWARLevel1);
            // 
            // autoPlayUntilWARLevel2ToolStripMenuItem
            // 
            this.autoPlayUntilWARLevel2ToolStripMenuItem.Name = "autoPlayUntilWARLevel2ToolStripMenuItem";
            this.autoPlayUntilWARLevel2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.autoPlayUntilWARLevel2ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.autoPlayUntilWARLevel2ToolStripMenuItem.Text = "AutoPlay until WAR level 2";
            this.autoPlayUntilWARLevel2ToolStripMenuItem.Click += new System.EventHandler(this.AutoPlayUntilWARLevel2);
            // 
            // autoPlayUntilWARLevel3ToolStripMenuItem
            // 
            this.autoPlayUntilWARLevel3ToolStripMenuItem.Name = "autoPlayUntilWARLevel3ToolStripMenuItem";
            this.autoPlayUntilWARLevel3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.autoPlayUntilWARLevel3ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.autoPlayUntilWARLevel3ToolStripMenuItem.Text = "AutoPlay until WAR level 3";
            this.autoPlayUntilWARLevel3ToolStripMenuItem.Click += new System.EventHandler(this.AutoPlayUntilWARLevel3);
            // 
            // resetGameToolStripMenuItem
            // 
            this.resetGameToolStripMenuItem.Enabled = false;
            this.resetGameToolStripMenuItem.Name = "resetGameToolStripMenuItem";
            this.resetGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.resetGameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.resetGameToolStripMenuItem.Text = "Reset Game";
            this.resetGameToolStripMenuItem.Visible = false;
            this.resetGameToolStripMenuItem.Click += new System.EventHandler(this.ResetGame);
            // 
            // stopAutoPlayToolStripMenuItem
            // 
            this.stopAutoPlayToolStripMenuItem.Enabled = false;
            this.stopAutoPlayToolStripMenuItem.Name = "stopAutoPlayToolStripMenuItem";
            this.stopAutoPlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.stopAutoPlayToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.stopAutoPlayToolStripMenuItem.Text = "Stop AutoPlay";
            this.stopAutoPlayToolStripMenuItem.Visible = false;
            this.stopAutoPlayToolStripMenuItem.Click += new System.EventHandler(this.StopAutoPlaying);
            // 
            // quitAutoPlayGameToolStripMenuItem
            // 
            this.quitAutoPlayGameToolStripMenuItem.Enabled = false;
            this.quitAutoPlayGameToolStripMenuItem.Name = "quitAutoPlayGameToolStripMenuItem";
            this.quitAutoPlayGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.quitAutoPlayGameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.quitAutoPlayGameToolStripMenuItem.Text = "Quit AutoPlay Game";
            this.quitAutoPlayGameToolStripMenuItem.Visible = false;
            this.quitAutoPlayGameToolStripMenuItem.Click += new System.EventHandler(this.QuitAutoPlayGame);
            // 
            // exitProgramToolStripMenuItem
            // 
            this.exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            this.exitProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitProgramToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.exitProgramToolStripMenuItem.Text = "Exit Program";
            this.exitProgramToolStripMenuItem.Click += new System.EventHandler(this.ExitProgram);
            // 
            // lblTopPlayer
            // 
            this.lblTopPlayer.AutoSize = true;
            this.lblTopPlayer.BackColor = System.Drawing.Color.Magenta;
            this.lblTopPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTopPlayer.Enabled = false;
            this.lblTopPlayer.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopPlayer.Location = new System.Drawing.Point(833, 109);
            this.lblTopPlayer.Name = "lblTopPlayer";
            this.lblTopPlayer.Size = new System.Drawing.Size(141, 27);
            this.lblTopPlayer.TabIndex = 5;
            this.lblTopPlayer.Text = "Top Player: ";
            this.lblTopPlayer.Visible = false;
            // 
            // lblBottomPlayer
            // 
            this.lblBottomPlayer.AutoSize = true;
            this.lblBottomPlayer.BackColor = System.Drawing.Color.Magenta;
            this.lblBottomPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBottomPlayer.Enabled = false;
            this.lblBottomPlayer.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomPlayer.Location = new System.Drawing.Point(408, 633);
            this.lblBottomPlayer.Name = "lblBottomPlayer";
            this.lblBottomPlayer.Size = new System.Drawing.Size(180, 27);
            this.lblBottomPlayer.TabIndex = 6;
            this.lblBottomPlayer.Text = "Bottom Player: ";
            this.lblBottomPlayer.Visible = false;
            // 
            // lblGameDuration
            // 
            this.lblGameDuration.AutoSize = true;
            this.lblGameDuration.Enabled = false;
            this.lblGameDuration.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameDuration.Location = new System.Drawing.Point(12, 650);
            this.lblGameDuration.Name = "lblGameDuration";
            this.lblGameDuration.Size = new System.Drawing.Size(170, 22);
            this.lblGameDuration.TabIndex = 7;
            this.lblGameDuration.Text = "Game Duration: ";
            this.lblGameDuration.Visible = false;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.BackColor = System.Drawing.Color.Orange;
            this.lblRound.Enabled = false;
            this.lblRound.Font = new System.Drawing.Font("Rockwell", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(12, 475);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(140, 39);
            this.lblRound.TabIndex = 8;
            this.lblRound.Text = "ROUND";
            this.lblRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRound.Visible = false;
            // 
            // lblCommentary
            // 
            this.lblCommentary.BackColor = System.Drawing.Color.Cyan;
            this.lblCommentary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCommentary.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentary.Location = new System.Drawing.Point(161, 475);
            this.lblCommentary.Name = "lblCommentary";
            this.lblCommentary.Size = new System.Drawing.Size(472, 77);
            this.lblCommentary.TabIndex = 9;
            this.lblCommentary.Text = "Welcome WAR Players!";
            this.lblCommentary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameStopTime
            // 
            this.lblGameStopTime.AutoSize = true;
            this.lblGameStopTime.Enabled = false;
            this.lblGameStopTime.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStopTime.Location = new System.Drawing.Point(351, 679);
            this.lblGameStopTime.Name = "lblGameStopTime";
            this.lblGameStopTime.Size = new System.Drawing.Size(172, 22);
            this.lblGameStopTime.TabIndex = 10;
            this.lblGameStopTime.Text = "Game Stop Time: ";
            this.lblGameStopTime.Visible = false;
            // 
            // autoPlayUntilWARLevel4ToolStripMenuItem
            // 
            this.autoPlayUntilWARLevel4ToolStripMenuItem.Name = "autoPlayUntilWARLevel4ToolStripMenuItem";
            this.autoPlayUntilWARLevel4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.autoPlayUntilWARLevel4ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.autoPlayUntilWARLevel4ToolStripMenuItem.Text = "AutoPlay until WAR level 4";
            this.autoPlayUntilWARLevel4ToolStripMenuItem.Click += new System.EventHandler(this.AutoPlayUntilWARLevel4);
            // 
            // autoPlayUntilWARLevel5ToolStripMenuItem
            // 
            this.autoPlayUntilWARLevel5ToolStripMenuItem.Name = "autoPlayUntilWARLevel5ToolStripMenuItem";
            this.autoPlayUntilWARLevel5ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
            this.autoPlayUntilWARLevel5ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.autoPlayUntilWARLevel5ToolStripMenuItem.Text = "AutoPlay until WAR level 5";
            this.autoPlayUntilWARLevel5ToolStripMenuItem.Click += new System.EventHandler(this.AutoPlayUntilWARLevel5);
            // 
            // lblWinnerBanner
            // 
            this.lblWinnerBanner.AutoSize = true;
            this.lblWinnerBanner.BackColor = System.Drawing.Color.Yellow;
            this.lblWinnerBanner.Font = new System.Drawing.Font("Stencil", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinnerBanner.Location = new System.Drawing.Point(295, 298);
            this.lblWinnerBanner.Name = "lblWinnerBanner";
            this.lblWinnerBanner.Size = new System.Drawing.Size(736, 114);
            this.lblWinnerBanner.TabIndex = 11;
            this.lblWinnerBanner.Text = "PLAYER WON!!!";
            this.lblWinnerBanner.Visible = false;
            // 
            // MainFormWAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1424, 711);
            this.ContextMenuStrip = this.cntxtMnStrpCardControl;
            this.Controls.Add(this.lblWinnerBanner);
            this.Controls.Add(this.lblGameStopTime);
            this.Controls.Add(this.lblCommentary);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lblGameDuration);
            this.Controls.Add(this.lblBottomPlayer);
            this.Controls.Add(this.lblTopPlayer);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.lblGameStartTime);
            this.Controls.Add(this.lblWAR);
            this.MaximumSize = new System.Drawing.Size(1440, 750);
            this.MinimumSize = new System.Drawing.Size(1440, 750);
            this.Name = "MainFormWAR";
            this.Text = "WAR Card Game";
            this.Load += new System.EventHandler(this.MainFormWAR_Load);
            this.Click += new System.EventHandler(this.DeselectSelectedCard);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressOnMainForm);
            this.cntxtMnStrpCardControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWAR;
        private System.Windows.Forms.Label lblGameStartTime;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Timer timerCurrentTime;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.ImageList imgLstPlayingCardFaces;
        private System.Windows.Forms.ContextMenuStrip cntxtMnStrpCardControl;
        private System.Windows.Forms.ToolStripMenuItem gatherDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spreadDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identifySelectedCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gatherFirstHalfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gatherSecondHalfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spreadFirstHalfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spreadSecondHalfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleFirstHalfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleSecondHalfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identifySelectedGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWARCardGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareCardsToolStripMenuItem;
        private System.Windows.Forms.Label lblTopPlayer;
        private System.Windows.Forms.Label lblBottomPlayer;
        private System.Windows.Forms.Label lblGameDuration;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label lblCommentary;
        private System.Windows.Forms.ToolStripMenuItem autoPlayGameToolStripMenuItem;
        private System.Windows.Forms.Label lblGameStopTime;
        private System.Windows.Forms.ToolStripMenuItem resetGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAutoPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoPlayThroughToEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoPlayUntilWARLevel1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoPlayUntilWARLevel2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoPlayUntilWARLevel3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitManualGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitAutoPlayGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoPlayUntilWARLevel4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoPlayUntilWARLevel5ToolStripMenuItem;
        private System.Windows.Forms.Label lblWinnerBanner;
    }
}

