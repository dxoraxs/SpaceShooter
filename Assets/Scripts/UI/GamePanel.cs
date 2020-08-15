using UnityEngine;
using UnityEngine.UI;

public class GamePanel : Panel
{
    [SerializeField] private Text count;

    private void Start()
    {
        EventManager.UpdateUILevel += SetText;
    }

    private void SetText(int value)
    {
        count.text = value.ToString();
    }

    private void OnDestroy()
    {
        EventManager.UpdateUILevel -= SetText;
    }
}
