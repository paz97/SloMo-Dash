using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Controller2D thePlayer;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    //void Awake()
    //{
    //    Application.targetFrameRate = 45;
    //}

    void Start () {

        thePlayer = FindObjectOfType<Controller2D>();
        lastPlayerPosition = thePlayer.transform.position;
    }
	

	void LateUpdate () {

        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;


	}
}
