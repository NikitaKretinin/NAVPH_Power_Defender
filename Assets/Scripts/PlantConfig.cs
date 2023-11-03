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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool(plantType.ToString(), true);
        Debug.Log("Plant type: " + plantType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
