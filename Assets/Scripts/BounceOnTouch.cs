using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnTouch : MonoBehaviour
{
    public static bool boolBounced;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            boolBounced = true;
    }
}

