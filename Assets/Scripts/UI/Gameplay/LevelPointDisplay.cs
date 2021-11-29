using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TutoTOONS_Task.UI
{
    public class LevelPointDisplay : MonoBehaviour
    {
        [SerializeField] private Image PointImage;
        [SerializeField] private Sprite NormalSprite;
        [SerializeField] private Sprite ClaimedSprite;
        [SerializeField] private Button PointButton;

        [Header("Index text")]
        [SerializeField] private TextMeshProUGUI PointIndexText;
        [SerializeField] private float IndexFadeOutDuration;

        private GameplayManager GameplayManager;
        private int PointIndex;
        private bool IsPointClaimed = false;
        private float PointIndexOriginalAlpha = -1;

        public void Setup(int pointIndex, Vector2 coordinates, GameplayManager gameplayManager)
        {
            if(PointIndexOriginalAlpha == -1)
            {
                PointIndexOriginalAlpha = PointIndexText.alpha;
            }
            else
            {
                PointIndexText.alpha = PointIndexOriginalAlpha;
            }

            PointIndex = pointIndex;
            IsPointClaimed = false;
            GameplayManager = gameplayManager;
            PointIndexText.SetText((pointIndex + 1).ToString());
            PointImage.sprite = NormalSprite;
            transform.localPosition = coordinates;
            PointButton.enabled = true;
        }

        [UsedImplicitly]
        public void OnPointClicked()
        {
            if(!IsPointClaimed && GameplayManager.TryClaimPoint(PointIndex))
            {
                IsPointClaimed = true;
                PointButton.enabled = false;
                PointImage.sprite = ClaimedSprite;
                PointIndexText.CrossFadeAlpha(0, IndexFadeOutDuration, false);
            }
        }
    }
}