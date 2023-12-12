using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;
    readonly string COLLISION_LISTEN_TO_TAG = "Player";
    public GenericPlant plant;
    bool wasTriggered = false;
    [SerializeField] GameObject unlockedPlantInfoUI;
    [SerializeField] GameObject GuiElements;
    [SerializeField] GameObject thanksButton;
    [SerializeField] GameObject plantInfoText;

    // function called when the player enters the trigger zone around the chest
    // the chest is opened and the player is rewarded with a new plant
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvents != null && !wasTriggered && collision.CompareTag(COLLISION_LISTEN_TO_TAG))
        {
            wasTriggered = true;
            myEvents.Invoke();

            GenericPlant unlockedPlant = GlobalInventoryManager.UnlockNextPlant();
            if (unlockedPlant != null)
            {
                GuiElements.SetActive(false);
                Time.timeScale = 0;
                thanksButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GlobalInventoryManager.SwitchToNextAttackLevel();
                    GlobalInventoryManager.RemoveMap();
                    Time.timeScale = 1;
                    SceneManager.LoadScene(InterScene.VICTORY_SCREEN);
                });

                var name = plantInfoText.transform.Find("Name").GetComponent<TextMeshProUGUI>();
                var effect = plantInfoText.transform.Find("Effect").GetComponent<TextMeshProUGUI>();
                var ripeTime = plantInfoText.transform.Find("RipeTime").GetComponent<TextMeshProUGUI>();

                name.text += unlockedPlant.name;
                effect.text += FruitsEffects.GetEffectDescription(unlockedPlant.effect);
                ripeTime.text += unlockedPlant.ripeTime + " seconds";

                var sprites = Resources.LoadAll<Sprite>(InterScene.IMAGE_PATH);
                var slot = plantInfoText.transform.Find("PlantSlot");
                slot.Find("PlantSprite").GetComponent<Image>().sprite = sprites[unlockedPlant.imageIndex];

                unlockedPlantInfoUI.SetActive(true);
            }
        }
    }
}
