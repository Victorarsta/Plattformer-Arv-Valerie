using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    Transform target; //What the camera will follow.
    [SerializeField]
    float smoothTime = 0.9f;

    Vector3 offset;
    Vector3 curSpeed; //Saves the current movement speed of the camera.

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref curSpeed, smoothTime);
    }
}
