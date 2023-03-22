using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapMenu : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;

    [SerializeField] private Slider shipTimeSlider;
    [SerializeField] private GameObject sliderPercentageDisplay;

    private void Update()
    {
        FillSlider();
        sliderPercentageDisplay.GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(timeManager.PassedTime / timeManager.NeededTime*100) + "%";
    }

    private void FillSlider()
    {
        shipTimeSlider.value = timeManager.PassedTime/timeManager.NeededTime;
    }
}