using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField] private List<IPlant> plants = new(4);

    private GameObject[] inventorySlots;
    private string ImagePath => "Farming Asset Pack/farming-tileset";

    // Start is called before the first frame update
    void Start()
    {
        inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponentInChildren<Text>().text = plants[i].Amount.ToString();
            inventorySlots[i].GetComponentsInChildren<Image>()[1].sprite = Resources.LoadAll<Sprite>(ImagePath)[plants[i].ImageIndex];
        }
    }

    public void AddPlant(IPlant plant)
    {
        plants.Add(plant);
    }

    public void UsePlant(int index)
    {
        if (plants[index].Consume())
        {
            Debug.Log("Plant consumed");
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("InventorySlot1"))
        {
            UsePlant(0);
        }
        else if (Input.GetButtonDown("InventorySlot2"))
        {
            UsePlant(1);
        }
        else if (Input.GetButtonDown("InventorySlot3"))
        {
            UsePlant(2);
        }
        else if (Input.GetButtonDown("InventorySlot4"))
        {
            UsePlant(3);
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponentInChildren<Text>().text = plants[i].Amount.ToString();
        }
    }
}
