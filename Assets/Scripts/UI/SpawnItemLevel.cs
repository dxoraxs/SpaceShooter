using System.Collections.Generic;
using UnityEngine;

public class SpawnItemLevel : MonoBehaviour
{
    [SerializeField] private ItemLevel prefabItem;

    private void Start()
    {
        var levels = new List<Level>(GameSettings.GetAllLevel);
        var openLevel = new List<int>(GameManager.GetSaveData().openLevel);
        var compliteLevel = new List<int>(GameManager.GetSaveData().completeLevel);
        for (var index = 0; index < levels.Count; index++)
        {
            var item = Instantiate(prefabItem, transform);
            item.InitItemLevel(index, openLevel.Contains(index), compliteLevel.Contains(index), OnClick);
        }
    }

    private void OnClick(int index)
    {
        GameManager.StartGame(index);
    }
}
