using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class GlobalInventoryBehaviour : MonoBehaviour
{
  private GlobalInventory globalInventory = null;

  public GlobalInventory GetGlobalInventory()
  {
    return globalInventory;
  }

  private void LoadGlobalInventory()
  {
    if (File.Exists(Application.persistentDataPath + "/GlobalInventory.json"))
    {
      globalInventory = JsonUtility.FromJson<GlobalInventory>(
        File.ReadAllText(Application.persistentDataPath + "/GlobalInventory.json")
      );
    }
    else
    {
      globalInventory = new GlobalInventory
      {
        plants = new List<GenericPlant> {
          new() {
            name = "RadiantGlow",
            id = "plant1",
            ripeTime = 6,
            imageIndex = 67,
            isUnlocked = true,
            effect = Effect.Heal
          },
          new() {
            name = "Emberflare",
            id = "plant2",
            ripeTime = 5,
            imageIndex = 56,
            isUnlocked = false,
            effect = Effect.AttackUp
          },
          new() {
            name = "Whisperleaf",
            id = "plant3",
            ripeTime = 2,
            imageIndex = 61,
            isUnlocked = false,
            effect = Effect.SpeedUp
          },
          new() {
            name = "Sparkbloom",
            id = "plant4",
            ripeTime = 3,
            imageIndex = 52,
            isUnlocked = false,
            effect = Effect.AttackEnemiesDown
          },
          new() {
            name = "Bloodwine",
            id = "plant5",
            ripeTime = 7,
            imageIndex = 55,
            isUnlocked = false,
            effect = Effect.SpeedEnemiesDown
          }
        },
        availableMaps = 0,
        currentAttackLevel = 1,
        currentDefenseLevel = 1
      };
      SaveGlobalInventory();
    }
  }

  public void SaveGlobalInventory()
  {
    string json = JsonUtility.ToJson(globalInventory);
    File.WriteAllText(Application.persistentDataPath + "/GlobalInventory.json", json);
  }

  public GenericPlant UnlockNextPlant()
  {
    var firstMatch = globalInventory.plants.FirstOrDefault(s => s.isUnlocked == false);
    if (firstMatch != null)
    {
      firstMatch.isUnlocked = true;
      SaveGlobalInventory();
    }
    return firstMatch;
  }

  public void AddMap()
  {
    globalInventory.availableMaps++;
    SaveGlobalInventory();
  }

  public void RemoveMap()
  {
    globalInventory.availableMaps--;
    SaveGlobalInventory();
  }

  public void SwitchToNextAttackLevel()
  {
    globalInventory.currentAttackLevel++;
    SaveGlobalInventory();
  }

  public void SwitchToNextDefenseLevel()
  {
    globalInventory.currentDefenseLevel++;
    SaveGlobalInventory();
  }

  public int GetAvailableMapCount()
  {
    return globalInventory.availableMaps;
  }

  public int GetCurrentAttackLevel()
  {
    return globalInventory.currentAttackLevel;
  }

  public int GetCurrentDefenseLevel()
  {
    return globalInventory.currentDefenseLevel;
  }

  private void Awake()
  {
    LoadGlobalInventory();
  }
}