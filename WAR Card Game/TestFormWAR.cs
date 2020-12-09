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

        private void btnEngage_Click(object sender, EventArgs e)
        {
            lstBxGamesInfoDisplay.Items.Clear();

            try
            {
                mainForm.AutoPlayMultipleGames(sender, e);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstBxGamesInfoDisplay.Items.Clear();
            txtBxNumberOfGameRuns.Clear();
            lblCurrentGameRunning.Text = "Current game running: ";
        }
    }
}
