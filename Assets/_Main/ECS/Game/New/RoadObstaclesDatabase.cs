using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/RoadObstacles", fileName = "RoadObstaclesDB", order = 0)]
public class RoadObstaclesDatabase : ScriptableObject, IRoadObstaclesDatabase
{
    public List<ObstacleView> ObstacleViews;

    public ObstacleView Get(EObstacleType type)
    {
        return ObstacleViews.Find(x => x.Type == type);
    }
}

public interface IFinishDatabase
{
    public FinishView Get();
}


[Serializable]
public struct FinishTextDBElement
{
    public string Text;
    public EStatType StatType;
}

public interface IFinishTextDatabase
{
    public string Get(EStatType statType);
}



 