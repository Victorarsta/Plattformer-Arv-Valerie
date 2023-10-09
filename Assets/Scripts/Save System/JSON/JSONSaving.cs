using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONSaving : MonoBehaviour
{
    [SerializeField]
    Transform player;

    string path;

    
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/SaveJSON.Valerie"; //Path to the save file (note this is a different file from the binary formatter example.)
    }

    public void Save()
    {
        JSONSaveObject saveObject = new JSONSaveObject();
        saveObject.pos = player.position; //Saves the player position into the save object
        string jsonData = JsonUtility.ToJson(saveObject); //Converts the object and its values to a json string.
        File.WriteAllText(path, jsonData); //Writes the string to the save file
        
    }

    public void Load()
    {
        if (File.Exists(path))
        {
            string loadedData = File.ReadAllText(path); //Reads the file and copies all the text into a string
            JSONSaveObject saveObject = new JSONSaveObject();
            saveObject = JsonUtility.FromJson<JSONSaveObject>(loadedData);//Converts the string into a save object.
            player.position = saveObject.pos; //Changes the players position into the position from the save object.
        }
        else
        {
            Debug.LogError("No JSON file found");
        }
    }
}
