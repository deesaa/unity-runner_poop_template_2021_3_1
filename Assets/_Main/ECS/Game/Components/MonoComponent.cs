using UnityEngine;

public struct MonoComponent<T> where T : Component
{
    public T Value;
}