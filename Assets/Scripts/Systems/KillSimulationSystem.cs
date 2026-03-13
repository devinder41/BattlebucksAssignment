
using System.Collections;
using UnityEngine;

public class KillSimulationSystem : MonoBehaviour
{
    PlayerManager playerManager;
    ScoreSystem scoreSystem;

    void Start()
    {
        playerManager = MatchController.Instance.playerManager;
        scoreSystem = MatchController.Instance.scoreSystem;

        StartCoroutine(OnStart());
    }

    IEnumerator OnStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            var players = playerManager.Players;

            var killer = players[Random.Range(0, players.Count)];
            var victim = players[Random.Range(0, players.Count)];

            if (killer == victim || !victim.IsAlive)
                continue;

            victim.IsAlive = false;

            scoreSystem.RegisterKill(killer);

            GameEvents.OnPlayerKilled?.Invoke(killer, victim);

            victim.IsAlive = false;

            if (victim.View != null)
            {
                victim.View.SetActive(false);
            }

            StartCoroutine(Respawn(victim));
        }
    }

    IEnumerator Respawn(PlayerModel player)
    {
        yield return new WaitForSeconds(3f);

        Vector3 newPos = new Vector3(
            Random.Range(-10f, 10f),
            .5f,
            Random.Range(-10f, 10f)
        );

        player.View.transform.position = newPos;
        player.View.SetActive(true);

        player.IsAlive = true;
    }
}
