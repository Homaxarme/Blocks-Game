using UnityEngine;

//This script needs a rigidbody and the Player script to work
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    //Says which player this is
    int playerNumber;

    //Gets the player rigidbody
    Rigidbody rigidbody;

    //The amount of force to use when moving the player
    [SerializeField]
    private float force = 100f;

    //Sets the rigidbody variable
    private void Start()
    {
        //Gets the rigidbody component inside the player object
        rigidbody = GetComponent<Rigidbody>();
        //Sets the player number so the script knows which inputs to use
        playerNumber = GetComponent<Player>().playerNumber;
    }
    //Applies the function that moves the player
    void FixedUpdate()
    {
        ApplyPlayerForces(rigidbody, playerNumber, force);
    }
    //Function to move the player
    void ApplyPlayerForces(Rigidbody _rigidbody, int _playerNumber, float _force)
    {
        //These inputs corresspond to player one
        if (_playerNumber == 1)
        {
            if (Input.GetKey("w"))
            {
                _rigidbody.AddForce(0, 0, _force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                _rigidbody.AddForce(0, 0, -_force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                _rigidbody.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                _rigidbody.AddForce(-_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        //These inputs correspond to player two
        else
        {
            if (Input.GetKey("up"))
            {
                _rigidbody.AddForce(0, 0, _force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("down"))
            {
                _rigidbody.AddForce(0, 0, -_force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("right"))
            {
                _rigidbody.AddForce(_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("left"))
            {
                _rigidbody.AddForce(-_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
    }
}