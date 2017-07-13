using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuManager : MonoBehaviour
{

    public bool IsConnectedToGoogleServices { set; get; }
    public GameObject window;

    void Start()
    {
        PlayGamesPlatform.Activate();

        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                IsConnectedToGoogleServices = success;
            });
        }

        
    }





    public bool ConnectToGoogleServices()
    {
        if (!IsConnectedToGoogleServices)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                IsConnectedToGoogleServices = success;
            });
        }

        return IsConnectedToGoogleServices;
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
        if(Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            window.SetActive(true);
        }
    }




}
