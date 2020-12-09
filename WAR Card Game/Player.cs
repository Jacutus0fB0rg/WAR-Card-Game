using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAR_Card_Game
{
    class Player
    {
        private string _identifier;
        private string _name;
        private CardReference _comparisonCard;
        private int _score;

        public Player()
        {
            _identifier = "";
            _name = "";
            _comparisonCard = new CardReference();
            _score = 0;
        }

        public string Identifier
        {
            get { return _identifier; }

            set { _identifier = value; }
        }

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public CardReference ComparisonCard
        {
            get { return _comparisonCard; }

            set { _comparisonCard = value; }
        }

        public int Score
        {
            get { return _score; }

            set { _score = value; }
        }
    }
}
