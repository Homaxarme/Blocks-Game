using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private bool playerOne;

    private Rigidbody rigidbody;

    [SerializeField]
    private float force = 100f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        ApplyPlayerForces(rigidbody, playerOne, force);
    }
    void ApplyPlayerForces(Rigidbody _rigidbody, bool _playerOne, float _force)
    {
        if (_playerOne)
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