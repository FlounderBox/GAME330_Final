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

    private void Update()
    {
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

        if (eyeTransform != null)
        {
            //Debug.DrawRay(transform.position, prevEyeRotation, Color.red);
            eyeTransform.position = transform.position;
            eyeTransform.localScale = transform.localScale;
            if (_torque != Vector3.zero)
            {
                eyeTransform.rotation = Quaternion.LookRotation(prevEyeRotation);
            }
            prevEyeRotation = Camera.main.transform.TransformDirection(transform.position - (transform.position + new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * 2));
        }

        jelly.AddTorque(Camera.main.transform.TransformDirection(_torque), true);


        UpdateSize();

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
