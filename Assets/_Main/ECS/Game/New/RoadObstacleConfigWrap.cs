using System;
using UnityEngine;

[CreateAssetMenu(menuName = "RunnerCreator/Obstacle", fileName = "Obstacle_", order = 0)]
public class RoadObstacleConfigWrap : RoadElementConfigWrap
{
    public EObstacleType Type;
   // public ESawType SawType;
    public float Amplitude;
    public float Speed;

    public override Transform CreateNew(RunnerCreator context)
    {
        var v = Instantiate(context.RoadObstaclesDatabase.Get(Type));
        v.Type = Type;

        if (v is GuitarSawObstacle saw)
        {
            saw.Amplitude = Amplitude;
            saw.Speed = Speed;
        }
        return v.transform;
    }
}

[Serializable]
public enum ESawType
{
    Full,
    Half
}