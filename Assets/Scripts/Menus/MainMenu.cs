using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ModeButtons : MonoBehaviour
{
  [SerializeField] GameObject defenseModeButton;
  [SerializeField] GameObject attackModeButton;
  [SerializeField] GameObject exitButton;
  [SerializeField] GameObject globalInventoryObject;
  [SerializeField] GameObject mapInfoObject;
  private GlobalInventoryBehaviour globalInventory = null;
  int mapCount;

  private void Awake()
  {
    globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>();
  }

  void Start()
  {
    mapCount = globalInventory.GetAvailableMapCount();

    if (mapCount > 0)
    {
      attackModeButton.GetComponent<Button>().interactable = true;
      mapInfoObject.GetComponent<TextMeshProUGUI>().text = "You have " + mapCount + " map(s) available.";
    }
    else
    {
      mapInfoObject.GetComponent<TextMeshProUGUI>().text = "You have no maps available. Collect maps in defense mode to play attack mode.";
    }

    defenseModeButton.GetComponent<Button>().onClick.AddListener(OnClickDefenseMode);
    attackModeButton.GetComponent<Button>().onClick.AddListener(OnClickAttackMode);
    exitButton.GetComponent<Button>().onClick.AddListener(OnClickExit);
  }

  void OnClickDefenseMode()
  {
    InterScene.gameMode = GameMode.Defense;
    SceneManager.LoadScene("PlantSelection");
  }

  void OnClickAttackMode()
  {
    InterScene.gameMode = GameMode.Attack;

    if (globalInventory.GetAvailableMapCount() > 0)
    {
      SceneManager.LoadScene("PlantSelection");
    }
  }

  void OnClickExit()
  {
    if (Application.isEditor)
    {
      UnityEditor.EditorApplication.isPlaying = false;
    }
    else
    {
      Application.Quit();
    }
  }
}