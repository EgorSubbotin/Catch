using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseExplosions : MonoBehaviour
{
    List<GameObject> explosions;
   
    public Clone theExplode; 
    AudioSource soundExplod;

    void Start()
    {
        explosions = new List<GameObject>();
        soundExplod = GameObject.Find("Explosion").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (RocketMove.startShoot)
        {            
            StartCoroutine(LoseExplode());
        }
    }
    IEnumerator LoseExplode()
    {
        RocketMove.startShoot = false;
        GameObject newTheExplode = theExplode.GetClone();
        newTheExplode.transform.position = RocketMove.temp; 
        newTheExplode.SetActive(true);
        explosions.Add(GameObject.FindGameObjectWithTag("Explosion"));
        
        for (int i = 0; i < explosions.Count; i++)
        {
            if (explosions[i].activeInHierarchy)
            {
                soundExplod.Play();
                yield return new WaitForSeconds(.05f);
                explosions[i].SetActive(false);
                
            }
            
        }
    }
}
