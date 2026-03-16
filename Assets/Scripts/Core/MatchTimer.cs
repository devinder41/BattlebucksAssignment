
using System.Collections;
using UnityEngine;

public class MatchTimer : MonoBehaviour
{
    public float matchTime = 180f;

    void OnEnable()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (matchTime > 0)
        {
            yield return new WaitForSeconds(1f);
            matchTime -= 1f;
        }

        GameEvents.OnMatchEnd?.Invoke();
    }
}
