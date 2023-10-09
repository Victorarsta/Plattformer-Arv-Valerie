using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour, IInteractable
{
    [SerializeField]
    float shonenJump;//The force of the jump pad.
    public void Interact(GameObject interactor)
    {
        interactor.GetComponent<Rigidbody>().AddForce(transform.up * shonenJump);
    }
}
