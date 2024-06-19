using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpCooldown = 0f;
    public float jumpInterval = 0.2f;
    public float jumpImpulse = 30f;
    [HideInInspector] public static Rigidbody thisRigidBody;
    [HideInInspector] public int gameScore;
    //*

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();

        gameScore = GameManager.Instance.gameScore;
    }

    void Update()
    {
        bool isGameOver = GameManager.Instance.IsGameOver();
        bool canJump = jumpCooldown <= 0 && !isGameOver;

        jumpCooldown -= Time.deltaTime;

        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);

            if (jumpInput)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        jumpCooldown = jumpInterval;

        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0, jumpImpulse, 0), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        OnCustomCollisionEnter(collision.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        OnCustomCollisionEnter(collider.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("scoreSensor");

        if (isSensor)
        {
            gameScore++;
            Debug.Log(gameScore);
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
}
