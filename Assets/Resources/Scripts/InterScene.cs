using System.Collections.Generic;

public enum GameMode
{
  None,
  Defense,
  Attack
}

public static class InterScene
{
  public static List<GenericPlant> selectedPlants = null;
  public static GameMode gameMode = GameMode.None;
}