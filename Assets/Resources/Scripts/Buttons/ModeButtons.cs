using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeButtons : MonoBehaviour
{
  [SerializeField] GameObject defenseModeButton;
  [SerializeField] GameObject attackModeButton;

  void Start()
  {
    defenseModeButton.GetComponent<Button>().onClick.AddListener(OnClickDefenseMode);
    attackModeButton.GetComponent<Button>().onClick.AddListener(OnClickAttackMode);
  }

  public void OnClickDefenseMode()
  {
    InterScene.gameMode = GameMode.Defense;
    SceneManager.LoadScene("PlantSelection");
  }

  public void OnClickAttackMode()
  {
    InterScene.gameMode = GameMode.Attack;
    SceneManager.LoadScene("PlantSelection");
  }
}