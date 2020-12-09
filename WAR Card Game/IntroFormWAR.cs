using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WAR_Card_Game
{
    public partial class InfoFormWAR : Form
    {
        public const int numberOfWARPlayers = 2;

        List<string> warPlayerNames = new List<string>();

        public bool validation = false, endProgram = false;

        public InfoFormWAR()
        {
            InitializeComponent();
        }
            

        //lblStartTime.Text += DateTime.Now.ToString("hh:mm:ss tt");

        //DateTime startDateTime = DateTime.Now;
        //DateTime currentDateTime = DateTime.Now;

        //MessageBox.Show(currentDateTime.Subtract(startDateTime).ToString());
        //this.Close();

        private void InfoFormWAR_Load(object sender, EventArgs e)
        {
            readWARPLayerNamesFile();

            if (warPlayerNames.Count == numberOfWARPlayers)
            {
                // auto fill the WARPlayerNames to the textboxes
                txtBxTopPlayerName.Text = warPlayerNames[0];

                txtBxBottomPlayerName.Text = warPlayerNames[1];

                txtBxTopPlayerName.Focus();
                txtBxTopPlayerName.SelectAll();

            }
            else
            {
                txtBxTopPlayerName.Focus();
            }
        }

        private void readWARPLayerNamesFile()
        {
            // attempt to read from the WARPlayerNames.txt file
            try
            {
                // Declare a variable to hold a line read from the file.
                string fileLine;

                // Declare a StreamReader variable.
                StreamReader inputFile;

                // Open the file and get a StreamReader object.
                inputFile = File.OpenText("WARPlayerNames.txt");

                while (!inputFile.EndOfStream)
                {
                    fileLine = inputFile.ReadLine();
                    warPlayerNames.Add(fileLine);
                }

                // Close the file.
                inputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool validatePlayerNames()
        {
            bool validated = false;
            // validate the player names

            // validate the top player name
            if (txtBxTopPlayerName.Text != "")
            {
                // validate the bottom player name
                if (txtBxBottomPlayerName.Text != "")
                {
                    //
                    savePlayerNamesToFile();
                    //this.Close();
                    validated = true;

                }
                else
                {
                    MessageBox.Show("You must enter a name for the Bottom Player!");
                    txtBxBottomPlayerName.Focus();
                }
            }
            else
            {
                MessageBox.Show("You must enter a name for the Top Player!");
                txtBxTopPlayerName.Focus();
            }

            return validated;
        }

        private void savePlayerNamesToFile()
        {
            // attempt to read from the WARPlayerNames.txt file
            try
            {
                // Declare a StreamReader variable.
                StreamWriter outFile;

                // Open the file and get a StreamReader object.
                outFile = File.CreateText("WARPlayerNames.txt");

                outFile.WriteLine(txtBxTopPlayerName.Text);
                outFile.WriteLine(txtBxBottomPlayerName.Text);

                // Close the file.
                outFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            validation = validatePlayerNames();

            if (validation == true)
            {
                this.Close();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            endProgram = true;
            this.Close();
        }

        private void InfoFormClosing(object sender, FormClosingEventArgs e)
        {
            if (validation == false)
            {
                //MessageBox.Show("You must enter names for the Top and Bottom Players\n and click the Continue button!");
                //this.Activate();
                //txtBxTopPlayerName.Focus();
                endProgram = true;
            }
        }
    }
}
