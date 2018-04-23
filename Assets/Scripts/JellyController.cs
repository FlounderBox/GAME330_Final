using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour {

    public float Torque;
    public float Score;
    public float ScalePercentage = 0.01f;

    private JellyMesh jelly;

    private void Awake()
    {
        jelly = GetComponent<JellyMesh>();
        UpdateSize();
    }

    float GetScaleFromScore(float pScore)
    {
        return (pScore / 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jelly.Scale(transform.localScale.x + 0.25f);
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

        jelly.AddTorque(Camera.main.transform.TransformDirection(_torque), true);
        //jelly.AddForce(Camera.main.transform.TransformDirection(_torque), false)
        Debug.DrawLine(transform.position, _torque);

        
        //UpdateSize();

    }

    void UpdateSize()
    {
        //NEEDS RATIO
        Debug.Log(Score / 100 + 1);
        jelly.Scale(Score / 100 + 1);
    }

    public void AddToScore(float f)
    {
        Score += f * ScalePercentage;
        UpdateSize();
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
