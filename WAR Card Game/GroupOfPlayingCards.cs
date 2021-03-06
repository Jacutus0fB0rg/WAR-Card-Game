﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WAR_Card_Game
{
    enum State { Initial, Gathered, Spread }        // Inital state is that the cards in this group have just been created 
                                                    // Gathered state is that the cards have been repositioned to all the same spot
                                                    // Spread state is that the cards have been spread out on the application form 
    class GroupOfPlayingCards
    {
        // this class is meant to model a group of playing cards from a deck of cards

        private string _identifier;                 // string variable which allows the group to be identified
        private List<PlayingCard> _group;           // List of playing cards in this group
        private State _state;                       // condition (state of being) of the group
        private Point _location;                    // position of the group on the application form

        public GroupOfPlayingCards()                // group constructor method
        {
            _identifier = "";
            _group = new List<PlayingCard>();
            _state = State.Initial;
        }

        // Indentifier property
        public string Identifier
        {
            get { return _identifier; }

            set { _identifier = value; }
        }

        // Group (List) property 
        public List<PlayingCard> Group
        {
            get { return _group; }

            set { _group = value; }
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public void AddCardToGroup(PlayingCard targetCard)
        {
            _group.Add(targetCard);
        }

        public void RemoveCardFromGroup(int index)
        {
            // determine if the index value is within the range of the group list
            // check to see if group count is greater than the index value
            if (_group.Count > index)
                // if group count is greater than index value, then remove the card at the target index
                _group.RemoveAt(index);
            else
                // if group count is not greater than index value, display an error message
                MessageBox.Show("Tried to remove card at index " + index + " from group " + _identifier + " whose count is " + _group.Count,
                    "Card Group Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void InsertCardToGroup(PlayingCard targetCard, int index)
        {
            // determine if the index value is within the range of the group list
            // check to see if group count is greater than the index value
            if (_group.Count > index)
                // if group count is greater than index value, then insert the card at the target index
                _group.Insert(index, targetCard);
            else
                // if group count is not greater than index value, display an error message
                MessageBox.Show("Tried to insert card at index " + index + " in group " + _identifier + " whose count is " + _group.Count,
                    "Card Group Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public PlayingCard GetCard(int index)
        {
            // determine if the index value is within the range of the group list
            // check to see if group count is greater than the index value
            if (_group.Count > index)
                // if group count is greater than index value, then return the card at the target index
                return _group[index];
            else
            {
                // if group count is not greater than index value, display an error message then return null
                MessageBox.Show("Tried to get card at index " + index + " in group " + _identifier + " whose count is " + _group.Count,
                    "Card Group Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public void SetCard(PlayingCard targetCard, int index)
        {
            // determine if the index value is within the range of the group list
            // check to see if group count is greater than the index value
            if (_group.Count > index)
                // if group count is greater than index value, then set the card at the target index
                _group[index] = targetCard;
            else
                // if group count is not greater than index value, display an error message
                MessageBox.Show("Tried to set card at index " + index + " in group " + _identifier + " whose count is " + _group.Count,
                    "Card Group Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public int GetCount()
        {
            return _group.Count;
        }
    }
}
