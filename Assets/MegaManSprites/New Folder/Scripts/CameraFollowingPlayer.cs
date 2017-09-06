using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{
    public Transform player;
    public float deadCameraZone = 2.5f;
    public float cameraXpos;

    // Use this for initialization
    void Start()
    {
        cameraXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > cameraXpos + deadCameraZone)
        {
            transform.position = new Vector3(player.position.x - deadCameraZone, transform.position.y, transform.position.z);
        }
        if (player.position.x < cameraXpos - deadCameraZone)
        {
            transform.position = new Vector3(player.position.x + deadCameraZone, transform.position.y, transform.position.z);
        }
        cameraXpos = transform.position.x;
    }
}
