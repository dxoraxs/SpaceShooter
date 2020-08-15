public abstract class LevelConfig
{
    public Level currentLevel;

    public LevelConfig(Level level)
    {
        currentLevel = level;
    }
    
    public abstract void Update(float stepTime);

    protected virtual void LevelFinal()
    {
        GameManager.EndGame();
    }
}