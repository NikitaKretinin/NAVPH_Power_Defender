using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantSelectHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  Button button;
  readonly string PLANT_INFO = "PlantInfoNoImage";

  void Start()
  {
    button = gameObject.GetComponent<Button>();
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    if (button.interactable)
    {
      Debug.Log("Hovering over " + gameObject.name);
      transform.Find(PLANT_INFO).gameObject.SetActive(true);
    }
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    if (button.interactable)
    {
      Debug.Log("No longer hovering over " + gameObject.name);
      transform.Find(PLANT_INFO).gameObject.SetActive(false);
    }
  }
}