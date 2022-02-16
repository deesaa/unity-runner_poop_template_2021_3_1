using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RunnerCreator/Group", fileName = "Group_", order = 0)]
public class RoadElementGroupConfigWrap : RoadElementConfigWrap
{
    public List<LevelCreatorConfigElement> Group;
    
    public override Transform CreateNew(RunnerCreator context)
    {
        var holder = new GameObject().transform;

        foreach (var elementConfigWrap in Group)
        {
            var newElement = elementConfigWrap.RoadElement.CreateNew(context);
            newElement.SetParent(holder, false);
            newElement.TranslateLocalX(elementConfigWrap.OffsetX);
            newElement.TranslateLocalZ(elementConfigWrap.OffsetZ);
        }
        
        return holder;
    }
}