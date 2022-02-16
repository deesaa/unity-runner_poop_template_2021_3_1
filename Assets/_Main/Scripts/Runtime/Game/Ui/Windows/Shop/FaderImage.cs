using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.Ui.Windows.Shop
{
    public class FaderImage : MonoBehaviour
    {
        public Image TargetImage;
        public Color MaxColor;
        public Color MinColor;
        public float time;

        public void DoFade(bool enable)
        {
            DOTween.Kill(TargetImage.gameObject, true);
            if (enable)
            {
                TargetImage.gameObject.SetActive(true);
                TargetImage.DOColor(MaxColor, time).SetTarget(TargetImage.gameObject).SetUpdate(true);;
            }
            else
            {
                TargetImage.DOColor(MinColor, time).OnComplete(() => TargetImage.gameObject.SetActive(false)).SetTarget(TargetImage.gameObject).SetUpdate(true);;
            }
        }
    }
}