using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpItem : Item//Another abstract class like Item.
{
    [SerializeField]
    float duration = 5;

    bool countdown = false;
    
    protected GameObject player; //A references to the player that is public to classes that inherit from PowerUpItem.

    // Update is called once per frame
    public virtual void Update()
    {
        if (countdown)
        {
            duration -= Time.deltaTime;
            if (duration > 0)
            {
                PowerUp();
            }
            else
            {
                StopPower();
            }
        }
    }

    public override void PickUp(Collider other)
    {
        player = other.gameObject;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        countdown = true;
    }

    public virtual void PowerUp()
    {

    }

    public virtual void StopPower()
    {
        Destroy(gameObject);
    }
}
