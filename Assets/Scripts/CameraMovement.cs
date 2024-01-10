using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera's Target")]
    public Transform cameraTarget;

    // Update is called once per frame
    void Update()
    {
        // The camera will follow the player only in the x direction
        // after the player clears the x postion 0
        if (cameraTarget.position.x > 0)
        {
            this.transform.position = new Vector3(cameraTarget.position.x, 0 , -10);
        }
    }
}
