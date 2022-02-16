using System;
using SimpleUi.Abstracts;
using CustomSelectables;
using Runtime.Game.Ui.Windows.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Runtime.Game.Ui.Windows.MainMenu
{
    public class RunnerMainMenuView : UiView, IPointerDownHandler
    {
        //public Button PlayButton;
        
        public Action OnPointerDownAction;
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDownAction();
        }
    }
}