using System.Collections.Generic;
using UnityEngine;

namespace TutoTOONS_Task.UI
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private LevelPointDisplay PointDisplayPrefab;
        [SerializeField] private Transform PointsDisplayRoot;
        [SerializeField] private GameObject GameplayScreen;
        [SerializeField] private GameplayManager GameplayManager;

        private List<LevelPointDisplay> SpawnedPoints = new List<LevelPointDisplay>();
        private int LastUsedPointIndex = 0;

        public void ShowLevel(List<Vector2> points)
        {
            for(int i = 0; i < points.Count; i++)
            {
                if(SpawnedPoints.Count <= i)
                {
                    SpawnedPoints.Add(Instantiate(PointDisplayPrefab, PointsDisplayRoot));
                }

                SpawnedPoints[i].Setup(i, points[i], GameplayManager);
                SpawnedPoints[i].gameObject.SetActive(true);
            }
            LastUsedPointIndex = points.Count - 1;

            for (int i = points.Count; i < SpawnedPoints.Count; i++)
            {
                SpawnedPoints[i].gameObject.SetActive(false);
            }

            GameplayScreen.SetActive(true);
        }

        public void OnLastPointClaimed()
        {
            //TODO: Connect last point to first point
            GameplayManager.OnLevelCompleted();
        }

        public void Hide()
        {
            GameplayScreen.SetActive(false);
        }
    }
}