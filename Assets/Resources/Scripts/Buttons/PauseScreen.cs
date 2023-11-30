using UnityEngine;
using UnityEngine.UI;

public class PauseBehavior : MonoBehaviour
{
  [SerializeField] private GameObject pauseScreen;
  [SerializeField] private GameObject resumeButton;
  [SerializeField] private GameObject GUIElements;

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
  }

  void Start()
  {
    gameObject.GetComponent<Button>().onClick.AddListener(Pause);
    resumeButton.GetComponent<Button>().onClick.AddListener(Resume);
  }
}