using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public RectTransform healthbar;

    public static int maxhealth = 100;

    public int currenthealth = maxhealth;
	

    public void TakeDammage(int ammount)
    {
        currenthealth -= ammount;
        if(currenthealth<=0)
        {
            Destroy(gameObject);
        }

        healthbar.sizeDelta = new Vector2(currenthealth * 5/2, healthbar.sizeDelta.y);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
