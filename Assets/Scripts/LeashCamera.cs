using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class LeashCamera : MonoBehaviour
{
    public PostProcessingProfile postProcessing;
    public Transform Target;
    public float LeashLength = 5;


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
        LeashLength += f * 0.0125f;
    }
}
