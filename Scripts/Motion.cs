using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour {


    float speedReg = -5f;
    float speedSlow = -1f;
    Vector3 velocity;
	
	// Update is called once per frame
	void Update () {

        if(Time.timeScale == 1.0f)
            velocity.x = speedReg;

        else
            velocity.x = speedSlow;





        transform.Translate(velocity * Time.deltaTime);
	}

    
}
