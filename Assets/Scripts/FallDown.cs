using System;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    public static float  fallSpeed = 3f;    
    void FixedUpdate()
    {
        fallSpeed += .001f;
        MovePlayer.speed += 0.001f;
        Vector3 movbom = transform.position;       
        if (transform.position.y < -5f)
        {            
            gameObject.SetActive(false);
             Player.countScore++;
        }   
        if (!Player.lose)
        {
            transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, (float)Math.Cos(movbom.y * 1.5f) * 10);
        }        
    }
}
