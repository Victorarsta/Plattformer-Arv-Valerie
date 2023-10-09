using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    int bounces = 3;
    float duration = 5;
    float colliderRadius = 2;
    [SerializeField]
    LayerMask mask;

    private void Start()
    {
        colliderRadius = gameObject.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (bounces <= 0 || duration <= 0)
        {
            Destroy(gameObject);
        }
        Collider[] colliders = Physics.OverlapSphere(transform.position, colliderRadius, mask);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].GetComponent<IInteractable>() != null)
                {
                    colliders[i].GetComponent<IInteractable>().Interact(gameObject);
                }
                if (colliders[i].GetComponent<IDestructable>() != null)
                {
                    colliders[i].GetComponent<IDestructable>().Destroy();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounces--;
    }
}
