using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour
{

    public float TorqueSpeed;
    Rigidbody rb;
    List<SpringJoint> boneSpringJoints = new List<SpringJoint>();

    List<Vector3> startingAnchors = new List<Vector3>();
    float startingMass;
    float startingSpringForce;
    float startingDamper;
    float startingTolerance;
    float startingTorque;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startingMass = rb.mass;

        foreach (Transform t in transform)
        {
            if (t.GetComponent<SpringJoint>() != null)
            {
                boneSpringJoints.Add(t.GetComponent<SpringJoint>());
            }
        }

        for (int i = 0; i < boneSpringJoints.Count; i++)
        {
            startingSpringForce = boneSpringJoints[i].spring;
            startingDamper = boneSpringJoints[i].damper;
            startingTolerance = boneSpringJoints[i].tolerance;

            startingAnchors.Add(boneSpringJoints[i].connectedAnchor);
        }
        startingTorque = TorqueSpeed;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale *= 1.1f;
            MultiplyAnchors(transform.localScale.x);
        }
    }

    private void FixedUpdate()
    {
        float _inputX = Input.GetAxis("Horizontal");
        float _inputY = Input.GetAxis("Vertical");

        Vector3 _torque = new Vector3(_inputX, 0, _inputY) * TorqueSpeed;
        rb.AddTorque(_torque);

        for (int i = 0; i < boneSpringJoints.Count; i++)
        {
            if (boneSpringJoints[i] != transform)
            {
                boneSpringJoints[i].transform.localRotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }

    void MultiplyAnchors(float f)
    {
        for (int i = 0; i < boneSpringJoints.Count; i++)
        {
            boneSpringJoints[i].connectedAnchor = startingAnchors[i] * f;
            boneSpringJoints[i].spring = startingSpringForce * f;
            boneSpringJoints[i].damper = startingDamper * f;
            //boneSpringJoints[i].tolerance = startingTolerance * f;
            //boneSpringJoints[i].massScale = transform.localScale.x * f;
            //boneSpringJoints[i].connectedMassScale = transform.localScale.x * f;
            boneSpringJoints[i].GetComponent<Rigidbody>().mass = startingMass * f;

            TorqueSpeed = startingTorque * f;
        }
    }
}
