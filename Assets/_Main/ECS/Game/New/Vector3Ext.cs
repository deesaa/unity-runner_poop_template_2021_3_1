using UnityEngine;

public static class Vector3Ext
{
    public static Transform TranslateLocalX(this Transform transform, float x)
    {
        var localPosition = transform.localPosition;
        localPosition = new Vector3(localPosition.x + x, localPosition.y, localPosition.z);
        transform.localPosition = localPosition;
        return transform;
    }
    
    public static Transform TranslateLocalZ(this Transform transform, float z)
    {
        var localPosition = transform.localPosition;
        localPosition = new Vector3(localPosition.x, localPosition.y, localPosition.z + z);
        transform.localPosition = localPosition;
        return transform;
    }
    
    public static Transform TranslateZ(this Transform transform, float z)
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y, position.z + z);
        transform.localPosition = position;
        return transform;
    }

    public static Transform SetX(this Transform transform, float x)
    {
        var position = transform.position;
        position = new Vector3(x, position.y, position.z);
        transform.position = position;
        return transform;
    }
    
    public static Transform SetY(this Transform transform, float y)
    {
        var position = transform.position;
        position = new Vector3(position.x, y, position.z);
        transform.position = position;
        return transform;
    }
    
    public static Transform SetZ(this Transform transform, float z)
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y, z);
        transform.position = position;
        return transform;
    }
    
    public static Transform SetLocalX(this Transform transform, float x)
    {
        var localPosition = transform.localPosition;
        localPosition = new Vector3(x, localPosition.y, localPosition.z);
        transform.localPosition = localPosition;
        return transform;
    }
    
    public static Transform SetLocalY(this Transform transform, float y)
    {
        var localPosition = transform.localPosition;
        localPosition = new Vector3(localPosition.x, y, localPosition.z);
        transform.localPosition = localPosition;
        return transform;
    }
    
    public static Transform SetLocalZ(this Transform transform, float z)
    {
        var localPosition = transform.localPosition;
        localPosition = new Vector3(localPosition.x, localPosition.y, z);
        transform.localPosition = localPosition;
        return transform;
    }
}