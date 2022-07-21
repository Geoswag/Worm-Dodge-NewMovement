using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormMoveHoriz : MonoBehaviour
{
    [SerializeField] float floatWormMaxz;
    [SerializeField] float floatWormMinz;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -0.4f);
    }

    void FixedUpdate()
    {
        if (transform.position.z <= floatWormMinz)
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0.3f);
        else if (transform.position.z > floatWormMaxz)
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -0.3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
