using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Description: This program is meant to model playing the card game called "WAR".

namespace WAR_Card_Game
{
    enum ControlMode { CardManipulation, UserGame }

    public partial class MainFormWAR : Form
    {
        // declare class variables
        const int cardsInDeck = 52, cardsInHalfDeck = 26;

        Random rand = new Random();     // variable for generating random numbers

        bool isDeckSplit = false;       // flag to indicate that the deck of cards has been divided in half
                                        // (split into first half group and  second half group)
        bool isGamePlaying = false;     // flag to indicate that the game is currently being played

        // the deckOfPlayingCards variable is a list of groups of playing card objects
        // each group is a list of playing card objects
        // the intention is to model a deck of playing cards such that it can be broken down
        // into groups of cards so the cards may be manipulated as groups of cards
        List<GroupOfPlayingCards> deckOfPlayingCards = new List<GroupOfPlayingCards>();

        const int cardWidth = 116, cardHeight = 178;  // measured card dimensions (experimentally determined)
        int halfCardWidth, halfCardHeight;      // the card width and height divided by two (used for centering the cards)
        const int splitCardOffset = 90;
        const int spreadOffset = 25;

        List<Player> warPlayers = new List<Player>();

        int topPlayerIndex = 0, bottomPlayerIndex = 1;

        // new class variables
        // these indices are for referring to and accessing individual groups of cards
        int deckGroupIndex,                 // this index refers to the deck when it is a single group of cards - "The deck" 
            shuffleGroupIndex,              // this index refers to a group used for shuffling the cards - "Shuffle"
            firstHalfGroupIndex,
            secondHalfGroupIndex,
            topPlayerGroupIndex,
            bottomPlayerGroupIndex,
            topPlayerWonCardsGroupIndex,
            bottomPlayerWonCardsGroupIndex,
            dealtCardsGroupIndex;

        Point formCenterPoint;              // this is the center point of the main form (MainFormWAR) 

        int centeredCardX, centeredCardY;   // these are the coordinates of the upper left corner (Location) of a card when it is
                                            // centered on the main form
        string keyString = "";

        CardReference selectedCardReference;
        string selectedCardString;

        // setup variables
        // coords for setting up positions of cards
        int setUpTPY, setUpBPY;
        int firstCardTPY, firstCardBPY;
        Point topPlayerLabelPoint, bottomPlayerLabelPoint;

        // game variables
        int warLevel = 0;
        int round = 1;
        DateTime gameStartTime, gameEndTime;
        TimeSpan gameElapsedTime;

        InfoFormWAR startForm;
        public TestFormWAR testForm;

        ControlMode controlMode = ControlMode.UserGame;

        public MainFormWAR()
        {
            InitializeComponent();
        }

        private void MainFormWAR_Load(object sender, EventArgs e)
        {
            startForm = new InfoFormWAR();
            
            while (startForm.validation == false && startForm.endProgram == false)
            {
                startForm.ShowDialog();
            }

            if (startForm.endProgram == true)
            {
                this.Close();
            }
            else
            {
                lblCommentary.Text = "Welcome WAR Players " + startForm.txtBxTopPlayerName.Text + " and "
                    + startForm.txtBxBottomPlayerName.Text + "! " + startForm.txtBxTopPlayerName.Text + 
                    ", you're the Top Player and " + startForm.txtBxBottomPlayerName.Text + 
                    ", you're the Bottom Player! Follow the instructions to begin playing!";
                
                IntialSetup();
            }

                        
        }

        private Point GetContextMenuLocation()
        {

            Point zeroPoint = new Point(0, 0);

            Point cmPoint = cntxtMnStrpCardControl.PointToScreen(zeroPoint);
            int cmX = cmPoint.X - this.Location.X - 10;
            int cmY = cmPoint.Y - this.Location.Y;
            cmPoint.X = cmX;
            cmPoint.Y = cmY;

            return cmPoint;

        }

        private void GatherTheDeck(object sender, EventArgs e)
        {
            
            if (isDeckSplit == false)
            {
                Point cmLocationPoint = GetContextMenuLocation();

                int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;

                GatherGroupOfCards(topLeftCornerX, topLeftCornerY, deckGroupIndex);
            }
        }

        private void SpreadTheDeck(object sender, EventArgs e)
        {
            if (isDeckSplit == false)
            {
                Point cmLocationPoint = GetContextMenuLocation();

                int topLeftCornerY = cmLocationPoint.Y - halfCardHeight;

                //Point cardLocation = deckOfPlayingCards[deckGroupIndex].Group[0].getLocation();
                int groupCount = deckOfPlayingCards[deckGroupIndex].getCount();
                int spreadWidth = cardWidth + spreadOffset * (groupCount - 1);
                int startingX = formCenterPoint.X - (spreadWidth / 2);

                SpreadGroupOfCards(startingX, topLeftCornerY, deckGroupIndex);
            }
        }

        private void ShuffleTheDeck(object sender, EventArgs e)
        {
            if (isDeckSplit == false)
            {
                ShuffleGroupOfCards(deckGroupIndex);
            }
        }

        private void ConfigureContextMenuForSplitDeck()
        {
            gatherFirstHalfToolStripMenuItem.Visible = true;
            gatherFirstHalfToolStripMenuItem.Enabled = true;

            gatherSecondHalfToolStripMenuItem.Visible = true;
            gatherSecondHalfToolStripMenuItem.Enabled = true;

            spreadFirstHalfToolStripMenuItem.Visible = true;
            spreadFirstHalfToolStripMenuItem.Enabled = true;

            spreadSecondHalfToolStripMenuItem.Visible = true;
            spreadSecondHalfToolStripMenuItem.Enabled = true;

            shuffleFirstHalfToolStripMenuItem.Visible = true;
            shuffleFirstHalfToolStripMenuItem.Enabled = true;

            shuffleSecondHalfToolStripMenuItem.Visible = true;
            shuffleSecondHalfToolStripMenuItem.Enabled = true;

            joinDeckToolStripMenuItem.Visible = true;
            joinDeckToolStripMenuItem.Enabled = true;

            splitDeckToolStripMenuItem.Enabled = false;
            splitDeckToolStripMenuItem.Visible = false;
        }

        private void ConfigureContextMenuForJoinDeck()
        {
            splitDeckToolStripMenuItem.Enabled = true;
            splitDeckToolStripMenuItem.Visible = true;

            gatherFirstHalfToolStripMenuItem.Visible = false;
            gatherFirstHalfToolStripMenuItem.Enabled = false;

            gatherSecondHalfToolStripMenuItem.Visible = false;
            gatherSecondHalfToolStripMenuItem.Enabled = false;

            spreadFirstHalfToolStripMenuItem.Visible = false;
            spreadFirstHalfToolStripMenuItem.Enabled = false;

            spreadSecondHalfToolStripMenuItem.Visible = false;
            spreadSecondHalfToolStripMenuItem.Enabled = false;

            shuffleFirstHalfToolStripMenuItem.Visible = false;
            shuffleFirstHalfToolStripMenuItem.Enabled = false;

            shuffleSecondHalfToolStripMenuItem.Visible = false;
            shuffleSecondHalfToolStripMenuItem.Enabled = false;

            joinDeckToolStripMenuItem.Visible = false;
            joinDeckToolStripMenuItem.Enabled = false;
        }

