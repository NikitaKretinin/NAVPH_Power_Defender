using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType
{
    plant1,
    plant2,
    plant3,
    plant4,
    plant5
}

public class PlantConfig : MonoBehaviour
{

    private Animator anim;
    public PlantType plantType = PlantType.plant1;

    public IPlant relatedPlant;

    [SerializeField] Transform HUDObject;


    // Start is called before the first frame update
    void Awake()
    {  
        switch(plantType) 
        {
        case PlantType.plant1:
            relatedPlant = new Plant1();
            break;
        case PlantType.plant2:
            relatedPlant = new Plant2();
            break;
        case PlantType.plant3:
            relatedPlant = new Plant3();
            break;
        case PlantType.plant4:
            relatedPlant = new Plant4();
            break;
        default:
            relatedPlant = new Plant1();
            break;
        }

        HUDObject = GameObject.FindWithTag("HUD").transform;
        HUDObject.GetComponentInChildren<Inventory>().AddPlant(relatedPlant);

        // Setup animation
        anim = GetComponent<Animator>();
        anim.SetBool(plantType.ToString(), true);
        // transit to the plant-related animation and adjust the speed
        anim.Play("Base Layer." + relatedPlant.GetType().Name);
        anim.speed = (float)(1.0 / relatedPlant.RipeTime);
    }

    void AddPlantToInventory()
    {
        // Increase plant counter by 1 in inventory
        relatedPlant.AddToInventory();
        Debug.Log("Plant added to inventory: " + relatedPlant.Amount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
