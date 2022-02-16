using System;

[Serializable]
public struct ValueGameData
{
    public DateTime FirstPlayDate;
    public int UpdateVersionShot;
    public DateTime CurrentLevelStartTime;
    public int EarnedStars;
    public int EarnedGems;
    public int CurrentLevelIndex;
    public bool IsNextLevelUnlocked;

    public GameItemID EquippedWeapon;
    public bool IsNewItemAvaibleNotification;
    public bool DisabledVibration;
}