
using UnityEngine;

public class PlayerModel
{
    public int Id;
    public int Score;
    public bool IsAlive = true;

    public GameObject View;

    public PlayerModel(int id)
    {
        Id = id;
        Score = 0;
    }
}
