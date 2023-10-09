using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; //This is important.
using System.IO; //This is also important.

public class BinarySaving : MonoBehaviour
{
    [SerializeField]
    Score scoreObject;

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter(); //Creates a formatter that will be used later.
        FileStream file = File.Create(Application.persistentDataPath + "/Save.Valerie"); //Creates or overwrites a file called "Save.Valerie" at a determined position.
        SaveObject saveObject = new SaveObject(); //Creates an new empty instance of the saveobject.
        
        saveObject.score = scoreObject.GetScore(); //Save the score into the saveobject.

        formatter.Serialize(file, saveObject); //Write the saveObject onto the file and "scramble" it.
        file.Close(); //Closes the file so nothing more is written.

    }

    public void Load()
    {
        BinaryFormatter formatter = new BinaryFormatter(); //Creates a formatter that will be used later.
        FileStream file = File.Open(Application.persistentDataPath + "/Save.Valerie", FileMode.Open); //Tries to find the save file and open it.
        if (file != null) //If a save file is found.
        {
            SaveObject saveObject = new SaveObject();//Creates an new empty instance of the saveobject.

            saveObject = (SaveObject)formatter.Deserialize(file); //Deserializes the content of the file and sets it to the saveobject.
            scoreObject.score = saveObject.score; //Sets the game score to the score from the save file.

            file.Close(); //Closes the file.
        }
        else //If a save file is not found.
        {
            Debug.LogError("Save file not found!");
        } 
    }

}
