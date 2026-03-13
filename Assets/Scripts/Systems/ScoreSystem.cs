
public class ScoreSystem
{
    public void RegisterKill(PlayerModel killer)
    {
        killer.Score++;

        GameEvents.OnScoreChanged?.Invoke(killer);

        if (killer.Score >= 10)
        {
            GameEvents.OnMatchEnd?.Invoke();
        }
    }
}
