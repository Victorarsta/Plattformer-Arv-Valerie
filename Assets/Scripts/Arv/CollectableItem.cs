using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : Item
{
    [SerializeField]
    int value;
    static Score score;
    // Start is called before the first frame update
    void Start()
    {
        if (score == null) //This looks for the object with the score code. But only one collectable item needs to find it.
        {
            score = GameObject.FindObjectOfType<Score>();
        }
    }

    public override void PickUp(Collider other) //New version of the pickup function. Changes the score before destroying the objects.
    {
        score.ChangeScore(value);
        base.PickUp(other);
    }
}
