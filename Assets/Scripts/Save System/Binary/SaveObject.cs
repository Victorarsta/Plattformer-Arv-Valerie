using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//This is needed to use [Serializable]

[Serializable]
public class SaveObject
{
    public int score; //What should be saved. Can be more than one thing but not "advanced" stuff like gameobjects or components.
}
