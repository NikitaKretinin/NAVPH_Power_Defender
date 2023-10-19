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
        slider.value = parentEntity.currentHealth / (float)parentEntity.maxHealth;
    }

    public void setMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health){
        slider.value = health;
    }
}
