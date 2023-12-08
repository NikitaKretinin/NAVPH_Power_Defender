using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlantSelection : MonoBehaviour
{
  private GlobalInventory globalInventory = null;
  [SerializeField] GameObject globalInventoryObject;
  [SerializeField] GameObject confirmButton;
  GameObject[] selectedPlantSlots = null;

  private void SelectPlant(int plantIndex, Sprite[] sprites)
  {
    var selectedPlantSlot = selectedPlantSlots.FirstOrDefault(slot => !slot.transform.Find("PlantSprite").GetComponent<Image>().gameObject.activeSelf);
    if (selectedPlantSlot != null)
    {
      selectedPlantSlot.transform.Find("PlantSprite").GetComponent<Image>().gameObject.SetActive(true);
      selectedPlantSlot.transform.Find("PlantSprite").GetComponent<Image>().sprite = sprites[globalInventory.plants[plantIndex].imageIndex];
      selectedPlantSlot.transform.Find("PlantText").GetComponent<TextMeshProUGUI>().text = globalInventory.plants[plantIndex].name;
      selectedPlantSlot.GetComponent<Button>().interactable = true;
    }
  }

  private void DeselectPlant(int plantIndex)
  {
    selectedPlantSlots[plantIndex].transform.Find("PlantSprite").GetComponent<Image>().gameObject.SetActive(false);
    selectedPlantSlots[plantIndex].transform.Find("PlantText").GetComponent<TextMeshProUGUI>().text = "";
    selectedPlantSlots[plantIndex].GetComponent<Button>().interactable = false;
  }

  private void OnConfirmButtonClicked()
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
      SceneManager.LoadScene("DefenseMode");
    }
    else if (InterScene.gameMode == GameMode.Attack)
    {
      SceneManager.LoadScene("AttackModeLevel" + globalInventory.currentAttackLevel);
    }
  }

  private void Start()
  {
    globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>().GetGlobalInventory();
    var sprites = Resources.LoadAll<Sprite>(InterScene.ImagePath);

    GameObject[] availablePlantSlots = GameObject.FindGameObjectsWithTag("AvailablePlantSlot");
    selectedPlantSlots = GameObject.FindGameObjectsWithTag("SelectedPlantSlot");

    availablePlantSlots = availablePlantSlots.OrderBy(go => go.name).ToArray();
    selectedPlantSlots = selectedPlantSlots.OrderBy(go => go.name).ToArray();

    for (int i = 0; i < availablePlantSlots.Length; i++)
    {
      availablePlantSlots[i].transform.Find("PlantSprite").GetComponent<Image>().sprite = sprites[globalInventory.plants[i].imageIndex];
      if (globalInventory.plants[i].isUnlocked)
      {
        availablePlantSlots[i].transform.Find("PlantText").GetComponent<TextMeshProUGUI>().text = globalInventory.plants[i].name;
        availablePlantSlots[i].GetComponent<Button>().interactable = true;
        var i_copy = i;
        availablePlantSlots[i].GetComponent<Button>().onClick.AddListener(() => SelectPlant(i_copy, sprites));
      }
      else
      {
        availablePlantSlots[i].transform.Find("PlantText").GetComponent<TextMeshProUGUI>().text = "???";
        var color = availablePlantSlots[i].transform.Find("PlantSprite").GetComponent<Image>().color;
        color.a = 0.25f;
        availablePlantSlots[i].transform.Find("PlantSprite").GetComponent<Image>().color = color;
      }
    }

    for (int i = 0; i < selectedPlantSlots.Length; i++)
    {
      selectedPlantSlots[i].transform.Find("PlantSprite").GetComponent<Image>().gameObject.SetActive(false);
      var i_copy = i;
      selectedPlantSlots[i].GetComponent<Button>().onClick.AddListener(() => DeselectPlant(i_copy));
    }

    confirmButton.GetComponent<Button>().onClick.AddListener(OnConfirmButtonClicked);
  }
}