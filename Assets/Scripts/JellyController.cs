using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour
{

    public float Torque;
    public float Score;
    public float ScalePercentage = 0.01f;
    public float BreakForce = 50;

    private JellyMesh jelly;
    private Transform eyeTransform;
    private Vector3 prevEyeRotation;
    float UnitScore;

    bool controllable = true;

    private void Start()
    {
        jelly = GetComponent<JellyMesh>();
        eyeTransform = transform.Find("Eyes");
        eyeTransform.parent = null;
        UnitScore = 1;
        UpdateSize();
    }

    float GetScaleFromScore(float pScore)
    {
        return (pScore / 1f);
    }

    public void EnableControls(bool pBool)
    {
        if (pBool)
            controllable = true;
        else
            controllable = false;
    }

    private void Update()
    {
        RotateEyes();
        if (controllable)
        {
            Movement();
        }
        foreach (JellyMesh.ReferencePoint j in jelly.ReferencePoints)
        {

            if (j.GameObject.GetComponent<SpringJoint>() != null)
            {
                if (j.GameObject.GetComponent<SpringJoint>().currentForce.magnitude > BreakForce)
                {
                    //Debug.Log(j.GameObject.GetComponent<SpringJoint>().currentForce.magnitude);
                    j.Collider.enabled = false;
                }
                else
                {
                    j.Collider.enabled = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        
        UpdateSize();
    }

    Vector3 GetInputVector()
    {
        Vector3 _inputVector = Vector3.zero;

        float _inputX;
        float _inputY;
        if (SimonXInterface.SimonXTransform != null)
        {
            _inputX = (SimonXInterface.GetUpVector() - Vector3.up).x;
            _inputY = (SimonXInterface.GetUpVector() - Vector3.up).z;
            Vector3 _difference = new Vector3(_inputX, _inputY, 0);
            _inputVector = new Vector3(-_difference.y, 0, _difference.x) * Torque;
        }
        else
        {
            _inputX = Input.GetAxis("Horizontal");
            _inputY = Input.GetAxis("Vertical");
            _inputVector = new Vector3(_inputY * Torque, 0, -_inputX * Torque);
        }
        return _inputVector;
    }

    void Movement()
    {
        Vector3 _torqueCameraDirection = Camera.main.transform.TransformDirection(GetInputVector());
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {

        }
        jelly.AddTorque(Vector3.ProjectOnPlane(_torqueCameraDirection, hit.normal), true);
    }

    void RotateEyes()
    {
        if (eyeTransform != null)
        {
            eyeTransform.position = transform.position;
            eyeTransform.localScale = transform.localScale;

            if (GetInputVector() != Vector3.zero)
            {
                eyeTransform.rotation = Quaternion.Slerp(eyeTransform.rotation, Quaternion.LookRotation(prevEyeRotation), Time.deltaTime * 10);
            }
            prevEyeRotation = Camera.main.transform.TransformDirection(transform.position - (transform.position + new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * 2));
        }
    }

    void UpdateSize()
    {
        jelly.Scale(Score / UnitScore);
        UnitScore = Score;
    }

    public void AddToScore(float f)
    {
        Score += f * ScalePercentage;
        UpdateSize();
        BreakForce += f * 5;
    }

    void OnJellyCollisionEnter(JellyMesh.JellyCollision collision)
    {
        if (collision.Collision.transform.GetComponent<Item>())
        {
            if (Item.CanBeEngulfed(Score, collision.Collision.transform.GetComponent<Item>().Score))
                collision.Collision.transform.GetComponent<Item>().Engulf(collision.Collision);
        }
    }
}
