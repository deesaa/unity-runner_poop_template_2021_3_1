using System;
using DG.Tweening;
using SimpleUi.Abstracts;
using SimpleUi.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.BlackScreen
{
    public class StickInputView : UiView
    {
        public Transform TutorialArrows;

        private bool _tutorialDisabled;
        
        protected override void Awake()
        {
            base.Awake();
            Debug.Log($"PlayerPrefs.GetInt(StickTutorial, 1) {PlayerPrefs.GetInt("StickTutorial", 1)}");
            if (PlayerPrefs.GetInt("StickTutorial", 1) == 0)
            {
                TutorialArrows.gameObject.SetActive(false);
                _tutorialDisabled = true;
            }
            else
            {
                TutorialArrows.gameObject.SetActive(true);
                _tutorialDisabled = false;
            }
        }

        private void Update()
        {
            if(_tutorialDisabled)
                return;
            
            if (PlayerPrefs.GetInt("StickTutorial", 1) == 0)
            {
                TutorialArrows.gameObject.SetActive(false);
                _tutorialDisabled = true;
            }
            else
            {
                TutorialArrows.gameObject.SetActive(true);
                _tutorialDisabled = false;
            }
        }
    }
}