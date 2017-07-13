using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchShizuka : MonoBehaviour {

    public Camera Camera;
    public Player Player;
    public TimeManager TimeKeeper;

    private void Start()
    {
        Camera = GetComponent<Camera>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }





        if (Time.timeScale == 1)
        { 
            if (Input.touchCount > 0)
            {


                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Stationary)
                    {
                       
                        Player.Jump();
                    }

                }
            }
        }
    }
}
