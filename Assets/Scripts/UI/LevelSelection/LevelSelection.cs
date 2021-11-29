using System.Collections.Generic;
using UnityEngine;
using TutoTOONS_Task.Data;

namespace TutoTOONS_Task.UI
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField] private LevelSelectionEntry EntryPrefab;
        [SerializeField] private Transform LevelsRoot;
        [SerializeField] private GameplayManager GameplayManager;

        public void OnLevelsDataParsed(List<Level> levels)
        {
            for(int i = 0; i < levels.Count; i++)
            {
                LevelSelectionEntry newEntry = Instantiate(EntryPrefab, LevelsRoot);
                newEntry.Setup(i, this);
            }
            Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void OnLevelSelected(int levelIndex)
        {
            gameObject.SetActive(false);
            GameplayManager.StartLevel(levelIndex);
        }
    }
}