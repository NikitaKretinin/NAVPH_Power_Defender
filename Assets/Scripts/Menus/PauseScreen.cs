using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseBehavior : MonoBehaviour
{
  [SerializeField] GameObject pauseScreen;
  [SerializeField] GameObject resumeButton;
  [SerializeField] GameObject exitLevelButton;
  [SerializeField] GameObject GUIElements;
  bool confirmedExit = false;

  void Pause()
  {
    Time.timeScale = 0;
    pauseScreen.SetActive(true);
    GUIElements.SetActive(false);
  }

  void Resume()
  {
    Time.timeScale = 1;
    pauseScreen.SetActive(false);
    GUIElements.SetActive(true);
    exitLevelButton.transform.Find("ExitLevelText").GetComponent<TextMeshProUGUI>().text = "Exit Level";
    exitLevelButton.GetComponent<Image>().color = Color.white;
    confirmedExit = false;
  }

  void ExitLevel()
  {
    if (confirmedExit)
    {
      Time.timeScale = 1;
      SceneManager.LoadScene(InterScene.MAIN_MENU);
    }
    else
    {
      exitLevelButton.transform.Find("ExitLevelText").GetComponent<TextMeshProUGUI>().text = "Confirm Exit";
      exitLevelButton.GetComponent<Image>().color = Color.red;
      confirmedExit = true;
    }
  }

  void Start()
  {
    gameObject.GetComponent<Button>().onClick.AddListener(Pause);
    resumeButton.GetComponent<Button>().onClick.AddListener(Resume);
    exitLevelButton.GetComponent<Button>().onClick.AddListener(ExitLevel);
  }
}