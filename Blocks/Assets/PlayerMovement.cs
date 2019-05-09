using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool playerOne;
    public Rigidbody rigidbody;
    public float force;
    void FixedUpdate()
        {
        if(playerOne)
        {
            if (Input.GetKey("w"))
            {
                rigidbody.AddForce(0, 0, force * Time.deltaTime,ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                rigidbody.AddForce(0, 0, -force * Time.deltaTime,ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                rigidbody.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                rigidbody.AddForce(-force* Time.deltaTime, 0, 0,ForceMode.VelocityChange);
            }
        }
        else
        {
            if (Input.GetKey("up"))
            {
                rigidbody.AddForce(0, 0, force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("down"))
            {
                rigidbody.AddForce(0, 0, -force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("right"))
            {
                rigidbody.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("left"))
            {
                rigidbody.AddForce(-force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
	}
}
