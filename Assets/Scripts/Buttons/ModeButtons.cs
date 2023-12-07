using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeButtons : MonoBehaviour
{
  [SerializeField] GameObject defenseModeButton;
  [SerializeField] GameObject attackModeButton;
  [SerializeField] GameObject globalInventoryObject;
  private GlobalInventoryBehaviour globalInventory = null;

  private void Awake()
  {
    globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>();
  }

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

    if (globalInventory.GetAvailableMapCount() > 0)
    {
      SceneManager.LoadScene("PlantSelection");
    }
  }
}