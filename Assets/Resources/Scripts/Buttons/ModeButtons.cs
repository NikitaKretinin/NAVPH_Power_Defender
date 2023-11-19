using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeButtons : MonoBehaviour
{
  private Button defenseModeButton = null;
  private Button attackModeButton = null;

  void Start()
  {
    defenseModeButton = GameObject.Find("DefenseModeButton").GetComponent<Button>();
    attackModeButton = GameObject.Find("AttackModeButton").GetComponent<Button>();

    defenseModeButton.onClick.AddListener(OnClickDefenseMode);
    attackModeButton.onClick.AddListener(OnClickAttackMode);
  }

  public void OnClickDefenseMode()
  {
    SceneManager.LoadScene("DefenseMode");
  }

  public void OnClickAttackMode()
  {
    SceneManager.LoadScene("AttackModeLevel1");
  }
}