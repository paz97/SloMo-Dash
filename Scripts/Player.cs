using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {


    public float jumpHeight = 5;
    public float timeToApex = 0.4f;
    float accelerationTimeAirborne = .05f;
    float accelerationTimeGrounded = .2f;


    float moveSpeed = 50;
    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D Controller;
    public Animation Animation;

    public TimeManager timeManager;
    private float time;
    private float minSpeed;
    private float maxSpeed;
    private float targetVelocityX;
    private float slowFactor = 4f;
    private float newTimeScale;

    public Sprite Moving;
    public Sprite Jump_;


    

    void Start()
    {
        Controller = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToApex;
        // Animation = GetComponent<Animation>();
        minSpeed = 30f;
        maxSpeed = 105f;
        newTimeScale = Time.timeScale / slowFactor;

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Moving;

    }

    void FixedUpdate()
    {

        if(Time.timeScale == 1)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Moving;



        time += Time.deltaTime;

        float targetVelocityX = time;
        targetVelocityX = Mathf.Clamp(targetVelocityX, minSpeed, maxSpeed);

        float speed = 105;


        //velocity.x = time;
        //velocity.x = Mathf.Clamp(velocity.x, minSpeed, maxSpeed);


        if (Controller.Collisions.above || Controller.Collisions.below)
            velocity.y = 0;


        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //if (Input.GetKeyDown(KeyCode.Space) && Controller.Collisions.below)
        //{
        //    velocity.y = jumpVelocity;
        //    timeManager.DoSlow();
        ////    //Animation.Play(Animation.clip.name, PlayMode.StopSameLayer);
        //}




        //float targetVelocityX = input.x * moveSpeed;     
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (Controller.Collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);


        velocity.y += gravity * Time.smoothDeltaTime;


        //Controller.Move(velocity * Time.fixedDeltaTime);

        //Jump(1);

        if (Input.GetKeyDown(KeyCode.Space) && Controller.Collisions.below)
        {
            velocity.y = jumpVelocity;
            timeManager.DoSlow();
            Controller.Move(velocity * Time.smoothDeltaTime);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Jump_;
            //Jump();
        }

        //else
        //    Move();
        Controller.Move(velocity * Time.fixedDeltaTime);
    }


    


    public void Jump()
    {
        //if (i == 1)
        //{
        //    //if (Input.GetKeyDown(KeyCode.Space) && Controller.Collisions.below)
        //    //{
        //        velocity.y = jumpVelocity;
        //       // timeManager.DoSlow();
        //    //}
        //}

        //else
        //{
        //    if (Controller.Collisions.below)
        //    {
        //        velocity.y = jumpVelocity;
        //       // timeManager.DoSlow();
        //    }
        //}

        if (Controller.Collisions.below)
        {
            velocity.y = jumpVelocity;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Jump_;
            //velocity.x = 0;
        }

        timeManager.DoSlow();
        Controller.Move(velocity * Time.smoothDeltaTime);
        
    }

    public void Move()
    {
        Controller.Move(velocity * Time.smoothDeltaTime);
    }
}
