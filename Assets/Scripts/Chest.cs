using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;

    public string collisionListenToTag = "Player";
    public GenericPlant plant;
    private bool _wasTriggered = false;
    [SerializeField] GameObject globalInventoryObject;
    private GlobalInventoryBehaviour globalInventory = null;

    private void Start()
    {
        globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvents == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else if (!_wasTriggered && collision.CompareTag(collisionListenToTag))
        {
            print("myEventTriggerOnEnter Activated. Triggering" + myEvents);
            _wasTriggered = true;
            myEvents.Invoke();

            GenericPlant unlockedPlant = globalInventory.UnlockNextPlant();
            if (unlockedPlant != null)
            {
                // TODO: Show a dialog box with the plant's name and ability.
                // TODO: Use SwitchToNextAttackLevel() from GlobalInventoryBehaviour.
                Debug.Log("Unlocked plant: " + unlockedPlant.name);
            }
        }
    }
}