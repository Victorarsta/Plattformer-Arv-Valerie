using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IInteractable
{
    [SerializeField]
    Teleport LinkedTeleport;
    public void Interact(GameObject interactor)
    {
        interactor.transform.position = LinkedTeleport.transform.position;
    }

}
