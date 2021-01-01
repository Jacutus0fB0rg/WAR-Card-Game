using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAR_Card_Game
{
    class Player                                            // this class is meant to model a player of the WAR Card Game
    {
        private string _identifier;                         // tells whether the player is the top or bottom player
        private string _name;                               // first name of the player
        private CardReference _comparisonCard;              // reference to the card in the deckOfPlayingCards that is to be compared during 
                                                            // the current round of game play
        private int _score;                                 // current score of the player (number of cards currently posessed by the player)

        public Player()                                     // constructor method
        {
            _identifier = "";                               
            _name = "";
            _comparisonCard = new CardReference();
            _score = 0;
        }

        // Identifier property
        public string Identifier
        {
            get { return _identifier; }

            set { _identifier = value; }
        }

        // Name property
        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        // Comparison Card property
        public CardReference ComparisonCard
        {
            get { return _comparisonCard; }

            set { _comparisonCard = value; }
        }

        // Score property
        public int Score
        {
            get { return _score; }

            set { _score = value; }
        }
    }
}
