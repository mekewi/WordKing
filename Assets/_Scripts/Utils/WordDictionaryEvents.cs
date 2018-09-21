using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WordDictionaryEvents : MonoBehaviour {
    public WordDictionary Event;
    public UnityEvent Response;
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }
    private void OnDisable()
    {
        Event.UnregisterListener(this);

    }
    internal void OnEventRaised()
    {
        Response.Invoke();
    }
}
