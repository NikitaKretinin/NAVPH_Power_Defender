using System;
using System.Collections.Generic;

[Serializable]
public class GlobalInventory
{
  public List<GenericPlant> plants;
  public int availableMaps;
  public int prevAttackLevel;
}