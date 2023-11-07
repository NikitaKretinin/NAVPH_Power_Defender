using System.Collections;
using System.Collections.Generic;
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
        slider.value = parentEntity.getHealth() / (float)parentEntity.getMaxHealth();
    }

    public void setMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health){
        slider.value = health;
    }
}
