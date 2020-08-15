using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemLevel : MonoBehaviour
{
    [SerializeField] private GameObject lockImage;
    [SerializeField] private Text textNumber;
    [SerializeField] private Image imageBackground;
    private Action<int> onClick; 
    private int index;

    public void InitItemLevel(int number, bool open, bool complite, Action<int> onClick)
    {
        if (open)
        {
            if (complite)
                imageBackground.color = Color.green;
            lockImage.SetActive(false);
            index = number;
            textNumber.text = (index + 1).ToString();
            this.onClick = onClick;
        }
        else
        {
            textNumber.gameObject.SetActive(false);
        }
    }

    public void OnClickButton()
    {
        onClick?.Invoke(index);
    }
}
