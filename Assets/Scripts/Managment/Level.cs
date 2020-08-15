using UnityEngine;

[CreateAssetMenu(fileName ="NewLevel", menuName = "Create Level")]
public class Level : ScriptableObject
{
    public LevelType LevelType;
    public int CountWin;
}

public enum LevelType
{
    Asteroid,
    Time
}
