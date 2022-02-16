using UnityEngine;

[CreateAssetMenu(menuName = "RunnerCreator/RoadResources", fileName = "RoadResource_", order = 0)]
public class RoadResourcesConfigWrap : RoadElementConfigWrap
{
    public EGameChoice Choice;
    public float OffsetZ;
    public int Count;
    
    public override Transform CreateNew(RunnerCreator context)
    {
        var holder = new GameObject().transform;
        
        for (int i = 0; i < Count; i++)
        {
            var v = Instantiate(context.RoadResourcesDatabase.Get(Choice), holder);
            v.transform.TranslateLocalZ(OffsetZ * i);
        }
        
        return holder;
    }
}