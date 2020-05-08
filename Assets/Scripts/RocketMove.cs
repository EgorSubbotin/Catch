using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    Rigidbody2D myBody;
    float speed = 50f;
    public static Vector3 temp;
    public static bool startShoot;
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }    
    void Update()
    {
        myBody.AddForce(new Vector3(0f, speed, 0f));
        if (transform.position.y > 6)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            temp = transform.position;
            collision.gameObject.SetActive(false);        
            
            gameObject.SetActive(false);
            startShoot = true;
        }
    }    
}
