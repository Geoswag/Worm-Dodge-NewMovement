using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormMove : MonoBehaviour
{
    [SerializeField] float floatWormMaxy;
    [SerializeField] float floatWormMiny;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0.35f, 0);
    }

    void FixedUpdate()
    {
        if (transform.position.y <= floatWormMiny)
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0.35f, 0);
        else if (transform.position.y > floatWormMaxy)
            GetComponent<Rigidbody>().velocity = new Vector3(0, -0.4f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
