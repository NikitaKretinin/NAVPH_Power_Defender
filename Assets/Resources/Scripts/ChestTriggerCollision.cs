using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestTriggerCollision : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;
    
    [SerializeField] public string listenToTag = "Player";
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvents == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else if(collision.CompareTag(listenToTag))
        {
            print("myEventTriggerOnEnter Activated. Triggering" + myEvents);
            myEvents.Invoke();
        }
    }
}
