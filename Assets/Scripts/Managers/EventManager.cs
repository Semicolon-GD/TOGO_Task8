using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class EventManager
{
    #region Empty Void Events
    
    private static Dictionary<EventList,Action> _eventTable= new Dictionary<EventList, Action>();

    public static void Subscribe(EventList eventName, Action action)
    {
        if (!_eventTable.ContainsKey(eventName))
            _eventTable[eventName] = action;
        else _eventTable[eventName] += action;
      //  Debug.Log("Subscribed to "+eventName+" event.");
    }
    
    public static void Unsubscribe(EventList eventName, Action action)
    {
        if (_eventTable[eventName] != null)
            _eventTable[eventName] -= action;
        if (_eventTable[eventName] == null)
            _eventTable.Remove(eventName);
    }
    
    public static void Trigger(EventList eventName)
    {
        if (_eventTable[eventName] != null)
            _eventTable[eventName]?.Invoke();
    }
    
    #endregion

    #region Float Events
    
    private static Dictionary<EventList,Action<float>> _eventTableFloat= new Dictionary<EventList, Action<float>>();
    
    public static void Subscribe(EventList eventName, Action<float> action)
    {
        if (!_eventTableFloat.ContainsKey(eventName))
            _eventTableFloat[eventName] = action;
        else _eventTableFloat[eventName] += action;
    }
    
    public static void Unsubscribe(EventList eventName, Action<float> action)
    {
        if (_eventTableFloat[eventName] != null)
            _eventTableFloat[eventName] -= action;
        if (_eventTableFloat[eventName] == null)
            _eventTableFloat.Remove(eventName);
    }
    
    public static void Trigger(EventList eventName, float value)
    {
        if (_eventTableFloat[eventName] != null)
            _eventTableFloat[eventName]?.Invoke(value);
    }
    
    #endregion
    
    #region Single GameObject Events
    
    private static Dictionary<EventList,Action<GameObject>> _eventTableGameObject= new Dictionary<EventList, Action<GameObject>>();
    
    public static void Subscribe(EventList eventName, Action<GameObject> action)
    {
        if (!_eventTableGameObject.ContainsKey(eventName))
            _eventTableGameObject[eventName] = action;
        else _eventTableGameObject[eventName] += action;
    }
    
    public static void Unsubscribe(EventList eventName, Action<GameObject> action)
    {
        if (_eventTableGameObject[eventName] != null)
            _eventTableGameObject[eventName] -= action;
        if (_eventTableGameObject[eventName] == null)
            _eventTableGameObject.Remove(eventName);
    }
    
    public static void Trigger(EventList eventName, GameObject value)
    {
        if (_eventTableGameObject[eventName] != null)
            _eventTableGameObject[eventName]?.Invoke(value);
    }
    
    #endregion
    
}
