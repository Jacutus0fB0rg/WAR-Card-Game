using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WAR_Card_Game
{
    public partial class TestFormWAR : Form
    {
        public MainFormWAR mainForm;

        public TestFormWAR(MainFormWAR mainForm1)
        {
            InitializeComponent();

            // obtain a reference to the mainForm
            this.mainForm = mainForm1;
            
        }

        async private void btnEngage_Click(object sender, EventArgs e)
        {
            // check to see if there are not multiple autoplay games running
            if (mainForm.currentGame == 0)
                // if multiple autoplay games are not running, then clear the testform
                ClearTestForm();

            // disable the engage and clear buttons
            btnEngage.Enabled = false;
            btnClear.Enabled = false;
            btnStop.Enabled = true;
            btnQuit.Enabled = true;

            try
            {
                // call the mainform method to start autoplaying multiple games
                await mainForm.AutoPlayMultipleGames(sender, e);
                
            }
            // if an exception occurs
            catch (Exception ex)
            {
                // display its error message
                MessageBox.Show(ex.Message);
            }
                        
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // clear the testform
            ClearTestForm();
            // clear the number of game runs textbox
            txtBxNumberOfGameRuns.Clear();
        }

        public void ClearTestForm()
        {
            // clear the games info display listbox
            lstBxGamesInfoDisplay.Items.Clear();

            // clear the label that displays the number of the game that had the minimum number of rounds
            lblMinRoundsGameNumber.Text = "#:";
            // clear the label that displays the number of the game that had the maximum number of rounds
            lblMaxRoundsGameNumber.Text = "#:";
            // clear the label that displays the minimum number of rounds
            lblMinRounds.Text = "Min:";
            // clear the label that displays the maximum number of rounds
            lblMaxRounds.Text = "Max:";
            // clear the label that displays the duration of the game that had the minimum number of rounds
            lblMinRGDuration.Text = "Min Rounds Game:";
            // clear the label that displays the duration of the game that had the maximum number of rounds
            lblMaxRGDuration.Text = "Max Rounds Game:";
            // clear the label that displays the number of the currently running game
            lblCurrentGameRunning.Text = "Current game running: ";
        }

        public void btnQuit_Click(object sender, EventArgs e)
        {
            // if multi-autoplaying is ongoing
            if (mainForm.isMultiAutoPlaying == true)
            {
                // set the number of games to zero
                mainForm.numberOfGames = 0;

                // stop multi-autoplaying
                mainForm.StopAutoPlaying(sender, e);

                // quit the resulting manual game
                mainForm.QuitManualGame(sender, e);
                
                // set the focus to the Number of Game Runs textbox
                txtBxNumberOfGameRuns.Focus();

                // select all the  textx in the text box so it is easier for the user to change
                txtBxNumberOfGameRuns.SelectAll();
                                
            }
            // if a multi-autoplaying is stopped
            else if (mainForm.currentGame > 0 && mainForm.isGamePlaying == true)
            {
                // clear the testForm
                ClearTestForm();

                // reset all of the game info variables
                mainForm.ResetAllGameInfoVariables();
                
                // end the game
                mainForm.End();

                // reset the game
                mainForm.ResetGame(sender, e);

            }
            // if a stopped multi-autoplaying game has be manually played to the end
            else if (mainForm.currentGame > 0 && mainForm.awaitingReset == true)
            {
                // clear the testForm
                ClearTestForm();

                // reset all of the game info variables
                mainForm.ResetAllGameInfoVariables();

                // reset the game
                mainForm.ResetGame(sender, e);
            }

            // reenable the Engage button on the testForm
            btnEngage.Enabled = true;

            // disable the Quit button on the testForm
            btnQuit.Enabled = false;

            // enable or disable the Clear button (depending on the circumstances) on the testForm
            mainForm.EnOrDisAbleClearButton();

            // disable the Stop button on the testForm
            btnStop.Enabled = false;
        }

        private void txtBxNumberOfGameRuns_TextChanged(object sender, EventArgs e)
        {
            // enable or disable the Clear button (depending on the circumstances) on the testForm
            mainForm.EnOrDisAbleClearButton();

            // if the Number of Game Runs text is not empty
            if (txtBxNumberOfGameRuns.Text != "")
                // enable the Engage button on the testform
                btnEngage.Enabled = true;
            // if the Number of Game Runs text is empty
            else
                // disable the Engage button on the testform
                btnEngage.Enabled = false;
        }

        private void lstBxGamesInfoDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enable or disable the Clear button (depending on the circumstances) on the testForm
            mainForm.EnOrDisAbleClearButton();
        }

        private void TestFormClosing(object sender, FormClosingEventArgs e)
        {
            // if multi-autoplaying games are running when the testForm is closed
            // call the Quit button click method
            btnQuit_Click(sender, e);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // stop autoplaying
            mainForm.StopAutoPlaying(sender, e);

            // disable the Stop button on the testform
            btnStop.Enabled = false;

            // enable the Engage button on the testform
            btnEngage.Enabled = true;

            // enable or disable the Clear button (depending on the circumstances) on the testForm
            mainForm.EnOrDisAbleClearButton();

            // enable the Quit button on the testForm
            btnQuit.Enabled = true;
        }

        private void TestFormWAR_Load(object sender, EventArgs e)
        {
            // disable all buttons on the  testForm
            btnEngage.Enabled = false;
            btnClear.Enabled = false;
            btnStop.Enabled = false;
            btnQuit.Enabled = false;
            btnExit.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
