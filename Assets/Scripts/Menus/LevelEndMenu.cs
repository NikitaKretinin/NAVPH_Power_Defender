using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEndMenu : MonoBehaviour
{
  [SerializeField] GameObject levelButton;
  [SerializeField] GameObject mainMenuButton;
  [SerializeField] bool isVictory;

  // load the screen after victory or defeat
  void Start()
  {
    levelButton.GetComponent<Button>().onClick.AddListener(OnClickLevel);
    mainMenuButton.GetComponent<Button>().onClick.AddListener(OnClickMainMenu);
    // If the player has won, change the text of the level button depending on the game mode
    if (isVictory)
    {
      var levelButtonText = levelButton.transform.Find("LevelButtonText").GetComponent<TextMeshProUGUI>();
      if (InterScene.gameMode == GameMode.Attack)
      {
        levelButtonText.text = "Next Attack Level";
        if (
          SceneUtility.GetBuildIndexByScenePath(
            InterScene.ATTACK_MODE_LEVEL_BASE + GlobalInventoryManager.GetCurrentAttackLevel()
          ) == -1
        )
        {
          levelButton.GetComponent<Button>().interactable = false;
        }
      }
      else
      {
        levelButtonText.text = "Next Defense Level";
      }
    }
  }

  public void OnClickLevel()
  {
    SceneManager.LoadScene(InterScene.PLANT_SELECTION);
  }

  public void OnClickMainMenu()
  {
    SceneManager.LoadScene(InterScene.MAIN_MENU);
  }
}