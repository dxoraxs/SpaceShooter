using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    [SerializeField] private PlayerShip player;
    [SerializeField] private MainUI mainUi;
    [SerializeField] private UnityEvent onClickStartGame;
    [SerializeField] private UnityEvent OnEndGame;
    private SaveData saveData;
    private LevelConfig currentLevelType;
    private int currentIndextLevel;

    public static void StartGame(int indexScene)
    {
        Instance.onClickStartGame?.Invoke();
        Instance.mainUi.HideStartPanel();
        Instance.mainUi.ShowGamePanel();
        SelectLevel(indexScene);

        Instance.enabled = true;
    }

    private static void SelectLevel(int indexScene)
    {
        Instance.currentIndextLevel = indexScene;

        var currentLevel = GameSettings.GetLevel(indexScene);
        if (currentLevel.LevelType == LevelType.Asteroid)
            Instance.currentLevelType = new AsteroidLevel(currentLevel);
        else if (currentLevel.LevelType == LevelType.Time)
            Instance.currentLevelType = new TimeLevel(currentLevel);
    }

    public static void RestartLevel()
    {
        Instance.currentLevelType = null;
        Instance.mainUi.HideEndPanel();
        Instance.mainUi.ShowGamePanel();
        AsteroidPool.ClearAsteroid();
        Instance.player.StartHealth();
        Instance.player.transform.position = Vector3.zero;
        StartGame(Instance.currentIndextLevel);
    }

    public static void EndGame()
    {
        Instance.mainUi.HideGamePanel();
        var endPanel = Instance.mainUi.ShowEndPanel();
        Instance.enabled = false;
        endPanel.InitEndPanel(true);
        Instance.OnEndGame?.Invoke();

        Instance.SaveOpenLevel();
        Instance.SaveCompleteLevel();

        SaveData();

        SelectLevel(Instance.currentIndextLevel + 1);
    }

    private void SaveOpenLevel()
    {
        var listOpen = new List<int>(saveData.openLevel);
        if (listOpen.Contains(currentIndextLevel + 1)) return;
        listOpen.Add(currentIndextLevel + 1);
        saveData.openLevel = listOpen.ToArray();
    }

    private void SaveCompleteLevel()
    {
        var listComplite = new List<int>(saveData.completeLevel);
        listComplite.Add(currentIndextLevel);
        saveData.completeLevel = listComplite.ToArray();
    }

    public static void PlayerDied()
    {
        Instance.OnEndGame?.Invoke();
        Instance.enabled = false;
        Instance.mainUi.HideGamePanel();
        var endPanel = Instance.mainUi.ShowEndPanel();
        endPanel.InitEndPanel(false);
    }

    private void Update()
    {
        if (currentLevelType != null)
        {
            Debug.Log("Update " + nameof(currentIndextLevel));
            currentLevelType.Update(Time.deltaTime);
        }
    }

    public static SaveData GetSaveData()
    {
        if (Instance.saveData == null)
            Instance.LoadData();

        return Instance.saveData;
    }

    public static void SaveData()
    {
        string json = JsonUtility.ToJson(Instance.saveData);
        PlayerPrefs.SetString("data", json);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("data"))
        {
            string json = PlayerPrefs.GetString("data");
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else saveData = new SaveData();
    }
}