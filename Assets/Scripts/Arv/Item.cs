using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour //Abstract means that this code can't be added to objects. Only code that inherits from this code.
{
    public virtual void PickUp(Collider other)
    {
        Destroy(gameObject);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }
}
