using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NCMB;
using Michsky.UI.ModernUIPack;
// using TwitterKit.Unity;
// using TwitterKit.Unity.Settings;

public class Login_Twitter : MonoBehaviour
{
    public string TWITTER_KEY, TWITTER_SECRET;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginWithTwitter()
    {
        // Debug.Log("TwitterLogin");
        // TwitterSettings.ConsumerKey = TWITTER_KEY;
        // TwitterSettings.ConsumerSecret = TWITTER_SECRET;
        // Twitter.Init();
        // var session = Twitter.Session;
        // if (session == null)
        // {
        //     //Twitterへログイン
        //     Twitter.LogIn(
        //     success =>
        //     {

        //         //認証用パラメータの作成
        //         NCMBTwitterParameters parameters = new NCMBTwitterParameters(
        //           success.id.ToString(),
        //           success.userName,
        //           TWITTER_KEY,
        //           TWITTER_SECRET,
        //           success.authToken.token,
        //           success.authToken.secret
        //         );

        //         NCMBUser user = new NCMBUser();
        //         user.AuthData = parameters.param;

        //         //ニフクラ mobile backendにログイン
        //         user.LogInWithAuthDataAsync((NCMBException e) =>
        //                 {
        //                     Debug.Log("login成功");
        //                 });
        //     });
        // }
    }
}
