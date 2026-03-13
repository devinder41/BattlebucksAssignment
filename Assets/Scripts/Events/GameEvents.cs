
using System;

public static class GameEvents
{
    public static Action<PlayerModel, PlayerModel> OnPlayerKilled;
    public static Action<PlayerModel> OnPlayerRespawn;
    public static Action<PlayerModel> OnScoreChanged;
    public static Action OnMatchEnd;
}
