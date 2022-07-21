using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMoveSpin : MonoBehaviour
{
    [SerializeField] float floatRotation;
    public GameObject worm;

    void FixedUpdate()
    {
        worm.transform.Rotate(0, floatRotation, 0);
    }
}
