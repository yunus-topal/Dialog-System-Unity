using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonSelectionHelper : MonoBehaviour
{
    [SerializeField] private bool useDefaultEvents = true;
    [SerializeField] private Color selectedColor = Color.green;
    [SerializeField] private Color deselectedColor = Color.white;
    
    public void OnSelected() {
        GetComponent<Image>().color = selectedColor;
    }
    
    public void OnDeselected() {
        GetComponent<Image>().color = deselectedColor;
    }
}
