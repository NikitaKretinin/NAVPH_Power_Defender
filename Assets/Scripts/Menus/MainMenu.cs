using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ModeButtons : MonoBehaviour
{
  [SerializeField] GameObject defenseModeButton;
  [SerializeField] GameObject attackModeButton;
  [SerializeField] GameObject exitButton;
  [SerializeField] GameObject controlsButton;
  [SerializeField] GameObject mapInfoObject;
  [SerializeField] GameObject mainMenuGUI;
  [SerializeField] GameObject controlsGUI;
  int mapCount;
  bool resetGame = false;

  void Awake()
  {
    GlobalInventoryManager.LoadGlobalInventory();
  }

  // load main menu screen
  void Start()
  {
    mapCount = GlobalInventoryManager.GetAvailableMapCount();
    if (SceneUtility.GetBuildIndexByScenePath(InterScene.ATTACK_MODE_LEVEL_BASE + GlobalInventoryManager.GetCurrentAttackLevel()) == -1)
    {
      // If the player has cleared all attack levels, reset the game
      resetGame = true;
      attackModeButton.GetComponent<Button>().interactable = true;
      attackModeButton.transform.Find("AttackModeButtonText").GetComponent<TextMeshProUGUI>().text = "Reset Game";
      mapInfoObject.GetComponent<TextMeshProUGUI>().text = "You have cleared all attack levels.";
    }
    else if (mapCount > 0)
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
    controlsButton.GetComponent<Button>().onClick.AddListener(OnClickControls);
    controlsGUI.GetComponent<Button>().onClick.AddListener(OnClickBackFromControls);
  }

  void OnClickDefenseMode()
  {
    InterScene.gameMode = GameMode.Defense;
    SceneManager.LoadScene(InterScene.PLANT_SELECTION);
  }

  void OnClickAttackMode()
  {
    if (resetGame)
    {
      GlobalInventoryManager.ResetGameJson();
      SceneManager.LoadScene(InterScene.MAIN_MENU);
    }
    else
    {
      InterScene.gameMode = GameMode.Attack;

      if (GlobalInventoryManager.GetAvailableMapCount() > 0)
      {
        SceneManager.LoadScene(InterScene.PLANT_SELECTION);
      }
    }
  }

  void OnClickExit()
  {
    if (Application.isEditor)
    {
#if UNITY_EDITOR
      EditorApplication.isPlaying = false;
#endif
    }
    else
    {
      Application.Quit();
    }
  }

  void OnClickControls()
  {
    mainMenuGUI.SetActive(false);
    controlsGUI.SetActive(true);
  }

  void OnClickBackFromControls()
  {
    mainMenuGUI.SetActive(true);
    controlsGUI.SetActive(false);
  }
}