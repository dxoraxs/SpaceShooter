using System.Linq;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Panel[] panels;

    public void HideStartPanel()
    {
        panels.First(x => x.GetType() == typeof(StartPanel)).Hide();
    }

    public void HideGamePanel()
    {
        panels.First(x => x.GetType() == typeof(GamePanel)).Hide();
    }

    public void ShowGamePanel()
    {
        panels.First(x => x.GetType() == typeof(GamePanel)).Show();
    }

    public void HideEndPanel()
    {
        panels.First(x => x.GetType() == typeof(EndPanel)).Hide();
    }

    public EndPanel ShowEndPanel()
    {
        var endPanel = panels.First(x => x.GetType() == typeof(EndPanel));
        endPanel.Show();
        return endPanel.GetComponent<EndPanel>();
    }
}