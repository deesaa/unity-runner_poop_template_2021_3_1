using UnityEngine;


public abstract class RoadElementConfigWrap : ScriptableObject
{
    public abstract Transform CreateNew(RunnerCreator context);
}