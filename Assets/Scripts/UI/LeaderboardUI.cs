using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LeaderboardUI : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;

    void OnEnable()
    {
        GameEvents.OnScoreChanged += UpdateLeaderboard;
    }

    void OnDisable()
    {
        GameEvents.OnScoreChanged -= UpdateLeaderboard;
    }

    void UpdateLeaderboard(PlayerModel player)
    {
        List<PlayerModel> players = MatchController.Instance.playerManager.Players;

        players.Sort((a, b) => b.Score.CompareTo(a.Score));

        string board = "Leaderboard\n";

        foreach (var p in players)
        {
            board += "Player " + p.Id + " : " + p.Score + "\n";
        }

        leaderboardText.text = board;
    }
}