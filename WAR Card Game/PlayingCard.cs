﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WAR_Card_Game
{
    enum Suit { Spades, Diamonds, Clubs, Hearts }
    enum FaceValue { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    class PlayingCard
    {
        // This class is meant to model a playing card from a deck of cards

        //public event EventHandler ClearOutputLabel;
        public EventHandler<string> ClearOutputLabel;

        private int _cardNumber;                                        // number from 0 - 51 that uniquely identifies the card in the deck
        public PictureBox pctrBxCard;                                   // picturebox on the application form that contains the image of the card
        public Image cardFace;                                          // image of the face of the card
        public static Image cardBack;                                   // image of the back of the card (is shared between all the cards)
        private bool cardFaceUp = true,                                 // flag indicating whether or not the card is face up or not
            pbCardIsDragging = false;                                   // flag indicating whether or not the card is being dragged by the mouse
        private Point pctrBxPoint; //, mousePoint;                      // Point used for setting the location of the card's picturebox
        private int current_pbCardX, current_pbCardY;                   // X and Y coordinates for the location of the cad's picturebox

        // defined as Properties
        private Suit _suit;                                             // suit of the card
        private FaceValue _faceValue;                                   // face value of the card
        private bool _selected;                                         // flag indicating whether or not the card is selected by the user

        private Padding pctrBxPadding;                                  // padding of the picturebox (used for selecting the card)

        private Size originalSize;                                      // actual size of the card
        private Size selectedSize;                                      // size of the card when selected (larger to keep the card the same size when selected)

        private const int SELECTION_LINE_THICKNESS = 5;                 // number of pixels thickness of the selection line around the card

        public PlayingCard(int cardnumber)                              // constructor method
        {
            _cardNumber = cardnumber;
            DetermineFaceValue();
            DetermineSuit();

            pctrBxCard = new PictureBox();

            pctrBxCard.Enabled = true;
            pctrBxCard.Visible = true;

            pctrBxPoint = new Point();
            
            //mousePoint = new Point();

            Size pctrBxSize = new Size(100, 140);

            pctrBxCard.Size = pctrBxSize;

            pctrBxCard.SizeMode = PictureBoxSizeMode.StretchImage;

            originalSize = new Size(pctrBxCard.ClientRectangle.Width, pctrBxCard.ClientRectangle.Height);
            selectedSize = new Size(pctrBxCard.ClientRectangle.Width + (SELECTION_LINE_THICKNESS * 2),
                pctrBxCard.ClientRectangle.Height + (SELECTION_LINE_THICKNESS * 2));

            // add the event handlers to the card's picturebox
            pctrBxCard.MouseDoubleClick += PctrBxCard_MouseDoubleClick;
            pctrBxCard.MouseDown += PctrBxCard_MouseDown;
            pctrBxCard.MouseMove += PctrBxCard_MouseMove;
            pctrBxCard.MouseUp += PctrBxCard_MouseUp;
            pctrBxCard.MouseClick += PctrBxCard_MouseClick;
            //pctrBxCard.MouseEnter += PctrBxCard_MouseEnter;
            //pctrBxCard.MouseLeave += PctrBxCard_MouseLeave;
            pctrBxCard.LostFocus += PctrBxCard_LostFocus;
            //pctrBxCard.Paint += pctrBxCard_Paint;
                        
        }

        
        private void PctrBxCard_MouseClick(object sender, EventArgs e)
        {
            if (!_selected)
            {
                SelectCard();
                //this.ClearOutputLabel(sender, e);
                string cardName = _faceValue.ToString() + " of " + _suit.ToString();
                ClearOutputLabel(this, cardName);
            }
        }

        // CardNumber property
        public int CardNumber
        {
            get { return _cardNumber; }
        }

        // Selected property
        public bool Selected
        {
            get
            {
                return _selected;
            }

            set
            {
                _selected = value;
            }
        }

        // Suit property
        public Suit Suit
        {
            get { return _suit; }
        }

        // FaceValue property
        public FaceValue FaceValue
        {
            get { return _faceValue; }
        }

        private void SelectCard()
        {
            pctrBxCard.Enabled = true;
            pctrBxCard.ClientSize = selectedSize;

            pctrBxCard.BackColor = Color.Yellow;

            // setting the padding to five makes the card look
            // like it is outlined in the  background color
            pctrBxPadding = new Padding();
            pctrBxPadding.All = SELECTION_LINE_THICKNESS;

            pctrBxCard.Padding = pctrBxPadding;
                                       
            // relocate the card
            //Point pctrBxPointS = new Point();
                
            pctrBxPoint.X = pctrBxCard.Location.X - SELECTION_LINE_THICKNESS;
            pctrBxPoint.Y = pctrBxCard.Location.Y - SELECTION_LINE_THICKNESS;
            
            pctrBxCard.Location = pctrBxPoint;

            pctrBxCard.Focus();

            _selected = true;
        }

        public void DeselectCard()
        {
            pctrBxCard.BackColor = Color.White;

            // setting the padding to zero takes away the outline
            pctrBxPadding = new Padding();
            pctrBxPadding.All = 0;

            pctrBxCard.Padding = pctrBxPadding;

            if (_selected)
            {

                // relocate the card
                //pctrBxPoint = new Point();

                pctrBxPoint.X = pctrBxCard.Location.X + SELECTION_LINE_THICKNESS;
                pctrBxPoint.Y = pctrBxCard.Location.Y + SELECTION_LINE_THICKNESS;

                pctrBxCard.Location = pctrBxPoint;

                pctrBxCard.ClientSize = originalSize;
            }

            _selected = false;
            
        }

        private void PctrBxCard_LostFocus(object sender, EventArgs e)
        {
            DeselectCard();
        }

        private void DetermineFaceValue()
        {
            // the way the deck is arranged, the face value of the card
            // can be determined by taking the remainder of the 
            // integer division of the card number by the number of
            // cards in each suit (13)
            int fv = _cardNumber % 13;
            _faceValue = (FaceValue)fv;
        }

        private void DetermineSuit()
        {
            // the way the deck is arranged, the suit of the card
            // can be determined by taking the result of the 
            // integer division of the card number by the number of
            // cards in each suit (13)
            int s = _cardNumber / 13;
            _suit = (Suit)s;
        }

        /*
        public FaceValue getFaceValue()
        {
            return _faceValue;
        }

        public Suit getSuit()
        {
            return _suit;
        }
        */

        public void TurnCardDown()
        {
            cardFaceUp = false;
        }

        public void TurnCardUp()
        {
            cardFaceUp = true;
        }

        private void PctrBxCard_MouseDown(object sender, MouseEventArgs e)
        {
            pbCardIsDragging = true;

            current_pbCardX = e.X;
            current_pbCardY = e.Y;

            pctrBxCard.BringToFront();

        }

        private void PctrBxCard_MouseMove(object sender, MouseEventArgs e)
        {
            if (pbCardIsDragging)
            {

                //pctrBxPoint = new Point();

                pctrBxPoint.X = pctrBxCard.Location.X + (e.X - current_pbCardX);
                pctrBxPoint.Y = pctrBxCard.Location.Y + (e.Y - current_pbCardY);

                pctrBxCard.Location = pctrBxPoint;

            }
        }

        private void PctrBxCard_MouseUp(object sender, MouseEventArgs e)
        {
            pbCardIsDragging = false;

        }

        public void SetLocation(int xCoord, int yCoord)
        {
            //pctrBxPoint = new Point(xCoord, yCoord);
            if (_selected)
            {
                pctrBxPoint.X = xCoord - SELECTION_LINE_THICKNESS;
                pctrBxPoint.Y = yCoord - SELECTION_LINE_THICKNESS;
            }
            else
            {
                pctrBxPoint.X = xCoord;
                pctrBxPoint.Y = yCoord;
            }
                        
            pctrBxCard.Location = pctrBxPoint;
        }

        public Point GetLocation()
        {
            
            //return cardLocationPoint;
            if (_selected)
            {
                pctrBxPoint.X = pctrBxCard.Location.X + SELECTION_LINE_THICKNESS;
                pctrBxPoint.Y = pctrBxCard.Location.Y + SELECTION_LINE_THICKNESS;

                return pctrBxPoint;
            }
            else
            {
                return pctrBxCard.Location;
            }
        }

        public void SetCardFaceImage(Image targetImage)
        {
            cardFace = targetImage;
        }

        public void SetCardBackImage(Image targetImage)
        {
            cardBack = targetImage;
        }

        public void DisplayCardImage()
        {
            if (cardFaceUp == true)
                pctrBxCard.Image = cardFace;
            else
                pctrBxCard.Image = cardBack;
        }

        private void PctrBxCard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Flip();
        }

        public void Flip()
        {
            if (cardFaceUp == true)
            {
                pctrBxCard.Image = cardBack;
                cardFaceUp = false;
            }
            else
            {
                pctrBxCard.Image = cardFace;
                cardFaceUp = true;
            }
        }

        public int FaceImageIndex()
        {
            return _cardNumber + 1;
        }
    }
}
