using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{
    public Transform player;
    public float deadCameraZoneXaxis = 2.5f;
    public float cameraXpos;

    public float minX;
    public float maxX;

    // Use this for initialization
    void Start()
    {
        cameraXpos = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.position.x < -12.5)
        {

        }
        else
        {
            if (player.position.x > cameraXpos + deadCameraZoneXaxis)
            {
                transform.position = new Vector3(player.position.x - deadCameraZoneXaxis, transform.position.y, transform.position.z);
                cameraXpos = transform.position.x;
            }
            if (player.position.x < cameraXpos - deadCameraZoneXaxis)
            {
                transform.position = new Vector3(player.position.x + deadCameraZoneXaxis, transform.position.y, transform.position.z);
                cameraXpos = transform.position.x;
            }
        }


    }
}
