using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera's Target")]
    public Transform cameraTarget;

    // Camera smoothing
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        // The camera will follow the player only in the x direction
        // after the player clears the x postion 0
        if (cameraTarget.position.x > 0)
        {
            Vector3 cameraTargetPosition = new Vector3(cameraTarget.position.x + offset.x, 0f, offset.z);

            transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref velocity, smoothTime);
        }
        else
        {
            Vector3 cameraTargetPosition = new Vector3(0 + offset.x, 0f, offset.z);

            transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref velocity, smoothTime);
        }
    }
}
