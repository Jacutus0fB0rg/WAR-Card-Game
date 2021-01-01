using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAR_Card_Game
{
    class CardReference
    {
        // This class is meant to refer to a card in the deckOfPlayingCards List
        // of groups of playing cards

        private int _group;             // index for the group of cards the referenced card is in
        private int _card;              // index for the card number of the referenced card in the referenced group of cards

        public CardReference()
        {
            _group = -1;                // card references are intialized to not refer to any card yet when this constructor is used
            _card = -1;
        }

        public CardReference(int group, int card)
        {
            _group = group;             // with this constructor, the card reference is created referring to a particular card
            _card = card;
        }

        // Group (index) property
        public int Group
        {
            get
            {
                return _group;
            }

            set
            {
                _group = value;
            }
        }

        // Card (index) property
        public int Card
        {
            get
            {
                return _card;
            }

            set
            {
                _card = value;
            }
        }

    }
}
