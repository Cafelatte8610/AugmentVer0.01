using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using NCMB;
using TMPro;
using Michsky.UI.ModernUIPack;
public class Usersettings : MonoBehaviour
{
    public TextMeshProUGUI Mail, Pass;
    public LoadingScene LoadingScene;
    public TextMeshProUGUI box_name;

    void Start()
    {
        Mail.text = "Mail : " + PlayerPrefs.GetString("MailAd", "Null");
        string PassAs = new System.String('*', PlayerPrefs.GetString("Pass", "Null").Length);
        Pass.text = "PassWard : " + PassAs;
        box_name.rectTransform.sizeDelta = new Vector2(box_name.preferredWidth, box_name.preferredHeight);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void logout()
    {
        try
        {
            NCMBUser.LogOutAsync();
        }
        catch (NCMBException e)
        {
            UnityEngine.Debug.Log("エラー: " + e.ErrorMessage);
        }
        LoadingScene.LoadNextScene("SignScenes");
    }

    public void ViewPass()
    {
        if (Pass.text[11] == '*')
        {
            Pass.text = "PassWard : " + PlayerPrefs.GetString("Pass", "Null");
        }
        else
        {
            string PassAs = new System.String('*', PlayerPrefs.GetString("Pass", "Null").Length);
            Pass.text = "PassWard : " + PassAs;
        }
        box_name.rectTransform.sizeDelta = new Vector2(box_name.preferredWidth, box_name.preferredHeight);
    }

    public void backselect()
    {
        LoadingScene.LoadNextScene("selection");
    }

    public void ResetPass()
    {
        NCMBUser.RequestPasswordResetAsync(Pass.text, (error) =>
        {
            if (error != null)
            {
                // エラー処理
            }
            else
            {
                LoadingScene.LoadNextScene("SignScenes");
            }
        });
    }
}
