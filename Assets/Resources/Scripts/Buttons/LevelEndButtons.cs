using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndButtons : MonoBehaviour
{
  private Button nextLevelButton = null;
  private Button mainMenuButton = null;

  void Start()
  {
    nextLevelButton = GameObject.Find("NextLevelButton").GetComponent<Button>();
    mainMenuButton = GameObject.Find("MainMenuButton").GetComponent<Button>();

    nextLevelButton.onClick.AddListener(OnClickNextLevel);
    mainMenuButton.onClick.AddListener(OnClickMainMenu);
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