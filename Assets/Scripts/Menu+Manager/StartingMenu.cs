using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;

public class StartingMenu : MonoBehaviour
{
    [SerializeField] private GameObject startingMenu;
    [SerializeField] private TMP_Text playerNameFinal;
    [SerializeField] private TMP_InputField inputText;
    
    [SerializeField] private GameObject notEnoughMessage;
    [SerializeField] private AudioManager audioManager;

    private const string PlayerNameKey = "PlayerFinalName";

    private void Start()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            playerNameFinal.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString(PlayerNameKey);
        }
        else
        {
            startingMenu.SetActive(true);
        }
    }

    public void AcceptName()
    {
        string inputTextString = inputText.text;

        if (!string.IsNullOrEmpty(inputTextString))
        {
            if (IsValidName(inputTextString))
            {
                playerNameFinal.GetComponent<TextMeshProUGUI>().text = inputText.text;
                startingMenu.SetActive(false);
                audioManager.Play("TreasureChest");

                PlayerPrefs.SetString(PlayerNameKey, inputText.text);
                PlayerPrefs.Save();
            }
            else
            {
                notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Имя не может содержать спецсимволы!";
                notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
                audioManager.Play("NotEnough");
            }
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Необходимо ввести имя!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }

    private bool IsValidName(string name)
    {
        // Regular expression pattern to match only letters, digits, and space
        string pattern = @"^[a-zA-Z0-яА-Я0-9 ]+$";

        // Check if the name matches the pattern
        return Regex.IsMatch(name, pattern);
    }
    
    public void NameNeeded()
    {
        notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Необходимо ввести имя!";
        notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        audioManager.Play("NotEnough");
    }
    
    public void DeleteName()
    {
        PlayerPrefs.DeleteKey(PlayerNameKey);
    }
}
