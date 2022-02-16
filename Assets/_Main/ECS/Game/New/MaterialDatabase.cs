using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/Materials", fileName = "MaterialsDB", order = 0)]
public class MaterialDatabase : ScriptableObject, IMaterialDatabase
{
    public List<GateMaterialElement> GateMaterialElements;

    public GateMaterialElement Get(EMaterialType materialType, EGameChoice choice)
    {
        switch (materialType)
        {
            case EMaterialType.Null:
                break;
            case EMaterialType.Gate:
                return GateMaterialElements.Find(x => x.Choice == choice);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(materialType), materialType, null);
        }

        return default;
    }
}