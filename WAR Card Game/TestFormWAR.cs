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

        private void ClearTestForm()
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
                
    }
}
