using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum e_EventID
{
    weatherChange=0
}
public class OberserverMng : Singleton<OberserverMng>
{
    Dictionary<e_EventID, Action<object>> _listener = new Dictionary<e_EventID, Action<object>>();

    public void RegisterListener(e_EventID eventID, Action<object> callback)
    {
        if(_listener.ContainsKey(eventID)==false)
        {
            _listener.Add(eventID, null);
        }
        _listener[eventID] += callback;
    }

    public void PostEvent(e_EventID eventID, object param =null)
    {
        if(_listener.ContainsKey(eventID) ==false)
        {
            Debug.LogError("Not contain key: "+eventID);
            return;
        }

        Action<object> callbacks = _listener[eventID];
        if(callbacks!=null)
        {
            callbacks(param);
        }
        else// if Listener not contain event of eventID =>remove
        {
            _listener.Remove(eventID);
        }
    }

    public void RemoveListener(e_EventID e_Event, Action<object> callback)
    {
        if(_listener.ContainsKey(e_Event))
        {
            _listener[e_Event] -= callback;
        }    
    }    

    public void ClearAllListener()
    {
        _listener.Clear();
    }
}

public static class EventDispatcherExtension
{
    public static void RegisterListener(this MonoBehaviour mono,e_EventID e_Event,Action<object> callback)
    {
        OberserverMng.singleton.RegisterListener(e_Event, callback);
    }

    /// <summary>
    /// post event with parameter
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="e_Event"></param>
    /// <param name="param"></param>
    public static void PostEvent(this MonoBehaviour mono,e_EventID e_Event,object param)
    {
        OberserverMng.singleton.PostEvent(e_Event, param);
    }

    /// <summary>
    /// post event without parameter
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="e_Event"></param>
    /// <param name="param"></param>
    public static void PostEvent(this MonoBehaviour mono, e_EventID e_Event)
    {
        OberserverMng.singleton.PostEvent(e_Event);
    }
}