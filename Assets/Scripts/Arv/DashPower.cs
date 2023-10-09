using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPower : PowerUpItem
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void DashBoost()
    {
        if (rb == null)
        {
            rb = player.GetComponent<Rigidbody>();
            itemType = "Dash";
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector3.left * 500.0f);
                print("dashed left");
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * 500.0f);
                print("dashed right");
            }
        }
    }

    // Update is called once per frame

}
