using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndButtons : MonoBehaviour
{
  [SerializeField] GameObject levelButton;
  [SerializeField] GameObject mainMenuButton;
  [SerializeField] bool isVictory;

  void Start()
  {
    levelButton.GetComponent<Button>().onClick.AddListener(OnClickLevel);
    mainMenuButton.GetComponent<Button>().onClick.AddListener(OnClickMainMenu);
  }

  public void OnClickLevel()
  {
    if (isVictory)
    {
      Debug.Log("Next Level");
    }
    else
    {
      Debug.Log("Retry Level");
    }
  }

  public void OnClickMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
}