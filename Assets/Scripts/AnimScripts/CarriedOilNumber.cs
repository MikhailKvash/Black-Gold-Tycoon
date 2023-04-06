using System.Collections;
using TMPro;
using UnityEngine;

public class CarriedOilNumber : MonoBehaviour
{
    [SerializeField] private OilVillager oilVillager;
    
    public TextMeshPro TextDialog;

    private IEnumerator TypeText(string text)
    {
        TextDialog.text = "";
        foreach (char c in text)
        {
            TextDialog.text += c;
            yield return new WaitForSeconds(0.1f);
        }
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
        if (other.CompareTag("Player"))
        {
            if (oilVillager.CarryingOil <= 1)
            {
                StartCoroutine(TypeText("+" + oilVillager.CarryingOil + " Нефть"));
            }
            else
            {
                StartCoroutine(TypeText("+" + oilVillager.CarryingOil + " Нефти"));
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOutText());
        }
    }
}
