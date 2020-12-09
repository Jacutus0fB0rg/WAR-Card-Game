
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstBxGamesInfoDisplay = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblMinDuration = new System.Windows.Forms.Label();
            this.lblMaxDuration = new System.Windows.Forms.Label();
            this.lblMinRounds = new System.Windows.Forms.Label();
            this.lblMaxRounds = new System.Windows.Forms.Label();
            this.lblMinRoundsGameNumber = new System.Windows.Forms.Label();
            this.lblMaxRoundsGameNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBxNumberOfGameRuns
            // 
            this.txtBxNumberOfGameRuns.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxNumberOfGameRuns.Location = new System.Drawing.Point(394, 363);
            this.txtBxNumberOfGameRuns.Name = "txtBxNumberOfGameRuns";
            this.txtBxNumberOfGameRuns.Size = new System.Drawing.Size(100, 27);
            this.txtBxNumberOfGameRuns.TabIndex = 0;
            // 
            // lblNumberOfGameRuns
            // 
            this.lblNumberOfGameRuns.BackColor = System.Drawing.Color.Magenta;
            this.lblNumberOfGameRuns.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfGameRuns.Location = new System.Drawing.Point(93, 363);
            this.lblNumberOfGameRuns.Name = "lblNumberOfGameRuns";
            this.lblNumberOfGameRuns.Size = new System.Drawing.Size(295, 27);
            this.lblNumberOfGameRuns.TabIndex = 1;
            this.lblNumberOfGameRuns.Text = "Enter number of games to autoplay: ";
            this.lblNumberOfGameRuns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentGameRunning
            // 
            this.lblCurrentGameRunning.AutoSize = true;
            this.lblCurrentGameRunning.BackColor = System.Drawing.Color.Yellow;
            this.lblCurrentGameRunning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentGameRunning.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentGameRunning.Location = new System.Drawing.Point(505, 367);
            this.lblCurrentGameRunning.Name = "lblCurrentGameRunning";
            this.lblCurrentGameRunning.Size = new System.Drawing.Size(202, 21);
            this.lblCurrentGameRunning.TabIndex = 2;
            this.lblCurrentGameRunning.Text = "Current game running:  ";
            this.lblCurrentGameRunning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEngage
            // 
            this.btnEngage.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEngage.Location = new System.Drawing.Point(235, 403);
            this.btnEngage.Name = "btnEngage";
            this.btnEngage.Size = new System.Drawing.Size(102, 35);
            this.btnEngage.TabIndex = 3;
            this.btnEngage.Text = "Engage";
            this.btnEngage.UseVisualStyleBackColor = true;
            this.btnEngage.Click += new System.EventHandler(this.btnEngage_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Aqua;
            this.label1.Font = new System.Drawing.Font("Swiss911 UCm BT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Multi-Game AutoPlay Control Panel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstBxGamesInfoDisplay
            // 
            this.lstBxGamesInfoDisplay.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBxGamesInfoDisplay.FormattingEnabled = true;
            this.lstBxGamesInfoDisplay.ItemHeight = 19;
            this.lstBxGamesInfoDisplay.Location = new System.Drawing.Point(12, 79);
            this.lstBxGamesInfoDisplay.Name = "lstBxGamesInfoDisplay";
            this.lstBxGamesInfoDisplay.Size = new System.Drawing.Size(776, 194);
            this.lstBxGamesInfoDisplay.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(424, 403);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMinDuration
            // 
            this.lblMinDuration.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMinDuration.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinDuration.Location = new System.Drawing.Point(404, 290);
            this.lblMinDuration.Name = "lblMinDuration";
            this.lblMinDuration.Size = new System.Drawing.Size(384, 28);
            this.lblMinDuration.TabIndex = 7;
            this.lblMinDuration.Text = "Min Dur: ";
            this.lblMinDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxDuration
            // 
            this.lblMaxDuration.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMaxDuration.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDuration.Location = new System.Drawing.Point(404, 327);
            this.lblMaxDuration.Name = "lblMaxDuration";
            this.lblMaxDuration.Size = new System.Drawing.Size(384, 28);
            this.lblMaxDuration.TabIndex = 8;
            this.lblMaxDuration.Text = "Max Dur: ";
            this.lblMaxDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinRounds
            // 
            this.lblMinRounds.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMinRounds.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinRounds.Location = new System.Drawing.Point(132, 290);
            this.lblMinRounds.Name = "lblMinRounds";
            this.lblMinRounds.Size = new System.Drawing.Size(266, 28);
            this.lblMinRounds.TabIndex = 9;
            this.lblMinRounds.Text = "Min Rounds:  ";
            this.lblMinRounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxRounds
            // 
            this.lblMaxRounds.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMaxRounds.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxRounds.Location = new System.Drawing.Point(132, 327);
            this.lblMaxRounds.Name = "lblMaxRounds";
            this.lblMaxRounds.Size = new System.Drawing.Size(266, 28);
            this.lblMaxRounds.TabIndex = 10;
            this.lblMaxRounds.Text = "Max Rounds:  ";
            this.lblMaxRounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinRoundsGameNumber
            // 
            this.lblMinRoundsGameNumber.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMinRoundsGameNumber.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinRoundsGameNumber.Location = new System.Drawing.Point(12, 290);
            this.lblMinRoundsGameNumber.Name = "lblMinRoundsGameNumber";
            this.lblMinRoundsGameNumber.Size = new System.Drawing.Size(114, 28);
            this.lblMinRoundsGameNumber.TabIndex = 11;
            this.lblMinRoundsGameNumber.Text = "#:  ";
            this.lblMinRoundsGameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxRoundsGameNumber
            // 
            this.lblMaxRoundsGameNumber.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMaxRoundsGameNumber.Font = new System.Drawing.Font("RM Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxRoundsGameNumber.Location = new System.Drawing.Point(12, 327);
            this.lblMaxRoundsGameNumber.Name = "lblMaxRoundsGameNumber";
            this.lblMaxRoundsGameNumber.Size = new System.Drawing.Size(114, 28);
            this.lblMaxRoundsGameNumber.TabIndex = 12;
            this.lblMaxRoundsGameNumber.Text = "#:  ";
            this.lblMaxRoundsGameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestFormWAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMaxRoundsGameNumber);
            this.Controls.Add(this.lblMinRoundsGameNumber);
            this.Controls.Add(this.lblMaxRounds);
            this.Controls.Add(this.lblMinRounds);
            this.Controls.Add(this.lblMaxDuration);
            this.Controls.Add(this.lblMinDuration);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstBxGamesInfoDisplay);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button btnEngage;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBxNumberOfGameRuns;
        public System.Windows.Forms.Label lblCurrentGameRunning;
        public System.Windows.Forms.ListBox lstBxGamesInfoDisplay;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Label lblMinDuration;
        public System.Windows.Forms.Label lblMaxDuration;
        public System.Windows.Forms.Label lblMinRounds;
        public System.Windows.Forms.Label lblMaxRounds;
        public System.Windows.Forms.Label lblMinRoundsGameNumber;
        public System.Windows.Forms.Label lblMaxRoundsGameNumber;
    }
}