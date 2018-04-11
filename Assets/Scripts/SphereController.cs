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
        return Vector3.one * pScore / unitScore;
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //startingScale = transform.localScale;
        unitScore = Item.CalculateScore(GetComponent<SphereCollider>());
        transform.localScale = GetScaleFromScore(Score);
    }

    [ExecuteInEditMode]
    void UpdateSize()
    {
        transform.localScale = GetScaleFromScore(Score);
    }

    void Update()
    {
        float _inputX = Input.GetAxis("Horizontal");
        float _inputY = Input.GetAxis("Vertical");

        rb.AddTorque(new Vector3(_inputX * Torque, 0, _inputY * Torque));
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
}
