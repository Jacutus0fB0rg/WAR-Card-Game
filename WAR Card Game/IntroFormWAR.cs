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
    public partial class IntroFormWAR : Form
    {
        public const int NUMBER_OF_WAR_PLAYERS = 2;                 // constant value for number of WAR players

        List<string> warPlayerNames = new List<string>();           // List of WAR player names read from the WAR player names file

        public bool validation = false,                             // flag indicating whether or not the intro form has been validated 
            endProgram = false;                                     // flag indicating that the program should end 

        string warPlayerNamesFileName = "WARPlayerNames.txt";       // name of the file that holds the names of the WAR players

        public IntroFormWAR()
        {
            InitializeComponent();
        }
        
        private void IntroFormWAR_Load(object sender, EventArgs e)
        {
            // attempt to read the WAR player's names file
            ReadWARPLayerNamesFile();

            // if the number of WAR player's names read from the file equals the number of WAR players in the constant value
            if (warPlayerNames.Count == NUMBER_OF_WAR_PLAYERS)
            {
                // auto fill the WARPlayerNames to the textboxes
                txtBxTopPlayerName.Text = warPlayerNames[0];
                txtBxBottomPlayerName.Text = warPlayerNames[1];

                // set the focus to the Top Player name textbox in case the user wants to change the names
                txtBxTopPlayerName.Focus();

                // select the text so the user may change it more easily
                txtBxTopPlayerName.SelectAll();

            }
            // if the number of WAR player's names read from the file does not equal the number of WAR players in the constant value
            else
            {
                // set the focus to the Top Player's name textbox so the user can enter new names
                txtBxTopPlayerName.Focus();
            }
        }

        private void ReadWARPLayerNamesFile()
        {
            // attempt to read from the WAR player's names file
            try
            {
                // Declare a string variable to hold a line read from the file.
                string fileLine;

                // Declare a StreamReader variable.
                StreamReader inputFile;

                if (File.Exists(warPlayerNamesFileName))
                {

                    // Open the file and get a StreamReader object.
                    inputFile = File.OpenText(warPlayerNamesFileName);

                    // while the end of stream has not been reached
                    while (!inputFile.EndOfStream)
                    {
                        // read a line from the file
                        fileLine = inputFile.ReadLine();

                        // add the line from the file to the WAR player names list
                        warPlayerNames.Add(fileLine);
                    }

                    // Close the file.
                    inputFile.Close();
                }
                else
                    WriteDefaultWARPlayerNames();
            }
            // if an error occurs
            catch (Exception ex)
            {
                // display the error's message
                MessageBox.Show(ex.Message);
                
            }
        }

        private void WriteDefaultWARPlayerNames()
        {
            // attempt to write to the WAR player's names file
            try
            {
                // Declare a StreamWriter variable.
                StreamWriter outFile;

                // Open the file and get a StreamWriter object.
                outFile = File.CreateText(warPlayerNamesFileName);

                // write the validated names to the WARPlayerNames.txt file
                outFile.WriteLine("Player 1");
                warPlayerNames.Add("Player 1");
                outFile.WriteLine("Player 2");
                warPlayerNames.Add("Player 2");

                // Close the file.
                outFile.Close();
                
            }
            // if an error occurs
            catch (Exception ex)
            {
                // display the error's message
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidatePlayerNames()
        {

            bool validated = false;                     // flag to indicate whether or not the player names have been validated

            // validate the player names

            // validate the top player name
            if (txtBxTopPlayerName.Text != "")
            {
                // validate the bottom player name
                if (txtBxBottomPlayerName.Text != "")
                {
                    // save the validated player names to the WAR player's names file
                    SavePlayerNamesToFile();

                    // set the flag to indicate the player names have been validated
                    validated = true;

                }
                // if the Bottom Player name is invalid
                else
                {
                    // display an error message
                    MessageBox.Show("You must enter a name for the Bottom Player!");

                    // set the focus to the Bottom Player name textbox
                    txtBxBottomPlayerName.Focus();
                }
            }
            // if the Top Player name is invalid
            else
            {
                // display an error message
                MessageBox.Show("You must enter a name for the Top Player!");

                // set the focus to the Top Player name textbox
                txtBxTopPlayerName.Focus();
            }

            // return the flag value
            return validated;
        }

        private void SavePlayerNamesToFile()
        {
            // attempt to write to the WAR player's names file
            try
            {
                // Declare a StreamWriter variable.
                StreamWriter outFile;

                // Open the file and get a StreamWriter object.
                outFile = File.CreateText(warPlayerNamesFileName);

                // write the validated names to the WARPlayerNames.txt file
                outFile.WriteLine(txtBxTopPlayerName.Text);
                outFile.WriteLine(txtBxBottomPlayerName.Text);

                // Close the file.
                outFile.Close();

            }
            // if an error occurs
            catch (Exception ex)
            {
                // display the error's message
                MessageBox.Show(ex.Message);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // validate the player names and get the return value
            validation = ValidatePlayerNames();

            // if the names have been validated
            if (validation == true)
            {
                // close the intro form and return control to the main form
                this.Close();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // set the flag value indicating the user wants to end the program
            endProgram = true;

            // close the intro form and return control to the main form
            this.Close();
        }

        private void IntroFormClosing(object sender, FormClosingEventArgs e)
        {
            // if the user has closed the intro form without validating the player names
            if (validation == false)
            {
                // set the flag indicating the program should end
                endProgram = true;
            }
        }
    }
}
