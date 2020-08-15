using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : Panel
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    private AudioEndLevel audioEndLevel;

    private void Awake()
    {
        audioEndLevel = GetComponent<AudioEndLevel>();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void InitEndPanel(bool win)
    {
        Debug.Log(audioEndLevel);
        audioEndLevel.PlayMusic(win);
        winPanel.SetActive(win);
        losePanel.SetActive(!win);
    }

    public void RestartLevel()
    {
        GameManager.RestartLevel();
    }
}