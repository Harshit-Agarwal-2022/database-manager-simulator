using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : ClickableObject
{
    public Action OnClick;

    [SerializeField] private GameObject noteUI;

    private void OnEnable() 
    {
        OnClick += ShowNote;
    }

    private void OnDisable() 
    {
        OnClick -= ShowNote;
        
    }

    protected override void ClickHandler()
    {
        Debug.Log(gameObject.name + " was clicked");
        OnClick?.Invoke();
    }

    private void ShowNote()
    {
        noteUI.SetActive(true);
    }
}
