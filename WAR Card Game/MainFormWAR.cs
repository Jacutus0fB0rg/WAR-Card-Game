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
        const int CARDS_IN_DECK = 52, cardsInHalfDeck = 26;         // number of cards in a deck of playing cards

        Random rand = new Random();     // variable for generating random numbers

        bool isDeckSplit = false;       // flag to indicate that the deck of cards has been divided in half
                                        // (split into first half group and  second half group)
        bool isGamePlaying = false;     // flag to indicate that a game is currently being played

        // the deckOfPlayingCards variable is a List of GroupOfPlayingCards objects
        // each group is a List of PlayingCard objects
        // the intention is to model a deck of playing cards such that it can be broken down
        // into groups of cards so the cards may be manipulated as groups of cards
        List<GroupOfPlayingCards> deckOfPlayingCards = new List<GroupOfPlayingCards>();

        const int CARD_WIDTH = 116, CARD_HEIGHT = 178;  // measured card dimensions (experimentally determined)
        int halfCardWidth, halfCardHeight;              // the card width and height divided by two (used for centering the cards)
        const int SPLIT_CARD_OFFSET = 90;               // distance to move the first half of the deck left and second half of the deck right
                                                        // when splitting the deck of cards
        const int SPREAD_OFFSET = 25;                   // distance to displace the cards to the right when spreading a group of cards
        const int SPACING_GAP = 10;

        List<Player> warPlayers = new List<Player>();   // List of Player objects representing the players of the WAR card game

        int topPlayerIndex = 0, bottomPlayerIndex = 1;  // indexes into the warPlayers List for the Top Player and Bottom Player

        // new class variables
        // these indices are for referring to and accessing individual groups of cards
        int deckGroupIndex,                             // this index refers to the deck when it is a single group of cards - "The deck" 
            shuffleGroupIndex,                          // this index refers to a group used for shuffling the cards - "Shuffle"
            firstHalfGroupIndex,                        // this index refers to the group that is the first half of the deck when split
            secondHalfGroupIndex,                       // this index refers to the group that is the second half of the deck when split
            topPlayerGroupIndex,                        // this index refers to the group that is the cards the Top Player deals from
            bottomPlayerGroupIndex,                     // this index refers to the group that is the cards the Bottom Player deals from
            topPlayerWonCardsGroupIndex,                // this index refers to the group that is the cards the Top Player has won
            bottomPlayerWonCardsGroupIndex,             // this index refers to the group that is the cards the Bottom Player has won
            dealtCardsGroupIndex;                       // this index refers to the group that is the cards that are dealt

        Point formCenterPoint;              // this is the center point of the main form (MainFormWAR) 

        int centeredCardX, centeredCardY;   // these are the coordinates of the upper left corner (Location) of a card when it is
                                            // centered on the main form
        string keyString = "";

        CardReference selectedCardReference;
        string selectedCardString;

        // setup variables
        // coords for setting up positions of cards
        int setUpTPY, setUpBPY;                                 // Y coordinates for the cards the Top and Bottom Players deal from 
        int firstCardTPY, firstCardBPY;                         // Y coordinates for the cards the Top and Bottom Players deal to
        Point topPlayerLabelPoint, bottomPlayerLabelPoint;      // location of the Player's identifier, name and score labels

        // game variables
        int warLevel = 0;                                       // indicates how many iterations there have been of the current card "WAR"
        int round = 1;                                          // number of times cards have been dealt in the currently playing game
        DateTime gameStartTime,                                 // time at which the currently playing game began
            gameEndTime;                                        // time at which the most recently played game ended
        TimeSpan gameElapsedTime;                               // duration of the  currently playing or most recently played game

        IntroFormWAR startForm;                                 // instance of the Intro Form (used for entering the players names)
        public TestFormWAR testForm;                            // instance of the Test Form (used for running multiple autoplayed games
                                                                // for test purposes)

        ControlMode controlMode = ControlMode.UserGame;         // configuration of the user interface for different purposes

        bool awaitingReset = false,                             // flag indicating there is a currently playing game that is waiting to be reset
                                                                // (this allows the user(s) to see the state of the currently playing game when it ends)                             
            isAutoPlaying = false;                              // flag indicating that the currently playing game is autoplaying

        bool gameDefault = false;

        int dealtCardCount = 0;

        int warThreshold = 100;

        int drawMaxRounds = 10000;                              // the number of rounds at which a game will be declared a draw

        bool isMultiAutoPlaying = false;
        public int currentGame = 0;

        int minRounds, minIndex = 0, maxRounds, maxIndex = 0;
        List<int> roundList = new List<int>();
        List<string> durationList = new List<string>();

        public MainFormWAR()
        {
            InitializeComponent();
        }

        private void MainFormWAR_Load(object sender, EventArgs e)
        {
            // instantiate the intro form
            startForm = new IntroFormWAR();

            // while the intro form is not validated and the user hasn't chosen to end the program
            while (startForm.validation == false && startForm.endProgram == false)
            {
                // display and turn control over to the intro form
                startForm.ShowDialog();
            }

            // if the intro form's endProgram flag is set
            if (startForm.endProgram == true)
            {
                // end the program
                this.Close();
            }
            // if the intro form's endProgram flag is not set
            else
            {
                // display the welcome message in the commentary label
                lblCommentary.Text = "Welcome WAR Players " + startForm.txtBxTopPlayerName.Text + " and "
                    + startForm.txtBxBottomPlayerName.Text + "! " + startForm.txtBxTopPlayerName.Text +
                    ", you're the Top Player and " + startForm.txtBxBottomPlayerName.Text +
                    ", you're the Bottom Player! Follow the instructions to begin playing!";

                // update the output label
                UpdateOutputLabel();

                // begin the the initial setup of the program
                IntialSetup();
            }

        }

        private void UpdateOutputLabel()
        {
            // if the control mode is set to card manipulation mode
            if (controlMode == ControlMode.CardManipulation)

                // display the appropriate message in the output label along with the card name of the selected card
                lblOutput.Text = "Instructions: Right click to select options!\nSelected card is " + selectedCardString;

            // if the control mode is set to user game mode
            else if (controlMode == ControlMode.UserGame)
            {
                // if a game is not currently being played and is not awaiting reset
                if (isGamePlaying == false && awaitingReset == false)
                {
                    // display the message telling the user to select either the "Start WAR Card Game" option or the "AutoPlay Game" option
                    lblOutput.Text = "Instructions: Right click and select the \"Start WAR Card Game \" option for manual game play!" +
                        " Select \"AutoPlay Game\" for automatic game play!";
                }
                // if a game is currently being played but is not awaiting reset
                else if (isGamePlaying == true && awaitingReset == false)
                {
                    // if the game is not autoplaying 
                    if (isAutoPlaying == false)
                    {
                        // if the "Compare Cards" Context Menu item is disabled
                        if (compareCardsToolStripMenuItem.Enabled == false)
                            // display a message telling the  user to either select the "Deal Cards" or "Auto Play Game" options
                            lblOutput.Text = "Instructions: Right click, select \"Play WAR Card Game\" then select \"Deal Cards\"!" +
                                " Select \"AutoPlay Game\" to continue automatically!";
                        // if  the "Deal Cards" Context Menu item is disabled
                        else if (dealCardsToolStripMenuItem.Enabled == false)
                            // display a message telling the user to either select the "Compare Cards" or "AuoPlay Game" options
                            lblOutput.Text = "Instructions: Right click, select \"Play WAR Card Game\" then select \"Compare Cards\"!" +
                                 " Select \"AutoPlay Game\" to continue automatically!";
                    }
                    // if the game is autoplaying
                    else
                    {
                        // display a message telling the  user to select the "Stop AutoPlay" option if they want to return to playing manually
                        lblOutput.Text = "Instructions: Right click and select the \"Stop AutoPlay\" option to return to manual game play!";
                    }
                }
            }
        }

        private void IntialSetup()
        {
            // calculate values of the halfCardWidth and halfCardHeight variables
            CalculateHalfWidthAndHeight();

            // create all the cards, groups of cards and WAR Players game objects
            CreateCardGroupsAndWARPlayers();

            // create an index to reference the deck of cards as a whole 
            deckGroupIndex = ReturnGroupIndexGivenIdentifier("The deck");

            // rearrange the deck of cards so the cards are in the order of a brand new deck of cards
            SetInitialCardOrder();

            // create an index to the group of cards used for shuffling any group of cards
            shuffleGroupIndex = ReturnGroupIndexGivenIdentifier("Shuffle");

            // create an index to the group of cards that will represent the first half of the deck when it is split
            firstHalfGroupIndex = ReturnGroupIndexGivenIdentifier("First Half");

            // create an index to the group of cards that will represent the second half of the deck when it is split
            secondHalfGroupIndex = ReturnGroupIndexGivenIdentifier("Second Half");

            // create an index to the group of cards that will represent the Top Player's cards (the cards from which the Top Player will deal)
            topPlayerGroupIndex = ReturnGroupIndexGivenIdentifier("Top Player cards");

            // create an index to the group of cards that will represent the Bottom Player's cards (the cards from which the Bottom Player will deal)
            bottomPlayerGroupIndex = ReturnGroupIndexGivenIdentifier("Bottom Player cards");

            // create an index to the group of cards that will represent the cards won by the Top Player during a game
            topPlayerWonCardsGroupIndex = ReturnGroupIndexGivenIdentifier("Top Player won cards");

            // create an index to the group of cards that will represent the cards won by the Bottom Player during a game
            bottomPlayerWonCardsGroupIndex = ReturnGroupIndexGivenIdentifier("Bottom Player won cards");

            // create an index to the group of cards that will represent the cards dealt during a game
            dealtCardsGroupIndex = ReturnGroupIndexGivenIdentifier("Dealt cards");

            // calculate the center point of the application form
            formCenterPoint = CalculateCenterPointOfForm();

            // calculate the X coordinate of the upper left hand corner of a card that is centered on the application form
            centeredCardX = formCenterPoint.X - halfCardWidth;

            // calculate the Y coordinate of the upper left hand corner of a card that is centered on the application form
            centeredCardY = formCenterPoint.Y - halfCardHeight;

            // calculate the Y coordinate of the upper left hand corner of a card that is positioned where the Top Player will deal from
            setUpTPY = formCenterPoint.Y - (formCenterPoint.Y / 2) - (formCenterPoint.Y / 4) - halfCardHeight;

            // calculate the Y coordinate of the upper left hand corner of a card that is positioned where the Bottom Player will deal from
            setUpBPY = formCenterPoint.Y + (formCenterPoint.Y / 2) + (formCenterPoint.Y / 4) - halfCardHeight;

            // calculate the Y coordinate of the upper left hand corner of a card that is positioned where the Top Player will deal to
            firstCardTPY = formCenterPoint.Y - (formCenterPoint.Y / 4) - halfCardHeight;

            // calculate the Y coordinate of the upper left hand corner of a card that is positioned where the Bottom Player will deal to
            firstCardBPY = formCenterPoint.Y + (formCenterPoint.Y / 4) - halfCardHeight;

            // gather the deck of cards at the position at which they are centered on the application form
            GatherGroupOfCards(centeredCardX, centeredCardY, deckGroupIndex);
        }

        private Point GetContextMenuLocation()
        {
            // instantiate the zero point
            Point zeroPoint = new Point(0, 0);

            // get the zero point (location) of the Context Menu (in screen coordinates)
            Point cmPoint = cntxtMnStrpCardControl.PointToScreen(zeroPoint);

            // calculate the location of the Context Menu in client coordinates relative to the application form
            int cmX = cmPoint.X - this.Location.X;
            int cmY = cmPoint.Y - this.Location.Y;

            // convert the Context Menu's location point to client coordinates relative to the application form
            cmPoint.X = cmX;
            cmPoint.Y = cmY;

            // return the Context Menu's location in client coordinates relative to the application form
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
                int groupCount = deckOfPlayingCards[deckGroupIndex].GetCount();
                int spreadWidth = CARD_WIDTH + SPREAD_OFFSET * (groupCount - 1);
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
            // enable and make visible the Gather Deck => First Half Context Menu item
            gatherFirstHalfToolStripMenuItem.Visible = true;
            gatherFirstHalfToolStripMenuItem.Enabled = true;

            // enable and make visible the Gather Deck => Second Half Context Menu item
            gatherSecondHalfToolStripMenuItem.Visible = true;
            gatherSecondHalfToolStripMenuItem.Enabled = true;

            // enable and make visible the Spread Deck => First Half Context Menu item
            spreadFirstHalfToolStripMenuItem.Visible = true;
            spreadFirstHalfToolStripMenuItem.Enabled = true;

            // enable and make visible the Spread Deck => Second Half Context Menu item
            spreadSecondHalfToolStripMenuItem.Visible = true;
            spreadSecondHalfToolStripMenuItem.Enabled = true;

            // enable and make visible the Shuffle Deck => First Half Context Menu item
            shuffleFirstHalfToolStripMenuItem.Visible = true;
            shuffleFirstHalfToolStripMenuItem.Enabled = true;

            // enable and make visible the Shuffle Deck => Second Half Context Menu item
            shuffleSecondHalfToolStripMenuItem.Visible = true;
            shuffleSecondHalfToolStripMenuItem.Enabled = true;

            // enable and make visible the Join Deck Context Menu item
            joinDeckToolStripMenuItem.Visible = true;
            joinDeckToolStripMenuItem.Enabled = true;

            // disable and make invisible the Split Deck Context Menu item
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
            // check if the control mode is set to CardManipulation
            if (controlMode == ControlMode.CardManipulation)
                // if the control mode is set to CardManipulation, configure the Context Menu for the deck being split
                ConfigureContextMenuForSplitDeck();

            int deckGroupCount = deckOfPlayingCards[deckGroupIndex].GetCount();     // number of cards in the deckGroup
            int halfDeckGroupCount = deckGroupCount / 2;                            // half of the number of cards in the deckGroup

            // split the deck of cards into first half and second half

            // loop through the first half of the deckGroup
            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                // get the current card from the deckGroup and add it to the firstHalfGroup
                deckOfPlayingCards[firstHalfGroupIndex].AddCardToGroup(deckOfPlayingCards[deckGroupIndex].GetCard(c));
            }

            // loop through the second half of the deckGroup
            for (int c = halfDeckGroupCount; c < deckGroupCount; c++)
            {
                // get the current card from the deckGroup and add it to the secondHalfGroup
                deckOfPlayingCards[secondHalfGroupIndex].AddCardToGroup(deckOfPlayingCards[deckGroupIndex].GetCard(c));
            }

            // loop through the deckGroup once for each card
            for (int c = 0; c < deckGroupCount; c++)
            {
                // remove the first card from the remaining cards in the deckGroup
                deckOfPlayingCards[deckGroupIndex].RemoveCardFromGroup(0);
            }

            // relocate the two half decks to either side of the location of the Context Menu

            // get the location point of the Context Menu
            Point cmLocationPoint = GetContextMenuLocation();

            // calculate the location coordinates of a card centered on the location point of the Context Menu
            int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;

            // gather the first half of the deck offset to the left of the location point centered on the Context Menu
            GatherGroupOfCards(topLeftCornerX - SPLIT_CARD_OFFSET, topLeftCornerY, firstHalfGroupIndex);

            // gather the second half of the deck offset to the right of the location point centered on the Context Menu
            GatherGroupOfCards(topLeftCornerX + SPLIT_CARD_OFFSET, topLeftCornerY, secondHalfGroupIndex);

            // set the flag which indicates whether the deck is split or not
            isDeckSplit = true;
        }

        private void JoinTheDeck(object sender, EventArgs e)
        {
            ConfigureContextMenuForJoinDeck();

            int halfDeckGroupCount = deckOfPlayingCards[firstHalfGroupIndex].GetCount(); ;

            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //
                //deckOfCards.Add(firstHalfOfDeck[c]);
                deckOfPlayingCards[deckGroupIndex].AddCardToGroup(deckOfPlayingCards[firstHalfGroupIndex].GetCard(c));
            }


            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //firstHalfOfDeck.RemoveAt(0);
                deckOfPlayingCards[firstHalfGroupIndex].RemoveCardFromGroup(0);

            }

            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //
                //deckOfCards.Add(firstHalfOfDeck[c]);
                deckOfPlayingCards[deckGroupIndex].AddCardToGroup(deckOfPlayingCards[secondHalfGroupIndex].GetCard(c));
            }

            for (int c = 0; c < halfDeckGroupCount; c++)
            {
                //firstHalfOfDeck.RemoveAt(0);
                deckOfPlayingCards[secondHalfGroupIndex].RemoveCardFromGroup(0);

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
                int groupCount = deckOfPlayingCards[firstHalfGroupIndex].GetCount();
                int spreadWidth = CARD_WIDTH + SPREAD_OFFSET * (groupCount - 1);
                int startingX = topLeftCornerX - (spreadWidth / 2);
                //formCenterPoint.X
                Size formSize = this.Size;

                if (startingX < SPACING_GAP)
                    startingX = SPACING_GAP;
                else if (startingX + spreadWidth > formSize.Width)
                    startingX = formSize.Width - spreadWidth - SPACING_GAP;

                SpreadGroupOfCards(startingX, topLeftCornerY, firstHalfGroupIndex);
            }
        }

        private void SpreadTheSecondHalfOfDeck(object sender, EventArgs e)
        {

            if (isDeckSplit == true)
            {
                Point cmLocationPoint = GetContextMenuLocation();

                int topLeftCornerX = cmLocationPoint.X - halfCardWidth, topLeftCornerY = cmLocationPoint.Y - halfCardHeight;
                int groupCount = deckOfPlayingCards[secondHalfGroupIndex].GetCount();
                int spreadWidth = CARD_WIDTH + SPREAD_OFFSET * (groupCount - 1);
                int startingX = topLeftCornerX - (spreadWidth / 2);
                //formCenterPoint.X
                Size formSize = this.Size;

                if (startingX < SPACING_GAP)
                    startingX = SPACING_GAP;
                else if (startingX + spreadWidth > formSize.Width)
                    startingX = formSize.Width - spreadWidth - SPACING_GAP;

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
            // instantiate the center point
            Point centerPoint = new Point();

            // get the size of the application form
            Size formSize = this.Size;

            // divide the form size width by two and store in centerPoint X
            centerPoint.X = formSize.Width / 2;

            // divide the form size heght by two and store in centerPoint Y
            centerPoint.Y = formSize.Height / 2;

            // return the center point
            return centerPoint;
        }

        private void CalculateHalfWidthAndHeight()
        {
            // divide the measured card width by two and store in halfCardWidth
            halfCardWidth = CARD_WIDTH / 2;

            // divide the measured card height by two and store in halfCardHeight
            halfCardHeight = CARD_HEIGHT / 2;
        }


        private void CreateCardGroupsAndWARPlayers()
        {
            // create card group zero (representing the deck of cards as a whole) - "The deck"
            GroupOfPlayingCards groupZero = new GroupOfPlayingCards();

            // set the identifier for group zero - "The deck"
            groupZero.Identifier = "The deck";

            // loop through the number of cards in a deck of cards
            for (int card = 0; card < CARDS_IN_DECK; card++)
            {
                // create the individual card assigning its card number which uniquely identifies each card
                // in the deck
                PlayingCard currentCard = new PlayingCard(card);

                // set the event handler for the ClearOutputLabel event generated by the playing cards when they are selected
                // so they can identify themselves in Card Manipulation mode
                currentCard.ClearOutputLabel += OnClearOutputLabel;

                // set the face image of each card from the PlayingCardFaces ImageList images
                currentCard.SetCardFaceImage(imgLstPlayingCardFaces.Images[currentCard.FaceImageIndex()]);

                // add the picturebox of each card to the application form
                this.Controls.Add(currentCard.pctrBxCard);

                // add the card to the deck
                groupZero.AddCardToGroup(currentCard);
            }

            // set the back image from element zero of the PlayingCardFaces ImageList images
            // the back image is a static variable in the PlayingCard class so it is shared by all the cards
            // since all cards look the same from the back they can use the same image
            PlayingCard cardZero = groupZero.GetCard(0);
            cardZero.SetCardBackImage(imgLstPlayingCardFaces.Images[0]);

            // add the cards to the deck
            deckOfPlayingCards.Add(groupZero);

            // instantiate groupOne
            GroupOfPlayingCards groupOne = new GroupOfPlayingCards();

            // set the identifier of groupOne - this is the group that is used when shuffling any other group
            // cards are randomly removed from the target group and added to the shuffle group then randomly removed from
            // the shuffle group and added back to the target group
            groupOne.Identifier = "Shuffle";

            // add groupOne to the deck
            deckOfPlayingCards.Add(groupOne);

            // instantiate groupTwo
            GroupOfPlayingCards groupTwo = new GroupOfPlayingCards();

            // set the identifier of groupTwo - this group is the first half of the deck when the deck is split
            groupTwo.Identifier = "First Half";

            // add groupTwo to the deck
            deckOfPlayingCards.Add(groupTwo);

            // instantiate groupThree
            GroupOfPlayingCards groupThree = new GroupOfPlayingCards();

            // set the identifier of groupThree - this group is the second half of the deck when the deck is split
            groupThree.Identifier = "Second Half";

            // add groupThree to the deck
            deckOfPlayingCards.Add(groupThree);

            // instantiate groupFour
            GroupOfPlayingCards groupFour = new GroupOfPlayingCards();

            // set the identifier of groupFour - this is the group that the Top Player will deal from during a game
            groupFour.Identifier = "Top Player cards";

            // add groupFour to the deck
            deckOfPlayingCards.Add(groupFour);

            // instantiate groupFive
            GroupOfPlayingCards groupFive = new GroupOfPlayingCards();

            // set the identifier of groupFive - this is the group that the Bottom Player will deal from during a game
            groupFive.Identifier = "Bottom Player cards";

            // add groupFive to the deck
            deckOfPlayingCards.Add(groupFive);

            // instantiate groupSix
            GroupOfPlayingCards groupSix = new GroupOfPlayingCards();

            // set the identifier of groupSix - this is the group of cards that the Top Player wins during a game
            groupSix.Identifier = "Top Player won cards";

            // add groupSix to the deck
            deckOfPlayingCards.Add(groupSix);

            // instantiate groupSeven
            GroupOfPlayingCards groupSeven = new GroupOfPlayingCards();

            // set the identifier of groupSeven - this is the group of cards that the Bottom Player wins during a game
            groupSeven.Identifier = "Bottom Player won cards";

            // add groupSeven to the deck
            deckOfPlayingCards.Add(groupSeven);

            // instantiate groupEight
            GroupOfPlayingCards groupEight = new GroupOfPlayingCards();

            // set the identifier of groupEight - this is the group of cards that are dealt during a game
            groupEight.Identifier = "Dealt cards";

            // add groupEight to the deck
            deckOfPlayingCards.Add(groupEight);

            // instantiate the Top Player player object
            Player topPlayer = new Player();

            // instantiate the Bottom Player player object
            Player bottomPlayer = new Player();

            // set the identifier of the Top Player player object to "Top Player"
            topPlayer.Identifier = "Top Player";

            // set the identifier of the Bottom Player player object to "Bottom Player"
            bottomPlayer.Identifier = "Bottom Player";

            // add the Top Player player object to the List of WAR players
            warPlayers.Add(topPlayer);

            // add the Bottom Player player object to the List of WAR players
            warPlayers.Add(bottomPlayer);
        }

        public void OnClearOutputLabel(object sender, string e)
        {
            selectedCardString = e;
            UpdateOutputLabel();
        }

        private void SetInitialCardOrder()
        {
            // rearrange the deck so it has the card order of a brand new deck of cards, which is:
            // A 2 3 4 5 6 7 8 9 10 J Q K for each suit in the order Spades, Diamonds, Clubs, Hearts
            // (the cards need to be created in the order: 2 3 4 5 6 7 8 9 10 J Q K A for each suit for the methods that get the face value
            // and the suit of the card to work)

            PlayingCard removedCard;            // card removed from the deck

            // starting with the twelfth card to remove and the zero postion to insert, continue until the fifty-first card is removed,
            // incrementing by thirteen
            for (int rC = 12, iC = 0; rC <= 51; rC += 13, iC += 13)
            {
                // get the Ace of the current suit (initially the twelfth card)
                removedCard = deckOfPlayingCards[deckGroupIndex].GetCard(rC);

                // remove the Ace of the current suit
                deckOfPlayingCards[deckGroupIndex].RemoveCardFromGroup(rC);

                // insert the Ace in front of the Two card of the current suit (the zero position)
                deckOfPlayingCards[deckGroupIndex].InsertCardToGroup(removedCard, iC);
            }

        }

        private void GatherGroupOfCards(int xCoord, int yCoord, int groupIndex)
        {
            int groupCount = deckOfPlayingCards[groupIndex].GetCount();     // the count of cards in the target group
            int offset = 0;                                                 // value to add to the X and Y coordinates so the cards are stacked
                                                                            // slightly spread out so the deck appears to have a little 
                                                                            // three-dimensional height
                                                                            // if there are cards in the group    
            if (groupCount > 0)
            {
                // starting with the last card, loop backward through the cards counting down
                for (int card = groupCount - 1; card >= 0; card--)
                {
                    // calculate the offset
                    offset = card / 5;

                    // set the position of the card on the application form
                    deckOfPlayingCards[groupIndex].Group[card].SetLocation(xCoord + offset, yCoord + offset);

                    // set the card so it is facing down
                    deckOfPlayingCards[groupIndex].Group[card].TurnCardDown();

                    // display the back image of the card
                    deckOfPlayingCards[groupIndex].Group[card].DisplayCardImage();

                    // bring the cards picturebox to the front so the card is on top of the previous cards
                    deckOfPlayingCards[groupIndex].Group[card].pctrBxCard.BringToFront();
                }

                // set the state of the target group to Gathered
                deckOfPlayingCards[groupIndex].State = State.Gathered;

                // instantiate the gather point for the Location property of the target group
                Point groupLocation = new Point(xCoord, yCoord);

                // set the Location property of the target group to the gather point
                deckOfPlayingCards[groupIndex].Location = groupLocation;

            }
            // if there are no cards in the group
            else
                // display an error message
                MessageBox.Show("Attempted to gather an empty group of cards.\nIdentifier = " + deckOfPlayingCards[groupIndex].Identifier);
        }

        private void SpreadGroupOfCards(int xCoord, int yCoord, int groupIndex)
        {

            int groupCount = deckOfPlayingCards[groupIndex].GetCount();     // number of cards in the target group of cards

            // check to see if there are cards in the target group to be spread
            if (groupCount > 0)
            {
                // loop through once for each card in the target group
                for (int card = 0; card < groupCount; card++)
                {
                    // set the position of the current card on the application form
                    deckOfPlayingCards[groupIndex].Group[card].SetLocation(card * SPREAD_OFFSET + xCoord, yCoord);

                    // turn up the current card
                    deckOfPlayingCards[groupIndex].Group[card].TurnCardUp();

                    // display the face image of the current card
                    deckOfPlayingCards[groupIndex].Group[card].DisplayCardImage();

                    // bring the picturebox of the current card to the front so it is over the previous card
                    deckOfPlayingCards[groupIndex].Group[card].pctrBxCard.BringToFront();
                }

                // set the state of the target group of cards to Spread
                deckOfPlayingCards[groupIndex].State = State.Spread;

                // create a new point to set the Location property of the target group
                Point groupLocation = new Point(xCoord, yCoord);

                // set the Location property of the target group which positions the group at the target coordinates
                deckOfPlayingCards[groupIndex].Location = groupLocation;

            }
            // if there are no cards in the target group
            else
                // display an error message indicating an attempt was made to spread an empty group and include the identifier of the target group
                MessageBox.Show("Attempted to spread an empty group of cards.\nIdentifier = " + deckOfPlayingCards[groupIndex].Identifier);

        }

        private void ShuffleGroupOfCards(int groupIndex)
        {

            int shuffleIndex;                                               // randomly chosen index into the group of cards to be shuffled
            int groupCount = deckOfPlayingCards[groupIndex].GetCount();     // number of cards in the target group of cards

            // check to see if there are cards in the target group to be shuffled
            if (groupCount > 0)
            {
                // loop through once for each card in the target group 
                for (int c = 0; c < groupCount; c++)
                {
                    // randomly pick a card from the remaining cards in the target group
                    shuffleIndex = rand.Next(deckOfPlayingCards[groupIndex].GetCount());

                    // add the randomly chosen card from the target group into the shuffle group
                    deckOfPlayingCards[shuffleGroupIndex].AddCardToGroup(deckOfPlayingCards[groupIndex].GetCard(shuffleIndex));

                    // remove the randomly chosen card from the target group
                    deckOfPlayingCards[groupIndex].RemoveCardFromGroup(shuffleIndex);

                }

                // loop through once for each card in the shuffle group
                for (int c = 0; c < groupCount; c++)
                {
                    // randomly pick a card from the remaining cards in the shuffle group
                    shuffleIndex = rand.Next(deckOfPlayingCards[shuffleGroupIndex].GetCount());

                    // add the randomly chosen card from the shuffle group back to the target group
                    deckOfPlayingCards[groupIndex].AddCardToGroup(deckOfPlayingCards[shuffleGroupIndex].GetCard(shuffleIndex));

                    // remove the randomly chosen card from the shuffle group
                    deckOfPlayingCards[shuffleGroupIndex].RemoveCardFromGroup(shuffleIndex);
                }

                //if the target group is in the gathered state 
                if (deckOfPlayingCards[groupIndex].State == State.Gathered)
                {
                    // gather the group of cards at the target group's location
                    GatherGroupOfCards(deckOfPlayingCards[groupIndex].Location.X, deckOfPlayingCards[groupIndex].Location.Y, groupIndex);
                }
                // if the target group is in the spread state
                else if (deckOfPlayingCards[groupIndex].State == State.Spread)
                {
                    // spread the target group of cards at the target group's location
                    SpreadGroupOfCards(deckOfPlayingCards[groupIndex].Location.X, deckOfPlayingCards[groupIndex].Location.Y, groupIndex);
                }


            }
            // if there are no cards in the target group
            else
                // display an error message indicating an attempt was made to shuffle an empty group and include the identifier of the target group
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
                while (!found && card < deckOfPlayingCards[group].GetCount())
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
            int i = 0,                      // index of the curent group whose identifier is being checked for a match to the target identifier
                index = -1;                 // index of the group whose identifier matches the target identifier
            bool found = false;             // flag indicating whether or not a match was found

            // while a match has not been found and the index of the current group is less than the count of groups in the deck
            while (!found && i < deckOfPlayingCards.Count)
            {
                // if the current group's identifier matches the target identifier
                if (deckOfPlayingCards[i].Identifier.ToLower() == targetIdentifier.ToLower())
                {
                    // set the index of the matching group equal to the index of the current group
                    index = i;

                    // set the flag to indicate a match was found
                    found = true;
                }
                // if current group's identifier doesn't match the target identifier
                else
                    // keeping looking by incrementing the current group index
                    i++;
            }

            // if index was not found
            if (!found)
                // display an error message
                MessageBox.Show("Group \"" + targetIdentifier + "\" index not found");

            // return the index of the group whose identifier matches the target identifier
            return index;
        }

        private void TransferFirstGroupOfCardsToSecondGroup(int group1Index, int group2Index)
        {
            int group1Count = deckOfPlayingCards[group1Index].GetCount();       // number of cards in the target group 1

            // check if there are cards in the target group 1
            if (group1Count > 0)
            {
                // add cards from group 1 to group 2

                // loop through the cards in target group 1
                for (int c = 0; c < group1Count; c++)
                {
                    // get the currently indexed card from the target group 1 and add it to the target group 2
                    deckOfPlayingCards[group2Index].AddCardToGroup(deckOfPlayingCards[group1Index].GetCard(c));
                }

                // loop through the cards in target group 1 once for each card
                for (int c = 0; c < group1Count; c++)
                {
                    // remove first card from the remaining cards in target group 1
                    deckOfPlayingCards[group1Index].RemoveCardFromGroup(0);
                }

            }
            // if there are no cards in target group 1
            else
                // display an error message indicating that an attempt was made to transfer an empty group which includes the target group 1 identifier
                MessageBox.Show("Attempted to transfer an empty group of cards.\nIdentifier = " + deckOfPlayingCards[group1Index].Identifier);
        }

        private void TransferFirstCardOfFirstGroupToSecondGroup(int group1Index, int group2Index)
        {
            int group1Count = deckOfPlayingCards[group1Index].GetCount();           // number of cards in target group 1

            // check that there are cards in the target group 1
            if (group1Count > 0)
            {
                // get the first card from target group 1 and add it to target group 2
                deckOfPlayingCards[group2Index].AddCardToGroup(deckOfPlayingCards[group1Index].GetCard(0));

                // remove the first card from target group 1
                deckOfPlayingCards[group1Index].RemoveCardFromGroup(0);
            }
            // if there are no cards in target group 1
            else
                // display an error messaage that an attempt was made to transfer a card from an empty group and include the target group 1 identifier
                MessageBox.Show("Attempted to transfer a card from an empty group of cards.\nIdentifier = " + deckOfPlayingCards[group1Index].Identifier);
        }

        private void SetUpToPlayWAR()
        {
            // check if the deck is split 
            if (isDeckSplit == true)
            {
                // if the deck is split

                // set the warLevel to zero (indicating that there currently is no "WAR")
                warLevel = 0;

                gameDefault = false;

                // gather the first half of the deck at the point at which the Top Player will deal cards from
                GatherGroupOfCards(centeredCardX, setUpTPY, firstHalfGroupIndex);

                // gather the second half of the deck at the point at which the Bottom Player will deal cards from
                GatherGroupOfCards(centeredCardX, setUpBPY, secondHalfGroupIndex);

                // transfer the first half group to the topPlayer group
                TransferFirstGroupOfCardsToSecondGroup(firstHalfGroupIndex, topPlayerGroupIndex);

                // transfer the second half group to the bottomPlayer group 
                TransferFirstGroupOfCardsToSecondGroup(secondHalfGroupIndex, bottomPlayerGroupIndex);

                // set player names

                // read the Top Player's name from the Top Player Name textbox on the Intro Form to the Name property of the Top Player player object
                // in the warPlayers List
                warPlayers[topPlayerIndex].Name = startForm.txtBxTopPlayerName.Text;

                // read the Bottom Player's name from the Bottom Player Name textbox on the Intro Form to the Name property of the Bottom Player player 
                // object in the warPlayers List
                warPlayers[bottomPlayerIndex].Name = startForm.txtBxBottomPlayerName.Text;

                // set player starting scores

                // set the Top Player player object's Score property from the number of cards in the topPlayer group
                warPlayers[topPlayerIndex].Score = deckOfPlayingCards[topPlayerGroupIndex].GetCount();

                // set the Bottom Player player object's Score property from the number of cards in the bottomPlayer group
                warPlayers[bottomPlayerIndex].Score = deckOfPlayingCards[bottomPlayerGroupIndex].GetCount();

                // set the text of the Top Player's identifier, name and score label
                lblTopPlayer.Text = warPlayers[topPlayerIndex].Identifier + ": " + warPlayers[topPlayerIndex].Name + "\nScore: " + warPlayers[topPlayerIndex].Score;

                // instantiate the point for setting the location of the Top Player's identifier, name and score label
                topPlayerLabelPoint = new Point();

                // calculate the X coordinate for setting the location of the Top Player's identifier, name and score label 
                topPlayerLabelPoint.X = centeredCardX + CARD_WIDTH + SPACING_GAP;

                // calculate the Y coordinate for setting the location of the Top Player's identifier, name and score label
                topPlayerLabelPoint.Y = setUpTPY + (CARD_HEIGHT / 3);

                // make the Top Player's identifier, name and score label visible
                lblTopPlayer.Visible = true;

                // set the text of the Bottom Player's identifier, name and score label
                lblBottomPlayer.Text = warPlayers[bottomPlayerIndex].Identifier + ": " + warPlayers[bottomPlayerIndex].Name + "\nScore: " + warPlayers[bottomPlayerIndex].Score;

                // instantiate the point for setting the location of the Bottom Player's identifier, name and score label
                bottomPlayerLabelPoint = new Point();

                // calculate the X coordinate for setting the location of the Bottom Player's identifier, name and score label
                bottomPlayerLabelPoint.X = centeredCardX - lblBottomPlayer.Size.Width - 30;

                // calculate the Y coordinate for setting the location of the Bottom Player's identifier, name and score label
                bottomPlayerLabelPoint.Y = setUpBPY + (CARD_HEIGHT / 3);

                // make the Bottom Player's identifier, name and score label visible
                lblBottomPlayer.Visible = true;

                // set the position of the Top Player's identifier, name and score label on the application form
                lblTopPlayer.Location = topPlayerLabelPoint;

                // set the position of the Bottom Player's identifier, name and score label on the application form
                lblBottomPlayer.Location = bottomPlayerLabelPoint;

                // set the flag indicating that a game is now playing
                isGamePlaying = true;

            }
        }

        private void PlayWAR(object sender, EventArgs e)
        {
            // check if a game is already playing
            if (isGamePlaying == false)
            {
                // if no game is currently playing, check if the deck is split
                if (isDeckSplit == false)
                {
                    // if no game is playing and the deck is not split
                    // loop ten times
                    for (int i = 1; i <= 10; i++)
                    {
                        // shuffle the deckGroup
                        ShuffleGroupOfCards(deckGroupIndex);
                    }
                }

                // split the deckGroup
                SplitTheDeck(sender, e);

                // set up to play a WAR card game
                SetUpToPlayWAR();

                // change the text on the start WAR card game context menu item 
                startWARCardGameToolStripMenuItem.Text = "Play War Card Game";

                // get the game start time
                gameStartTime = DateTime.Now;

                // set the Game Start Time label text
                lblGameStartTime.Text = "Game Start Time: " + gameStartTime.ToString("hh:mm:ss tt");

                // make the Game Start Time label visible
                lblGameStartTime.Visible = true;

                // make the Game Duration label visible
                lblGameDuration.Visible = true;

                // set the Round label text 
                lblRound.Text = "Round\n" + round;

                // make the Round label visible
                lblRound.Visible = true;

                // enable the Deal Cards Context Menu item
                dealCardsToolStripMenuItem.Enabled = true;

                // make the Deal Cards Context Menu item visible
                dealCardsToolStripMenuItem.Visible = true;

                // disable the Compare Cards Context Menu item
                compareCardsToolStripMenuItem.Enabled = false;

                // make the Compare Cards Context Menu item visible so the user will know they can select it in the future
                compareCardsToolStripMenuItem.Visible = true;

                // update the Output label
                UpdateOutputLabel();
            }
        }

        async public Task AutoPlayMultipleGames(object sender, EventArgs e)
        {
            
            int numberOfGames,                          // number of games to be autoplayed
                game;                                   // number of the current game being autoplayed
                   
            // check to see if autoplaying multiple games is not already ongoing
            if (isMultiAutoPlaying == false)
            {
                // if autoplaying multiple games is not already ongoing, set the flag indicating that autoplaying multiple games
                // is now ongoing
                isMultiAutoPlaying = true;

                // get the number of games to autoplay from the test form;
                if (int.TryParse(testForm.txtBxNumberOfGameRuns.Text, out numberOfGames))
                {
                    // if numberOfGames is valid

                    // check to see if number of games is greater than zero
                    if (numberOfGames > 0)
                    {
                        // check to see that autoplaying multiple games is not picking up from where it was stopped
                        if (currentGame == 0)
                        {
                            // if autoplaying multiple games is not picking up from where it was stopped, start autoplaying multiple games
                            // from the first game
                            game = 1;
                        }
                        // check to see that autoplaying multiple games is picking up from where it was stopped
                        else
                            // if autoplaying multiple games is picking up from where it was stopped, start autoplaying multiple games
                            // from the game where this method left off
                            game = currentGame;

                        // loop through autoplaying games until the numberOfGames have been autoplayed or autoplaying is stopped by the user(s)
                        while (game <= numberOfGames && isMultiAutoPlaying == true)
                        {
                            // display on the testform the number of the current game being autoplayed
                            testForm.lblCurrentGameRunning.Text = "Current game running: " + game;

                            // if a game was being autoplayed (but not multi-autoplayed)
                            if (isAutoPlaying == true)
                            {
                                // stop the autoplaying playing game so it can be finished as one of the multiple autoplayed games
                                isAutoPlaying = false;
                            }

                            // if a manual or autoplaying game is not finished (awaitingReset) or a new game is ready to be played
                            if (awaitingReset == false)
                                // then play through the unfinished game or play through a new game
                                await AutoPlayGame(sender, e);

                            // check if the autoplayed game returned unfinished (perhaps stopped by the user(s))
                            if (awaitingReset == false)
                            {
                                // save where this method is leaving off (the number of the game in progress) 
                                currentGame = game;
                                // stop multi-autoplaying
                                isMultiAutoPlaying = false;
                                // re-enable the Engage button on the testForm
                                testForm.btnEngage.Enabled = true;

                            }
                            // check if the game in progress returned finished
                            else if (awaitingReset == true)
                            {
                                // if the game in progress is finished

                                // gather information about the game for the testForm game info display
                                string defaultStatus = "";

                                // if the game default flag is set, set the status to DEFAULT
                                if (gameDefault == true)
                                    defaultStatus = "DEFAULT";
                                else
                                {
                                    // otherwise, check if the top player won
                                    if (warPlayers[topPlayerIndex].Score == CARDS_IN_DECK)
                                        // if the top player won, set the status to TP WIN
                                        defaultStatus = "_____TP_WIN";
                                    // check if the bottom player won
                                    else if (warPlayers[bottomPlayerIndex].Score == CARDS_IN_DECK)
                                        // if the bottom player, won set the  status to BP WIN
                                        defaultStatus = "_____BP_WIN";
                                    // check if the game was a draw
                                    else if (warPlayers[topPlayerIndex].Score == warPlayers[bottomPlayerIndex].Score)
                                        // if the game was a draw, set the status to DRAW
                                        defaultStatus = "______DRAW";
                                }
                                
                                // get the string representation of how long the game lasted
                                string gameDurationString = GetGameDuration();
                                
                                // make the string representation of all the game info
                                string listString = game.ToString().PadRight(10- game.ToString().Length) + gameStartTime.ToString("hh:mm:ss tt").PadLeft(20)
                                    + gameEndTime.ToString("hh:mm:ss tt").PadLeft(18) + gameDurationString.PadLeft(14,'_') 
                                    + round.ToString().PadLeft(10 - round.ToString().Length) + defaultStatus.PadLeft(10,'_') 
                                    + warLevel.ToString().PadLeft(10) + warPlayers[topPlayerIndex].Score.ToString().PadLeft(10) + 
                                    warPlayers[bottomPlayerIndex].Score.ToString().PadLeft(10) +
                                     dealtCardCount.ToString().PadLeft(10);
                                
                                // add the number of rounds the game lasted to the round list
                                roundList.Add(round);

                                // add the game duration to the duration list
                                durationList.Add(gameDurationString);

                                // add the game info to the Games Info Display listbox on the testform
                                testForm.lstBxGamesInfoDisplay.Items.Add(listString);

                                // find the minimum number of rounds of all the games autoplayed and the index to the game that had the minimum

                                // set the minimum number of rounds to the first number of rounds in the round list
                                minRounds = roundList[0];

                                // loop through the round list searching for the minimum number of rounds
                                for (int r = 0; r < roundList.Count; r++)
                                {
                                    // if the current number of rounds is less than the minimum
                                    if (roundList[r] < minRounds)
                                    {
                                        // make the current number of rounds the new minimum
                                        minRounds = roundList[r];

                                        // take note of the index to the minimum
                                        minIndex = r;
                                    }
                                }

                                // find the maximum number of rounds of all the games autoplayed and the index to the game that had the maximum

                                // set the maximum number of rounds to the first number of rounds in the round list
                                maxRounds = roundList[0];

                                // loop through the round list searching for the maximum number of rounds
                                for (int r = 0; r < roundList.Count; r++)
                                {
                                    // if the current number of rounds is greater than the maximum
                                    if (roundList[r] > maxRounds)
                                    {
                                        // make the current number of rounds the new maximum
                                        maxRounds = roundList[r];

                                        // take note of the index to the maximum
                                        maxIndex = r;
                                    }
                                }

                                // display the game number of the game that had the minimum number of rounds in the Min Rounds Game Number label
                                // on the testForm
                                testForm.lblMinRoundsGameNumber.Text = "#: " + (minIndex + 1);

                                // display the game number of the game that had the maximum number of rounds in the Max Rounds Game Number label
                                // on the testForm
                                testForm.lblMaxRoundsGameNumber.Text = "#: " + (maxIndex + 1);

                                // display the minimum number of rounds in the Min Rounds label on the testForm
                                testForm.lblMinRounds.Text = "Min: " + minRounds;

                                // display the maximum number of rounds in the Max Rounds label on the testForm
                                testForm.lblMaxRounds.Text = "Max: " + maxRounds;

                                // display the duration of the game that had the minimum number of rounds in the MinRGDuration label on the testForm
                                testForm.lblMinRGDuration.Text = "Min Rounds Game: " + ReplaceUnderscoreWithSpace(durationList[minIndex]);

                                // display the duration of the game that had the maximum number of rounds in the MaxRGDuration label on the testForm
                                testForm.lblMaxRGDuration.Text = "Max Rounds Game: " + ReplaceUnderscoreWithSpace(durationList[maxIndex]);

                                // reset the current game
                                ResetGame(sender, e);

                                // increment the game counter
                                game++;
                            }
                            
                        }

                        // check if all games have been autoplayed
                        if (game > numberOfGames)
                        {
                            // if all games have been autoplayed, display in the Current Game Running label on the testForm that the final game is complete
                            testForm.lblCurrentGameRunning.Text = "Game " + numberOfGames + " is now complete";

                            // reset all of the game info variables
                            currentGame = 0;

                            minRounds = 0;
                            minIndex = 0;
                            maxRounds = 0;
                            maxIndex = 0;
                            roundList.Clear();
                            durationList.Clear();

                            // reenable the clear button on the testForm
                            testForm.btnClear.Enabled = true;

                            // reset the flag indicating that multiple games are being autoplayed
                            isMultiAutoPlaying = false;
                        }

                        // reenable the Engage button on the testForm
                        testForm.btnEngage.Enabled = true;
                    }
                    // check if the number of games entered on the testForm is not greater than zero
                    else
                        // display an error message to the user(s) indicating that the number of games must be greater than zero
                        MessageBox.Show("Number entered must be greater than 0");
                }
                // check if the text from the number of games text box is a valid number
                else
                    // display an error message indicating to the user(s) that the number of games must be a valid integer number
                    MessageBox.Show("You must enter an integer number");
            }
                        
        }

        // this method removes the underscores present in a target string and replaces them with spaces
        private string ReplaceUnderscoreWithSpace(string targetString)
        {
            string resultString = "";                       // variable to hold the result of this method operating on the target string
            
            // loop through the characters in the target string one at a time
            for (int c = 0; c < targetString.Length; c++)
            {
                // if the current character is an underscore
                if (targetString[c] == '_')
                    // place a space character in the result string
                    resultString += ' ';
                // if the current character is not an underscore
                else
                    // place the current character in the result string
                    resultString += targetString[c];
            }

            // return the result string
            return resultString;
        }

        private string GetGameDuration()
        {
            string duration = "";                   // a string representation of the duration of a game

            // check if the game took more than a day to play 
            if (gameElapsedTime.Days > 0)
                // if the game did take more than a day to play, include the number of days in the game duration along with the hours, minutes and seconds
                duration = gameElapsedTime.Days + "_days_" + gameElapsedTime.Hours + "_hr_" + gameElapsedTime.Minutes + "_min_" + 
                    gameElapsedTime.Seconds + "_sec";
            // check if the game took more than an hour to play
            else if (gameElapsedTime.Hours > 0)
                // if the game did take more than an hour to play, include the number of hours in the game duration along with the minutes and seconds
                duration = gameElapsedTime.Hours + "_hr_" + gameElapsedTime.Minutes + "_min_" + gameElapsedTime.Seconds + "_sec";
            // check if the game took more than a minute to play
            else if (gameElapsedTime.Minutes > 0)
                // if the game did take more than a minute to play, include the number of minutes in the game duration along with the seconds
                duration = gameElapsedTime.Minutes.ToString() + "_min_" + gameElapsedTime.Seconds.ToString() + "_sec";
            // check if the game took more than a second to play
            else if (gameElapsedTime.Seconds > 0)
                // if the game did take more than a second, include the number of seconds in the game duration
                duration = gameElapsedTime.Seconds.ToString() + "_sec";
            // check if the game took less than a second to play
            else
                // if the game took less than a second to play, then include that information in the game duration
                duration = "<_1_sec";

            // return the string representation of the game duration
            return duration;
        }

        private void StopAutoPlaying(object sender, EventArgs e)
        {
            isAutoPlaying = false;
            if (isMultiAutoPlaying == true)
                isMultiAutoPlaying = false;
        }

        async private void AutoPlayThroughToEnd(object sender, EventArgs e)
        {
            warThreshold = 100;

            // check if autoplaying multiple games is not ongoing
            if (currentGame == 0)                       
                await AutoPlayGame(sender, e);
            else if (currentGame > 0)
                await AutoPlayMultipleGames(sender, e);

        }

        async private void AutoPlayUntilWARLevel1(object sender, EventArgs e)
        {
            warThreshold = 1;
            // check if autoplaying multiple games is not ongoing
            if (currentGame == 0)
                await AutoPlayGame(sender, e);
            else if (currentGame > 0)
                await AutoPlayMultipleGames(sender, e);

        }

        async private void AutoPlayUntilWARLevel2(object sender, EventArgs e)
        {
            warThreshold = 2;
            // check if autoplaying multiple games is not ongoing
            if (currentGame == 0)
                await AutoPlayGame(sender, e);
            else if (currentGame > 0)
                await AutoPlayMultipleGames(sender, e);

        }

        async private void AutoPlayUntilWARLevel3(object sender, EventArgs e)
        {
            warThreshold = 3;
            // check if autoplaying multiple games is not ongoing
            if (currentGame == 0)
                await AutoPlayGame(sender, e);
            else if (currentGame > 0)
                await AutoPlayMultipleGames(sender, e);

        }

        async private Task AutoPlayGame(object sender, EventArgs e)
        {
            int milliseconds = 1;               // the time of the delay (in milliseconds) that the game is displayed
                                                // so the user(s) may see the state of the game

            // check to see that a game is not already autoplaying
            if (isAutoPlaying == false)
            {
                // set the flag to indicate that a game is now autoplaying
                isAutoPlaying = true;

                // update the Output label
                UpdateOutputLabel();

                // reconfigure context menu

                // disable and make invisible the AutoPlay Game context menu item
                autoPlayGameToolStripMenuItem.Enabled = false;
                autoPlayGameToolStripMenuItem.Visible = false;

                // enable and make visible the Stop AutoPlay context menu item
                stopAutoPlayToolStripMenuItem.Enabled = true;
                stopAutoPlayToolStripMenuItem.Visible = true;

                // disable and make invisible the Start WAR Card Game context menu item
                startWARCardGameToolStripMenuItem.Enabled = false;
                startWARCardGameToolStripMenuItem.Visible = false;

                // check to see if a manual game has not started
                if (isGamePlaying == false)
                {
                    // if a game hasn't started yet

                    // begin to play an autoplay game
                    PlayWAR(sender, e);
                                        
                }
                // check to see if a manual game has started
                else
                {
                    // if a manual game has started
                    // finish the current round

                    // if the current round is in the "deal the cards" phase
                    if (dealCardsToolStripMenuItem.Enabled == true)
                    {
                        // deal the cards
                        DealTheCards(sender, e);

                        // check to see if the game has ended
                        if (isGamePlaying == true)
                        {
                            // if the game has not ended, compare the cards
                            CompareTheCards(sender, e);

                        }
                    }
                    // if the current round is in the "compare the cards" phase
                    else if (compareCardsToolStripMenuItem.Enabled == true)
                        // compare the cards
                        CompareTheCards(sender, e);
                                        
                }

                // loop through rounds of the game until the game is either called a draw or the game ends or the user stops autoplaying
                // or the war level rises to the threshold
                while (isGamePlaying == true && isAutoPlaying == true && warLevel < warThreshold)
                {
                    // deal the cards
                    DealTheCards(sender, e);

                    // implement the delay
                    await Task.Delay(milliseconds);

                    // check if the game has not ended
                    if (isGamePlaying == true)
                    {
                        // if the game has not ended, compare the cards
                        CompareTheCards(sender, e);

                    }
                }

                // set the flag to indicate that the game has stopped autoplaying
                isAutoPlaying = false;

                // update the Output label
                UpdateOutputLabel();

                // reconfigure context menu

                // if the user has stopped autoplay and the game is not yet awaiting reset
                if (awaitingReset == false)
                {
                    // enable and make visible the AutoPlay Game context menu item
                    autoPlayGameToolStripMenuItem.Enabled = true;
                    autoPlayGameToolStripMenuItem.Visible = true;

                    // enable and make visible the Start WAR Card Game context menu item
                    startWARCardGameToolStripMenuItem.Enabled = true;
                    startWARCardGameToolStripMenuItem.Visible = true;

                }
                
                // disable and make invisible the Stop AutoPlay context menu item
                stopAutoPlayToolStripMenuItem.Enabled = false;
                stopAutoPlayToolStripMenuItem.Visible = false;

            }
            
        }

        private bool ReadyForTransfer(int playerCardsGroupIndex, int playerWonCardsGroupIndex, int gatherX, int gatherY)
        {
            // this method checks if a player has cards remaining that can be dealt

            bool ready = false;     // flag indicating readiness to be able to deal from a player's player cards group

            // if the player has cards in his or her player cards group
            if (deckOfPlayingCards[playerCardsGroupIndex].GetCount() > 0)
            {
                // then he or she is ready to deal cards from his or her player cards group so set the ready flag
                ready = true;
            }
            // if the player doesn't have cards in his player cards group but does have cards in his player won cards group
            else if (deckOfPlayingCards[playerCardsGroupIndex].GetCount() == 0 && deckOfPlayingCards[playerWonCardsGroupIndex].GetCount() > 0)
            {
                //
                RegatherPlayerCards(playerCardsGroupIndex, playerWonCardsGroupIndex, gatherX, gatherY);

                // then set the ready flag
                ready = true;

            }
            // if the player is all out of cards
            else if (deckOfPlayingCards[playerCardsGroupIndex].GetCount() == 0 && deckOfPlayingCards[playerWonCardsGroupIndex].GetCount() == 0)
            {
                // reset the ready flag
                ready = false;
            }

            // return the ready flag value
            return ready;

        }

        private void NonWARDeal(int cardIndex, int yCoord, int targetWARPlayerIndex)
        {
            // set the position of the dealt card on the application form
            deckOfPlayingCards[dealtCardsGroupIndex].Group[cardIndex].SetLocation(centeredCardX, yCoord);

            // turn up the Top Player's dealt card
            deckOfPlayingCards[dealtCardsGroupIndex].Group[cardIndex].TurnCardUp();

            // display the face image of the dealt card
            deckOfPlayingCards[dealtCardsGroupIndex].Group[cardIndex].DisplayCardImage();

            // set the target player's comparison card CardReference so the players' cards can be compared later in the CompareTheCards method

            // set the target player's comparison card CardReference Group property
            warPlayers[targetWARPlayerIndex].ComparisonCard.Group = dealtCardsGroupIndex;

            //  set the target player's comparison card CardReference Card property
            warPlayers[targetWARPlayerIndex].ComparisonCard.Card = cardIndex;
        }

        private void WARDeal(int targetWARPlayerIndex)
        {
            int xCoordP = 0, yCoordP = 0;                                   // X and Y coordinates of the position to place the WAR cards
                                                                            // on the application form

            // if the target player is the top player
            if (targetWARPlayerIndex == topPlayerIndex)
            {
                // place the cards at coordinates to the left of the previously dealt cards so all dealt cards can be seen
                xCoordP = centeredCardX - ((SPACING_GAP + CARD_WIDTH) * warLevel);
                yCoordP = firstCardTPY;
            }
            // if the target player is the bottom player
            else if (targetWARPlayerIndex == bottomPlayerIndex)
            {
                // place the cards at coordinates to the right of the previously dealt cards so all dealt cards can be seen
                xCoordP = centeredCardX + ((SPACING_GAP + CARD_WIDTH) * warLevel);
                yCoordP = firstCardBPY;
            }

            // deal the down card
            // set location of card that is turned down (displace the down card slightly so the user can see that it's there)
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card - 1].SetLocation(xCoordP + 10, yCoordP + 10);

            // turn the card down
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card - 1].TurnCardDown();

            // display the back image of the  down card
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card - 1].DisplayCardImage();

            // bring the down card's picturebox to front so it is over any previous card
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card - 1].pctrBxCard.BringToFront();

            // deal the up card
            // set location of card that is turned up
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card].SetLocation(xCoordP, yCoordP);

            // turn the card up
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card].TurnCardUp();

            // display the face image of the up card
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card].DisplayCardImage();

            // bring the up card's picturebox to front so it is over the down card
            deckOfPlayingCards[warPlayers[targetWARPlayerIndex].ComparisonCard.Group].Group[warPlayers[targetWARPlayerIndex].ComparisonCard.Card].pctrBxCard.BringToFront();
        }

        private void DealTheCards(object sender, EventArgs e)
        {
            // if the WAR label is visible, make it invisible so it doesn't cover up the dealt cards
            if (lblWAR.Visible == true)
                lblWAR.Visible = false;
                        
            // check the WAR level
            if (warLevel == 0)
            {
                // if there is no WAR going on

                // determine if the Top Player has cards remaining before trying to deal his or her card
                if (ReadyForTransfer(topPlayerGroupIndex, topPlayerWonCardsGroupIndex, centeredCardX, setUpTPY))
                {
                    // if he or she does have cards remaining, transfer the first card from the Top Player's cards group to the dealt cards group
                    TransferFirstCardOfFirstGroupToSecondGroup(topPlayerGroupIndex, dealtCardsGroupIndex);

                    // determine if the Bottom Player has cards remaining before trying to deal his or her card 
                    if (ReadyForTransfer(bottomPlayerGroupIndex, bottomPlayerWonCardsGroupIndex, centeredCardX, setUpBPY))
                    {
                        // if he or she does have cards remaining, transfer the first card from the Bottom Player's cards group to the dealt cards group
                        TransferFirstCardOfFirstGroupToSecondGroup(bottomPlayerGroupIndex, dealtCardsGroupIndex);

                        // deal the Top Player's card
                        NonWARDeal(0, firstCardTPY, topPlayerIndex);

                        // deal the Bottom Player's card
                        NonWARDeal(1, firstCardBPY, bottomPlayerIndex);
                    }
                    // if the Bottom Player has no cards remaining
                    else
                    {
                        // set the flag that indicates that a game default has occurred
                        gameDefault = true;

                        // handle the game default
                        GameDefault(bottomPlayerIndex);
                    }
                }
                // if the Top Player has no cards remaining
                else
                {
                    // set the flag that indicates that a game default has occurred
                    gameDefault = true;

                    // handle the game default
                    GameDefault(topPlayerIndex);
                }

            }
            // if there is a WAR going on
            else if (warLevel > 0)
            {
                // determine if the Top Player has cards remaining before trying to deal his or her down card
                if (ReadyForTransfer(topPlayerGroupIndex, topPlayerWonCardsGroupIndex, centeredCardX, setUpTPY))
                {
                    // if he or she does have cards remaining, transfer the first card from the Top Player's cards group to the dealt cards group
                    TransferFirstCardOfFirstGroupToSecondGroup(topPlayerGroupIndex, dealtCardsGroupIndex);

                    // determine if the Top Player has cards remaining before trying to deal his or her up card
                    if (ReadyForTransfer(topPlayerGroupIndex, topPlayerWonCardsGroupIndex, centeredCardX, setUpTPY))
                    {
                        // if he or she does have cards remaining, transfer the first card from the Top Player's cards group to the dealt cards group
                        TransferFirstCardOfFirstGroupToSecondGroup(topPlayerGroupIndex, dealtCardsGroupIndex);

                        // determine if the Bottom Player has cards remaining before trying to deal his or her down card
                        if (ReadyForTransfer(bottomPlayerGroupIndex, bottomPlayerWonCardsGroupIndex, centeredCardX, setUpBPY))
                        {
                            // if he or she does have cards remaining, transfer the first card from the Top Player's cards group to the dealt cards group
                            TransferFirstCardOfFirstGroupToSecondGroup(bottomPlayerGroupIndex, dealtCardsGroupIndex);

                            // determine if the bottom Player has cards remaining before trying to deal his or her up card
                            if (ReadyForTransfer(bottomPlayerGroupIndex, bottomPlayerWonCardsGroupIndex, centeredCardX, setUpBPY))
                            {
                                // if he or she does have cards remaining, transfer the first card from the Top Player's cards group to the dealt cards group
                                TransferFirstCardOfFirstGroupToSecondGroup(bottomPlayerGroupIndex, dealtCardsGroupIndex);

                                // deal top player's war cards (one down one up)

                                // set the top player's comparison card CardReference Group property
                                warPlayers[topPlayerIndex].ComparisonCard.Group = dealtCardsGroupIndex;

                                // set the top player's comparison card CardReference Card property
                                if (warLevel == 1)
                                    warPlayers[topPlayerIndex].ComparisonCard.Card += 3;
                                else
                                    warPlayers[topPlayerIndex].ComparisonCard.Card += 4;
                                                                
                                // deal the top player's down card and up card
                                WARDeal(topPlayerIndex);

                                // deal bottom player's war cards (one down one up)

                                // set the bottom player's comparison card CardReference Group property
                                warPlayers[bottomPlayerIndex].ComparisonCard.Group = dealtCardsGroupIndex;

                                // set the bottom player's comparison card CardReference Card property
                                warPlayers[bottomPlayerIndex].ComparisonCard.Card += 4;

                                // deal the bottom player's down card and up card
                                WARDeal(bottomPlayerIndex);

                            }
                            // if the bottom player has no cards remaining
                            else
                            {
                                // set the flag that indicates that a game default has occurred
                                gameDefault = true;

                                // handle the game default
                                GameDefault(bottomPlayerIndex);
                            }

                        }
                        // if the bottom player has no cards remaining
                        else
                        {
                            // set the flag that indicates that a game default has occurred
                            gameDefault = true;

                            // handle the game default
                            GameDefault(bottomPlayerIndex);
                        }

                    }
                    // if the top player has no cards remaining
                    else
                    {
                        // set the flag that indicates that a game default has occurred
                        gameDefault = true;

                        // handle the game default
                        GameDefault(topPlayerIndex);
                    }

                }
                // if the top player has no cards remaining
                else
                {
                    // set the flag that indicates that a game default has occurred
                    gameDefault = true;

                    // handle the game default
                    GameDefault(topPlayerIndex);
                }
                                        

            } // end of else if (warLevel > 0) 

            // disable the Deal Cards context menu item
            dealCardsToolStripMenuItem.Enabled = false;

            // enable the Compare Cards context menu item
            compareCardsToolStripMenuItem.Enabled = true;

            // if a game is still playing,
            if (isGamePlaying == true)
            {
                // update the output label
                UpdateOutputLabel();
                DealCommentary();
            }
                
        }

        private void DealCommentary()
        {
            int lead = 0;               // number of points that one player is ahead of the other

            // check if the top player is in the lead
            if (warPlayers[topPlayerIndex].Score > warPlayers[bottomPlayerIndex].Score)
            {
                // if the top player is in the lead, calculate the lead he or she has
                lead = warPlayers[topPlayerIndex].Score - warPlayers[bottomPlayerIndex].Score;

                // display commentary of the top player being in the lead and by how much
                lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name +
                    " in the lead by " + lead + " points!";
            }
            // check if  the bottom player is in the lead
            else if (warPlayers[bottomPlayerIndex].Score > warPlayers[topPlayerIndex].Score)
            {
                // if the bottom player is in the lead, calculate the lead he or she has
                lead = warPlayers[bottomPlayerIndex].Score - warPlayers[topPlayerIndex].Score;

                // display commentary of the bottom player being in the lead and by how much
                lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                    " in the lead by " + lead + " points!";

            }
            // check if both player's scores are equal
            else if (warPlayers[topPlayerIndex].Score == warPlayers[bottomPlayerIndex].Score)
            {
                // if both scores are equal

                // check if it's the first round
                if (round == 1)
                    // if it's the first round, display the start message
                    lblCommentary.Text = "Let's get started, shall we?";
                else
                    // otherwise, display the undecided message 
                    lblCommentary.Text = "It's anybody's game, folks!";
            }

        }

        private void GameDefault(int targetPlayerIndex_NoCards)
        {
            // this method is called when one player runs out of cards and then the other player wins by default

            // check the war level
            if (warLevel > 0)
            {
                // if the war level is greater than zero, the default is a WAR default
                if (targetPlayerIndex_NoCards == topPlayerIndex)
                {
                    // if the target player who has no cards is the top player, display appropriate message in the commentary label
                    lblCommentary.Text = "Top Player " + warPlayers[topPlayerIndex].Name +
                                " doesn't have enough cards left for the war so Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                                " wins the game by default!";
                }
                else if (targetPlayerIndex_NoCards == bottomPlayerIndex)
                {
                    // if the target player who has no cards is the bottom player, display appropriate message in the commentary label
                    lblCommentary.Text = "Bottom Player " + warPlayers[bottomPlayerIndex].Name +
                                    " doesn't have enough cards left for the war so Top Player " + warPlayers[topPlayerIndex].Name +
                                    " wins the game by default!";
                }

            }
            else
            {
                // if the war level is not greater than zero, then something has gone wrong so display an error message
                MessageBox.Show("Error: Non WAR Default occurred.  Player identifier is \"" + warPlayers[targetPlayerIndex_NoCards].Identifier + "\"." 
                    + "\nThe program must now end.");

                // end the program
                this.Close();
            }

            // call the method to end the game
            End();

        }

        private void CollectWonCards(int winnerPlayerIndex, int winnerPlayerWonCardsGroupIndex, int loserPlayerIndex)
        {
            // get indexes to access winner player's comparison card
            int WPCCGroupIndex = warPlayers[winnerPlayerIndex].ComparisonCard.Group;
            int WPCCCardIndex = warPlayers[winnerPlayerIndex].ComparisonCard.Card;

            // get indexes to access loser player's comparison card
            int LPCCGroupIndex = warPlayers[loserPlayerIndex].ComparisonCard.Group;
            int LPCCCardIndex = warPlayers[loserPlayerIndex].ComparisonCard.Card;

            // declare the variables that will hold the coordinates from which to spread the winner's won cards 
            int spreadCardsX = 0, spreadCardsY = 0;
            
            // check if there is not a WAR presently ongoing
            if (warLevel == 0)
            {
                // if there is no WAR presently ongoing, set the commentary label text to display that the winner's comparison card beat the loser's comparison card
                lblCommentary.Text = warPlayers[winnerPlayerIndex].Identifier + " " + warPlayers[winnerPlayerIndex].Name + "'s " + deckOfPlayingCards[WPCCGroupIndex].Group[WPCCCardIndex].FaceValue.ToString() + " of " +
                    deckOfPlayingCards[WPCCGroupIndex].Group[WPCCCardIndex].Suit.ToString() + " beat " + warPlayers[loserPlayerIndex].Identifier + " " + warPlayers[loserPlayerIndex].Name + "'s " +
                    deckOfPlayingCards[LPCCGroupIndex].Group[LPCCCardIndex].FaceValue.ToString() + " of " + deckOfPlayingCards[LPCCGroupIndex].Group[LPCCCardIndex].Suit.ToString() + "!";
            }
            // check if there is a WAR presently ongoing
            else if (warLevel > 0)
            {
                // if there is a WAR presently ongoing, set the commentary label text to display that the winner won the WAR with his or her comparison card beating the loser's comparison card
                lblCommentary.Text = warPlayers[winnerPlayerIndex].Identifier + " " + warPlayers[winnerPlayerIndex].Name + "'s " + deckOfPlayingCards[WPCCGroupIndex].Group[WPCCCardIndex].FaceValue.ToString() + " of " +
                    deckOfPlayingCards[WPCCGroupIndex].Group[WPCCCardIndex].Suit.ToString() + " won the war by beating " + warPlayers[loserPlayerIndex].Identifier + " "  + warPlayers[loserPlayerIndex].Name + "'s " +
                    deckOfPlayingCards[LPCCGroupIndex].Group[LPCCCardIndex].FaceValue.ToString() + " of " + deckOfPlayingCards[LPCCGroupIndex].Group[LPCCCardIndex].Suit.ToString() + "!";

                // end the war (deescalate the war)
                warLevel = 0;

                // make the WAR label invisible
                lblWAR.Visible = false;
            }

            // tranfer all dealt cards from the dealt cards group to the winner's won cards group
            TransferFirstGroupOfCardsToSecondGroup(dealtCardsGroupIndex, winnerPlayerWonCardsGroupIndex);

            // check if the winner was the top player
            if (winnerPlayerIndex == topPlayerIndex)
            {
                // if the winner is the top player, then calculate the X coordinate from which to spread the top player's won cards to be far enough to the left of the top player's cards to have a little space
                // between the two groups of cards
                spreadCardsX = centeredCardX - (SPACING_GAP + CARD_WIDTH + SPREAD_OFFSET * (deckOfPlayingCards[winnerPlayerWonCardsGroupIndex].Group.Count - 1));

                // set the Y coordinate from which to spread the top player's won cards to the same Y coordinate from where the top player's cards are dealt from
                spreadCardsY = setUpTPY;
            }
            // check if the winner was the bottom player
            else if (winnerPlayerIndex == bottomPlayerIndex)
            {
                // if  the  winner is the bottom player, then calculate the X coordinate from which to spread the bottom player's won cards to be just to the right of the bottom player's cards with a little space
                // between the two groups of cards
                spreadCardsX = centeredCardX + SPACING_GAP + CARD_WIDTH;

                // set the Y coordinate from which to spread the bottom player's won cards to the same Y coordinate from where the bottom player's cards are dealt from
                spreadCardsY = setUpBPY;
            }

            // spread the winner's won cards at the calculated coordinates 
            SpreadGroupOfCards(spreadCardsX, spreadCardsY, winnerPlayerWonCardsGroupIndex);

        }

        private void CompareTheCards(object sender, EventArgs e)
        {

            // get indexes to access Top Player's comparison card
            int TPCCGroupIndex = warPlayers[topPlayerIndex].ComparisonCard.Group;
            int TPCCCardIndex = warPlayers[topPlayerIndex].ComparisonCard.Card;

            // get indexes to access Bottom Player's comparison card
            int BPCCGroupIndex = warPlayers[bottomPlayerIndex].ComparisonCard.Group;
            int BPCCCardIndex = warPlayers[bottomPlayerIndex].ComparisonCard.Card;

            // check if top player's card beats bottom player's card
            if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue > deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
            {
                // if the top player did win, collect all the dealt cards that the top player just won into the top player's won cards group
                CollectWonCards(topPlayerIndex, topPlayerWonCardsGroupIndex, bottomPlayerIndex);
                
            }
            // check if bottom player's card beats top player's card
            else if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue < deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
            {
                // if the bottom player did win, collect all the dealt cards that the bottom player just won into the bottom player's won cards group
                CollectWonCards(bottomPlayerIndex, bottomPlayerWonCardsGroupIndex, topPlayerIndex);
                                                
            }
            // check if both cards are of equal face value
            else if (deckOfPlayingCards[TPCCGroupIndex].Group[TPCCCardIndex].FaceValue == deckOfPlayingCards[BPCCGroupIndex].Group[BPCCCardIndex].FaceValue)
            {
                // If the cards are equal, then there's a WAR!!!

                // check if there isn't a WAR presently ongoing
                if (warLevel == 0)
                {
                    // if there is no WAR presently ongoing, start a WAR
                    // set the warlevel to one
                    warLevel = 1;

                    // display in the WAR label an announcement that there's a WAR now
                    lblWAR.Text = "WAR!!!";

                    // center the WAR label on the application form
                    CenterWARLabel();

                    // display commentary announcing that the WAR level is now one
                    lblCommentary.Text = "WAR level: 1!";
                }
                // check if there is a WAR presently ongoing
                else if (warLevel > 0)
                {
                    // raise the WAR level by one (escalate the WAR)
                    warLevel++;

                    // display in the WAR label an announcement that there's another WAR now
                    lblWAR.Text = "WAR AGAIN!!!";

                    // center the WAR label on the application form
                    CenterWARLabel();

                    // display commentary announcing the new WAR level
                    lblCommentary.Text = "WAR level: " + warLevel;
                    
                }

                // make the WAR label visible
                lblWAR.Visible = true;

                // bring the WAR label to the front so it can be seen over the cards
                lblWAR.BringToFront();
                                
            }

            // check if there is no WAR presently ongoing
            if (warLevel == 0)
            {
                // if there is  no WAR presently ongoing
                // set the player's scores equal to the count of the cards in their respective player cards groups and won cards groups combined
                warPlayers[topPlayerIndex].Score = deckOfPlayingCards[topPlayerWonCardsGroupIndex].Group.Count + deckOfPlayingCards[topPlayerGroupIndex].Group.Count;
                warPlayers[bottomPlayerIndex].Score = deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].Group.Count + deckOfPlayingCards[bottomPlayerGroupIndex].Group.Count;

                // display both player's identifier, name and score
                lblTopPlayer.Text = warPlayers[topPlayerIndex].Identifier + ": " + warPlayers[topPlayerIndex].Name + "\nScore: " + warPlayers[topPlayerIndex].Score;
                lblBottomPlayer.Text = warPlayers[bottomPlayerIndex].Identifier + ": " + warPlayers[bottomPlayerIndex].Name + "\nScore: " + warPlayers[bottomPlayerIndex].Score;


                // check if someone has won the game

                // check if the top player won
                if (warPlayers[topPlayerIndex].Score == CARDS_IN_DECK)
                {
                    // if the top player won, end the game with the top player as winner
                    EndGame(topPlayerIndex);

                }
                // check if the bottom player won
                else if (warPlayers[bottomPlayerIndex].Score == CARDS_IN_DECK)
                {
                    // if the botom player won, end the game with the bottom player as winner
                    EndGame(bottomPlayerIndex);

                }
            }

            // check if a game is still playing
            if (isGamePlaying == true)
            {
                // if a game is still playing

                // check if top player has no cards in his or her player cards group but does have cards in his or her won cards group
                if (deckOfPlayingCards[topPlayerGroupIndex].GetCount() == 0 && deckOfPlayingCards[topPlayerWonCardsGroupIndex].GetCount() > 0)
                {
                    // if the top player doesn't have cards in his or her player cards group but does have cards in his or her won cards group,
                    // transfer the cards in the won cards group to the player cards group and gather them where the top player deals from  
                    RegatherPlayerCards(topPlayerGroupIndex, topPlayerWonCardsGroupIndex, centeredCardX, setUpTPY);

                }
                // check if top player has no cards in his or her player cards group and has no cards in his or her won cards group
                else if (deckOfPlayingCards[topPlayerGroupIndex].GetCount() == 0 && deckOfPlayingCards[topPlayerWonCardsGroupIndex].GetCount() == 0)
                {
                    
                    // if the top player has no cards, then he or she loses the game by default

                    // set the game default flag to indicate there is a game default    
                    gameDefault = true;

                    // call the method to handle the game default with the top player as loser
                    GameDefault(topPlayerIndex);
                        
                    // make the WAR label invisible
                    lblWAR.Visible = false;
                        
                }

                // check if bottom player has no cards in his or her player cards group but does have cards in his or her won cards group
                if (deckOfPlayingCards[bottomPlayerGroupIndex].GetCount() == 0 && deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].GetCount() > 0)
                {
                    // if the bottom player doesn't have cards in his or her player cards group but does have cards in his or her won cards group,
                    // transfer the cards in the won cards group to the player cards group and gather them where the bottom player deals from
                    RegatherPlayerCards(bottomPlayerGroupIndex, bottomPlayerWonCardsGroupIndex, centeredCardX, setUpBPY);
                                        
                }
                // check if bottom player has no cards in his or her player cards group and has no cards in his or her won cards group
                else if (deckOfPlayingCards[bottomPlayerGroupIndex].GetCount() == 0 && deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].GetCount() == 0)
                {
                    
                    // if the bottom player has no cards, then he or she loses the game by default

                    // set the game default flag to indicate there is a game default
                    gameDefault = true;

                    // call the method to handle the game default with the bottom player as loser
                    GameDefault(bottomPlayerIndex);
                        
                    // make the WAR label invisible
                    lblWAR.Visible = false;
                        
                }

                // enable the Deal Cards context menu item
                dealCardsToolStripMenuItem.Enabled = true;

                // disable the Compare Cards context menu item
                compareCardsToolStripMenuItem.Enabled = false;

                // check if a  game is still playing
                if (isGamePlaying == true)
                {
                    // if a game is still playing
                    if (round >= drawMaxRounds)
                    {
                        int lead = 0;

                        if (warPlayers[topPlayerIndex].Score > warPlayers[bottomPlayerIndex].Score)
                        {
                            lead = warPlayers[topPlayerIndex].Score - warPlayers[bottomPlayerIndex].Score;
                            lblCommentary.Text = "Sorry folks, we've reached the round limit at which we have to call the game!  " 
                                + warPlayers[topPlayerIndex].Identifier + " " + warPlayers[topPlayerIndex].Name + " won by " + lead 
                                + " points!";

                        }
                        else if (warPlayers[bottomPlayerIndex].Score > warPlayers[topPlayerIndex].Score)
                        {
                            lead = warPlayers[bottomPlayerIndex].Score - warPlayers[topPlayerIndex].Score;
                            lblCommentary.Text = "Sorry folks, we've reached the round limit at which we have to call the game!  "
                                + warPlayers[bottomPlayerIndex].Identifier + " " + warPlayers[bottomPlayerIndex].Name + " won by " + lead
                                + " points!";
                        }
                        else
                            lblCommentary.Text = "Sorry folks, since noone's ahead and we've reached the round limit, we have to call the game a draw!";

                        End();
                    }
                    else if (round < drawMaxRounds)
                    {
                        // update the output label
                        UpdateOutputLabel();

                        // increment the round
                        round++;

                        // display the round in the Round label
                        lblRound.Text = "Round\n" + round;
                    }
                }
                
            }

        }

        private void RegatherPlayerCards(int playerGroupIndex, int playerWonCardsGroupIndex, int playerXCoord, int playerYCoord)
        {
            // tranfer the target player's won cards to the target player's cards group
            TransferFirstGroupOfCardsToSecondGroup(playerWonCardsGroupIndex, playerGroupIndex);

            // shuffle the target player's cards three times
            ShuffleGroupOfCards(playerGroupIndex);
            ShuffleGroupOfCards(playerGroupIndex);
            ShuffleGroupOfCards(playerGroupIndex);

            // gather the target player's cards at the target coordinates (the coordinates passed to this method as arguments)
            GatherGroupOfCards(playerXCoord, playerYCoord, playerGroupIndex);
        }

        private void CenterWARLabel()
        {
            // get the size of the application form
            Size formSize = this.Size;

            // get the size of the WAR label
            Size WARLabelSize = lblWAR.Size;

            // get the WAR label's location
            Point WARLabelLocation = lblWAR.Location;

            // calculate the X coordinate that will center the WAR label horizontally on the application form
            int wlCenteredX = (formSize.Width - WARLabelSize.Width) / 2;

            // set the WARLabelLocation's X coordinate to the value that will center the WAR Label
            WARLabelLocation.X = wlCenteredX;

            // set the WAR label Location property to the location that will center the WAR label
            lblWAR.Location = WARLabelLocation;
            
        }

        private void EndGame(int winnerPlayerIndex)
        {
            // set the commentary text to display a message telling who won the game
            lblCommentary.Text = warPlayers[winnerPlayerIndex].Identifier + " " + warPlayers[winnerPlayerIndex].Name + " has won the game!";

            // perform tasks to end the game and prepare for resetting to play another game
            End();

        }

        private void End()
        {
            // set the game end time to the current time
            gameEndTime = DateTime.Now;

            // display the game end time in the Game Stop Time label
            lblGameStopTime.Text = "Game End Time: " + gameEndTime.ToString("hh:mm:ss tt");

            // make the Game Stop Time label visible
            lblGameStopTime.Visible = true;

            // calculate how long the game was
            gameElapsedTime = gameEndTime - gameStartTime;

            // display how long the game was
            DisplayGameDuration();

            // reset the the flag that indicates whether or not a game is playing
            isGamePlaying = false;

            // set up for resetting to play another game

            // make the Start WAR Card Game context menu item invisible
            startWARCardGameToolStripMenuItem.Visible = false;

            // disable the Start WAR Card Game context menu item
            startWARCardGameToolStripMenuItem.Enabled = false;

            // make the AutoPlay Game context menu item invisible
            autoPlayGameToolStripMenuItem.Visible = false;

            // disable the AutoPlay Game context menu item
            autoPlayGameToolStripMenuItem.Enabled = false;

            // enable the Reset Game context menu item
            resetGameToolStripMenuItem.Enabled = true;

            // make the Reset Game context menu item visible
            resetGameToolStripMenuItem.Visible = true;

            // display instructions to reset the game in the Output label
            lblOutput.Text = "Instructions: To play again, right click and select the \"Reset Game\" option!";

            // set the flag indicating that the game is waiting to be reset
            awaitingReset = true;

            // set the dealt card count for the multiple autoplay game display in the test form
            dealtCardCount = deckOfPlayingCards[dealtCardsGroupIndex].GetCount();
        }

        private void ResetGame(object sender, EventArgs e)
        {
            // check to see if the game is waiting to be reset
            if (awaitingReset == true)
            {
                // if the game is waiting to be reset

                // change the text of the Start WAR Card Game context menu item to "Start WAR Card Game"
                startWARCardGameToolStripMenuItem.Text = "Start WAR Card Game";

                // disable the Deal Cards context menu item
                dealCardsToolStripMenuItem.Enabled = false;

                // make the Deal Cards context menu item invisible
                dealCardsToolStripMenuItem.Visible = false;

                // disable the Compare Cards context menu item
                compareCardsToolStripMenuItem.Enabled = false;

                // make the Compare Cards context menu item invisible
                compareCardsToolStripMenuItem.Visible = false;

                // transfer cards in the following groups back to the deck group 
                // top player's cards
                if (deckOfPlayingCards[topPlayerGroupIndex].GetCount() > 0)
                    TransferFirstGroupOfCardsToSecondGroup(topPlayerGroupIndex, deckGroupIndex);

                // top player's won cards
                if (deckOfPlayingCards[topPlayerWonCardsGroupIndex].GetCount() > 0)
                    TransferFirstGroupOfCardsToSecondGroup(topPlayerWonCardsGroupIndex, deckGroupIndex);

                // bottom player's cards
                if (deckOfPlayingCards[bottomPlayerGroupIndex].GetCount() > 0)
                    TransferFirstGroupOfCardsToSecondGroup(bottomPlayerGroupIndex, deckGroupIndex);

                // bottom player's won cards
                if (deckOfPlayingCards[bottomPlayerWonCardsGroupIndex].GetCount() > 0)
                    TransferFirstGroupOfCardsToSecondGroup(bottomPlayerWonCardsGroupIndex, deckGroupIndex);

                // check dealt cards just in case
                if (deckOfPlayingCards[dealtCardsGroupIndex].GetCount() > 0)
                    TransferFirstGroupOfCardsToSecondGroup(dealtCardsGroupIndex, deckGroupIndex);

                // reset the flag that indicates whether or not the deck is split
                isDeckSplit = false;

                // recenter the deck of cards
                GatherGroupOfCards(centeredCardX, centeredCardY, deckGroupIndex);

                // make the Start WAR Card Game context menu item visible
                startWARCardGameToolStripMenuItem.Visible = true;

                // enable the Start WAR Card Game context menu item
                startWARCardGameToolStripMenuItem.Enabled = true;

                // make the AutoPlay Game context menu item visible
                autoPlayGameToolStripMenuItem.Visible = true;

                // enable the AutoPlay Game context menu item
                autoPlayGameToolStripMenuItem.Enabled = true;

                // disable the Reset Game context menu item
                resetGameToolStripMenuItem.Enabled = false;

                // make the Reset Game context menu item invisible
                resetGameToolStripMenuItem.Visible = false;

                // reset the Commentary label
                lblCommentary.Text = warPlayers[topPlayerIndex].Name + " and " + warPlayers[bottomPlayerIndex].Name +
                    " are you ready to play again?";

                // make the top player identifier, name and score label invisible
                lblTopPlayer.Visible = false;

                // make the bottom player identifier, name and score label invisible
                lblBottomPlayer.Visible = false;

                // make the Game Start Time label invisible
                lblGameStartTime.Visible = false;

                // make the Game Stop Time label invisible
                lblGameStopTime.Visible = false;

                // reset the the game duration to zero
                gameElapsedTime = TimeSpan.Zero;

                // make the Game Duration label invisible
                lblGameDuration.Visible = false;

                // reset the round variable to the first round
                round = 1;

                // make the Round label invisible
                lblRound.Visible = false;

                // reset the flag that indicates whether or not the game is waiting to be reset
                awaitingReset = false;

                // update the Output label
                UpdateOutputLabel();
            }
            // if the game is not waiting to be reset
            else
            {
                // display error message
                MessageBox.Show("Attempting to reset game when game is not awaiting reset");
            }
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
            // if the game lasted for days
            if (gameElapsedTime.Days > 0)
                // display days, hours, minutes and seconds
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Days + " days " + gameElapsedTime.Hours + " hr, " +
                    gameElapsedTime.Minutes + " min, " + gameElapsedTime.Seconds + " sec";
            // if the game lasted for hours
            else if (gameElapsedTime.Hours > 0)
                // display hours, minutes and seconds
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Hours + " hr, " + gameElapsedTime.Minutes + " min, "
                    + gameElapsedTime.Seconds + " sec";
            // if  the game lasted for minutes
            else if (gameElapsedTime.Minutes > 0)
                // display minutes and seconds
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Minutes + " min, " + gameElapsedTime.Seconds + " sec";
            // if the game lasted for seconds
            else if (gameElapsedTime.Seconds > 0)
                // display seconds
                lblGameDuration.Text = "Game Duration: " + gameElapsedTime.Seconds + " sec";
            // if the game lasted for less than one second
            else if (gameElapsedTime > TimeSpan.Zero)
                // display less than one second
                lblGameDuration.Text = "Game Duration: < 1 sec";
        }

        // this method allows me to type a code which launchs the testform 
        // unlocking the capability to autoplay multiple games (primarily for test purposes)
        private void KeyPressOnMainForm(object sender, KeyEventArgs e)           
        {
            //int keyValue = e.KeyValue;
            Keys keyCode = e.KeyCode;                   // the code of the key that was pressed

            // check if up to four keys have been pressed
            if (keyString.Length <= 4)
            {
                // if up to 4 keys have been pressed, store the key codes to the key string
                keyString += keyCode.ToString();
                //lblOutput.Text = "Key was pressed with keyCode = " + keyCode.ToString() +
                    //"\n keyString = " + keyString;
            }

            // check if four keys have been pressed 
            if (keyString.Length == 4)
            {
                // if four keys have been pressed, compare them to the secret code
                if (keyString.ToLower() == "jhle")
                {
                    // display a message to indcate the code was accepted
                    //MessageBox.Show("Code \"" + keyString + "\" accepted");

                    // empty the key string
                    keyString = "";

                    // if the testForm hasn't been instantiated
                    if (testForm == null)
                    {
                        // instantiate the testForm
                        testForm = new TestFormWAR(this);

                        // display the testForm
                        testForm.Show();
                    }
                    // if the  testForm has  been instantiated
                    else if (testForm != null)
                    {
                        // close this existing testForm so that there are not two testforms
                        testForm.Close();

                        // instantiate a new testForm
                        testForm = new TestFormWAR(this);

                        // display the new testform
                        testForm.Show();
                    }
                    
                }
                // check if the the four keys pressed don't match the the secret code
                else if (keyString.ToLower() != "jhle")
                {
                    // display a message indcating the code was rejected
                    //MessageBox.Show("Code \"" + keyString + "\" rejected");

                    // empty the key string
                    keyString = "";
                }
            }

            // if five or more characters get into the key string
            if (keyString.Length >= 5)
            {
                // empty the key string
                keyString = "";
            }
             
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            // exit the program
            this.Close();
        }
    }
}
