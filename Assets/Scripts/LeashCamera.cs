using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class LeashCamera : MonoBehaviour
{
    public PostProcessingProfile postProcessing;
    public Transform Target;
    public float LeashLength = 5;
    public float RotateSpeed = 3;


    private void Start()
    {
        postProcessing = GetComponent<PostProcessingBehaviour>().profile;
    }

    private void Update()
    {
        if (postProcessing != null)
        {
            var _dof = postProcessing.depthOfField.settings;
            _dof.focusDistance = Vector3.Distance(transform.position, Target.transform.position);
            postProcessing.depthOfField.settings = _dof;
        }

        //Vector3 targetCamPos = transform.position;

        Vector3 offsetTargetPos = Target.position + Vector3.up * 0.5f;
        Vector3 targetCamPos = offsetTargetPos + Vector3.Normalize(transform.position- offsetTargetPos) * LeashLength; 

        //if (Vector3.Distance(Target.position, transform.position) > LeashLength)
        //{
        //    targetCamPos = Target.position + Vector3.up * 0.5f;
        //}
        //transform.position = Vector3.Lerp(transform.position, targetCamPos, 0.4f * Time.deltaTime);
        transform.position += (targetCamPos - transform.position) * 0.1f * Time.timeScale;

        //transform.rotation += Quaternion.Euler((Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up).eulerAngles - transform.rotation.eulerAngles * 0.1f * Time.timeScale));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up), Time.deltaTime * RotateSpeed);
    }

    public void AddLength(float f)
    {
        LeashLength += f * 0.0125f;
    }
}
