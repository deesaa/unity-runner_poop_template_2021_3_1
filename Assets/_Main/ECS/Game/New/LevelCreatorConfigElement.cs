using System;
using UnityEngine;

[Serializable]
public struct LevelCreatorConfigElement
{
    public RoadElementConfigWrap RoadElement;
    [Range(-10, 30)]
    public float OffsetZ;
    [Range(-3, 3)]
    public float OffsetX;
}