﻿using System.Collections.Generic;

namespace PollBall.Services
{
    public class PollResultsService : IPollResultsService
    {
        private Dictionary<SelectedGame, int> _selectionVotes;

        public PollResultsService() { 
            _selectionVotes = new Dictionary<SelectedGame, int>();
        }

        public void AddVote(SelectedGame game)
        {
            if (_selectionVotes.ContainsKey(game))
            {
                _selectionVotes[game] += 1;
            }
            else
            {
                _selectionVotes.Add(game, 1);
            }
        }

        public SortedDictionary<SelectedGame, int> GetVoteResult()
        {
            return new SortedDictionary<SelectedGame, int>(_selectionVotes);
        }
    }
}
