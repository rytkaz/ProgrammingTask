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
        [SerializeField] private RopesDisplay RopesDisplay;
        [SerializeField] private LevelSelection LevelSelection;

        private int CurrentClaimedPoint;
        private int LastPointIndex;
        private int CurrentLevel;

        public void StartLevel(int levelIndex)
        {
            CurrentLevel = levelIndex;
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
            if(CurrentClaimedPoint > 0)
            {
                RopesDisplay.ConnectPoints(GameDataParser.Levels[CurrentLevel].Points[CurrentClaimedPoint - 1], GameDataParser.Levels[CurrentLevel].Points[CurrentClaimedPoint]);
            }

            if (CurrentClaimedPoint == LastPointIndex)
            {
                RopesDisplay.OnRopeAnimationsFinished.AddListener(OnLevelCompleted);
                RopesDisplay.ConnectPoints(GameDataParser.Levels[CurrentLevel].Points[LastPointIndex], GameDataParser.Levels[CurrentLevel].Points[0]);
            }
            return true;
        }

        private void OnLevelCompleted()
        {
            RopesDisplay.OnRopeAnimationsFinished.RemoveListener(OnLevelCompleted);
            StartCoroutine(BackToLevelSelection());
        }

        private IEnumerator BackToLevelSelection()
        {
            float elapsedTime = 0;
            float returnDelay = 1;
            while(elapsedTime < returnDelay)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            RopesDisplay.Hide();
            LevelDisplay.Hide();
            LevelSelection.Show();
        }
    }
}