using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerUI : MonoBehaviour
{
    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;
    public Button RestartBtn;

    void OnEnable()
    {
        GameEvents.OnMatchEnd += ShowWinner;
        RestartBtn.onClick.AddListener(delegate
        {
            OnRestartBtnClick();
        });
    }

    void OnDisable()
    {
        GameEvents.OnMatchEnd -= ShowWinner;
        RestartBtn.onClick.RemoveAllListeners();
    }

    void ShowWinner()
    {
        var players = MatchController.Instance.playerManager.Players;

        PlayerModel winner = players.OrderByDescending(p => p.Score).First();

        winnerPanel.SetActive(true);

        winnerText.text = "Winner: Player " + winner.Id +
                          "\nScore: " + winner.Score;
    }

    public void OnRestartBtnClick()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}