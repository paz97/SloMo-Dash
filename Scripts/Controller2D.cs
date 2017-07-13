using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;


[RequireComponent (typeof (BoxCollider2D))]
public class Controller2D : MonoBehaviour {

    public LayerMask collisionMask;
    public LayerMask Destroyer;

    const float skinWidth = .010f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    BoxCollider2D Collider;
    RaycastOrigins raycastOrigins;
    public CollisionInfo Collisions;
    public TimeManager TimeKeeper;

    public AudioSource Audio;
    private int hiScore;
 


    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
        hiScore = PlayerPrefs.GetInt("hiScore", 0);
    }

    void UpdateRaycastOrigins()
    {
        Bounds Bounds = Collider.bounds;
        Bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(Bounds.min.x, Bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(Bounds.max.x, Bounds.min.y);
        raycastOrigins.topLeft = new Vector2(Bounds.min.x, Bounds.max.y);
        raycastOrigins.topRight = new Vector2(Bounds.max.x, Bounds.max.y);

    }


    public void Move(Vector3 velocity)
    {
        UpdateRaycastOrigins();
        Collisions.Reset();

        if (velocity.x != 0)
            HorizontalCollisions(ref velocity);

        if (velocity.y != 0)
            VerticalCollisions(ref velocity);

        
        transform.Translate(velocity);

        //if (i == 1)
         //   TimeKeeper.DoSlow();
    }

    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;



        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D Hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);


            //This is my code to destroy the object on detection of the destroyer !!
            RaycastHit2D deathHit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, Destroyer);

            if (deathHit)
            {
                if (deathHit.distance == 0)
                {
                    Debug.Log("Dead" + Time.fixedTime);
                    Audio.Play();
                    Time.timeScale = 0;
                    //yield return new WaitForSecondsRealtime(Audio.clip.length);
                    //
                    hiScore = PlayerPrefs.GetInt("hiScore", 0);

                    if (Social.localUser.authenticated)
                        Social.ReportScore(hiScore, SloMoResources.leaderboard_high_score, (bool success) => { });

                    Wait();
                    SceneManager.LoadScene(2);
                }
                
            }

            //  Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.up * -2, Color.red);
            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

            if (Hit)
            {
                velocity.x = (Hit.distance - skinWidth) * directionX;
                rayLength = Hit.distance;

                Collisions.left = directionX == -1;
                Collisions.right = directionX == 1;
            }
        }
    }

    
    void VerticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign (velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;



        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D Hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            RaycastHit2D deathHit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, Destroyer);

            if (deathHit)
            {
                if (deathHit.distance == 0)
                {
                    Debug.Log("Dead" + Time.fixedTime);
                    Audio.Play();
                    Time.timeScale = 0;
                    //yield return new WaitForSecondsRealtime(Audio.clip.length);
                    //SceneManager.LoadScene(2);
                    hiScore = PlayerPrefs.GetInt("hiScore", 0);

                    if (Social.localUser.authenticated)
                        Social.ReportScore(hiScore, SloMoResources.leaderboard_high_score, (bool success) => { });
                    Wait();
                    SceneManager.LoadScene(2);
                }
            }

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

            if (Hit)
            {
                velocity.y = (Hit.distance - skinWidth) * directionY;
                rayLength = Hit.distance;

                Collisions.below = directionY == -1;
                Collisions.above = directionY == 1;

            }
        }
    }

    void CalculateRaySpacing()
    {
        Bounds Bounds = Collider.bounds;
        Bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = Bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = Bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(Audio.clip.length);
       // SceneManager.LoadScene(2);

    }
}
