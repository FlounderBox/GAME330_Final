using UnityEngine;
using UnityEngine.Events;

//Registers the UnityEvent to the GameEvent, and invokes the response
public class GameEventListener : MonoBehaviour {

    public GameEvent Event;

    //UnityEvent is used to display the event gui in the inspector
    public UnityEvent Response;
    public UnityEventFloat ResponseFloat;
    public UnityEventSprite ResponseSprite;

    private void OnEnable()
    {
        //Adds listener to event
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        //Removes listener from event
        Event.UnregisterListener(this);
    }

    public void Invoke()
    {
        Response.Invoke();
    }

    public void Invoke(float f)
    {
        ResponseFloat.Invoke(f);
    }

    public void Invoke(Sprite s)
    {
        ResponseSprite.Invoke(s);
    }

    public void Invoke (float f, Sprite s)
    {
        Invoke(f);
        Invoke(s);
        Invoke();
    }
}
