using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject clone;
    public float min=10;
    List<GameObject> clones;
    private void Start()
    {
        clones = new List<GameObject>();
        for (int i = 0; i < min; i++)
        {
            GameObject obj = Instantiate(clone, transform.position, Quaternion.identity);
            obj.SetActive(false);
            clones.Add(obj);
        }
    }
    public GameObject GetClone()
    {
        for(int i =0; i<clones.Count; i++)
        {
            if (!clones[i].activeInHierarchy)
                return clones[i];
        }
        GameObject obj = Instantiate(clone, transform.position, Quaternion.identity);
        obj.SetActive(false);
        clones.Add(obj);
        return obj;
    }
}
