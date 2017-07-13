using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;


    public ObjectPooler theObjectPool;

    private ProjectileGenerator theProjectileGenerator;
    private float projectileHeight;
    private int randomNess;
    bool Word;

    private float obstacleDist;
    private float time;

	
	void Start () {

       

        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().bounds.size.x;
        platformWidth = thePlatform.transform.localScale.x;

        //Debug.Log(platformWidth);

        theProjectileGenerator = FindObjectOfType<ProjectileGenerator>();
	}
	
	
	void Update () {

        time += Time.smoothDeltaTime;

		if(transform.position.x < generationPoint.position.x)
        {
            // transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Debug.Log(transform.position.y);

            //Instantiate(thePlatform, transform.position, transform.rotation); 
            GameObject newPlatform = theObjectPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            randomNess = Random.Range(0, 3);

            if (randomNess == 0)
            {
                projectileHeight = 0.5f;
                
            }
            else if(randomNess == 1)
            {
                projectileHeight = 10f;
                
            }
            else
                projectileHeight = -0.5f;

            if (time <= 60)
                obstacleDist = 100;

            else if (time <= 90)
                obstacleDist = 120;

            else
                obstacleDist = 150;


            theProjectileGenerator.SpawnProjectiles(new Vector3(transform.position.x + obstacleDist, projectileHeight, transform.position.z), randomNess);

        }
	}
}
