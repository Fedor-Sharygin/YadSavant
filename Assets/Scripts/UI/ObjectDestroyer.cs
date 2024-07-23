using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDestroyer : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i).localPosition.magnitude < 0.005f)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
