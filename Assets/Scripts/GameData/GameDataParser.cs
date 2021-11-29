using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TutoTOONS_Task
{
    public class GameDataParser : MonoBehaviour
    {
        [SerializeField] private TextAsset DataFile;

        public List<Level> Levels = new List<Level>();

        private void Awake()
        {
            ParseGameData();
        }

        private void ParseGameData()
        {
            GameData data = JsonUtility.FromJson<GameData>(DataFile.text);
            for(int i = 0; i < data.levels.Length; i++)
            {
                Level newLevel = new Level(data.levels[i].level_data);
                if(newLevel.Points.Count > 1)
                {
                    Levels.Add(newLevel);
                }
                else
                {
                    Debug.LogWarning($"Level {i} has less than 2 points. Not adding to level list");
                }
            }
        }
    }
}