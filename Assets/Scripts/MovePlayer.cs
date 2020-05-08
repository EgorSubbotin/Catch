
using System;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    public static float speed = 15f;
    float moveX2 = 0f;

    void OnMouseDrag()
    {
        if (!Player.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float x = mousePos.x;
            float y = mousePos.y;
            if (x > 2.3f) x = 2.3f;
            if (x < -2.3f) x = -2.3f;
            if (y > Math.Sqrt(Math.Abs(Math.Pow(15.65f, 2) - Math.Pow(x - 4.08f, 2))) - 18.84f) y = (float)Math.Sqrt(Math.Abs(Math.Pow(15.65f, 2) - Math.Pow(x - 4.08f, 2))) - 17.1f;
            if (y < Math.Sqrt(Math.Abs(Math.Pow(15.65f, 2) - Math.Pow(x - 4.08f, 2))) - 18.84f) y = (float)Math.Sqrt(Math.Abs(Math.Pow(15.65f, 2) - Math.Pow(x - 4.08f, 2))) - 17.1f;
                
            player.position = Vector2.MoveTowards(player.position, new Vector2(x, y), speed * Time.deltaTime);
            player.localScale = Vector2.MoveTowards(player.localScale, new Vector2((10 - x / 1.8f) / 11.1f, (10 - x / 1.8f) / 11.1f), speed * Time.deltaTime / 10);

            float moveX1 = Input.mousePosition.x;
            if (moveX1< moveX2)
            {
                player.rotation = Quaternion.Euler(0, 0, 18 - (5 / 2.2f * x));
            }
            if (moveX1 > moveX2)
            {
                player.rotation = Quaternion.Euler(0, 180, (5 / 2.2f * x) - 18);
            }
            moveX2 = Input.mousePosition.x;
            
        }
    }
}
