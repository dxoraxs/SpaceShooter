public class TimeLevel : LevelConfig
{
    private float timeLevel;
    
    public override void Update(float stepTime)
    {
        timeLevel -= stepTime;
        EventManager.UpdateUILevel?.Invoke((int)timeLevel);
        if (timeLevel <= 0)
        {
            LevelFinal();
        }
    }

    public TimeLevel(Level level) : base(level)
    {
        timeLevel = level.CountWin;
    }
}
