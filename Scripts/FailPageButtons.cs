using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class FailPageButtons : MonoBehaviour {


    public GameObject window;
    private int hiScore;

    private void Start()
    {
        if (Social.localUser.authenticated)
        {
            hiScore = PlayerPrefs.GetInt("hiScore", 0);
            Social.ReportScore(hiScore, SloMoResources.leaderboard_high_score, (bool success) => { });

            if (hiScore >= 100)
                Social.ReportProgress(SloMoResources.achievement_rapid_100, 100, (bool success) => { });

            if (hiScore >= 200)
                Social.ReportProgress(SloMoResources.achievement_cracking_200, 100, (bool success) => { });

            if (hiScore >= 300)
                Social.ReportProgress(SloMoResources.achievement_trippy_300, 100, (bool success) => { });

            if (hiScore >= 400)
                Social.ReportProgress(SloMoResources.achievement_quadrangle, 100, (bool success) => { });

            if (hiScore >= 1000)
                Social.ReportProgress(SloMoResources.achievement_slow_down_buddy_, 100, (bool success) => { });
        }
    }




    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            window.SetActive(true);
        }
    }

    public void Leaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            window.SetActive(true);
        }
    }

}
