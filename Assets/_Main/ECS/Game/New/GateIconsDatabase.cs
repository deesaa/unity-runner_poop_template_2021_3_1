using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/GateIcons", fileName = "GateIconsDB", order = 0)]
public class GateIconsDatabase : ScriptableObject, IGateIconsDatabase
{
    public List<GateIconsDBElement> IconElements;

    public Sprite Get(EGameChoice choice, int index)
    {
        Debug.Log(choice);
        Debug.Log(index);
        return IconElements.Find(x => x.Choice == choice).Icons[index];
    }
}