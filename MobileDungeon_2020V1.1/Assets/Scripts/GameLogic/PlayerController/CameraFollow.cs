using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 12, -25);
    void Update()
    {
        if (SetupLocalPlayer.player!=null)
        {
            this.transform.position = SetupLocalPlayer.player.position + offset;
            this.transform.LookAt(SetupLocalPlayer.player.position, Vector3.up);
        }

    }
}
