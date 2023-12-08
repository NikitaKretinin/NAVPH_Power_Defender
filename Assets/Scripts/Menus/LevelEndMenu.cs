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
     SceneManager.LoadScene("PlantSelection");
  }

  public void OnClickMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
}