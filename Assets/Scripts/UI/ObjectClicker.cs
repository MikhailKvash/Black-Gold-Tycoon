using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField] private GameObject mainBuildingMenu;
    [SerializeField] private GameObject villagerHouseMenu;
    [SerializeField] private GameObject oilTowerMenu;
    [SerializeField] private GameObject storageMenu;
    [SerializeField] private GameObject docksMenu;
    [SerializeField] private GameObject mapMenu;
    [SerializeField] private GameObject settingsMenu;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private OilTower oilTower;
    [SerializeField] private TreasureChest treasureChest;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (EventSystem.current.currentSelectedGameObject != null) return;
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f,LayerMask.GetMask("Buildings")))
            {
                if (hit.collider)
                {
                    audioManager.Play("OpenMenu");
                    
                    mainBuildingMenu.SetActive(hit.collider.CompareTag("MainBuilding"));
                    villagerHouseMenu.SetActive(hit.collider.CompareTag("VillagerHouse"));
                    oilTowerMenu.SetActive(hit.collider.CompareTag("OilTower"));
                    storageMenu.SetActive(hit.collider.CompareTag("Storage"));
                    docksMenu.SetActive(hit.collider.CompareTag("Docks"));
                }
            }

            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("OilClicker")))
            {
                oilTower.ClickOil();
            }
            
            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("TreasureChest")))
            {
                treasureChest.GetReward();
            }
        }
    }

    public void DisableUI()
    {
        audioManager.Play("CloseMenu");
        
        mainBuildingMenu.SetActive(false);
        villagerHouseMenu.SetActive(false);
        oilTowerMenu.SetActive(false);
        storageMenu.SetActive(false);
        docksMenu.SetActive(false);
        mapMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
}