        private void SplitTheDeck(object sender, EventArgs e)
        {
            if (controlMode == ControlMode.CardManipulation)
                ConfigureContextMenuForSplitDeck();

            int deckGroupCount = deckOfPlayingCards[deckGroupIndex].getCount();
            int halfDeckGroupCount = deckGroupCount / 2;

            // split the deck of cards into first half and second half
            for (int c = 0; c < halfDeckGroupCount; c++)
            {

                deckOfPlayingCards[firstHalfGroupIndex].addCardToGroup(deckOfPlayingCards[deckGroupIndex].getCard(c));
            }

            for (int c = halfDeckGroupCount; c < deckGroupCount; c++)
            {

                deckOfPlayingCards[secondHalfGroupIndex].addCardToGroup(deckOfPlayingCards[deckGroupIndex].getCard(c));
            }

            //deckOfPlayingCards[shuffleGroupIndex].removeCardFromGroup(shuffleIndex);
            for (int c = 0; c < deckGroupCount; c++)
            {
                deckOfPlayingCards[deckGroupIndex].removeCardFromGroup(0);
            }

            // relocate the two half decks to either side of the mouse pointer
            Point cmLocationPoint = GetContextMenuLocation();

            int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;

            GatherGroupOfCards(topLeftCornerX - splitCardOffset, topLeftCornerY, firstHalfGroupIndex);
            GatherGroupOfCards(topLeftCornerX + splitCardOffset, topLeftCornerY, secondHalfGroupIndex);

            isDeckSplit = true;
        }

