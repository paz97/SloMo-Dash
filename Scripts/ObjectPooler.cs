using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {


    public GameObject pooledObject;
    public int pooledAmount;
    List<GameObject> pooledObjects;


	void Start () {

        pooledObjects = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject Object = (GameObject)Instantiate(pooledObject);
            Object.SetActive(false);
            pooledObjects.Add(Object);
        }
	}
	
	
	public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject Object = (GameObject)Instantiate(pooledObject);
        Object.SetActive(false);
        pooledObjects.Add(Object);
        return Object;

    }
}
