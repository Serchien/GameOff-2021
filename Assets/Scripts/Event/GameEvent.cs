using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    // list of all the event
    private static HashSet<GameEvent> listedEvents = new HashSet<GameEvent>();

    // list of all the listener
    HashSet<GameEventListener> gameEventListeners = new HashSet<GameEventListener>();

    public void Register(GameEventListener gameEventListener)
    {
        gameEventListeners.Add(gameEventListener);
        listedEvents.Add(this);

    }

    public void Deregister(GameEventListener gameEventListener)
    {
        gameEventListeners.Remove(gameEventListener);

        if(gameEventListeners.Count == 0)
        {
            listedEvents.Remove(this);
        }

    }


    [ContextMenu("Invoke")]
    public void Invoke()
    {
        foreach(GameEventListener gameEventListener in gameEventListeners.ToList())
        {
            gameEventListener.RaiseEvent();
        }
    }

    public static void RaiseEvent(string eventName)
    {
        foreach(GameEvent gameEvent in listedEvents)
        {
            if(gameEvent.name == eventName)
            {
                gameEvent.Invoke();

            }
        }
    }


}
