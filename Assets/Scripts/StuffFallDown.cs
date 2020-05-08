using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffFallDown : MonoBehaviour
{
    float fallSpeed_1 = FallDown.fallSpeed;
    void FixedUpdate()
    {
        Vector3 movbom = transform.position;
        if (transform.position.y < -5f)
        {
            gameObject.SetActive(false);           
        }
        if (!Player.lose)
        {
            transform.position -= new Vector3(0, fallSpeed_1 * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, (float)Math.Cos(movbom.y * 1.5f) * 10);
        }
    }
}
