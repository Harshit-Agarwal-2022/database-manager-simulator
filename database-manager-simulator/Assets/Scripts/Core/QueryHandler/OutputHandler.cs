using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public string logHistory{ get; private set;} = ""; 

     private void Start()
    {
        inputField.onValueChanged.AddListener(OverrideInput); 
       
    }

     private void OverrideInput(string currentText)
    {
        inputField.text = logHistory;
        inputField.caretPosition = inputField.text.Length;
    }

    public void UpdateOutputText(string query ,string result)
    {
        logHistory += "query submitted: " + query + " result: " + result + "\n";
        inputField.text = logHistory;
    }

}
