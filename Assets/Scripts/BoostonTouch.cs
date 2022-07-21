using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostonTouch : MonoBehaviour
{
    public static bool boolBoosted;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            boolBoosted = true;
    }
}

