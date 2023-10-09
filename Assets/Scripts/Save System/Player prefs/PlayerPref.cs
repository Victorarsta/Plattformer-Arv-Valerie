using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPref : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;

    string savedText = "";

    // Start is called before the first frame update
    void Start()
    {
        savedText = PlayerPrefs.GetString("savedText", ""); //Gets the value from the slot "savedText" (Doesn't have to be the same name as the variable). If no slot is found, it set the value of "". 
        inputField.text = savedText;

    }

    public void SaveString(string value)
    {
        print(value);
        savedText = value;
        PlayerPrefs.SetString("savedText", savedText); //saves the variable savedText in the slot named savedText.
    }
}
