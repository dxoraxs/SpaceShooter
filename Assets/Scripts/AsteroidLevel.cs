public class AsteroidLevel : LevelConfig
{
    private int countDestroy;
    
    public AsteroidLevel(Level level) : base(level)
    {
        EventManager.OnAsteroidDestroy += CountAsteroidDied;
    }

    private void CountAsteroidDied()
    {
        countDestroy++;
        EventManager.UpdateUILevel?.Invoke(countDestroy);
        if (countDestroy == currentLevel.CountWin)
        {
            LevelFinal();
        }
    }

    public override void Update(float stepTime){}

    protected override void LevelFinal()
    {
        base.LevelFinal();
        EventManager.OnAsteroidDestroy -= CountAsteroidDied;
    }
}
