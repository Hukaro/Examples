using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    bool dest = false;
    float destroyIn = 1f;

    public void StartDest(bool _dest)
    {
        dest = _dest;
    }

    void FixedUpdate()
    {
        if (dest)
        {
            destroyIn -= Time.fixedDeltaTime;
            if (destroyIn <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
