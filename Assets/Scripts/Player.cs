using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject panel;
    public Text score;
    public Text thelifePoint;
    public GameObject panelScore;
    public static int countScore;
    public static bool lose = false;   
    public GameObject deadPlayer;

    public Text highScore;
    public Text myScore;
   
    public SpownStuff theSpawnBombs;

    AudioSource soundLife;
    AudioSource oonooo;
    public static int lifePoint;

    void Awake()
    {
        lifePoint = 0;
        lose = false;
        soundLife = GameObject.Find("sound life").GetComponent<AudioSource>();
        oonooo = GameObject.Find("oonooo").GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        score.text = $"{countScore}";
        thelifePoint.text = $"{lifePoint}";
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            if (lifePoint == 0)
            {
                panelScore.SetActive(false);
                ShowScore();
                lose = true;

                gameObject.SetActive(false);
                Instantiate(deadPlayer, transform.position, transform.rotation);

                panel.SetActive(true);
                countScore = 0;
                theSpawnBombs.Exploses();
            }
            else if (lifePoint != 0)
            {
                lifePoint--;

                other.gameObject.SetActive(false);
                oonooo.Play();
                theSpawnBombs.NotDeadBombExplosion();
            }            
        }
        if (other.gameObject.tag == "life")
        {
            lifePoint++;
            countScore += 2;
            soundLife.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Time")
        {
            countScore += 3;
            soundLife.Play();
            FallDown.fallSpeed = 3f;
            SpownStuff.interval = .5f;
            MovePlayer.speed = 15f;
            other.gameObject.SetActive(false);
        }
    }
    void ShowScore()
    {
        if (countScore > GameController.instance.GetHighScore())
        {
            GameController.instance.SetHighScore(countScore);
        }
        highScore.text = $" {GameController.instance.GetHighScore()}";
        myScore.text = countScore.ToString();
        GameController.instance.SetMyScore(countScore);
        FallDown.fallSpeed = 3f;
        SpownStuff.interval = .5f;
        MovePlayer.speed = 15f;
    }

}
