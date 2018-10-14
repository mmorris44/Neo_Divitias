using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventHandler : EventSystem {

    public int playerLayer;

    GameObject lastSelectedGameObject;

    protected override void Start()
    {
        base.Start();
        lastSelectedGameObject = currentSelectedGameObject;
    }

    protected override void OnEnable()
    {
        // do not assign EventSystem.current
        base.OnEnable(); // remove?
    }

    protected override void Update()
    {
        EventSystem originalCurrent = EventSystem.current;
        current = this; // in order to avoid reimplementing half of the EventSystem class, just temporarily assign this EventSystem to be the globally current one
        base.Update();
        current = originalCurrent;

        // Check for if legal selection
        if (currentSelectedGameObject.layer != playerLayer)
        {
            SetSelectedGameObject(lastSelectedGameObject);
        } else
        {
            lastSelectedGameObject = currentSelectedGameObject;
        }
    }
}
