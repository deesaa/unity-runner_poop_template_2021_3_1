using UnityEngine;

[CreateAssetMenu(menuName = "RunnerCreator/Environment", fileName = "Environment_", order = 0)]
public class RoadEnvironmentConfigWrap : RoadElementConfigWrap
{
    public GameObject Prefab;

    public override Transform CreateNew(RunnerCreator context)
    {
        var v = Instantiate(Prefab);
        return v.transform;
    }
}