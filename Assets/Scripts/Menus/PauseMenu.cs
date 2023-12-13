using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
  [SerializeField] GameObject pauseScreen;
  [SerializeField] GameObject resumeButton;
  [SerializeField] GameObject controlsButton;
  [SerializeField] GameObject exitLevelButton;
  [SerializeField] GameObject controlsScreen;
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

  void OpenControls()
  {
    pauseScreen.SetActive(false);
    controlsScreen.SetActive(true);
  }

  void CloseControls()
  {
    pauseScreen.SetActive(true);
    controlsScreen.SetActive(false);
  }

  void Start()
  {
    gameObject.GetComponent<Button>().onClick.AddListener(Pause);
    resumeButton.GetComponent<Button>().onClick.AddListener(Resume);
    controlsButton.GetComponent<Button>().onClick.AddListener(OpenControls);
    controlsScreen.GetComponent<Button>().onClick.AddListener(CloseControls);
    exitLevelButton.GetComponent<Button>().onClick.AddListener(ExitLevel);
  }
}