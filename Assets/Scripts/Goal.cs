using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameObject levelEndMenu; //The menu that appears when the level is complete.

    private void Start()
    {
        levelEndMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelEndMenu.SetActive(true);
        }
    }
}
