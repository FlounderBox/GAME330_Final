using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour
{
    public float Torque;
    public float Force;
    Rigidbody rb;
    Rigidbody rbCenter;
    List<SpringJoint> boneSpringJoints = new List<SpringJoint>();
    public float ScalePercentage = 0.01f;
    public float Score;

    //float unitScore;

    Vector3 GetScaleFromScore(float pScore)
    {
        return Vector3.one * pScore / 1;
    }

    List<Vector3> startingAnchors = new List<Vector3>();
    List<Quaternion> startingRotations = new List<Quaternion>();

    float startingMass;
    float startingSpringForce;
    float startingDamper;
    float startingTolerance;
    float startingTorque;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //unitScore = Item.CalculateScore(GetComponent<SphereCollider>());
        startingMass = rb.mass;

        foreach (Transform t in transform)
        {
            if (t.GetComponent<SpringJoint>() != null)
            {
                boneSpringJoints.Add(t.GetComponent<SpringJoint>());
                startingRotations.Add(t.rotation);
            }
        }

        for (int i = 0; i < boneSpringJoints.Count; i++)
        {
            startingSpringForce = boneSpringJoints[i].spring;
            startingDamper = boneSpringJoints[i].damper;
            startingTolerance = boneSpringJoints[i].tolerance;

            startingAnchors.Add(boneSpringJoints[i].connectedAnchor);
        }
        startingTorque = Torque;

        rbCenter = transform.Find("b_center").GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.localScale *= 1.1f;
            //MultiplyAnchors(transform.localScale.x);
        }
    }

    private void FixedUpdate()
    {
        Vector3 _torque = Vector3.zero;
        if (SimonXInterface.SimonXTransform != null)
        {
            Vector3 _difference = new Vector3((SimonXInterface.GetUpVector() - Vector3.up).x, (SimonXInterface.GetUpVector() - Vector3.up).z, 0);
            _torque = new Vector3(-_difference.y, 0, _difference.x) * Torque;
        }
        else
        {
            float _inputX = Input.GetAxis("Horizontal");
            float _inputY = Input.GetAxis("Vertical");
            _torque = new Vector3(_inputY * Torque, 0, -_inputX * Torque);
        }

        rb.AddTorque(Camera.main.transform.TransformDirection(_torque));
        //rb.AddForce(_torque);
        Debug.DrawLine(transform.position, _torque);

        for (int i = 0; i < boneSpringJoints.Count; i++)
        {
            if (boneSpringJoints[i] != transform)
            {
                //boneSpringJoints[i].transform.localRotation = Quaternion.Euler(Vector3.zero);
                boneSpringJoints[i].transform.localRotation = startingRotations[i];
            }
        }
        UpdateSize();

        //rbCenter.rotation = Quaternion.Euler(transform.up);
    }

    public void AddToScore(float f)
    {
        //Score = Item.CalculateScore(GetComponent<SphereCollider>());
        //scaleMod += f * ScalePercentage;
        //transform.localScale = startingScale * scaleMod;
        Score += f * ScalePercentage;
    }

    void MultiplyAnchors(float f)
    {
        for (int i = 0; i < boneSpringJoints.Count; i++)
        {
            boneSpringJoints[i].connectedAnchor = startingAnchors[i] * f;
            //boneSpringJoints[i].spring = startingSpringForce / f;
            //boneSpringJoints[i].damper = startingDamper * f;
            //boneSpringJoints[i].tolerance = startingTolerance * f;
            //boneSpringJoints[i].massScale = transform.localScale.x * f;
            //boneSpringJoints[i].connectedMassScale = transform.localScale.x * f;
            boneSpringJoints[i].GetComponent<Rigidbody>().mass = startingMass * f;
            Torque = startingTorque * f;
        }
    }

    public void UpdateSize()
    {
        transform.localScale = GetScaleFromScore(Score);
        MultiplyAnchors(transform.localScale.x);
    }

    private void OnDrawGizmos()
    {
        SceneDebugText.drawString(Score.ToString(), transform.position, 0, 0, Color.red);
    }
}
