using UnityEngine;

public class PlantFarmConfig : MonoBehaviour
{
    Animator anim;
    public GenericPlant relatedPlant = null;

    void Start()
    {
        if (relatedPlant != null)
        {
            // Setup animation
            anim = GetComponent<Animator>();
            anim.SetBool(relatedPlant.id, true);
            // transit to the plant-related animation and adjust the speed
            anim.Play("Base Layer." + relatedPlant.id);
            anim.speed = (float)(1.0 / relatedPlant.ripeTime);
        }
    }

    // Called using animator
    void AddPlantToInventory()
    {
        if (relatedPlant != null)
        {
            // Increase plant counter by 1 in inventory
            relatedPlant.amount++;
        }
    }
}
