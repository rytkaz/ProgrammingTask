namespace TutoTOONS_Task.Data
{
    [System.Serializable]
    public struct GameData
    {
       public LevelData[] levels;
    }

    [System.Serializable]
    public struct LevelData
    {
        public int[] level_data;
    }
}