        private void JoinTheDeck(object sender, EventArgs e)
        {
            ConfigureContextMenuForJoinDeck();

            int halfDeckGroupCount = deckOfPlayingCards[firstHalfGroupIndex].getCount(); ;

            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //
                //deckOfCards.Add(firstHalfOfDeck[c]);
                deckOfPlayingCards[deckGroupIndex].addCardToGroup(deckOfPlayingCards[firstHalfGroupIndex].getCard(c));
            }


            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //firstHalfOfDeck.RemoveAt(0);
                deckOfPlayingCards[firstHalfGroupIndex].removeCardFromGroup(0);

            }

            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //
                //deckOfCards.Add(firstHalfOfDeck[c]);
                deckOfPlayingCards[deckGroupIndex].addCardToGroup(deckOfPlayingCards[secondHalfGroupIndex].getCard(c));
            }

            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //firstHalfOfDeck.RemoveAt(0);
                deckOfPlayingCards[secondHalfGroupIndex].removeCardFromGroup(0);

            }

            Point cmLocationPoint = GetContextMenuLocation();

            int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;

            GatherGroupOfCards(topLeftCornerX, topLeftCornerY, deckGroupIndex);

            isDeckSplit = false;
        }

        private void GatherTheFirstHalfOfDeck(object sender, EventArgs e)
        {
            if (isDeckSplit == true)
            {
                Point cmLocationPoint = GetContextMenuLocation();

                int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;

                GatherGroupOfCards(topLeftCornerX, topLeftCornerY, firstHalfGroupIndex);
            }
        }

        private void GatherTheSecondHalfOfDeck(object sender, EventArgs e)
        {
            if (isDeckSplit == true)
            {
                Point cmLocationPoint = GetContextMenuLocation();

                int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;

                GatherGroupOfCards(topLeftCornerX, topLeftCornerY, secondHalfGroupIndex);
            }
        }

        private void SpreadTheFirstHalfOfDeck(object sender, EventArgs e)
        {
            if (isDeckSplit == true)
            {
                Point cmLocationPoint = GetContextMenuLocation();

                int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;
                int groupCount = deckOfPlayingCards[firstHalfGroupIndex].getCount();
                int spreadWidth = cardWidth + spreadOffset * (groupCount - 1);
                int startingX = topLeftCornerX - (spreadWidth / 2);
                //formCenterPoint.X
                Size formSize = this.Size;

                if (startingX < 10)
                    startingX = 10;
                else if (startingX + spreadWidth > formSize.Width)
                    startingX = formSize.Width - spreadWidth - 10;

                SpreadGroupOfCards(startingX, topLeftCornerY, firstHalfGroupIndex);
            }
        }

        private void SpreadTheSecondHalfOfDeck(object sender, EventArgs e)
        {

            if (isDeckSplit == true)
            {
                Point cmLocationPoint = GetContextMenuLocation();

                int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;
                int groupCount = deckOfPlayingCards[secondHalfGroupIndex].getCount();
                int spreadWidth = cardWidth + spreadOffset * (groupCount - 1);
                int startingX = topLeftCornerX - (spreadWidth / 2);
                //formCenterPoint.X
                Size formSize = this.Size;

                if (startingX < 10)
                    startingX = 10;
                else if (startingX + spreadWidth > formSize.Width)
                    startingX = formSize.Width - spreadWidth - 10;

                SpreadGroupOfCards(startingX, topLeftCornerY, secondHalfGroupIndex);
            }
        }

        private void ShuffleTheFirstHalfOfDeck(object sender, EventArgs e)
        {
            if (isDeckSplit == true)
            {
                ShuffleGroupOfCards(firstHalfGroupIndex);
            }
        }

        private void ShuffleTheSecondHalfOfDeck(object sender, EventArgs e)
        {
            if (isDeckSplit == true)
            {
                ShuffleGroupOfCards(secondHalfGroupIndex);
            }
        }

        private Point CalculateCenterPointOfForm()
        {
            Point centerPoint = new Point();

            Size formSize = this.Size;

            centerPoint.X = formSize.Width / 2;
            centerPoint.Y = formSize.Height / 2;

            return centerPoint;
        }

        private void CalculateHalfWidthAndHeight()
        {
            halfCardWidth = cardWidth / 2;
            halfCardHeight = cardHeight / 2;
        }

        private void IntialSetup()
        {
            
            CalculateHalfWidthAndHeight();

            // create group zero "the deck"
            CreateCardGroupsAndWARPlayers();

            deckGroupIndex = ReturnGroupIndexGivenIdentifier("The deck");
            shuffleGroupIndex = ReturnGroupIndexGivenIdentifier("Shuffle");
            firstHalfGroupIndex = ReturnGroupIndexGivenIdentifier("First Half");
            secondHalfGroupIndex = ReturnGroupIndexGivenIdentifier("Second Half");
            topPlayerGroupIndex = ReturnGroupIndexGivenIdentifier("Top Player cards");
            bottomPlayerGroupIndex = ReturnGroupIndexGivenIdentifier("Bottom Player cards");
            topPlayerWonCardsGroupIndex = ReturnGroupIndexGivenIdentifier("Top Player won cards");
            bottomPlayerWonCardsGroupIndex = ReturnGroupIndexGivenIdentifier("Bottom Player won cards");
            dealtCardsGroupIndex = ReturnGroupIndexGivenIdentifier("Dealt cards");

            formCenterPoint = CalculateCenterPointOfForm();

            centeredCardX = formCenterPoint.X - halfCardWidth;
            centeredCardY = formCenterPoint.Y - halfCardHeight;

            setUpTPY = formCenterPoint.Y - (formCenterPoint.Y / 2) - (formCenterPoint.Y / 4) - halfCardHeight;
            setUpBPY = formCenterPoint.Y + (formCenterPoint.Y / 2) + (formCenterPoint.Y / 4) - halfCardHeight;

            firstCardTPY = formCenterPoint.Y - (formCenterPoint.Y / 4) - halfCardHeight;
            firstCardBPY = formCenterPoint.Y + (formCenterPoint.Y / 4) - halfCardHeight;

            GatherGroupOfCards(centeredCardX, centeredCardY, deckGroupIndex);
        }

        private void CreateCardGroupsAndWARPlayers()
        {
            // create card group zero (representing the deck of cards as a whole) - "The deck"
            GroupOfPlayingCards groupZero = new GroupOfPlayingCards();

            // set the identifier for group zero - "The deck"
            groupZero.Identifier = "The deck";

            // loop through the number of cards in a  deck of cards
            for (int card = 0; card < cardsInDeck; card++)
            {
                // create the individual card assigning its card number which uniquely identifies each card
                // in the deck
                PlayingCard currentCard = new PlayingCard(card);

                //currentCard.ClearOutputLabel += this.OnClearOutputLabel;
                currentCard.ClearOutputLabel += OnClearOutputLabel;

                // set the face image of each card from the ImageList on the main form
                currentCard.SetCardFaceImage(imgLstPlayingCardFaces.Images[currentCard.FaceImageIndex()]);
                // add the picturebox of each card to the main form
                this.Controls.Add(currentCard.pctrBxCard);
                // add the card to the deck
                groupZero.addCardToGroup(currentCard);
            }

            
            // set the back image from element zero of the ImageList on the main form
            // the  back image is a static variable in the PlayingCard class so it is shared by all the cards
            // because all cards look the same from the back
            PlayingCard cardZero = groupZero.getCard(0);
            cardZero.SetCardBackImage(imgLstPlayingCardFaces.Images[0]);

            // add the cards to the deck
            deckOfPlayingCards.Add(groupZero);

            SetInitalCardOrder();

            GroupOfPlayingCards groupOne = new GroupOfPlayingCards();

            groupOne.Identifier = "Shuffle";

            deckOfPlayingCards.Add(groupOne);

            GroupOfPlayingCards groupTwo = new GroupOfPlayingCards();

            groupTwo.Identifier = "First Half";

            deckOfPlayingCards.Add(groupTwo);

            GroupOfPlayingCards groupThree = new GroupOfPlayingCards();

            groupThree.Identifier = "Second Half";

            deckOfPlayingCards.Add(groupThree);

            GroupOfPlayingCards groupFour = new GroupOfPlayingCards();

            groupFour.Identifier = "Top Player cards";

            deckOfPlayingCards.Add(groupFour);

            GroupOfPlayingCards groupFive = new GroupOfPlayingCards();

            groupFive.Identifier = "Bottom Player cards";

            deckOfPlayingCards.Add(groupFive);

            GroupOfPlayingCards groupSix = new GroupOfPlayingCards();

            groupSix.Identifier = "Top Player won cards";

            deckOfPlayingCards.Add(groupSix);

            GroupOfPlayingCards groupSeven = new GroupOfPlayingCards();

            groupSeven.Identifier = "Bottom Player won cards";

            deckOfPlayingCards.Add(groupSeven);

            GroupOfPlayingCards groupEight = new GroupOfPlayingCards();

            groupEight.Identifier = "Dealt cards";

            deckOfPlayingCards.Add(groupEight);

            Player topPlayer = new Player();
            Player bottomPlayer = new Player();

            topPlayer.Identifier = "Top Player";
            bottomPlayer.Identifier = "Bottom Player";

            warPlayers.Add(topPlayer);
            warPlayers.Add(bottomPlayer);
        }

        private void UpdateOutputLabel()
        {
            if (controlMode == ControlMode.CardManipulation)
                lblOutput.Text = "Instructions: Right click to select options!\nSelected card is " + selectedCardString;
            else if (controlMode == ControlMode.UserGame)
            {
                if (isGamePlaying == false)
                    lblOutput.Text = "Instructions: Right click and select the \"Start WAR Card Game \"option!";
                else
                {
                    if (compareCardsToolStripMenuItem.Enabled == false)
                        lblOutput.Text = "Instructions: Right click, select \"Play WAR Card Game\" then select \"Deal Cards\"!";
                    else if (dealCardsToolStripMenuItem.Enabled == false)
                        lblOutput.Text = "Instructions: Right click, select \"Play WAR Card Game\" then select \"Compare Cards\"!";
                }
            }
        }

        public void OnClearOutputLabel(object sender, string e)
        {
            selectedCardString = e;
            UpdateOutputLabel();
        }

        private void SetInitalCardOrder()
        {
            // rearrange the deck so it has the card order of a brand new deck of cards
            // set all suits to the intial order of
            // A 2 3 4 5 6 7 8 9 10 J Q K

            PlayingCard removedCard;

            for (int rC = 12, iC = 0; rC <= 51; rC+=13, iC+=13)
            {
                removedCard = deckOfPlayingCards[deckGroupIndex].getCard(rC);
                deckOfPlayingCards[deckGroupIndex].removeCardFromGroup(rC);
                deckOfPlayingCards[deckGroupIndex].insertCardToGroup(removedCard, iC);
            }

        }

        private void GatherGroupOfCards(int xCoord, int yCoord, int groupIndex)
        {
            int groupCount = deckOfPlayingCards[groupIndex].getCount();
            int offset = 0;

            if (groupCount > 0)
            {
                for (int card = groupCount - 1; card >= 0; card--)
                {
                    offset = card / 5;
                    deckOfPlayingCards[groupIndex].Group[card].SetLocation(xCoord + offset, yCoord + offset);
                    deckOfPlayingCards[groupIndex].Group[card].TurnCardDown();
                    deckOfPlayingCards[groupIndex].Group[card].DisplayCardImage();
                    deckOfPlayingCards[groupIndex].Group[card].pctrBxCard.BringToFront();
                }

                deckOfPlayingCards[groupIndex].State = State.Gathered;
                Point groupLocation = new Point(xCoord, yCoord);
                deckOfPlayingCards[groupIndex].Location = groupLocation;

            }
            else
                MessageBox.Show("Attempted to gather an empty group of cards.\nIdentifier = " + deckOfPlayingCards[groupIndex].Identifier);
        }

        private void SpreadGroupOfCards(int xCoord, int yCoord, int groupIndex)
        {

            int groupCount = deckOfPlayingCards[groupIndex].getCount();
            
            if (groupCount > 0)
            {
                for (int card = 0; card < groupCount; card++)
                {
                    deckOfPlayingCards[groupIndex].Group[card].SetLocation(card * spreadOffset + xCoord, yCoord);
                    deckOfPlayingCards[groupIndex].Group[card].TurnCardUp();
                    deckOfPlayingCards[groupIndex].Group[card].DisplayCardImage();
                    deckOfPlayingCards[groupIndex].Group[card].pctrBxCard.BringToFront();
                }

                deckOfPlayingCards[groupIndex].State = State.Spread;
                Point groupLocation = new Point(xCoord, yCoord);
                deckOfPlayingCards[groupIndex].Location = groupLocation;

            }
            else
                MessageBox.Show("Attempted to spread an empty group of cards.\nIdentifier = " + deckOfPlayingCards[groupIndex].Identifier);

        }

        private void ShuffleGroupOfCards(int groupIndex)
        {

            int shuffleIndex;
            int groupCount = deckOfPlayingCards[groupIndex].getCount();

            if (groupCount > 0)
            {
                for (int c = 0; c < groupCount; c++)
                {
                    shuffleIndex = rand.Next(deckOfPlayingCards[groupIndex].getCount());
                    deckOfPlayingCards[shuffleGroupIndex].addCardToGroup(deckOfPlayingCards[groupIndex].getCard(shuffleIndex));
                    deckOfPlayingCards[groupIndex].removeCardFromGroup(shuffleIndex);

                }

                for (int c = 0; c < groupCount; c++)
                {
                    shuffleIndex = rand.Next(deckOfPlayingCards[shuffleGroupIndex].getCount());
                    deckOfPlayingCards[groupIndex].addCardToGroup(deckOfPlayingCards[shuffleGroupIndex].getCard(shuffleIndex));
                    deckOfPlayingCards[shuffleGroupIndex].removeCardFromGroup(shuffleIndex);
                }

                //if group is in the gathered state, gather the group of cards
                if (deckOfPlayingCards[groupIndex].State == State.Gathered)
                {
                    GatherGroupOfCards(deckOfPlayingCards[groupIndex].Location.X, deckOfPlayingCards[groupIndex].Location.Y, groupIndex);
                }
                // if group is in the spread state, spread the group of cards
                else if (deckOfPlayingCards[groupIndex].State == State.Spread)
                {
                    SpreadGroupOfCards(deckOfPlayingCards[groupIndex].Location.X, deckOfPlayingCards[groupIndex].Location.Y, groupIndex);
                }


            }
            else
                MessageBox.Show("Attempted to shuffle an empty group of cards.\nIdentifier = " + deckOfPlayingCards[groupIndex].Identifier);

        }

        private CardReference SearchAllGroupsForSelectedCard()
        {
            CardReference referenceToSelectedCard = new CardReference();

            bool found = false;
            int group = 0;
            int card;

            while (!found && group < deckOfPlayingCards.Count)
            {
                card = 0;
                while (!found && card < deckOfPlayingCards[group].getCount())
                {
                    if (deckOfPlayingCards[group].Group[card].Selected)
                    {
                        //MessageBox.Show("Selected card is " + searchCard.FaceValue.ToString() + " of " + searchCard.getSuit().ToString());
                        found = true;

                        referenceToSelectedCard.Group = group;
                        referenceToSelectedCard.Card = card;
                    }
                    else
                        card++;
                }

                group++;
            }

            return referenceToSelectedCard;
        }

        private void DeselectSelectedCard(object sender, EventArgs e)
        {
            // search all cards of all groups to find selected card
            selectedCardReference = SearchAllGroupsForSelectedCard();
            if (selectedCardReference.Group != -1 && selectedCardReference.Card != -1)
            {
                // when found
                deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].DeselectCard();
                deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].DisplayCardImage();
                deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].pctrBxCard.Enabled = false;
                this.Focus();
                deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].pctrBxCard.Enabled = true;
            }
                                    
        }

        private void IdentifySelectedCard(object sender, EventArgs e)
        {
            // search all cards of all groups to find selected card
            CardReference selectedCardReference = SearchAllGroupsForSelectedCard();
            if (selectedCardReference.Group != -1 && selectedCardReference.Card != -1)
            {
                // when found
                //deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].deselectCard();
                //deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].displayCardImage();
                lblOutput.Text = "Selected card: " + 
                    deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].FaceValue.ToString() + " of " +
                    deckOfPlayingCards[selectedCardReference.Group].Group[selectedCardReference.Card].Suit.ToString(); 
            }
            else
            {
                lblOutput.Text = "No card was selected";
            }
        }

        private void IdentifySelectedGroup(object sender, EventArgs e)
        {
            // search all cards of all groups to find selected card
            CardReference selectedCardReference = SearchAllGroupsForSelectedCard();
            if (selectedCardReference.Group != -1 && selectedCardReference.Card != -1)
            {
                lblOutput.Text = "Selected group: " + deckOfPlayingCards[selectedCardReference.Group].Identifier;
            }
            else
            {
                lblOutput.Text = "No group was selected";
            }
        }

        private int ReturnGroupIndexGivenIdentifier(string targetIdentifier)
        {
            int i = 0, index = -1;
            bool found = false;

            while (!found && i < deckOfPlayingCards.Count)
            {
                if (deckOfPlayingCards[i].Identifier.ToLower() == targetIdentifier.ToLower())
                {
                    index = i;
                    found = true;
                }
                else
                    i++;
            }

            // if index was not found
            if (!found)
                MessageBox.Show("Group " + targetIdentifier + " index not found");

            return index;
        }

        private void TransferFirstGroupOfCardsToSecondGroup(int group1Index, int group2Index)
        {
            int group1Count = deckOfPlayingCards[group1Index].getCount();

            if (group1Count > 0)
            {
                // add cards from group 1 to group 2
                for (int c = 0; c < group1Count; c++)
                {
                    deckOfPlayingCards[group2Index].addCardToGroup(deckOfPlayingCards[group1Index].getCard(c));
                }

                for (int c = 0; c < group1Count; c++)
                {
                    // remove cards from group 1
                    deckOfPlayingCards[group1Index].removeCardFromGroup(0);
                }

            }
            else
                MessageBox.Show("Attempted to transfer an empty group of cards.\nIdentifier = " + deckOfPlayingCards[group1Index].Identifier);
        }

        private void TransferFirstCardOfFirstGroupToSecondGroup(int group1Index, int group2Index)
        {
            int group1Count = deckOfPlayingCards[group1Index].getCount();

            if (group1Count > 0)
            {
                deckOfPlayingCards[group2Index].addCardToGroup(deckOfPlayingCards[group1Index].getCard(0));
                deckOfPlayingCards[group1Index].removeCardFromGroup(0);
            }
            else
                MessageBox.Show("Attempted to transfer a card from an empty group of cards.\nIdentifier = " + deckOfPlayingCards[group1Index].Identifier);
        }

        private void SetUpToPlayWAR()
        {
            if (isDeckSplit == true)
            {
                warLevel = 0;

                GatherGroupOfCards(centeredCardX, setUpTPY, firstHalfGroupIndex);

                GatherGroupOfCards(centeredCardX, setUpBPY, secondHalfGroupIndex);

                TransferFirstGroupOfCardsToSecondGroup(firstHalfGroupIndex, topPlayerGroupIndex);

                TransferFirstGroupOfCardsToSecondGroup(secondHalfGroupIndex, bottomPlayerGroupIndex);

                // set player names
                warPlayers[topPlayerIndex].Name = startForm.txtBxTopPlayerName.Text;
                warPlayers[bottomPlayerIndex].Name = startForm.txtBxBottomPlayerName.Text;

                // set player starting scores
                warPlayers[topPlayerIndex].Score = deckOfPlayingCards[topPlayerGroupIndex].getCount();
                warPlayers[bottomPlayerIndex].Score = deckOfPlayingCards[bottomPlayerGroupIndex].getCount();

                topPlayerLabelPoint = new Point();
                topPlayerLabelPoint.X = centeredCardX + cardWidth + 10;
                topPlayerLabelPoint.Y = setUpTPY + (cardHeight / 3);
                lblTopPlayer.Text = warPlayers[topPlayerIndex].Identifier + ": " + warPlayers[topPlayerIndex].Name + "\nScore: " + warPlayers[topPlayerIndex].Score;
                lblTopPlayer.Visible = true;

                lblBottomPlayer.Text = warPlayers[bottomPlayerIndex].Identifier + ": " + warPlayers[bottomPlayerIndex].Name + "\nScore: " + warPlayers[bottomPlayerIndex].Score;
                bottomPlayerLabelPoint = new Point();
                bottomPlayerLabelPoint.X = centeredCardX - lblBottomPlayer.Size.Width - 30;
                bottomPlayerLabelPoint.Y = setUpBPY + (cardHeight / 3);
                lblBottomPlayer.Visible = true;

                lblTopPlayer.Location = topPlayerLabelPoint;
                lblBottomPlayer.Location = bottomPlayerLabelPoint;
                
                isGamePlaying = true;
                                
            }
        }

        private void PlayWAR(object sender, EventArgs e)
        {
            if (isGamePlaying == false)
            {
                if (isDeckSplit == false)
                {
                    // shuffle deck ten times
                    for (int i = 1; i <= 10; i++)
                    {
                        ShuffleGroupOfCards(deckGroupIndex);
                    }
                }

                SplitTheDeck(sender, e);
                SetUpToPlayWAR();
                startWARCardGameToolStripMenuItem.Text = "Play War Card Game";

                gameStartTime = DateTime.Now;

                lblGameStartTime.Text = "Game Start Time: " + gameStartTime.ToString("hh:mm:ss tt");
                lblGameStartTime.Visible = true;
                lblGameDuration.Visible = true;
                lblRound.Text = "Round\n" + round;
                lblRound.Visible = true;

                dealCardsToolStripMenuItem.Enabled = true;
                dealCardsToolStripMenuItem.Visible = true;
                compareCardsToolStripMenuItem.Enabled = false;
                compareCardsToolStripMenuItem.Visible = true;
                UpdateOutputLabel();
            }
        }

        async public void AutoPlayMultipleGames(object sender, EventArgs e)
        //public void AutoPlayMultipleGames(object sender, EventArgs e)
        {
            // get the number of games to autoplay from the test form;
            int numberOfGames, minRounds, minIndex = 0, maxRounds, maxIndex = 0;
            List<int> roundList = new List<int>();
            List<string> durationList = new List<string>();

            if (int.TryParse(testForm.txtBxNumberOfGameRuns.Text, out numberOfGames))
            {
                if (numberOfGames > 0)
                {
                    
                    for (int game = 1; game <= numberOfGames; game++)
                    {
                        testForm.lblCurrentGameRunning.Text = "Current game running: " + game;
                        //MessageBox.Show("Trying to autoplay game " + game);
                        int i;
                        if (isGamePlaying == false)
                        {
                            // if game hasn't started yet
                            i = 1;

                            PlayWAR(sender, e);

                            while (i <= 10000 && isGamePlaying == true)
                            {
                                DealTheCards(sender, e);
                                int milliseconds = 10;
                                await Task.Delay(milliseconds);
                                i++;
                                if (isGamePlaying == true)
                                {
                                    CompareTheCards(sender, e);

                                }
                            }
                        }

                        string listString = game + "   " + gameStartTime.ToString("hh:mm:ss tt") + "   " + gameEndTime.ToString("hh:mm:ss tt")
                            + "   " + GetGameDuration() + "   " + round;
                        roundList.Add(round);
                        durationList.Add(GetGameDuration());
                        testForm.lstBxGamesInfoDisplay.Items.Add(listString);

                        ResetGame(sender, e);
                    }

                    // find the min and max number of round and their indexes
                    minRounds = roundList[0];

                    for (int r = 0; r < roundList.Count; r++)
                    {
                        if (roundList[r] < minRounds)
                        {
                            minRounds = roundList[r];
                            minIndex = r;
                        }
                    }
                    maxRounds = roundList[0];
                    for (int r = 0; r < roundList.Count; r++)
                    {
                        if (roundList[r] > maxRounds)
                        {
                            maxRounds = roundList[r];
                            maxIndex = r;
                        }
                    }

                    testForm.lblMinRoundsGameNumber.Text = "#: " + (minIndex + 1);
                    testForm.lblMaxRoundsGameNumber.Text = "#: " + (maxIndex + 1);
                    testForm.lblMinRounds.Text = "Min Rounds: " + minRounds;
                    testForm.lblMaxRounds.Text = "Max Rounds: " + maxRounds;
                    testForm.lblMinDuration.Text = "Min Dur: " + durationList[minIndex];
                    testForm.lblMaxDuration.Text = "Max Dur: " + durationList[maxIndex];

                }
                else
                    MessageBox.Show("Number entered must be greater than 0");
            }
            else
                MessageBox.Show("You must enter an integer number");
        }

        private string GetGameDuration()
        {
            string duration = "";

            if (gameElapsedTime.Days > 0)
                duration = gameElapsedTime.Days + " days " + gameElapsedTime.Hours + " hr, " +
                    gameElapsedTime.Minutes + " min, " + gameElapsedTime.Seconds + " sec";
            else if (gameElapsedTime.Hours > 0)
                duration = gameElapsedTime.Hours + " hr, " + gameElapsedTime.Minutes + " min, "
                    + gameElapsedTime.Seconds + " sec";
            else if (gameElapsedTime.Minutes > 0)
                duration = gameElapsedTime.Minutes + " min, " + gameElapsedTime.Seconds + " sec";
            else if (gameElapsedTime.Seconds > 0)
                duration = gameElapsedTime.Seconds + " sec        ";
            else
                duration = "< 1 sec        ";

            return duration;
        }

        async private void AutoPlayGame(object sender, EventArgs e)
        {
            int i;
            if (isGamePlaying == false)
            {
                // if game hasn't started yet
                i = 1;

                PlayWAR(sender, e);

                while (i <= 10000 && isGamePlaying == true)
                {
                    DealTheCards(sender, e);
                    int milliseconds = 100;
                    //Thread.Sleep(milliseconds);
                    await Task.Delay(milliseconds);
                    i++;
                    if (isGamePlaying == true)
                    {
                        CompareTheCards(sender, e);

                    }
                }
            }
            else
            {
                // if game has started
                // finish the current round

                // if the current round  is in the "deal the cards" phase
                if (dealCardsToolStripMenuItem.Enabled == true)
                {
                    DealTheCards(sender, e);
                    if (isGamePlaying == true)
                    {
                        CompareTheCards(sender, e);

                    }
                }
                else if (compareCardsToolStripMenuItem.Enabled == true)
                    // if the current round is in the "compare the cards" phase
                    CompareTheCards(sender, e);

                i = 1;

                while (i <= 10000 && isGamePlaying == true)
                {
                    DealTheCards(sender, e);
                    int milliseconds = 100;
                    //Thread.Sleep(milliseconds);
                    await Task.Delay(milliseconds);
                    i++;
                    if (isGamePlaying == true)
                    {
                        CompareTheCards(sender, e);

                    }
                }


            }
            //MessageBox.Show("Number of rounds = " + i);
            //resetGame();
        }

        private bool ReadyForTransfer(int playerCardsGroupIndex, int playerWonCardsGroupIndex, int gatherX, int gatherY)
        {
            // this method checks if a player has cards remaining that can be dealt

            bool ready = false;     // flag indicating readiness to be able to deal from a player's playerCardsGroup

            // if the player has cards in his playerCards group
            if (deckOfPlayingCards[playerCardsGroupIndex].getCount() > 0)
            {
                // then he is ready to deal cards from his playerCardsGroup so set the ready flag
                ready = true;
            }
            // if the player doesn't have cards in his playerCards group but does have cards in his playerWonCards group
            else if (deckOfPlayingCards[playerCardsGroupIndex].getCount() == 0 && deckOfPlayingCards[playerWonCardsGroupIndex].getCount() > 0)
            {
                // then transfer the Won cards to the Player cards group
                TransferFirstGroupOfCardsToSecondGroup(playerWonCardsGroupIndex, playerCardsGroupIndex);
                // shuffle 3 times to keep the cards from getting in a configuration in which the players just trade cards back and forth
                // endlessly
                ShuffleGroupOfCards(playerCardsGroupIndex);
                ShuffleGroupOfCards(playerCardsGroupIndex);
                ShuffleGroupOfCards(playerCardsGroupIndex);
                // regather the cards
                GatherGroupOfCards(gatherX, gatherY, playerCardsGroupIndex);
                // then set the ready flag
                ready = true;

            }
            // if the player is all out of cards
            else if (deckOfPlayingCards[playerCardsGroupIndex].getCount() == 0 && deckOfPlayingCards[playerWonCardsGroupIndex].getCount() == 0)
            {
                //MessageBox.Show(deckOfPlayingCards[playerCardsGroupIndex].Identifier + " has no cards to deal");
                // reset the ready flag
                ready = false;
            }

            return ready;

        }

        private void DealTheCards(object sender, EventArgs e)
        {
            if (lblWAR.Visible == true)
                lblWAR.Visible = false;

            //int firstCardTPY = formCenterPoint.Y - (formCenterPoint.Y / 4) - halfCardHeight;
            //int firstCardBPY = formCenterPoint.Y + (formCenterPoint.Y / 4) - halfCardHeight;

            if (deckOfPlayingCards[topPlayerGroupIndex].getCount() > 0 && deckOfPlayingCards[bottomPlayerGroupIndex].getCount() > 0)
            {
                if (warLevel == 0)
                {
                    if (ReadyForTransfer(topPlayerGroupIndex, topPlayerWonCardsGroupIndex, centeredCardX, setUpTPY))
                        TransferFirstCardOfFirstGroupToSecondGroup(topPlayerGroupIndex, dealtCardsGroupIndex);
                    else
                        MessageBox.Show("Error message from line 996");

                    // transfer the 
                    if (ReadyForTransfer(bottomPlayerGroupIndex, bottomPlayerWonCardsGroupIndex, centeredCardX, setUpBPY))
                        TransferFirstCardOfFirstGroupToSecondGroup(bottomPlayerGroupIndex, dealtCardsGroupIndex);
                    else
                        MessageBox.Show("Error message from line 1002");

                    //Point centerPoint = calculateCenterPointOfForm();

                    //int setUpX = centerPoint.X - halfCardWidth;

                    //int FirstCardTPY = centerPoint.Y - (centerPoint.Y / 4) - halfCardHeight;

                    deckOfPlayingCards[dealtCardsGroupIndex].Group[0].SetLocation(centeredCardX, firstCardTPY);

                    // Turn up the Top Player's dealt card
                    deckOfPlayingCards[dealtCardsGroupIndex].Group[0].TurnCardUp();
                    deckOfPlayingCards[dealtCardsGroupIndex].Group[0].DisplayCardImage();

                    warPlayers[topPlayerIndex].ComparisonCard.Group = dealtCardsGroupIndex;
                    warPlayers[topPlayerIndex].ComparisonCard.Card = 0;
                    //int FirstCardBPX = formSize.Width - 100;

                    //int FirstCardBPY = centerPoint.Y + (centerPoint.Y / 4) - halfCardHeight;

                    deckOfPlayingCards[dealtCardsGroupIndex].Group[1].SetLocation(centeredCardX, firstCardBPY);

                    // turn up Bottom Player's dealt card
                    deckOfPlayingCards[dealtCardsGroupIndex].Group[1].TurnCardUp();
                    deckOfPlayingCards[dealtCardsGroupIndex].Group[1].DisplayCardImage();

                    warPlayers[bottomPlayerIndex].ComparisonCard.Group = dealtCardsGroupIndex;
                    warPlayers[bottomPlayerIndex].ComparisonCard.Card = 1;
                    //int secondCardTPX = setUpX - (cardWidth + 10);

                    //deckOfPlayingCards[firstHalfGroupIndex].Group[1].setLocation(secondCardTPX, FirstCardTPY);
                }
                else if (warLevel > 0)
                {

                    bool topPlayerHasNoCards = false, bottomPlayerHasNoCards = false;

                    if (ReadyForTransfer(topPlayerGroupIndex, topPlayerWonCardsGroupIndex, centeredCardX, setUpTPY))
                        TransferFirstCardOfFirstGroupToSecondGroup(topPlayerGroupIndex, dealtCardsGroupIndex);
                    else
                    {
                        //MessageBox.Show("Line 973 - Potential WAR Default:\nTop Player has no more cards so Bottom Player wins!");
                        //lblOutput.Text = "WAR Default:\nTop Player has no more cards so Bottom Player wins!";

                        lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name + 
                            " doesn't have enough cards left for the war so Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                            " wins the game by default!";

                        topPlayerHasNoCards = true;
                        End();
                    }
                    if (ReadyForTransfer(topPlayerGroupIndex, topPlayerWonCardsGroupIndex, centeredCardX, setUpTPY))
                        TransferFirstCardOfFirstGroupToSecondGroup(topPlayerGroupIndex, dealtCardsGroupIndex);
                    else
                    {
                        //MessageBox.Show("Line 982 - Potential WAR Default:\nTop Player has no more cards so Bottom Player wins!");
                        //lblOutput.Text = "WAR Default:\nTop Player has no more cards so Bottom Player wins!"

                        lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name +
                            " doesn't have enough cards left for the war so Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                            " wins the game by default!";

                        topPlayerHasNoCards = true;
                        End();
                    }

                    if (ReadyForTransfer(bottomPlayerGroupIndex, bottomPlayerWonCardsGroupIndex, centeredCardX, setUpBPY))
                        TransferFirstCardOfFirstGroupToSecondGroup(bottomPlayerGroupIndex, dealtCardsGroupIndex);
                    else
                    {
                        //MessageBox.Show("Line 992 - Potential WAR Default:\nBottom Player has no more cards so Top Player wins!");
                        //lblOutput.Text = "WAR Default:\nBottom Player has no more cards so Top Player wins!";

                        lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                            " doesn't have enough cards left for the war so Top Player " + warPlayers[topPlayerIndex].Name +
                            " wins the game by default!";

                        bottomPlayerHasNoCards = true;
                        End();
                    }
                    if (ReadyForTransfer(bottomPlayerGroupIndex, bottomPlayerWonCardsGroupIndex, centeredCardX, setUpBPY))
                        TransferFirstCardOfFirstGroupToSecondGroup(bottomPlayerGroupIndex, dealtCardsGroupIndex);
                    else
                    {
                        //MessageBox.Show("Line 1001 - Potential WAR Default:\nBottom Player has no more cards so Top Player wins!");
                        //lblOutput.Text = "WAR Default:\nBottom Player has no more cards so Top Player wins!";

                        lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                            " doesn't have enough cards left for the war so Top Player " + warPlayers[topPlayerIndex].Name +
                            " wins the game by default!";

                        bottomPlayerHasNoCards = true;
                        End();
                    }
                    if (isGamePlaying == false && warLevel > 0)
                    {
                        lblWAR.Visible = false;
                        lblWAR.Enabled = false;
                    }

                    if (topPlayerHasNoCards == false && bottomPlayerHasNoCards == false)
                    {
                        // deal top players war cards (one down one up)
                        if (warLevel == 1)
                            warPlayers[topPlayerIndex].ComparisonCard.Card += 3;
                        else
                            warPlayers[topPlayerIndex].ComparisonCard.Card += 4;

                        int xCoordTP = centeredCardX - ((10 + cardWidth) * warLevel);

                        // set location of turned down card
                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card - 1].SetLocation(xCoordTP, firstCardTPY);
                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card - 1].TurnCardDown();
                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card - 1].DisplayCardImage();
                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card - 1].pctrBxCard.BringToFront();

                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card].SetLocation(xCoordTP, firstCardTPY);
                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card].TurnCardUp();
                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card].DisplayCardImage();
                        deckOfPlayingCards[warPlayers[topPlayerIndex].ComparisonCard.Group].Group[warPlayers[topPlayerIndex].ComparisonCard.Card].pctrBxCard.BringToFront();

                        // deal bottom players war cards (one down one up)

                        warPlayers[bottomPlayerIndex].ComparisonCard.Card += 4;

                        int xCoordBP = centeredCardX + ((10 + cardWidth) * warLevel);

                        // set location of turned down card
                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card - 1].SetLocation(xCoordBP, firstCardBPY);
                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card - 1].TurnCardDown();
                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card - 1].DisplayCardImage();
                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card - 1].pctrBxCard.BringToFront();

                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card].SetLocation(xCoordBP, firstCardBPY);
                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card].TurnCardUp();
                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card].DisplayCardImage();
                        deckOfPlayingCards[warPlayers[bottomPlayerIndex].ComparisonCard.Group].Group[warPlayers[bottomPlayerIndex].ComparisonCard.Card].pctrBxCard.BringToFront();
                    }

                }

                // disable the Deal Cards menu item
                dealCardsToolStripMenuItem.Enabled = false;
                compareCardsToolStripMenuItem.Enabled = true;
                if (isGamePlaying == true)
                    UpdateOutputLabel();
            }
            else
                MessageBox.Show("Line 1150 - The top or bottom player has no cards to deal");
                        
        }

        private void CompareTheCards(object sender, EventArgs e)
        {

            // access Top Player's card
            int TPCCGroupIndex = warPlayers[topPlayerIndex].ComparisonCard.Group;
            int TPCCCardIndex = warPlayers[topPlayerIndex].ComparisonCard.Card;

            //deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue;

            // access Bottom Player's card
            int BPCCGroupIndex = warPlayers[bottomPlayerIndex].ComparisonCard.Group;
            int BPCCCardIndex = warPlayers[bottomPlayerIndex].ComparisonCard.Card;

            if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue > deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
            {
                // Top Player wins both cards

                lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name + "'s " + deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue.ToString() + " of " +
                    deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].Suit.ToString() + " beat Bottom Player " + warPlayers[bottomPlayerIndex].Name + "'s " +
                    deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue.ToString() + " of " +
                    deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].Suit.ToString();

                // move both cards from dealt cards group to Top Player Won Cards group
                TransferFirstGroupOfCardsToSecondGroup(dealtCardsGroupIndex, topPlayerWonCardsGroupIndex);

                // spread the won cards next to Top Player's cards
                SpreadGroupOfCards(centeredCardX - (10 + cardWidth + 25 * (deckOfPlayingCards[topPlayerWonCardsGroupIndex].Group.Count - 1)), setUpTPY, topPlayerWonCardsGroupIndex);

                if (warLevel > 0)
                {
                    warLevel = 0;
                    lblWAR.Visible = false;
                    lblWAR.Enabled = false;
                }


            }
            else if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue < deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
            {
                // Bottom Player wins both cards

                lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name + "'s " + deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue.ToString() + " of " +
                    deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].Suit.ToString() + " beat Top Player " + warPlayers[topPlayerIndex].Name + "'s " +
                    deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue.ToString() + " of " +
                    deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].Suit.ToString();

                // move both cards from dealt cards group to Bottom Player Won Cards group
                TransferFirstGroupOfCardsToSecondGroup(dealtCardsGroupIndex, bottomPlayerWonCardsGroupIndex);

                // spread the won cards next to Bottom Player's won cards
                SpreadGroupOfCards(centeredCardX + (10 + cardWidth), setUpBPY, bottomPlayerWonCardsGroupIndex);

                if (warLevel > 0)
                {
                    warLevel = 0;
                    lblWAR.Visible = false;
                    lblWAR.Enabled = false;
                }
            }
            else if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue == deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
            {
                // WAR!!!
                lblWAR.Enabled = true;
                lblWAR.Visible = true;
                lblWAR.BringToFront();

                if (warLevel == 0)
                {
                    warLevel = 1;
                    lblCommentary.Text = "WAR level: 1!";
                }
                else if (warLevel > 0)
                {
                    // compare cards
                    if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue > deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
                    {
                        // Top Player wins both cards

                        lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name + "'s " + deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue.ToString() + " of " +
                            deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].Suit.ToString() + " beat Bottom Player " + warPlayers[bottomPlayerIndex].Name + "'s " +
                            deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue.ToString() + " of " +
                            deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].Suit.ToString();

                        // move both cards from dealt cards group to Top Player Won Cards group
                        TransferFirstGroupOfCardsToSecondGroup(dealtCardsGroupIndex, topPlayerWonCardsGroupIndex);

                        // spread the won cards next to Top Player's cards
                        SpreadGroupOfCards(centeredCardX - (10 + cardWidth + 25 * (deckOfPlayingCards[topPlayerWonCardsGroupIndex].Group.Count - 1)), setUpTPY, topPlayerWonCardsGroupIndex);

                        if (warLevel > 0)
                        {
                            warLevel = 0;
                            lblWAR.Visible = false;
                            lblWAR.Enabled = false;
                        }

                    }
                    else if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue < deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
                    {
                        // Bottom Player wins both cards

                        lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name + "'s " + deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue.ToString() + " of " +
                            deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].Suit.ToString() + " beat Top Player " + warPlayers[topPlayerIndex].Name + "'s " +
                            deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue.ToString() + " of " +
                            deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].Suit.ToString();

                        // move both cards from dealt cards group to Bottom Player Won Cards group
                        TransferFirstGroupOfCardsToSecondGroup(dealtCardsGroupIndex, bottomPlayerWonCardsGroupIndex);

                        // spread the won cards next to Bottom Player's won cards
                        SpreadGroupOfCards(centeredCardX + (10 + cardWidth), setUpBPY, bottomPlayerWonCardsGroupIndex);

                        if (warLevel > 0)
                        {
                            warLevel = 0;
                            lblWAR.Visible = false;
                            lblWAR.Enabled = false;
                        }

                    }
                    else if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue == deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
                    {
                        lblWAR.Enabled = true;
                        lblWAR.Visible = true;
                        lblWAR.BringToFront();

                        warLevel++;
                        lblCommentary.Text = "WAR level: " + warLevel;
                    }
                }
            }

            // adjust and display scores
            warPlayers[topPlayerIndex].Score = deckOfPlayingCards[topPlayerWonCardsGroupIndex].Group.Count + deckOfPlayingCards[topPlayerGroupIndex].Group.Count;
            warPlayers[bottomPlayerIndex].Score = deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].Group.Count + deckOfPlayingCards[bottomPlayerGroupIndex].Group.Count;
            lblTopPlayer.Text = warPlayers[topPlayerIndex].Identifier + ": " + warPlayers[topPlayerIndex].Name + "\nScore: " + warPlayers[topPlayerIndex].Score;
            lblBottomPlayer.Text = warPlayers[bottomPlayerIndex].Identifier + ": " + warPlayers[bottomPlayerIndex].Name + "\nScore: " + warPlayers[bottomPlayerIndex].Score;

            
            // check if someone has won the game
            if (warPlayers[topPlayerIndex].Score == cardsInDeck)
            {
                EndGame(warPlayers[topPlayerIndex].Name, "Top");
                                
            }
            else if (warPlayers[bottomPlayerIndex].Score == cardsInDeck)
            {
                EndGame(warPlayers[bottomPlayerIndex].Name, "Bottom");
                                
            }

            if (isGamePlaying)
            {
                //int topPlayerGroupIndex = returnGroupIndexGivenIdentifier("Top Player cards");
                //int bottomPlayerGroupIndex = returnGroupIndexGivenIdentifier("Bottom Player cards");


                if (deckOfPlayingCards[topPlayerGroupIndex].getCount() == 0 && deckOfPlayingCards[topPlayerWonCardsGroupIndex].getCount() > 0)
                {
                    TransferFirstGroupOfCardsToSecondGroup(topPlayerWonCardsGroupIndex, topPlayerGroupIndex);
                    ShuffleGroupOfCards(topPlayerGroupIndex);
                    ShuffleGroupOfCards(topPlayerGroupIndex);
                    ShuffleGroupOfCards(topPlayerGroupIndex);
                    GatherGroupOfCards(centeredCardX, setUpTPY, topPlayerGroupIndex);

                }
                else if (deckOfPlayingCards[topPlayerGroupIndex].getCount() == 0 && deckOfPlayingCards[topPlayerWonCardsGroupIndex].getCount() == 0)
                {
                    //MessageBox.Show("FROM COMPARE CARDS METHOD: Top Player has no cards to deal");
                    if (warLevel > 0)
                    {
                        lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name +
                            " doesn't have enough cards left for the war so Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                            " wins the game by default!";

                        End();

                        //lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name + " has won the game by WAR Default!";
                        //isGamePlaying = false;
                        lblWAR.Visible = false;
                        lblWAR.Enabled = false;
                    }
                }

                if (deckOfPlayingCards[bottomPlayerGroupIndex].getCount() == 0 && deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].getCount() > 0)
                {
                    TransferFirstGroupOfCardsToSecondGroup(bottomPlayerWonCardsGroupIndex, bottomPlayerGroupIndex);
                    ShuffleGroupOfCards(bottomPlayerGroupIndex);
                    ShuffleGroupOfCards(bottomPlayerGroupIndex);
                    ShuffleGroupOfCards(bottomPlayerGroupIndex);
                    GatherGroupOfCards(centeredCardX, setUpBPY, bottomPlayerGroupIndex);

                }
                else if (deckOfPlayingCards[bottomPlayerGroupIndex].getCount() == 0 && deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].getCount() == 0)
                {
                    //MessageBox.Show("FROM COMPARE CARDS METHOD: Bottom Player has no cards to deal");
                    if (warLevel > 0)
                    {
                        lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                            " doesn't have enough cards left for the war so Top Player " + warPlayers[topPlayerIndex].Name +
                            " wins the game by default!";

                        End();

                        //lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name + " has won the game by WAR Default!";
                        //isGamePlaying = false;
                        lblWAR.Visible = false;
                        lblWAR.Enabled = false;
                    }
                }

                dealCardsToolStripMenuItem.Enabled = true;
                compareCardsToolStripMenuItem.Enabled = false;
                if (isGamePlaying == true)
                {
                    UpdateOutputLabel();
                    round++;
                    lblRound.Text = "Round\n" + round;
                }
                //else
                    //MessageBox.Show("Wait a minute...");
            }
                        
        }

        private void EndGame(string winnerName, string winnerTopOrBottom)
        {
            lblCommentary.Text = winnerTopOrBottom + " Player " + winnerName + " has won the game!";

            End();

        }

        private void End()
        {
            gameEndTime = DateTime.Now;

            lblGameStopTime.Text = "Game End Time: " + gameEndTime.ToString("hh:mm:ss tt");
            lblGameStopTime.Visible = true;

            gameElapsedTime = gameEndTime - gameStartTime;

            DisplayGameDuration();

            isGamePlaying = false;

            // set up for reset
            startWARCardGameToolStripMenuItem.Visible = false;
            startWARCardGameToolStripMenuItem.Enabled = false;
            autoPlayGameToolStripMenuItem.Visible = false;
            autoPlayGameToolStripMenuItem.Enabled = false;

            resetGameToolStripMenuItem.Enabled = true;
            resetGameToolStripMenuItem.Visible = true;

            lblOutput.Text = "Instructions: To play again, right click and select the \"Reset Game\" option!";
        }

        private void ResetGame(object sender, EventArgs e)
        {
            startWARCardGameToolStripMenuItem.Text = "Start WAR Card Game";

            dealCardsToolStripMenuItem.Enabled = false;
            dealCardsToolStripMenuItem.Visible = false;
            compareCardsToolStripMenuItem.Enabled = false;
            compareCardsToolStripMenuItem.Visible = false;

            // transfer to the deck 
            // top player's cards
            if (deckOfPlayingCards[topPlayerGroupIndex].getCount() > 0)
                TransferFirstGroupOfCardsToSecondGroup(topPlayerGroupIndex, deckGroupIndex);

            // top player's won cards
            if (deckOfPlayingCards[topPlayerWonCardsGroupIndex].getCount() > 0)
                TransferFirstGroupOfCardsToSecondGroup(topPlayerWonCardsGroupIndex, deckGroupIndex);

            // bottom player's cards
            if (deckOfPlayingCards[bottomPlayerGroupIndex].getCount() > 0)
                TransferFirstGroupOfCardsToSecondGroup(bottomPlayerGroupIndex, deckGroupIndex);

            // bottom player's won cards
            if (deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].getCount() > 0)
                TransferFirstGroupOfCardsToSecondGroup(bottomPlayerWonCardsGroupIndex, deckGroupIndex);

            // check dealt cards just in case
            if (deckOfPlayingCards[dealtCardsGroupIndex].getCount() > 0)
                TransferFirstGroupOfCardsToSecondGroup(dealtCardsGroupIndex, deckGroupIndex);

            isDeckSplit = false;

            GatherGroupOfCards(centeredCardX, centeredCardY, deckGroupIndex);

            startWARCardGameToolStripMenuItem.Visible = true;
            startWARCardGameToolStripMenuItem.Enabled = true;
            autoPlayGameToolStripMenuItem.Visible = true;
            autoPlayGameToolStripMenuItem.Enabled = true;

            resetGameToolStripMenuItem.Enabled = false;
            resetGameToolStripMenuItem.Visible = false;

            UpdateOutputLabel();

            // reset the commentary label
            lblCommentary.Text = warPlayers[topPlayerIndex].Name + " and " + warPlayers[bottomPlayerIndex].Name + 
                " are you ready to play again?";

            lblTopPlayer.Visible = false;
            lblBottomPlayer.Visible = false;
            lblGameStartTime.Visible = false;
            lblGameStopTime.Visible = false;
            lblGameDuration.Visible = false;

            round = 1;
            lblRound.Visible = false;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            
            lblCurrentTime.Text = "Current Time: " + DateTime.Now.ToString("hh:mm:ss tt");

            if (isGamePlaying == true)
            {
                gameElapsedTime = DateTime.Now - gameStartTime;

                DisplayGameDuration();
            }
        }

        private void DisplayGameDuration()
        {
            if (gameElapsedTime.Days > 0)
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Days + " days " + gameElapsedTime.Hours + " hr, " + 
                    gameElapsedTime.Minutes + " min, " + gameElapsedTime.Seconds + " sec";
            else if (gameElapsedTime.Hours > 0)
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Hours + " hr, " + gameElapsedTime.Minutes + " min, "
                    + gameElapsedTime.Seconds + " sec";
            else if (gameElapsedTime.Minutes > 0)
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Minutes + " min, " + gameElapsedTime.Seconds + " sec";
            else if (gameElapsedTime.Seconds > 0)
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Seconds + " sec";
        }

        /*
        private void DoubleClickOnMainForm(object sender, EventArgs e)
        {
            //lblOutput.Text = "Double click on the form is working";
            //this.SetTopLevel(true);
            //this.BringToFront();

            if (this.Focused)
                lblOutput.Text = "Form has focus";
            else
                lblOutput.Text = "Form does not have focus";

        }
        */

        private void KeyPressOnMainForm(object sender, KeyEventArgs e)
        {
            //int keyValue = e.KeyValue;
            Keys keyCode = e.KeyCode;

            if (keyString.Length < 4)
            {
                keyString += keyCode.ToString();
                lblOutput.Text = "Key was pressed with keyCode = " + keyCode.ToString() +
                    "\n keyString = " + keyString;
            }

            if (keyString.Length == 4 && keyString.ToLower() == "jhle")
            {
                lblOutput.Text = "Code \"" + keyString  + "\" accepted";
                keyString = "";

                testForm = new TestFormWAR(this);
                testForm.Show();
            }
            else if (keyString.Length == 4 && keyString.ToLower() != "jhle")
            {
                lblOutput.Text = "Code \"" + keyString + "\" rejected";
                keyString = "";
            }

        }
    }
}
