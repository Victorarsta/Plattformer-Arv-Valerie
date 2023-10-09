using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    GameObject textPrompt;
    [SerializeField]
    LayerMask mask;
    [SerializeField, Range(1,10)]
    float colliderSize = 1;

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(colliderSize, colliderSize, colliderSize), Quaternion.identity, mask);
        if (colliders.Length > 0)
        {
            textPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].GetComponent<IInteractable>().Interact(gameObject);
                }
            }
        }
        else
        {
            textPrompt.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, new Vector3(colliderSize, colliderSize, colliderSize));
    }
}
