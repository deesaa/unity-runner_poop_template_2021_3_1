using UnityEngine;

[CreateAssetMenu(menuName = "RunnerCreator/Finish", fileName = "Finish_", order = 0)]
public class RoadFinishWrap : RoadElementConfigWrap
{
    public override Transform CreateNew(RunnerCreator context)
    {
        return Instantiate(context.FinishDatabase.Get()).transform;
    }
}