using System;
using System.Collections;
using System.Collections.Generic;
using DataBase.Game;
using DG.Tweening;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class MainCameraGroup : LinkableView, IReinitializable
{
    private Vector3 _initialLocalPosition;
    private Quaternion _initialLocalRotation;
    
    public Camera Camera;
    public Camera UICamera;
    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        var transform1 = transform;
        _initialLocalPosition = transform1.localPosition;
        _initialLocalRotation = transform1.localRotation;
    }

    public void Reinitialize()
    {
        DOTween.Sequence().Append(transform.DOLocalMove(_initialLocalPosition, 1.5f))
            .Join(transform.DOLocalRotateQuaternion(_initialLocalRotation, 1.5f)).SetEase(Ease.OutCubic).SetUpdate(true);
    }

    public void SetState(EGameStage gameState)
    {
        Camera.gameObject.SetActive(true);
        switch (gameState)
        {
            case EGameStage.Empty:
                break;
            case EGameStage.Play:
                break;
            case EGameStage.Pause:
                break;
            case EGameStage.GameOver:
                break;
            case EGameStage.LevelCompleted:
                //Camera.gameObject.SetActive(false);
                break;
            case EGameStage.GameStart:
                break;
            case EGameStage.Transition:
                break;
            case EGameStage.Restart:
                break;
            case EGameStage.MenuShop:
                break;
            case EGameStage.MainMenu:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    }
}