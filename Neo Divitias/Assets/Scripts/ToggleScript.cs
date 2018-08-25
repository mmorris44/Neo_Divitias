using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleScript : MonoBehaviour {

    private UnityEngine.UI.Toggle toggle;

    private void Start(){
        TextMeshProUGUI mText = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        string item_name = gameObject.name;

        mText.text = string.Format("{0}", GameState.player_one.Equipment[item_name.ToLower()]);
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn){
        UnityEngine.UI.ColorBlock cb = toggle.colors;
        if (isOn){
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.gray;
        }
        else{
            cb.normalColor = Color.green;
            cb.highlightedColor = Color.green;
        }
        toggle.colors = cb;
    }
}



