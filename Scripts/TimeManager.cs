using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    private float slowdownFactor = 0.1f;
    private float slowdownLength = 0.5f;
    public float counter;



    private int trig = 1;
    private float slowFactor = 4f;
    private float newTimeScale;


   




    private void Start()
    {
        newTimeScale = Time.timeScale / slowFactor;
        Time.timeScale = 1;
    }


    void Update()
    {


        Time.fixedDeltaTime = Time.timeScale * 0.02f; //This line made everything function till now


        if (Time.timeScale < 1.0f)
           counter += Time.fixedDeltaTime;

       if (counter > slowdownLength)
       {
          Time.timeScale = 1.0f;
       //     //Time.fixedDeltaTime = 0.02f;
            //Time.maximumDeltaTime = 0.02f;
            counter = 0;

       }

        Debug.Log(counter + "Shit");

        //Time.fixedDeltaTime = Time.timeScale * .02f;
        //Time.maximumDeltaTime = Time.maximumDeltaTime * 0.02f;
        //Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        //if (trig == 2)
        //{
        //    if (Time.timeScale == 1.0f)
        //    {
        //        //assign the 'newTimeScale' to the current 'timeScale'  
        //        Time.timeScale = newTimeScale;
        //        //proportionally reduce the 'fixedDeltaTime', so that the Rigidbody simulation can react correctly  
        //        Time.fixedDeltaTime = Time.fixedDeltaTime /slowFactor;
        //        //The maximum amount of time of a single frame  
        //        Time.maximumDeltaTime = Time.maximumDeltaTime /slowFactor;
        //    }
        //    else if(Time.timeScale == newTimeScale) //the game is running in slow motion  
        //    {
        //        //reset the values  
        //        Time.timeScale = 1.0f;
        //        Time.fixedDeltaTime = Time.fixedDeltaTime * slowFactor;
        //        Time.maximumDeltaTime = Time.maximumDeltaTime * slowFactor;
        //    }
        //    trig = 1;
        //}





    }


    public void DoSlow()
    {
        Time.timeScale = slowdownFactor;
        counter = 0f;
        //Debug.Log("Slow Called");
    }
}
