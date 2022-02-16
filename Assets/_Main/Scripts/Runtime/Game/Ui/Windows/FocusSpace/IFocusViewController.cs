using System;
using UnityEngine;

namespace Runtime.Game.Ui.Windows.FocusSpace
{
    public interface IFocusViewController
    {
        void Focus(GameObject gameObject, Action onComplete = null);
        void Unfocus(GameObject gameObject);
        void UnfocusAll();
    }
}