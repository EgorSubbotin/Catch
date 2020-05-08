using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowThePlayer : MonoBehaviour
{
    public GameObject thePlayer;
        
    void FixedUpdate()
    {
        transform.position = thePlayer.transform.position;
    }
}
