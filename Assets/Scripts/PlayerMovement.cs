using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private InputAction move;

    private Rigidbody playerBody;

    [SerializeField] private Vector3 movementSpeed = new Vector3(0.2f, 0, 0.2f);
    [SerializeField] private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private float jumpForce = 3.8f;
    [SerializeField] private Transform transformCheckGrounded;
    [SerializeField] private LayerMask layerCollide;
    [SerializeField] Vector3 v3BoostForce = new Vector3(0, 0, 19.5f);
    [SerializeField] Vector3 v3BounceForce = new Vector3(0, 10f, 0);

    [SerializeField] Camera playerCamera;

    public static bool boolGamePaused = false;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        playerBody = this.GetComponent<Rigidbody>();
        playerInputs = new PlayerInputs();
        PlayerPrefs.SetInt("HasJumped", 0);
        //movementForce = (movementForce / Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        playerInputs.Player.Jump.started += DoJump;
        playerInputs.Player.Reset.performed += DoReset;
        playerInputs.Player.Pause.performed += DoPause;
        move = playerInputs.Player.Move;
        playerInputs.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Player.Jump.started -= DoJump;
        playerInputs.Player.Disable();
    }

    private void FixedUpdate()
    {
        //Debug.Log("x speed:" + playerBody.velocity.x);
        //Debug.Log("z speed:" + playerBody.velocity.z);
        if (BoostonTouch.boolBoosted)
        {
            playerBody.velocity = v3BoostForce;
            BoostonTouch.boolBoosted = false;
        }

        if (BounceOnTouch.boolBounced)
        {
            playerBody.velocity += v3BounceForce;
            BounceOnTouch.boolBounced = false;
        }
        if (playerBody.velocity.x < maxSpeed && move.ReadValue<Vector2>().x > 0)
            forceDirection.x += movementSpeed.x;
        if (playerBody.velocity.x > -maxSpeed && move.ReadValue<Vector2>().x < 0)
            forceDirection.x -= movementSpeed.x;
        if (playerBody.velocity.z < maxSpeed && move.ReadValue<Vector2>().y > 0)
            forceDirection.z += movementSpeed.z;
        if (playerBody.velocity.z > -maxSpeed && move.ReadValue<Vector2>().y < 0)
            forceDirection.z -= movementSpeed.z;

        playerBody.velocity += forceDirection;
        forceDirection = Vector3.zero;

        /*
        if (playerBody.velocity.y < 0f)
            playerBody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        */
    }

    /*
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    */

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (Physics.OverlapSphere(transformCheckGrounded.position, 0.3f, layerCollide).Length != 0)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            PlayerPrefs.SetInt("HasJumped", 1);
        }
    }

    private void DoReset(InputAction.CallbackContext obj)
    {
        PlayerPrefs.SetInt("EndScreen", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Reset")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DoPause(InputAction.CallbackContext obj)
    {
        if (PlayerPrefs.GetInt("EndScreen") == 0)
        {
            if (boolGamePaused)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                boolGamePaused = false;
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                boolGamePaused = true;
            }
        }
    }
}
