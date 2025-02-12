using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        private readonly int _numberOfPlayers;
        private IList<string> _marks = new List<string>();

        public int Active { private set; get; }
        public string Mark { get { return _marks[Active-1]; } }

        public Player(int maxPlayers = 2)
        {
            _numberOfPlayers = maxPlayers;
            Active = 1;
            SetMarks(maxPlayers);
        }

        public void NextPlayer()
        {
            if ((Active + 1) > _numberOfPlayers)
            {
                Active = 1;
                return;
            }
            Active++;
        }

        private void SetMarks(int maxPlayers)
        {
            //TODO: generic randomly create marks for the number of players.
            _marks = new List<string>();
            _marks.Add("X");
            _marks.Add("O");
        }
    }
}
