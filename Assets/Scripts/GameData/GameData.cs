namespace TutoTOONS_Task
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