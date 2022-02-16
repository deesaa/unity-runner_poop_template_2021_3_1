using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

public class GuitarSawObstacle : ObstacleView
{
    public float Amplitude;
    public float Speed;
    public Transform MoveTransform;
    private float _inititalLocalX;
    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        float startLocalPosX = MoveTransform.localPosition.x - Amplitude * 0.5f;
        float endLocalPosX = MoveTransform.localPosition.x + Amplitude * 0.5f;

        MoveTransform.transform.SetLocalX(startLocalPosX);
        DOTween.Sequence()
            .Append(MoveTransform.transform.DOLocalMoveX(endLocalPosX, Speed).SetEase(Ease.Linear))
            .Append(MoveTransform.transform.DOLocalMoveX(startLocalPosX, Speed).SetEase(Ease.Linear))
            .SetLoops(-1).SetEase(Ease.Linear);
    }
}