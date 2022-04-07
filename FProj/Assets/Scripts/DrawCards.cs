using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

public class DrawCards : MonoBehaviour
{
    public PlayerManager PlayerManager;
    

    public void OnClick()
    {
        NetworkIdentity nerworkIdentity = NetworkClient.connection.identity;
        PlayerManager = nerworkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdDealCards();
    }


    
}
