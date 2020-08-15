using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject indicatorPrefab;
    private List<GameObject> indicators = new List<GameObject>();

    private void OnEnable()
    {
        for (int i = 0; i < GameSettings.GetPlayerSettings.Health; i++)
        {
            var indicator = Instantiate(indicatorPrefab, transform);
            indicators.Add(indicator);
        }
        EventManager.OnUpdateHealth += UpdateBar;
    }

    private void OnDisable()
    {
        EventManager.OnUpdateHealth -= UpdateBar;
    }

    private void UpdateBar()
    {
        if (indicators.Count == 0) return;

        var selectIndicators = indicators[indicators.Count - 1];
        Destroy(selectIndicators);
        indicators.Remove(selectIndicators);
    }
}
