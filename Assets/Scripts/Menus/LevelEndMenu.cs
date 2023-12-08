using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndButtons : MonoBehaviour
{
  [SerializeField] GameObject levelButton;
  [SerializeField] GameObject mainMenuButton;
  [SerializeField] bool isVictory;
  [SerializeField] GameObject globalInventoryObject;
  private GlobalInventoryBehaviour globalInventory = null;

  void Start()
  {
    levelButton.GetComponent<Button>().onClick.AddListener(OnClickLevel);
    mainMenuButton.GetComponent<Button>().onClick.AddListener(OnClickMainMenu);
    globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>();
  }

  public void OnClickLevel()
  {
    if (InterScene.gameMode == GameMode.Defense)
    {
      // If the player won the level, the current defense level has already been incremented
      // and the level is altered by scaling
      SceneManager.LoadScene("DefenseMode");
    }
    else if (InterScene.gameMode == GameMode.Attack)
    {
      // If the player won the level, the current attack level has already been incremented
      SceneManager.LoadScene("AttackModeLevel" + globalInventory.GetCurrentAttackLevel());
    }
  }

  public void OnClickMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
}