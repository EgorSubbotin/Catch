using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownStuff : MonoBehaviour
{
    public Clone bomb;
    public Clone life;
    public Clone time; 
    public Clone explosion;
    Clone randomStuff;
    public static float interval = .5f;
    FallDown[] bombsList;

    public Transform thePlayer; 
    AudioSource soundExplod;
    void Start()
    {
        StartCoroutine(Spawn());
        soundExplod = GameObject.Find("Explosion").GetComponent<AudioSource>();
    }
    IEnumerator Spawn()
    {
        while (!Player.lose)
        {
            float ran2 = Random.Range(1, 102);
            if (ran2 < 100 && ran2 > 95)
                randomStuff = life;
            else if (ran2 > 100)
                randomStuff = time;
            else randomStuff = bomb;

            if (interval > .1)
                interval -= .003f;

            GameObject newStuff = randomStuff.GetClone();
            newStuff.transform.position = new Vector2(Random.Range(-2.5f, 2.5f), 5.9f);
            newStuff.transform.rotation = Quaternion.identity;
            newStuff.SetActive(true);
           yield return new WaitForSeconds(interval);
        }
    }

    public void Exploses()
    {
        StartCoroutine(Exp());
    }
    IEnumerator Exp()
    {
        bombsList = FindObjectsOfType<FallDown>();

        for (int i = bombsList.Length - 1; i > -1; i--)
        {
            bombsList[i].gameObject.SetActive(false);
            GameObject newExplosion = explosion.GetClone();
            newExplosion.transform.position = bombsList[i].gameObject.transform.position;
            newExplosion.SetActive(true);
            soundExplod.Play();
            yield return new WaitForSeconds(.2f);            
        }
    }
    public void NotDeadBombExplosion()
    {
        StartCoroutine(Exp2());
    }
    IEnumerator Exp2()
    {
        GameObject newExplosion = explosion.GetClone();
        newExplosion.transform.position = thePlayer.position;
        newExplosion.SetActive(true);
        soundExplod.Play();
        yield return new WaitForSeconds(.1f);
        newExplosion.SetActive(false);

    }
}
