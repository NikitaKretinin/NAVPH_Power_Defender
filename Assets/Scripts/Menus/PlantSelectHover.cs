using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantSelectHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  Button button;

  void Start()
  {
    button = gameObject.GetComponent<Button>();
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    if (button.interactable)
    {
      transform.Find(InterScene.PLANT_INFO_NO_IMG_OBJECT).gameObject.SetActive(true);
    }
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    if (button.interactable)
    {
      transform.Find(InterScene.PLANT_INFO_NO_IMG_OBJECT).gameObject.SetActive(false);
    }
  }
}