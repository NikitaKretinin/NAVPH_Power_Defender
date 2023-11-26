using System;

public enum Effect
{
    Heal,
    AttackUp,
    SpeedUp,
    AttackEnemiesDown,
    SpeedEnemiesDown
}

[Serializable]
public class GenericPlant
{
    public string name;
    public string id;
    public int ripeTime;
    public int imageIndex;
    public bool isUnlocked;
    public Effect ability;

    [NonSerialized]
    public int amount = 0;

    public GenericPlant() { }

    public GenericPlant(GenericPlant plant)
    {
        name = plant.name;
        id = plant.id;
        ripeTime = plant.ripeTime;
        imageIndex = plant.imageIndex;
        isUnlocked = plant.isUnlocked;
        ability = plant.ability;
    }
}
