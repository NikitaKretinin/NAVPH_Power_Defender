using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;

    public string collisionListenToTag = "Player";
    public GenericPlant plant;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvents == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else if (collision.CompareTag(collisionListenToTag))
        {
            print("myEventTriggerOnEnter Activated. Triggering" + myEvents);
            myEvents.Invoke();
            // TODO: Show a dialog box with the plant's name and ability.
            // TODO: Unlock the plant in the global inventory.
            // TODO: Use SwitchToNextAttackLevel() from GlobalInventoryBehaviour.
        }
    }
}
