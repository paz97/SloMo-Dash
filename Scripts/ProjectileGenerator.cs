using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour {

    public ObjectPooler projectilePool;
    public ObjectPooler obstaclePool;
    public ObjectPooler groundParticlePool;
    GameObject Thing;



    public void SpawnProjectiles (Vector3 startPosition, int type)
    {
        //GameObject Proj_1 = projectilePool.GetPooledObject();
        //Proj_1.transform.position = startPosition;

        //if(Word)
        //    Proj_1.transform.localScale = new Vector3(3f, 3f);

        //else
        //    Proj_1.transform.localScale = new Vector3(1f, 1f);

        //Proj_1.SetActive(true);


        //GameObject Proj_2 = projectilePool.GetPooledObject();
        //Proj_2.transform.position = startPosition;
        //Proj_2.SetActive(true);

        //GameObject Proj_3 = projectilePool.GetPooledObject();
        //Proj_3.transform.position = startPosition;
        //Proj_3.SetActive(true);

        if (type == 1)
            Thing = obstaclePool.GetPooledObject();

        else if (type == 0)
            Thing = projectilePool.GetPooledObject();

        else if(type == 2)
            Thing = groundParticlePool.GetPooledObject();

        Thing.transform.position = startPosition;
        Thing.SetActive(true);


    }


}
