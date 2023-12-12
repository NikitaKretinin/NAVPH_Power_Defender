using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehavior : MonoBehaviour
{
    [SerializeField] Damageable parentEntity;
    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = parentEntity.GetHealth() / (float)parentEntity.GetMaxHealth();
    }
}
