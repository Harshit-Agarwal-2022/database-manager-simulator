using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_InputField inputField; 
    [SerializeField] private SQLSimulator sqlSimulator; 

    [SerializeField] private OutputHandler outputHandler;

    private void Start()
    {
        inputField.onSubmit.AddListener(SubmitQueryOnEnter);
    }

    public void OnSubmitQuery()
    {
        string query = inputField.text;
        inputField.Select();
        inputField.text = "";  
        string result = sqlSimulator.ProcessQuery(query);
        outputHandler.UpdateOutputText(query, result);
    }


    private void SubmitQueryOnEnter(string query)
    {
        OnSubmitQuery();
        inputField.text = "";
    }

    private void OnDestroy()
    {
        inputField.onSubmit.RemoveListener(SubmitQueryOnEnter);
    }
}
