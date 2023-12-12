using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    [SerializeField] List<GameObject> relatedEnemies;

    void FixedUpdate()
    {
        // Check if all related enemies are dead
        if (relatedEnemies.All(enemy => enemy == null))
        {
            gameObject.SetActive(false);
        }
    }
}
