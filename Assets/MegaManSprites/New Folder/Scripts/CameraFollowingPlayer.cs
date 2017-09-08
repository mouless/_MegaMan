using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{
    public Transform player;
    public float deadCameraZoneXaxis = 2.5f;
    public float cameraXpos;

    // Use this for initialization
    void Start()
    {
        cameraXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > cameraXpos + deadCameraZoneXaxis)
        {
            transform.position = new Vector3(player.position.x - deadCameraZoneXaxis, transform.position.y, transform.position.z);
        }
        if (player.position.x < cameraXpos - deadCameraZoneXaxis)
        {
            transform.position = new Vector3(player.position.x + deadCameraZoneXaxis, transform.position.y, transform.position.z);
        }
        cameraXpos = transform.position.x;
    }
}
