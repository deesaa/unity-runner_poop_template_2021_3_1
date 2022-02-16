using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    void Start()
    {
        if (Random.Range(0, 2000) == 1337)
        {
            target.gameObject.SetActive(true);
        }
    }
}