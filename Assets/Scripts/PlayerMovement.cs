using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveForce = 25;
    [SerializeField]
    float jumpForce = 300;
    [SerializeField, Range(1,10)]
    float maxVelocity;
    [SerializeField]
    LayerMask groundMask;

    Rigidbody rb;

    float inputX;
    float inputY;
    bool hasJumped = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs( rb.velocity.x) < maxVelocity)
        {
            rb.AddForce(transform.right * inputX * moveForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (!hasJumped && inputY > 0.1f) //If player hasn't jumped and Up/W is pressed then jump.
        {
            rb.AddForce(transform.up * jumpForce);
            hasJumped = true;
        } else if (Physics.CheckBox(transform.position - transform.up, new Vector3(0.25f, 0.25f, 0.25f), Quaternion.identity, groundMask)) //Kollar en kub under spelaren och letar kollar om man är på marken.
        {
            hasJumped = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position - transform.up, new Vector3(0.25f, 0.25f, 0.25f)); //Ritar ground check kuben när spelaren är selected. För debug.
    }

}
