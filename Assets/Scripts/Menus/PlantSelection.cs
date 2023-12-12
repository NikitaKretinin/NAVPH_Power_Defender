using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlantSelection : MonoBehaviour
{
  GlobalInventory globalInventory = null;
  [SerializeField] GameObject confirmButton;
  [SerializeField] GameObject backButton;
  GameObject[] selectedPlantSlots = null;

  // add plant to selected plant slot
  void SelectPlant(int plantIndex, Sprite[] sprites)
  {
    var selectedPlantSlot = selectedPlantSlots.FirstOrDefault(
      slot => !slot.transform.Find("PlantSprite").GetComponent<Image>().gameObject.activeSelf
    );
    if (selectedPlantSlot != null)
    {
      var plantSprite = selectedPlantSlot.transform.Find("PlantSprite").GetComponent<Image>();
      var plantText = selectedPlantSlot.transform.Find("PlantText").GetComponent<TextMeshProUGUI>();

      plantSprite.gameObject.SetActive(true);
      plantSprite.sprite = sprites[globalInventory.plants[plantIndex].imageIndex];
      plantText.text = globalInventory.plants[plantIndex].name;

      selectedPlantSlot.GetComponent<Button>().interactable = true;
    }
  }

  // remove plant from selected plant slot
  void DeselectPlant(int plantIndex)
  {
    var plantSprite = selectedPlantSlots[plantIndex].transform.Find("PlantSprite").GetComponent<Image>();
    var plantText = selectedPlantSlots[plantIndex].transform.Find("PlantText").GetComponent<TextMeshProUGUI>();

    plantSprite.gameObject.SetActive(false);
    plantText.text = "";

    selectedPlantSlots[plantIndex].GetComponent<Button>().interactable = false;
  }

  // load the game scene with the selected plants stored in InterScene
  void OnConfirmButtonClicked()
  {
    InterScene.selectedPlants = new List<GenericPlant>();

    var selectedPlants = selectedPlantSlots
      .Where(slot => slot.transform.Find("PlantSprite").GetComponent<Image>().gameObject.activeSelf)
      .Select(slot => slot.transform.Find("PlantText").GetComponent<TextMeshProUGUI>().text)
      .ToList();


    foreach (var plant in selectedPlants)
    {
      var selected = globalInventory.plants.FirstOrDefault(p => p.name == plant);
      InterScene.selectedPlants.Add(new GenericPlant(selected));
    }

    if (InterScene.gameMode == GameMode.Defense)
    {
      SceneManager.LoadScene(InterScene.DEFENSE_MODE);
    }
    else if (InterScene.gameMode == GameMode.Attack)
    {
      SceneManager.LoadScene(InterScene.ATTACK_MODE_LEVEL_BASE + globalInventory.currentAttackLevel);
    }
  }

  // load the plant selection screen, only plants that are unlocked are selectable
  void Start()
  {
    globalInventory = GlobalInventoryManager.GetGlobalInventory();
    var sprites = Resources.LoadAll<Sprite>(InterScene.IMAGE_PATH);

    GameObject[] availablePlantSlots = GameObject.FindGameObjectsWithTag("AvailablePlantSlot");
    selectedPlantSlots = GameObject.FindGameObjectsWithTag("SelectedPlantSlot");

    availablePlantSlots = availablePlantSlots.OrderBy(go => go.name).ToArray();
    selectedPlantSlots = selectedPlantSlots.OrderBy(go => go.name).ToArray();

    // set up available plant slots
    for (int i = 0; i < availablePlantSlots.Length; i++)
    {
      var plantSprite = availablePlantSlots[i].transform.Find("PlantSprite").GetComponent<Image>();
      var plantText = availablePlantSlots[i].transform.Find("PlantText").GetComponent<TextMeshProUGUI>();
      plantSprite.sprite = sprites[globalInventory.plants[i].imageIndex];

      if (globalInventory.plants[i].isUnlocked)
      {
        var iCopy = i;

        var plantInfo = availablePlantSlots[i].transform.Find(InterScene.PLANT_INFO_NO_IMG_OBJECT);
        var plantButton = availablePlantSlots[i].GetComponent<Button>();

        var plantName = plantInfo.Find("Name").GetComponent<TextMeshProUGUI>();
        var plantEffect = plantInfo.Find("Effect").GetComponent<TextMeshProUGUI>();
        var plantRipeTime = plantInfo.Find("RipeTime").GetComponent<TextMeshProUGUI>();

        plantText.text = globalInventory.plants[i].name;
        plantButton.interactable = true;
        plantButton.onClick.AddListener(() => SelectPlant(iCopy, sprites));

        plantName.text += globalInventory.plants[i].name;
        plantEffect.text += FruitsEffects.GetEffectDescription(globalInventory.plants[i].effect);
        plantRipeTime.text += globalInventory.plants[i].ripeTime + " seconds";
      }
      else
      {
        plantText.text = "???";
        var color = plantSprite.color;
        color.a = 0.25f;
        plantSprite.color = color;
      }
    }

    // set up selected plant slots
    for (int i = 0; i < selectedPlantSlots.Length; i++)
    {
      var iCopy = i;
      var plantSprite = selectedPlantSlots[i].transform.Find("PlantSprite").GetComponent<Image>();
      plantSprite.gameObject.SetActive(false);
      selectedPlantSlots[i].GetComponent<Button>().onClick.AddListener(
        () => DeselectPlant(iCopy)
      );
    }

    confirmButton.GetComponent<Button>().onClick.AddListener(OnConfirmButtonClicked);
    backButton.GetComponent<Button>().onClick.AddListener(
      () => SceneManager.LoadScene(InterScene.MAIN_MENU)
    );
  }
}