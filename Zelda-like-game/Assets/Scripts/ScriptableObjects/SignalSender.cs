using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalSender : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise()
    {
        //go through list of listeners backwards in case listener removes itself from list and causes out of range exception
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
