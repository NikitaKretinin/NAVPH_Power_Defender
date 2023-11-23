using System;
using System.Collections.Generic;

[Serializable]
public class GlobalInventory
{
  // plant1, plant2, ...
  public HashSet<string> unlockedPlants;
  // map1, map2, ...
  public HashSet<string> availableMaps;
}