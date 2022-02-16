using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/Finish", fileName = "FinishDB", order = 0)]
public class FinishDatabase : ScriptableObject, IFinishDatabase
{
    public List<FinishView> FinishViews;

    public FinishView Get()
    {
        return FinishViews[0];
    }
}