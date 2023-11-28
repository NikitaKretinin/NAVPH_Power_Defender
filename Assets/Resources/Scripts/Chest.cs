using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;
    
    public string collisionListenToTag = "Player";
    private bool _wasTriggered = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvents == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else if(!_wasTriggered && collision.CompareTag(collisionListenToTag))
        {
            print("myEventTriggerOnEnter Activated. Triggering" + myEvents);
            _wasTriggered = true;
            myEvents.Invoke();
            
            GlobalInventoryBehaviour globalInventory = new GlobalInventoryBehaviour();
            GenericPlant unlockedPlant = globalInventory.UnlockNextPlant();
            if (unlockedPlant != null)
            {
                // show image to player (show that new plant was unlocked)
            }
        }
    }
}
