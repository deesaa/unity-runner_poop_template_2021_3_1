using System;
using UnityEngine;

namespace DataBase.Objects.Impl
{
    [CreateAssetMenu(menuName = "Bases/PrefabsBase", fileName = "PrefabsBase")]
    public class PrefabsBase : ScriptableObject, IPrefabsBase
    {
        [SerializeField] private PrefabsList _prefabsList;
        public PrefabsList PrefabsList => _prefabsList;
    }
}