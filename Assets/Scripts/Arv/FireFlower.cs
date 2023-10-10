using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlower : PowerUpItem
{
    [SerializeField]
    Rigidbody fireBall;

    Rigidbody playerRB;

    public override void PowerUp()
    {
        if (playerRB == null)
        {
            playerRB = player.GetComponent<Rigidbody>();
            itemType = "Fire";
            duration = 10.0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody temp = Instantiate(fireBall, player.transform.position, Quaternion.identity);
            temp.AddForce((playerRB.velocity.x < 0f ? -Vector3.right : Vector3.right) *500); //Adds a force to the fireball to the left or right depending on the players velocity.
        }
    }
}
