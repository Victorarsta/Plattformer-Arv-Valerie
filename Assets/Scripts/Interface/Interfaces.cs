using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDestructable
{
    void Destroy();
}

interface IInteractable
{
    void Interact(GameObject interactor);
}