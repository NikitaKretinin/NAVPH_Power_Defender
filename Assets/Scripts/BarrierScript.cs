using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    [SerializeField] List<GameObject> relatedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if all related enemies are dead
        if (relatedEnemies.All(enemy => enemy == null))
        {
            gameObject.SetActive(false);
        }
    }
}
