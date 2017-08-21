using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public GameObject player;
    public float smoothing = 5f;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = player.transform.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
