using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerID : NetworkBehaviour
{

    [SyncVar]
    public NetworkInstanceId playerNetID;
    private Transform myTransform;
    [SyncVar] public string playerUniqueID;

    public override void OnStartLocalPlayer()
    {
        playerNetID = GetComponent<NetworkIdentity>().netId;
        playerUniqueID = playerNetID.ToString();
    }
}