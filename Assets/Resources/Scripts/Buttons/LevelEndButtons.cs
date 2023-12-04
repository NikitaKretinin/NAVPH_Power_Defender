using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndButtons : MonoBehaviour
{
  [SerializeField] GameObject nextLevelButton = null;
  [SerializeField] GameObject mainMenuButton = null;

  void Start()
  {
    nextLevelButton.GetComponent<Button>().onClick.AddListener(OnClickNextLevel);
    mainMenuButton.GetComponent<Button>().onClick.AddListener(OnClickMainMenu);
  }

  public void OnClickNextLevel()
  {
    Debug.Log("Next Level");
  }

  public void OnClickMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
}