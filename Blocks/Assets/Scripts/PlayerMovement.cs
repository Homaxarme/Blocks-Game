using UnityEngine;

//This script needs a rigidbody and the Player script to work
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    //The amount of force to use when moving the player
    [SerializeField]
    public float force = 100f;

    //Applies the function that moves the player
    void FixedUpdate()
    {
        ApplyPlayerForces(GetComponent<Rigidbody>(), force);
    }
    //Function to move the player
    void ApplyPlayerForces(Rigidbody rigidbody, float _force)
    {
        //These inputs corresspond to player one
        if (GetComponent<Player>().playerNumber == 0)
        {
            if (Input.GetKey("w"))
            {
                //Moves the player forward
                rigidbody.AddForce(0, 0, _force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                //Moves the player backward
                rigidbody.AddForce(0, 0, -_force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                //Moves the player to the right
                rigidbody.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                //Moves the player to the left
                rigidbody.AddForce(-_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        //These inputs correspond to player two
        else
        {
            if (Input.GetKey("up"))
            {
                //Moves the player forward
                rigidbody.AddForce(0, 0, _force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("down"))
            {
                //Moves the player backward
                rigidbody.AddForce(0, 0, -_force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("right"))
            {
                //Moves the player to the right
                rigidbody.AddForce(_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("left"))
            {
                //Moves the player to the left
                rigidbody.AddForce(-_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
    }
}