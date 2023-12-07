using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseBehavior : MonoBehaviour
{
  [SerializeField] private GameObject pauseScreen;
  [SerializeField] private GameObject resumeButton;
  [SerializeField] private GameObject exitLevelButton;
  [SerializeField] private GameObject GUIElements;
  private bool confirmedExit = false;

  private void Pause()
  {
    Time.timeScale = 0;
    pauseScreen.SetActive(true);
    GUIElements.SetActive(false);
  }

  private void Resume()
  {
    Time.timeScale = 1;
    pauseScreen.SetActive(false);
    GUIElements.SetActive(true);
    exitLevelButton.transform.Find("ExitLevelText").GetComponent<TextMeshProUGUI>().text = "Exit Level";
    exitLevelButton.GetComponent<Image>().color = Color.white;
    confirmedExit = false;
  }

  private void ExitLevel()
  {
    if (confirmedExit)
    {
      Time.timeScale = 1;
      SceneManager.LoadScene("MainMenu");
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