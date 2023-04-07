using System;
using UnityEngine;
using TMPro;

public class MainBuilding : MonoBehaviour
{
    [SerializeField] private int level;
    
    [SerializeField] private GameObject mainBuildingLevelDisplay;

    public int Level
    {
        get => level;
        set => level = value;
    }

    public void Update()
    {
        mainBuildingLevelDisplay.GetComponent<TextMeshProUGUI>().text = level + " ";
    }
}
