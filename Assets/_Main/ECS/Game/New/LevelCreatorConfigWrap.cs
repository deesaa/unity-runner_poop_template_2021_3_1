using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RunnerCreator/Level", fileName = "Level_", order = 0)]
public class LevelCreatorConfigWrap : ScriptableObject
{
    public List<LevelCreatorConfigElement> Elements;
}