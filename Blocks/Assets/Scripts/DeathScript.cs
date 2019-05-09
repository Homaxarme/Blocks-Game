using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
public class DeathScript : MonoBehaviour
{
    private Transform transform;
    private PlayerMovement movement;
    private Rigidbody rigidbody;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        movement = GetComponent<PlayerMovement>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfInBoundaries();
    }
    private void CheckIfInBoundaries()
    {
        if (transform.position.y <= -1)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        movement.enabled = false;
        Debug.Log("Disabled Movement!");
        gameManager.GetComponent<GameManager>().InvokeRestart();
    }

}
