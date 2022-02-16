using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.InGameMenu
{
    public class GameHoodView : UiView
    {
        public List<Transform> Stars;
        public Image ProgressFiller;
        public TMP_Text coinsCount;
        public TMP_Text gemsCount;

        public TMP_Text levelIndex;
        
        private Tweener ProgressFillerTween;

        public Animation NextLevelUnlockedAnimation;

        public Canvas Canvas;

        public CheckPopupView FinishCheckPopupView;
        public LevelRewardsView LevelRewardsView;

        public void UpdateLevelProgress(float targetValue)
        {
            ProgressFillerTween?.Kill();
            ProgressFillerTween = DOTween.To(value => ProgressFiller.fillAmount = value, ProgressFiller.fillAmount, targetValue, 0.5f).SetAutoKill(false).SetEase(Ease.OutQuad);
        }

        public void OnNextLevelUnlocked()
        {
            NextLevelUnlockedAnimation.Play();
        }
    }
}