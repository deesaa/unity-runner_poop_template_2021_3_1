using System;
using UnityEngine;

[Serializable]
public struct BrokePart
{
    public Rigidbody Rb;
    public Vector3 InitialPosition;
    public Quaternion InitialRotation;
}