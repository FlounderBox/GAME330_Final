using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    public GameEvent EngulfedEvent;

    public UnityEventFloat Response;

    public enum ItemState
    {
        Idle,
        Engulfed,
    }

    ItemState currentState;

    public float Score
    {
        get
        {
            return CalculateScore(GetComponent<Collider>());
        }
    }

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public static float CalculateScore(Collider col)
    {

        return Mathf.Round(col.bounds.size.magnitude * 100) / 100;
        //return col.bounds.size.magnitude;
    }

    public static bool CanBeEngulfed(float src, float dest)
    {
        if (src > dest)
            return true;
        else
            return false;
    }

    void ChangeState(ItemState newState)
    {
        currentState = newState;
    }

    public void Engulf(Collision collision)
    {
        if (currentState != ItemState.Engulfed)
        {
            {
                ChangeState(ItemState.Engulfed);
                EngulfedEvent.Raise(Score);
                Response.Invoke(Score);
                HideItem();
                //gameObject.SetActive(false);
                //rb.isKinematic = true;
                //ChangeState(ItemState.Engulfed);
                //Vector3 localOffset = transform.position - collision.transform.position;
                //transform.parent = collision.transform;
                //transform.localPosition = localOffset;
            }
        }
    }

    private void HideItem()
    {
        GetComponent<Collider>().enabled = false;
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        SceneDebugText.drawString(Score.ToString(), transform.position, 0, 0, Color.blue);
    }
}
