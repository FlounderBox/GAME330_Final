using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 1 * Time.deltaTime);
        transform.LookAt(Target.transform);
    }
}
