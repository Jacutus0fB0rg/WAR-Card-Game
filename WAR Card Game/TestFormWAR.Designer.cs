
namespace WAR_Card_Game
{
    partial class TestFormWAR
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
            this.txtBxNumberOfGameRuns = new System.Windows.Forms.TextBox();
            this.lblNumberOfGameRuns = new System.Windows.Forms.Label();
            this.lblCurrentGameRunning = new System.Windows.Forms.Label();
            this.btnEngage = new System.Windows.Forms.Button();
            this.lblMAGContolPanel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblMinRGDuration = new System.Windows.Forms.Label();
            this.lblMaxRGDuration = new System.Windows.Forms.Label();
            this.lblMinRounds = new System.Windows.Forms.Label();
            this.lblMaxRounds = new System.Windows.Forms.Label();
            this.lblMinRoundsGameNumber = new System.Windows.Forms.Label();
            this.lblMaxRoundsGameNumber = new System.Windows.Forms.Label();
            this.lblGame = new System.Windows.Forms.Label();
            this.lblRounds = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblMAGNumber = new System.Windows.Forms.Label();
            this.lblMAGStartTime = new System.Windows.Forms.Label();
            this.lbMAGEndTime = new System.Windows.Forms.Label();
            this.lblMAGDuration = new System.Windows.Forms.Label();
            this.lblMAGRounds = new System.Windows.Forms.Label();
            this.lblMAGDefaultStatus = new System.Windows.Forms.Label();
            this.lblMAGTopPlayerScore = new System.Windows.Forms.Label();
            this.lblMAGBottomPlayerScore = new System.Windows.Forms.Label();
            this.lblMAGWARLevel = new System.Windows.Forms.Label();
            this.lblMAGDealtCardCount = new System.Windows.Forms.Label();
            this.lstBxGamesInfoDisplay = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtBxNumberOfGameRuns
            // 
            this.txtBxNumberOfGameRuns.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxNumberOfGameRuns.Location = new System.Drawing.Point(403, 447);
            this.txtBxNumberOfGameRuns.Name = "txtBxNumberOfGameRuns";
            this.txtBxNumberOfGameRuns.Size = new System.Drawing.Size(100, 27);
            this.txtBxNumberOfGameRuns.TabIndex = 0;
            // 
            // lblNumberOfGameRuns
            // 
            this.lblNumberOfGameRuns.BackColor = System.Drawing.Color.Magenta;
            this.lblNumberOfGameRuns.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfGameRuns.Location = new System.Drawing.Point(12, 447);
            this.lblNumberOfGameRuns.Name = "lblNumberOfGameRuns";
            this.lblNumberOfGameRuns.Size = new System.Drawing.Size(385, 27);
            this.lblNumberOfGameRuns.TabIndex = 1;
            this.lblNumberOfGameRuns.Text = "Enter number of games to autoplay: ";
            this.lblNumberOfGameRuns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentGameRunning
            // 
            this.lblCurrentGameRunning.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblCurrentGameRunning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentGameRunning.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentGameRunning.Location = new System.Drawing.Point(509, 447);
            this.lblCurrentGameRunning.Name = "lblCurrentGameRunning";
            this.lblCurrentGameRunning.Size = new System.Drawing.Size(278, 27);
            this.lblCurrentGameRunning.TabIndex = 2;
            this.lblCurrentGameRunning.Text = "Current game running:  ";
            this.lblCurrentGameRunning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEngage
            // 
            this.btnEngage.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEngage.Location = new System.Drawing.Point(234, 487);
            this.btnEngage.Name = "btnEngage";
            this.btnEngage.Size = new System.Drawing.Size(102, 35);
            this.btnEngage.TabIndex = 3;
            this.btnEngage.Text = "Engage";
            this.btnEngage.UseVisualStyleBackColor = true;
            this.btnEngage.Click += new System.EventHandler(this.btnEngage_Click);
            // 
            // lblMAGContolPanel
            // 
            this.lblMAGContolPanel.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGContolPanel.Font = new System.Drawing.Font("Swiss911 UCm BT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGContolPanel.Location = new System.Drawing.Point(272, 18);
            this.lblMAGContolPanel.Name = "lblMAGContolPanel";
            this.lblMAGContolPanel.Size = new System.Drawing.Size(238, 41);
            this.lblMAGContolPanel.TabIndex = 4;
            this.lblMAGContolPanel.Text = "Multi-Game AutoPlay Control Panel";
            this.lblMAGContolPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(423, 487);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMinRGDuration
            // 
            this.lblMinRGDuration.BackColor = System.Drawing.Color.Yellow;
            this.lblMinRGDuration.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinRGDuration.Location = new System.Drawing.Point(403, 374);
            this.lblMinRGDuration.Name = "lblMinRGDuration";
            this.lblMinRGDuration.Size = new System.Drawing.Size(384, 28);
            this.lblMinRGDuration.TabIndex = 7;
            this.lblMinRGDuration.Text = "Min Rounds Game: ";
            this.lblMinRGDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxRGDuration
            // 
            this.lblMaxRGDuration.BackColor = System.Drawing.Color.Yellow;
            this.lblMaxRGDuration.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxRGDuration.Location = new System.Drawing.Point(403, 411);
            this.lblMaxRGDuration.Name = "lblMaxRGDuration";
            this.lblMaxRGDuration.Size = new System.Drawing.Size(384, 28);
            this.lblMaxRGDuration.TabIndex = 8;
            this.lblMaxRGDuration.Text = "Max Rounds Game: ";
            this.lblMaxRGDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinRounds
            // 
            this.lblMinRounds.BackColor = System.Drawing.Color.Yellow;
            this.lblMinRounds.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinRounds.Location = new System.Drawing.Point(131, 374);
            this.lblMinRounds.Name = "lblMinRounds";
            this.lblMinRounds.Size = new System.Drawing.Size(266, 28);
            this.lblMinRounds.TabIndex = 9;
            this.lblMinRounds.Text = "Min:  ";
            this.lblMinRounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxRounds
            // 
            this.lblMaxRounds.BackColor = System.Drawing.Color.Yellow;
            this.lblMaxRounds.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxRounds.Location = new System.Drawing.Point(131, 411);
            this.lblMaxRounds.Name = "lblMaxRounds";
            this.lblMaxRounds.Size = new System.Drawing.Size(266, 28);
            this.lblMaxRounds.TabIndex = 10;
            this.lblMaxRounds.Text = "Max: ";
            this.lblMaxRounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinRoundsGameNumber
            // 
            this.lblMinRoundsGameNumber.BackColor = System.Drawing.Color.Yellow;
            this.lblMinRoundsGameNumber.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinRoundsGameNumber.Location = new System.Drawing.Point(11, 374);
            this.lblMinRoundsGameNumber.Name = "lblMinRoundsGameNumber";
            this.lblMinRoundsGameNumber.Size = new System.Drawing.Size(114, 28);
            this.lblMinRoundsGameNumber.TabIndex = 11;
            this.lblMinRoundsGameNumber.Text = "#:  ";
            this.lblMinRoundsGameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxRoundsGameNumber
            // 
            this.lblMaxRoundsGameNumber.BackColor = System.Drawing.Color.Yellow;
            this.lblMaxRoundsGameNumber.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxRoundsGameNumber.Location = new System.Drawing.Point(11, 411);
            this.lblMaxRoundsGameNumber.Name = "lblMaxRoundsGameNumber";
            this.lblMaxRoundsGameNumber.Size = new System.Drawing.Size(114, 28);
            this.lblMaxRoundsGameNumber.TabIndex = 12;
            this.lblMaxRoundsGameNumber.Text = "#:  ";
            this.lblMaxRoundsGameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGame
            // 
            this.lblGame.BackColor = System.Drawing.Color.Aqua;
            this.lblGame.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGame.Location = new System.Drawing.Point(12, 336);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(114, 28);
            this.lblGame.TabIndex = 13;
            this.lblGame.Text = "Game";
            this.lblGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRounds
            // 
            this.lblRounds.BackColor = System.Drawing.Color.Aqua;
            this.lblRounds.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRounds.Location = new System.Drawing.Point(132, 336);
            this.lblRounds.Name = "lblRounds";
            this.lblRounds.Size = new System.Drawing.Size(266, 28);
            this.lblRounds.TabIndex = 14;
            this.lblRounds.Text = "Rounds  ";
            this.lblRounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.Aqua;
            this.lblDuration.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(404, 336);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(384, 28);
            this.lblDuration.TabIndex = 15;
            this.lblDuration.Text = "Duration";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGNumber
            // 
            this.lblMAGNumber.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGNumber.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGNumber.Location = new System.Drawing.Point(12, 86);
            this.lblMAGNumber.Name = "lblMAGNumber";
            this.lblMAGNumber.Size = new System.Drawing.Size(65, 28);
            this.lblMAGNumber.TabIndex = 26;
            this.lblMAGNumber.Text = "Game #";
            this.lblMAGNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGStartTime
            // 
            this.lblMAGStartTime.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGStartTime.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGStartTime.Location = new System.Drawing.Point(88, 86);
            this.lblMAGStartTime.Name = "lblMAGStartTime";
            this.lblMAGStartTime.Size = new System.Drawing.Size(104, 28);
            this.lblMAGStartTime.TabIndex = 27;
            this.lblMAGStartTime.Text = "Start Time";
            this.lblMAGStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMAGEndTime
            // 
            this.lbMAGEndTime.BackColor = System.Drawing.Color.Aqua;
            this.lbMAGEndTime.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMAGEndTime.Location = new System.Drawing.Point(204, 86);
            this.lbMAGEndTime.Name = "lbMAGEndTime";
            this.lbMAGEndTime.Size = new System.Drawing.Size(102, 28);
            this.lbMAGEndTime.TabIndex = 28;
            this.lbMAGEndTime.Text = "End Time";
            this.lbMAGEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGDuration
            // 
            this.lblMAGDuration.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGDuration.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGDuration.Location = new System.Drawing.Point(318, 86);
            this.lblMAGDuration.Name = "lblMAGDuration";
            this.lblMAGDuration.Size = new System.Drawing.Size(80, 28);
            this.lblMAGDuration.TabIndex = 29;
            this.lblMAGDuration.Text = "Duration";
            this.lblMAGDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGRounds
            // 
            this.lblMAGRounds.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGRounds.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGRounds.Location = new System.Drawing.Point(409, 86);
            this.lblMAGRounds.Name = "lblMAGRounds";
            this.lblMAGRounds.Size = new System.Drawing.Size(65, 28);
            this.lblMAGRounds.TabIndex = 30;
            this.lblMAGRounds.Text = "Rounds";
            this.lblMAGRounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGDefaultStatus
            // 
            this.lblMAGDefaultStatus.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGDefaultStatus.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGDefaultStatus.Location = new System.Drawing.Point(486, 86);
            this.lblMAGDefaultStatus.Name = "lblMAGDefaultStatus";
            this.lblMAGDefaultStatus.Size = new System.Drawing.Size(90, 28);
            this.lblMAGDefaultStatus.TabIndex = 31;
            this.lblMAGDefaultStatus.Text = "Status";
            this.lblMAGDefaultStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGTopPlayerScore
            // 
            this.lblMAGTopPlayerScore.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGTopPlayerScore.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGTopPlayerScore.Location = new System.Drawing.Point(639, 86);
            this.lblMAGTopPlayerScore.Name = "lblMAGTopPlayerScore";
            this.lblMAGTopPlayerScore.Size = new System.Drawing.Size(39, 28);
            this.lblMAGTopPlayerScore.TabIndex = 32;
            this.lblMAGTopPlayerScore.Text = "TP";
            this.lblMAGTopPlayerScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGBottomPlayerScore
            // 
            this.lblMAGBottomPlayerScore.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGBottomPlayerScore.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGBottomPlayerScore.Location = new System.Drawing.Point(690, 86);
            this.lblMAGBottomPlayerScore.Name = "lblMAGBottomPlayerScore";
            this.lblMAGBottomPlayerScore.Size = new System.Drawing.Size(39, 28);
            this.lblMAGBottomPlayerScore.TabIndex = 33;
            this.lblMAGBottomPlayerScore.Text = "BP";
            this.lblMAGBottomPlayerScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGWARLevel
            // 
            this.lblMAGWARLevel.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGWARLevel.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGWARLevel.Location = new System.Drawing.Point(587, 86);
            this.lblMAGWARLevel.Name = "lblMAGWARLevel";
            this.lblMAGWARLevel.Size = new System.Drawing.Size(40, 28);
            this.lblMAGWARLevel.TabIndex = 34;
            this.lblMAGWARLevel.Text = "WAR";
            this.lblMAGWARLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMAGDealtCardCount
            // 
            this.lblMAGDealtCardCount.BackColor = System.Drawing.Color.Aqua;
            this.lblMAGDealtCardCount.Font = new System.Drawing.Font("RM Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAGDealtCardCount.Location = new System.Drawing.Point(741, 86);
            this.lblMAGDealtCardCount.Name = "lblMAGDealtCardCount";
            this.lblMAGDealtCardCount.Size = new System.Drawing.Size(39, 28);
            this.lblMAGDealtCardCount.TabIndex = 35;
            this.lblMAGDealtCardCount.Text = "DC";
            this.lblMAGDealtCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstBxGamesInfoDisplay
            // 
            this.lstBxGamesInfoDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBxGamesInfoDisplay.FormattingEnabled = true;
            this.lstBxGamesInfoDisplay.ItemHeight = 20;
            this.lstBxGamesInfoDisplay.Location = new System.Drawing.Point(12, 122);
            this.lstBxGamesInfoDisplay.Name = "lstBxGamesInfoDisplay";
            this.lstBxGamesInfoDisplay.Size = new System.Drawing.Size(768, 204);
            this.lstBxGamesInfoDisplay.TabIndex = 36;
            // 
            // TestFormWAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.lstBxGamesInfoDisplay);
            this.Controls.Add(this.lblMAGDealtCardCount);
            this.Controls.Add(this.lblMAGWARLevel);
            this.Controls.Add(this.lblMAGBottomPlayerScore);
            this.Controls.Add(this.lblMAGTopPlayerScore);
            this.Controls.Add(this.lblMAGDefaultStatus);
            this.Controls.Add(this.lblMAGRounds);
            this.Controls.Add(this.lblMAGDuration);
            this.Controls.Add(this.lbMAGEndTime);
            this.Controls.Add(this.lblMAGStartTime);
            this.Controls.Add(this.lblMAGNumber);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblRounds);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.lblMaxRoundsGameNumber);
            this.Controls.Add(this.lblMinRoundsGameNumber);
            this.Controls.Add(this.lblMaxRounds);
            this.Controls.Add(this.lblMinRounds);
            this.Controls.Add(this.lblMaxRGDuration);
            this.Controls.Add(this.lblMinRGDuration);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblMAGContolPanel);
            this.Controls.Add(this.btnEngage);
            this.Controls.Add(this.lblCurrentGameRunning);
            this.Controls.Add(this.lblNumberOfGameRuns);
            this.Controls.Add(this.txtBxNumberOfGameRuns);
            this.Name = "TestFormWAR";
            this.Text = "Test Form for WAR Card Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNumberOfGameRuns;
        private System.Windows.Forms.Label lblMAGContolPanel;
        public System.Windows.Forms.TextBox txtBxNumberOfGameRuns;
        public System.Windows.Forms.Label lblCurrentGameRunning;
        public System.Windows.Forms.Label lblMinRGDuration;
        public System.Windows.Forms.Label lblMaxRGDuration;
        public System.Windows.Forms.Label lblMinRounds;
        public System.Windows.Forms.Label lblMaxRounds;
        public System.Windows.Forms.Label lblMinRoundsGameNumber;
        public System.Windows.Forms.Label lblMaxRoundsGameNumber;
        public System.Windows.Forms.Button btnEngage;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Label lblGame;
        public System.Windows.Forms.Label lblRounds;
        public System.Windows.Forms.Label lblDuration;
        public System.Windows.Forms.Label lblMAGNumber;
        public System.Windows.Forms.Label lblMAGStartTime;
        public System.Windows.Forms.Label lbMAGEndTime;
        public System.Windows.Forms.Label lblMAGDuration;
        public System.Windows.Forms.Label lblMAGRounds;
        public System.Windows.Forms.Label lblMAGDefaultStatus;
        public System.Windows.Forms.Label lblMAGTopPlayerScore;
        public System.Windows.Forms.Label lblMAGBottomPlayerScore;
        public System.Windows.Forms.Label lblMAGWARLevel;
        public System.Windows.Forms.Label lblMAGDealtCardCount;
        public System.Windows.Forms.ListBox lstBxGamesInfoDisplay;
    }
}