﻿using UnityEngine.Networking;

public class CarController : NetworkBehaviour
{
    private float speed = 30f;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
    }

    private void Update()
    {

    }

    //[Command]
    //public void CmdMove()
    //{
    //    moveX = x;
    //    moveY = y;
    //}
}
