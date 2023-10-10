using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpItem : Item//Another abstract class like Item.
{
    [SerializeField] public string itemType;
    private bool hasGivenDuration = false;

    [SerializeField]
    protected float duration;

    bool countdown = false;
    
    protected GameObject player; //A references to the player that is public to classes that inherit from PowerUpItem.

    // Update is called once per frame

    public virtual void Update()
    {
        if (countdown)
        {
            if (!hasGivenDuration)
            {
                if (itemType == "Fire")
                {
                    duration = 10.0f;
                }
                if (itemType == "Dash")
                {
                    duration = 15.0f;
                }
                hasGivenDuration = true;
            }
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
