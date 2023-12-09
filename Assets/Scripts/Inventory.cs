using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<GenericPlant> plants = null;

    private GameObject[] inventorySlots;

    void Awake()
    {
        plants = InterScene.selectedPlants;
        GameObject[] farmSlots = null;
        if (InterScene.gameMode == GameMode.Defense)
        {
            farmSlots = GameObject.FindGameObjectsWithTag("FarmSlot");
            farmSlots = farmSlots.OrderBy(slot => slot.name).ToArray();
        }
        inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        inventorySlots = inventorySlots.OrderBy(slot => slot.name).ToArray();
        
        // Set the inventory slots to the plants in the inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < plants.Count() && plants[i] != null)
            {
                inventorySlots[i].transform.Find("AmountText").GetComponent<Text>().text = plants[i].amount.ToString();
                inventorySlots[i].transform.Find("PlantSprite").GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(InterScene.imagePath)[plants[i].imageIndex];
                if (farmSlots != null && farmSlots[i] != null)
                {
                    farmSlots[i].GetComponent<PlantFarmConfig>().relatedPlant = plants[i];
                }
                if (InterScene.gameMode == GameMode.Attack)
                {
                    plants[i].amount = 2;
                }
            }
            else
            {
                inventorySlots[i].transform.Find("AmountText").GetComponent<Text>().gameObject.SetActive(false);
                inventorySlots[i].transform.Find("PlantSprite").GetComponent<Image>().gameObject.SetActive(false);
                if (farmSlots != null && farmSlots[i] != null)
                {
                    farmSlots[i].GetComponent<SpriteRenderer>().gameObject.SetActive(false);
                }
            }
        }
    }

    public void UsePlant(int index)
    {
        GameObject player = GameObject.Find("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (index < plants.Count() && plants[index] != null && plants[index].amount > 0)
        {
            // If the plant is used successfully, decrease the amount of the plant in the inventory
            if (FruitsEffects.ActivateFruitEffect(plants[index].effect, player, enemies))
                plants[index].amount--;
        }
    }

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
            if (i < plants.Count() && plants[i] != null)
            {
                inventorySlots[i].transform.Find("AmountText").GetComponent<Text>().text = plants[i].amount.ToString();
            }
        }
    }
}
