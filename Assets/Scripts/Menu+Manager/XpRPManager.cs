using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpRpManager : MonoBehaviour
{
    [SerializeField] private GameObject xpDisplay;
    [SerializeField] private GameObject rpDisplay;

    [SerializeField] private GameObject xpUpArrow;
    [SerializeField] private GameObject rpUpArrow;
    
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private Slider xpSlider;
    [SerializeField] private Slider rpSlider;

    private float _xp;
    private float _rp;

    private float _xpLvl;
    private float _rpLvl;

    #region Public links
    public float Xp
    {
        get => _xp;
        set => _xp = value;
    }
    public float Rp
    {
        get => _rp;
        set => _rp = value;
    }
    public float XpLvl
    {
        get => _xpLvl;
        set => _xpLvl = value;
    }
    public float RpLvl
    {
        get => _rpLvl;
        set => _rpLvl = value;
    }
    #endregion

    public void Start()
    {
        _xpLvl = 1;
        _rpLvl = 1;
    }

    public void Update()
    {
        xpSlider.value = _xp;
        rpSlider.value = _rp;
        
        if (xpSlider.value == xpSlider.maxValue)
        {
            _xpLvl += 1;
            _xp = 0;
            StartCoroutine(XpUp());
            audioManager.Play("XpRpUp");
        }
        
        if (rpSlider.value == rpSlider.maxValue)
        {
            _rpLvl += 1;
            _rp = 0;
            StartCoroutine(RpUp());
            audioManager.Play("XpRpUp");
        }
        
        xpDisplay.GetComponent<TextMeshProUGUI>().text = "" + _xpLvl;
        rpDisplay.GetComponent<TextMeshProUGUI>().text = "" + _rpLvl;
    }

    public void PlayRpUp()
    {
        StartCoroutine(RpUp());
        audioManager.Play("XpRpUp");
    }
    
    private IEnumerator XpUp ()
    {
        xpUpArrow.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        xpUpArrow.SetActive(false);
    }
    
    private IEnumerator RpUp ()
    {
        rpUpArrow.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        rpUpArrow.SetActive(false);
    }
}
