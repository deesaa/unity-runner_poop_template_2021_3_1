using UnityEngine;

public interface IGateIconsDatabase
{
    public Sprite Get(EGameChoice choice, int index);
}