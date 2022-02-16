using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PageButtonView : MonoBehaviour
{
    public Button OpenedPageButtonView;
    public Button ClosedPageButtonView;
    public LayoutElement LayoutElement;
    
    public float OpenedStateHeight;
    public float ClosedStateHeight;
    public float TransitionTime;

    public RectTransform OpenedStatePosition;
    public RectTransform ClosedStatePosition;

    public EItemType PageItemType;

    public void SetOpen(bool open)
    {
        if (open)
        {
            LayoutElement.DOPreferredHeight(OpenedStateHeight, TransitionTime);
            
            ClosedPageButtonView.gameObject.SetActive(false);
            OpenedPageButtonView.transform.localPosition = new Vector3()
            {
                x = ClosedStatePosition.localPosition.x,
                y = OpenedPageButtonView.transform.localPosition.y,
                z = OpenedPageButtonView.transform.localPosition.z
            };
            OpenedPageButtonView.gameObject.SetActive(true);
            OpenedPageButtonView.GetComponent<RectTransform>()
                .DOLocalMoveX(OpenedStatePosition.localPosition.x, TransitionTime);
        }
        else
        {
            LayoutElement.DOPreferredHeight(ClosedStateHeight, TransitionTime);
            
            OpenedPageButtonView.gameObject.SetActive(false);
            ClosedPageButtonView.transform.localPosition = new Vector3()
            {
                x = OpenedStatePosition.localPosition.x,
                y = ClosedPageButtonView.transform.localPosition.y,
                z = ClosedPageButtonView.transform.localPosition.z
            };
            ClosedPageButtonView.gameObject.SetActive(true);
            ClosedPageButtonView.GetComponent<RectTransform>()
                .DOLocalMoveX(ClosedStatePosition.localPosition.x, TransitionTime);
        }
    }
}

/*[Serializable]
public enum EPageType
{
    Weapons,
    Skins
} */
