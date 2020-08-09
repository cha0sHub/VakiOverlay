namespace FightGameOverlayCore.Interfaces.Models
{
    public interface IMatchModel
    {
        string CurrentNamePlayerOne { get; set; }
        string CurrentNamePlayerTwo { get; set; }
        string CurrentTournamentRound { get; set; }
        int CurrentWinsPlayerOne { get; set; }
        int CurrentWinsPlayerTwo { get; set; }
        string DisplayedNamePlayerOne { get; set; }
        string DisplayedNamePlayerTwo { get; set; }
        string DisplayedTournamentRound { get; set; }
        int DisplayedWinsPlayerOne { get; set; }
        int DisplayedWinsPlayerTwo { get; set; }
    }
}