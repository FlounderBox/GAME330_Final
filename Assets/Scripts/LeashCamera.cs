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

    public bool moveTowardsTarget = true;
    public bool lookAtTarget = true;


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

        if (moveTowardsTarget)
            MoveTowardsTarget();

        if (lookAtTarget)
            LookAtTarget();
    }

    public void EnableLooking(bool pBool)
    {
        if (pBool)
            lookAtTarget = true;
        else
            lookAtTarget = false;
    }

    public void EnableMoving(bool pBool)
    {
        if (pBool)
            moveTowardsTarget = true;
        else
            moveTowardsTarget = false;
    }

    void MoveTowardsTarget()
    {
        Vector3 offsetTargetPos = Target.position + Vector3.up * 0.5f;
        Vector3 targetCamPos = offsetTargetPos + Vector3.Normalize(transform.position - offsetTargetPos) * LeashLength;

        transform.position += (targetCamPos - transform.position) * 0.1f * Time.timeScale;
    }

    void LookAtTarget()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up), Time.deltaTime * RotateSpeed);
    }

    public void AddLength(float f)
    {
        LeashLength += f * 0.0125f;
    }
}
