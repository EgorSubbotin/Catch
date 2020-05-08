using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Clone rocket;
    public Transform pointShoot;
   
    public void Shoote()
    {          
        GameObject newRocket = rocket.GetClone();
        newRocket.transform.position = pointShoot.position;
        newRocket.transform.rotation = Quaternion.Euler(0,0,0);
        newRocket.SetActive(true);
    }
}
