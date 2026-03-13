
using UnityEngine;

public class MatchTimer : MonoBehaviour
{
    public float matchTime = 180f;

    void Update()
    {
        matchTime -= Time.deltaTime;

        if (matchTime <= 0)
        {
            GameEvents.OnMatchEnd?.Invoke();
            enabled = false;
        }
    }
}
