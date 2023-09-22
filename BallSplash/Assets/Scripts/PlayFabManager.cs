using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement; 

public class PlayFabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Login(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError); 
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successfull Login!"); 
    }

    void OnError(PlayFabError resulterr)
    {
        Debug.Log("Failed to login :("); 
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "GameScore",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult res)
    {
        Debug.Log("Successfully sent leaderboard score!");
    }

    public void RegisterUser(string email, string password)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,  
            Password = password,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError); 
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult request)
    {
        Debug.Log("Successfully registered!");
        SceneManager.LoadScene("MainScene");
    }

    public void LoginUser(string email, string password)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = password
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Successfully login!");
        SceneManager.LoadScene("MainScene");
    }

    public void ResetPassword(string email)
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = email,
            TitleId = "981A0" //This is a unique identifier for our game in playfab
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError); 
    }

    private void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        Debug.Log("Successfully resetted the email");
    }
}
