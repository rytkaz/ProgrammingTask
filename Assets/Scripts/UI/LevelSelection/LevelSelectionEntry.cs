using UnityEngine;
using TMPro;
using JetBrains.Annotations;

namespace TutoTOONS_Task.UI
{
    public class LevelSelectionEntry : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI IndexText;

        private int LevelIndex = 0;
        private LevelSelection LevelSelection;

        public void Setup(int levelIndex, LevelSelection levelSelection)
        {
            LevelIndex = levelIndex;
            LevelSelection = levelSelection;
            IndexText.SetText((levelIndex+1).ToString());
        }

        [UsedImplicitly]
        public void OnEntryClicked()
        {
            LevelSelection.OnLevelSelected(LevelIndex);
        }
    }
}