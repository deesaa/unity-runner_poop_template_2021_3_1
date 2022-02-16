using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/FinishText", fileName = "FinishTextDB", order = 0)]
public class FinishTextDatabase : ScriptableObject, IFinishTextDatabase
{
    public List<FinishTextDBElement> Texts;
    public string Get(EStatType statType)
    {
        return Texts.Find(x => x.StatType == statType).Text;
    }
}