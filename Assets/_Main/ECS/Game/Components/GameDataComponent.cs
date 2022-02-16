using System;
using DataBase.Game;
using Runtime.DataBase.General.GameCFG;
using UniRx;
using UnityEngine;

[Serializable]
public struct GameDataComponent
{
    [SerializeField]
    public ValueGameData ValueGameData;
    
    [SerializeField]
    public ReferenceGameData ReferenceGameData;
    
    public GameDataComponent(ValueGameData valueGameData, ReferenceGameData referenceGameData)
    {
        this.ValueGameData = valueGameData;
        this.ReferenceGameData = referenceGameData;
    }
}