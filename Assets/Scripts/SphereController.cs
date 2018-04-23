using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float Torque;
    public float ScalePercentage = 0.01f;
    public float Score;
    Rigidbody rb;

    float unitScore;

    Vector3 GetScaleFromScore(float pScore)
    {
            return Vector3.one * pScore/1;
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //startingScale = transform.localScale;
        unitScore = Item.CalculateScore(GetComponent<SphereCollider>());
        transform.localScale = GetScaleFromScore(Score);
    }

    public void UpdateSize()
    {
        transform.localScale = GetScaleFromScore(Score);
    }

    void Update()
    {
        Vector3 _torque = Vector3.zero;
        if (SimonXInterface.SimonXTransform != null)
        {
            Vector3 _difference = new Vector3((SimonXInterface.GetUpVector() - Vector3.up).x, (SimonXInterface.GetUpVector() - Vector3.up).z,0 );
            _torque = new Vector3(-_difference.y, 0, _difference.x) * Torque;
        }
        else
        {
            float _inputX = Input.GetAxis("Horizontal");
            float _inputY = Input.GetAxis("Vertical");
            _torque = new Vector3(_inputY * Torque, 0, -_inputX * Torque);
        }

        rb.AddTorque(Camera.main.transform.TransformDirection(_torque));
        UpdateSize();
    }

    private void OnDrawGizmos()
    {
        SceneDebugText.drawString(Score.ToString(), transform.position, 0, 0, Color.red);
    }

    public void AddToScore(float f)
    {
        //Score = Item.CalculateScore(GetComponent<SphereCollider>());
        //scaleMod += f * ScalePercentage;
        //transform.localScale = startingScale * scaleMod;
        Score += f * ScalePercentage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Item>())
        {
            if (Item.CanBeEngulfed(Score, collision.transform.GetComponent<Item>().Score))
                collision.transform.GetComponent<Item>().Engulf(collision);
        }
    }
}
