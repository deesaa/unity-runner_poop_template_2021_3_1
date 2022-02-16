using UnityEngine;

[CreateAssetMenu(menuName = "RunnerCreator/Gate", fileName = "Element_", order = 0)]
public class RoadGateConfigWrap : RoadElementConfigWrap
{
    public EGameChoice LeftGate;
    public EGameChoice RightGate;
    public GateView GatePrefab;
    
    public override Transform CreateNew(RunnerCreator context)
    {
        var v = Instantiate(GatePrefab);
        v.SetIcons(
            context.IconsDatabase.Get(LeftGate, 1), 
            context.IconsDatabase.Get(LeftGate, 0),
            context.IconsDatabase.Get(RightGate, 1),
            context.IconsDatabase.Get(RightGate, 0)
            );
        v.SetChoices(LeftGate, RightGate);
        var leftMats = context.MaterialDatabase.Get(EMaterialType.Gate, LeftGate);
        var rightMats = context.MaterialDatabase.Get(EMaterialType.Gate, RightGate);
        v.SetMaterials(leftMats, rightMats);
        return v.transform;
    }
}