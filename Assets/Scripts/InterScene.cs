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

  public static readonly string IMAGE_PATH = "Farming Asset Pack/farming-tileset";
  public static readonly string MAIN_MENU = "MainMenu";
  public static readonly string DEFENSE_MODE = "DefenseMode";
  public static readonly string ATTACK_MODE_LEVEL_BASE = "AttackModeLevel";
  public static readonly string PLANT_SELECTION = "PlantSelection";
  public static readonly string VICTORY_SCREEN = "VictoryScreen";
  public static readonly string DEFEAT_SCREEN = "DefeatScreen";
  public static readonly string GLOBAL_INVENTORY_JSON = "GlobalInventory.json";
  public static readonly string PLANT_INFO_NO_IMG_OBJECT = "PlantInfoNoImage";
}