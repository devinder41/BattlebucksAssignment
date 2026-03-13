using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager
{
    public List<PlayerModel> Players = new List<PlayerModel>();

    GameObject playerPrefab;
    Transform parent;

    public PlayerManager(GameObject prefab, Transform parentTransform)
    {
        playerPrefab = prefab;
        parent = parentTransform;
    }

    public void SpawnPlayers(int count)
    {
        Players.Clear();

        for (int i = 0; i < count; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-10f, 10f),
                .5f,
                Random.Range(-10f, 10f)
            );

            GameObject obj = GameObject.Instantiate(playerPrefab, randomPos, Quaternion.identity, parent);
            // SET PLAYER NUMBER
            TextMeshPro text = obj.GetComponentInChildren<TextMeshPro>();
            text.text = "Player " + (i + 1);

            PlayerModel player = new PlayerModel(i);
            player.View = obj;

            Players.Add(player);
        }
    }
}