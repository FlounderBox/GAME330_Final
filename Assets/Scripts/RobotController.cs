using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//DEPRECIATED
//PLS IGNORE
public class RobotController : MonoBehaviour
{

    Rigidbody rb;

    public float Speed;
    public float RotationSpeed;
    public Vector3 JumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float _inputX = Input.GetAxis("Horizontal");
        float _inputY = Input.GetAxis("Vertical");

        //rb.MovePosition(transform.position + (transform.forward * _inputY * Speed));
        rb.MoveRotation(Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + _inputX * RotationSpeed, transform.eulerAngles.z)));

        Vector3 _targetVelocity = transform.forward * _inputY * Speed;

        Vector3 _velocity = rb.velocity;
        Vector3 _velocityChange = (_targetVelocity - _velocity);
        _velocityChange.z = Mathf.Clamp(_velocityChange.z, -3.5f, 3.5f);
        _velocityChange.y = 0;
        Debug.DrawLine(transform.position, transform.position + _velocityChange);
        rb.AddForce(_velocityChange, ForceMode.VelocityChange);

        float rotationThreshold = 0;
        float autoBalanceForce = 10;

        if (transform.rotation.eulerAngles.z > 0 + rotationThreshold && transform.rotation.eulerAngles.z < 180)
            rb.AddRelativeTorque(-transform.forward * autoBalanceForce * transform.rotation.eulerAngles.z);

        if (transform.rotation.eulerAngles.z >= 180 && transform.rotation.eulerAngles.z < 359 - rotationThreshold)
            rb.AddRelativeTorque(transform.forward * autoBalanceForce * -(transform.rotation.eulerAngles.z - 360));
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(JumpForce);
        }
    }
}
