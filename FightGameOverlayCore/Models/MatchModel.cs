using FightGameOverlayCore.Interfaces.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FightGameOverlayCore.Models
{
    internal class MatchModel : INotifyPropertyChanged, IMatchModel
    {
        private int _currentWinsPlayerOne;
        private int _currentWinsPlayerTwo;
        private int _displayedWinsPlayerOne;
        private int _displayedWinsPlayerTwo;
        private string _currentNamePlayerOne;
        private string _currentNamePlayerTwo;
        private string _displayedNamePlayerOne;
        private string _displayedNamePlayerTwo;
        private string _currentTournamentRound;
        private string _displayedTournamentRound;

        public int CurrentWinsPlayerOne
        {
            get
            {
                return _currentWinsPlayerOne;
            }
            set
            {
                _currentWinsPlayerOne = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentWinsPlayerTwo
        {
            get
            {
                return _currentWinsPlayerTwo;
            }
            set
            {
                _currentWinsPlayerTwo = value;
                NotifyPropertyChanged();
            }
        }

        public int DisplayedWinsPlayerOne
        {
            get
            {
                return _displayedWinsPlayerOne;
            }
            set
            {
                _displayedWinsPlayerOne = value;
                NotifyPropertyChanged();
            }
        }

        public int DisplayedWinsPlayerTwo
        {
            get
            {
                return _displayedWinsPlayerTwo;
            }
            set
            {
                _displayedWinsPlayerTwo = value;
                NotifyPropertyChanged();
            }
        }

        public string CurrentNamePlayerOne
        {
            get
            {
                return _currentNamePlayerOne;
            }
            set
            {
                _currentNamePlayerOne = value;
                NotifyPropertyChanged();
            }
        }

        public string CurrentNamePlayerTwo
        {
            get
            {
                return _currentNamePlayerTwo;
            }
            set
            {
                _currentNamePlayerTwo = value;
                NotifyPropertyChanged();
            }
        }

        public string DisplayedNamePlayerOne
        {
            get
            {
                return _displayedNamePlayerOne;
            }
            set
            {
                _displayedNamePlayerOne = value;
                NotifyPropertyChanged();
            }
        }

        public string DisplayedNamePlayerTwo
        {
            get
            {
                return _displayedNamePlayerTwo;
            }
            set
            {
                _displayedNamePlayerTwo = value;
                NotifyPropertyChanged();
            }
        }

        public string CurrentTournamentRound
        {
            get
            {
                return _currentTournamentRound;
            }
            set
            {
                _currentTournamentRound = value;
                NotifyPropertyChanged();
            }
        }

        public string DisplayedTournamentRound
        {
            get
            {
                return _displayedTournamentRound;
            }
            set
            {
                _displayedTournamentRound = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
