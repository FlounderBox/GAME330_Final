using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class LeashCamera : MonoBehaviour
{

    public Transform Target;
    public float LeashLength = 5;


    private void Start()
    {

    }

    private void LateUpdate()
    {

        Vector3 targetCamPos = transform.position;

        if (Vector3.Distance(Target.position, transform.position) > LeashLength)
        {
            targetCamPos = Target.position + Vector3.up * 0.5f;
        }
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 0.4f * Time.deltaTime);
        transform.LookAt(Target.transform);
    }

    public void AddLength(float f)
    {
        LeashLength += f * 0.125f;
    }
}
