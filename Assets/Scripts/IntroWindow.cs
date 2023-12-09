using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroWindow : MonoBehaviour
{
    [SerializeField] private GameObject globalInventoryObject;
    [SerializeField] private GameObject GUIElements;
    private GlobalInventoryBehaviour globalInventory = null;

    // Show the intro window if the player has just started the game
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Resume);
        globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>();
        if (globalInventory.GetCurrentDefenseLevel() == 1)
        {
            gameObject.SetActive(true);
            Pause();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        GUIElements.SetActive(false);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        GUIElements.SetActive(true);
    }
}
