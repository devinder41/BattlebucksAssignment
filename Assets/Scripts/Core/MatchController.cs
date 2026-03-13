
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public static MatchController Instance;

    public PlayerManager playerManager;
    public ScoreSystem scoreSystem;

    public GameObject playerPrefab;
    public Transform playersParent;

    void Awake()
    {
        Instance = this;

        playerManager = new PlayerManager(playerPrefab, playersParent);
        playerManager.SpawnPlayers(10);
        scoreSystem = new ScoreSystem();
    }
}
