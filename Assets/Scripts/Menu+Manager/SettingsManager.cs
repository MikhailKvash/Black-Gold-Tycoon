using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject soundOnButton;
    [SerializeField] private GameObject soundOnText;
    [SerializeField] private Slider volumeSlider;
    
    [SerializeField] private GameObject lowQualityDisplay;
    [SerializeField] private GameObject medQualityDisplay;
    [SerializeField] private GameObject highQualityDisplay;
    
    public AudioMixer audioMixer;

    private float _loadedVolume;
    private int _loadedQuality = 1;
    private int _loadedSoundOn = 1;
    private bool _muted;
    

    public void Start()
    {
        _loadedVolume = PlayerPrefs.GetFloat("VolumeLevel");
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeSlider");
        audioMixer.GetFloat("volume", out _loadedVolume);

        _loadedQuality = PlayerPrefs.GetInt("Quality");
        if (_loadedQuality == 0)
        {
            QualitySettings.SetQualityLevel(0, false);
            lowQualityDisplay.SetActive(true);
            medQualityDisplay.SetActive(false);
            highQualityDisplay.SetActive(false);
        }
        if (_loadedQuality == 1)
        {
            QualitySettings.SetQualityLevel(1, false);
            lowQualityDisplay.SetActive(false);
            medQualityDisplay.SetActive(true);
            highQualityDisplay.SetActive(false);
        }
        if (_loadedQuality == 2)
        {
            QualitySettings.SetQualityLevel(2, false);
            lowQualityDisplay.SetActive(false);
            medQualityDisplay.SetActive(false);
            highQualityDisplay.SetActive(true);
        }

        _loadedSoundOn = PlayerPrefs.GetInt("SoundOn");
        if (_loadedSoundOn == 0)
        {
            AudioListener.volume = 0;
            _muted = true;
            soundOnButton.SetActive(false);
            soundOnText.GetComponent<TextMeshProUGUI>().text = "Выключен";
        }
        if (_loadedSoundOn == 1)
        {
            AudioListener.volume = 1;
            _muted = false;
            soundOnButton.SetActive(true);
            soundOnText.GetComponent<TextMeshProUGUI>().text = "Включен";
        }
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumeSlider", volume);
        PlayerPrefs.SetFloat("VolumeLevel", Mathf.Log10(volume) * 20);
    }
    
    public void MuteAudio ()
    {
        if (!_muted)
        {
            AudioListener.volume = 0;
            _muted = true;
            soundOnButton.SetActive(false);
            soundOnText.GetComponent<TextMeshProUGUI>().text = "Выключен";
            PlayerPrefs.SetInt("SoundOn", 0);
        }
        else
        {
            AudioListener.volume = 1;
            _muted = false;
            soundOnButton.SetActive(true);
            soundOnText.GetComponent<TextMeshProUGUI>().text = "Включен";
            PlayerPrefs.SetInt("SoundOn", 1);
        }
    }

    public void SetQualityLow()
    {
        QualitySettings.SetQualityLevel(0, false);
        PlayerPrefs.SetInt("Quality", 0);
    }
    
    public void SetQualityMedium()
    {
        QualitySettings.SetQualityLevel(1, false);
        PlayerPrefs.SetInt("Quality", 1);
    }
    
    public void SetQualityHigh()
    {
        QualitySettings.SetQualityLevel(2, false);
        PlayerPrefs.SetInt("Quality", 2);
    }
}
