using UnityEngine;
using TMPro;
using System.Collections;

public class TimerUI : MonoBehaviour
{
    public MatchTimer matchTimer;
    public TextMeshProUGUI timerText;

    void OnEnable()
    {
        StartCoroutine(UpdateTimer());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            float time = matchTimer.matchTime;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            yield return new WaitForSeconds(1f);
        }
    }
}