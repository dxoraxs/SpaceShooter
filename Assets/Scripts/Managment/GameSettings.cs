using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="GameSettings", menuName = "Create CameraPosition")]
public class GameSettings : ScriptableObject
{
    private static GameSettings _instance;
    [SerializeField] private PlayerSettings Player;
    [SerializeField] private Level[] levels;

    private static GameSettings Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.FindObjectsOfTypeAll<GameSettings>().FirstOrDefault();
            return _instance;
        }
    }
    
    public static PlayerSettings GetPlayerSettings => Instance.Player;
    public static Level[] GetAllLevel => Instance.levels;
    public static Level GetLevel(int index) => Instance.levels[index];
    
}

[Serializable]
public class PlayerSettings
{
    public int Health;
    public float Speed;
    public float DelayShot;
}
