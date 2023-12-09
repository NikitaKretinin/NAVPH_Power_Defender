using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;

    public string collisionListenToTag = "Player";
    public GenericPlant plant;
    private bool _wasTriggered = false;
    [SerializeField] GameObject unlockedPlantInfoUI;
    [SerializeField] GameObject globalInventoryObject;
    [SerializeField] GameObject GuiElements;
    [SerializeField] GameObject thanksButton;
    [SerializeField] GameObject plantInfoText;
    private GlobalInventoryBehaviour globalInventory = null;

    private void Start()
    {
        globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>();
    }

    // function called when the player enters the trigger zone around the chest
    // the chest is opened and the player is rewarded with a new plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvents != null && !_wasTriggered && collision.CompareTag(collisionListenToTag))
        {
            _wasTriggered = true;
            myEvents.Invoke();

            GenericPlant unlockedPlant = globalInventory.UnlockNextPlant();
            if (unlockedPlant != null)
            {
                GuiElements.SetActive(false);
                Time.timeScale = 0;
                thanksButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    globalInventory.SwitchToNextAttackLevel();
                    globalInventory.RemoveMap();
                    Time.timeScale = 1;
                    SceneManager.LoadScene("VictoryScreen");
                });
                plantInfoText.transform.Find("Name").GetComponent<TextMeshProUGUI>().text += unlockedPlant.name;
                plantInfoText.transform.Find("Effect").GetComponent<TextMeshProUGUI>().text += FruitsEffects.GetEffectDescription(unlockedPlant.effect);
                plantInfoText.transform.Find("RipeTime").GetComponent<TextMeshProUGUI>().text += unlockedPlant.ripeTime + " seconds";

                var sprites = Resources.LoadAll<Sprite>(InterScene.ImagePath);
                var slot = plantInfoText.transform.Find("PlantSlot");
                slot.Find("PlantSprite").GetComponent<Image>().sprite = sprites[unlockedPlant.imageIndex];

                unlockedPlantInfoUI.SetActive(true);
            }
        }
    }
}
