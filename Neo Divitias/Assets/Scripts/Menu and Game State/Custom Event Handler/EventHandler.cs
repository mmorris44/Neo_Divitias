using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Custom event handler to manage two players in one menu at once
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
        // Do not assign EventSystem.current
        base.OnEnable();
    }

    protected override void Update()
    {
        EventSystem originalCurrent = EventSystem.current;
        
        // In order to avoid reimplementing half of the EventSystem class, just temporarily assign this EventSystem to be the globally current one
        current = this; 
        base.Update();
        current = originalCurrent;

        // Check for if legal selection for player number, moving to previous selection if not
        if (currentSelectedGameObject.layer != playerLayer)
        {
            SetSelectedGameObject(lastSelectedGameObject);
        } else
        {
            lastSelectedGameObject = currentSelectedGameObject;
        }
    }
}
