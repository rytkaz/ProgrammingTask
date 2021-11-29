using System.Collections;
using UnityEngine;
using TutoTOONS_Task.UI;
using TutoTOONS_Task.Data;

namespace TutoTOONS_Task
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private GameDataParser GameDataParser;
        [SerializeField] private LevelDisplay LevelDisplay;
        [SerializeField] private LevelSelection LevelSelection;

        private int CurrentClaimedPoint;
        private int LastPointIndex;

        public void StartLevel(int levelIndex)
        {
            CurrentClaimedPoint = -1;
            LastPointIndex = GameDataParser.Levels[levelIndex].Points.Count - 1;
            LevelDisplay.ShowLevel(GameDataParser.Levels[levelIndex].Points);
        }

        public bool TryClaimPoint(int index)
        {
            if(CurrentClaimedPoint + 1 != index)
            { 
                return false;
            }

            CurrentClaimedPoint = index;
            if(CurrentClaimedPoint == LastPointIndex)
            {
                LevelDisplay.OnLastPointClaimed();
            }
            return true;
        }

        public void OnLevelCompleted()
        {
            StartCoroutine(BackToLevelSelection());
        }

        private IEnumerator BackToLevelSelection()
        {
            float elapsedTime = 0;
            float returnDelay = 2;
            while(elapsedTime < returnDelay)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            LevelDisplay.Hide();
            LevelSelection.Show();
        }
    }
}