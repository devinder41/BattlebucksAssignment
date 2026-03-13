using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public MatchTimer matchTimer;
    public TextMeshProUGUI timerText;

    void Update()
    {
        float time = matchTimer.matchTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}