using System.Collections;
using TMPro;
using UnityEngine;

public class CarriedOilNumber : MonoBehaviour
{
    [SerializeField] private OilVillager oilVillager;
    
    public TextMeshPro TextDialog;
    private float _carriedOilNumber;
    private bool _singleDelivery;

    #region Public links
    public float CarriedOilNumber1
    {
        get => _carriedOilNumber;
        set => _carriedOilNumber = value;
    }
    public bool SingleDelivery
    {
        get => _singleDelivery;
        set => _singleDelivery = value;
    }
    #endregion
    
    private IEnumerator TypeText(string text)
    {
        TextDialog.text = "";
        foreach (char c in text)
        {
            TextDialog.text += c;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(FadeOutText());
    }
    
    IEnumerator FadeOutText()
    {
        if (TextDialog != null)
        {
            Color textColor = TextDialog.color;

            for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
            {
                textColor.a = t;
                TextDialog.color = textColor;
                yield return null;
            }

            TextDialog.text = "";
            TextDialog.color = new Color(textColor.r, textColor.g, textColor.b, 1f);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_singleDelivery)
        {
            _singleDelivery = true;
            if (oilVillager.CarryingOil <= 1)
            {
                StartCoroutine(TypeText("+" + _carriedOilNumber + " Нефть"));
            }
            else
            {
                StartCoroutine(TypeText("+" + _carriedOilNumber + " Нефти"));
            }
        }
    }
}
