using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormFall : MonoBehaviour
{
    [SerializeField] float floatWormMaxy;
    [SerializeField] float floatWormMiny;

    void Update()
    {
        if (GetComponent<Rigidbody>().transform.position.y <= floatWormMiny)
        {
            GetComponent<Rigidbody>().transform.position += new Vector3(0, (floatWormMaxy-floatWormMiny), 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
