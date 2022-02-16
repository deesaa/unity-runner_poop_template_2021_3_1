using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/RoadObstacles", fileName = "RoadObstaclesDB", order = 0)]
public class RoadEnvironmentDatabase : ScriptableObject, IEnvironmentDatabase
{
    public List<Transform> EnvironmentViews;

    public Transform Get(EEnvironmentType environmentType)
    {
        return EnvironmentViews[0];
    }
}



[Serializable]
public enum EMaterialType
{
    Null,
    Gate
}
public interface IEnvironmentDatabase
{
    public Transform Get(EEnvironmentType environmentType);
}

public interface IMaterialDatabase
{
    public GateMaterialElement Get(EMaterialType materialType, EGameChoice choice);
}

[Serializable]
public struct GateMaterialElement
{
    public EGameChoice Choice;
    public Material BaseMaterial;
    public Material DoorMaterial;
}