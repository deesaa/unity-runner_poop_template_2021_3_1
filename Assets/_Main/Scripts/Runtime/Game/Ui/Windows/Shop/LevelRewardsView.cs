using TMPro;
using UnityEngine;

public class LevelRewardsView : MonoBehaviour
{
    public TMP_Text StarsCount;

    public void Set(int starsReward)
    {
        StarsCount.text = $"x{starsReward.ToString()}";
    }
}