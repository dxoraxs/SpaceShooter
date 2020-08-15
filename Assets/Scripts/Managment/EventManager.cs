using System;
public class EventManager
{
    public static Action OnUpdateHealth;
    public static Action OnLoseGame;

    public static Action OnAsteroidDestroy;
    public static Action<int> UpdateUILevel;
}