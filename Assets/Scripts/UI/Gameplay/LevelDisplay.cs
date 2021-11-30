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

            for (int i = points.Count; i < SpawnedPoints.Count; i++)
            {
                SpawnedPoints[i].gameObject.SetActive(false);
            }

            GameplayScreen.SetActive(true);
        }

        public void Hide()
        {
            GameplayScreen.SetActive(false);
        }
    }
}