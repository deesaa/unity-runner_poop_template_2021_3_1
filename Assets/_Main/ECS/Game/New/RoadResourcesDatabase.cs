using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/RoadResources", fileName = "RoadResourcesDB", order = 0)]
public class RoadResourcesDatabase : ScriptableObject, IRoadResourceDatabase
{
    public List<RoadResourceView> RoadResourceViews;

    public RoadResourceView Get(EGameChoice choice)
    {
        return RoadResourceViews.Find(x => x.Choice == choice);
    }
}