using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public RectTransform healthbar;

    public static int maxhealth = 100;

    [SyncVar (hook = "OnChangeHealth")] public int currenthealth = maxhealth;



    public void TakeDammage(int ammount)
    {
        if(!isServer)
        {
            return;
        }


        currenthealth -= ammount;
        if(currenthealth<=0)
        {
            Destroy(gameObject);
        }

    }
	void OnChangeHealth (int health) {
        healthbar.sizeDelta = new Vector2(health * 5 / 2, healthbar.sizeDelta.y);
    }
}
