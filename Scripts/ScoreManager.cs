using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    private float pointsPerSecond;
    public int score;

    public float time;
    public int hiScore;
    private bool countScore;

	void Start () {
        pointsPerSecond = 1;
        countScore = true;
        hiScore =  PlayerPrefs.GetInt("hiScore", 0);
    }
	
	
	void Update () {

       // if (countScore)
       // {
            time += Time.smoothDeltaTime;
            score = (int)time;

            scoreText.text = score + "s";

            if(score > hiScore)
            {
                hiScore = score;
                PlayerPrefs.SetInt("hiScore", hiScore);
            }
       // }
        hiScoreText.text = "High Score: " + hiScore;
	}

    //private void OnApplicationFocus(bool focus)
    //{
    //    countScore = focus;
    //}

    private void OnApplicationPause(bool pause)
    {
        countScore = !pause;
    }

}
