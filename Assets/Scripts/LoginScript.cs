using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using NCMB;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour {
    public TMP_InputField Mail, Pass;
    public NotificationManager Notification;
    public LoadingScene LoadingScene;
    NCMBQuery<NCMBObject> Userquery = new NCMBQuery<NCMBObject> ("UserData");

    NCMBObject UserDataStore = new NCMBObject ("UserData");

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void Login () {
        Debug.Log (Mail.text);
        Debug.Log (Pass.text);
        NCMBUser.LogInWithMailAddressAsync (Mail.text, Pass.text, (NCMBException e) => {
            if (e != null) {
                Notification.OpenNotification ();
                UnityEngine.Debug.Log ("ログインに失敗: " + e.ErrorMessage);
            } else {
                NCMBUser current = NCMBUser.CurrentUser;
                Userquery.WhereEqualTo ("UserID", current.ObjectId);
                Userquery.FindAsync ((List<NCMBObject> objList, NCMBException e_userdata) => {
                    if (e_userdata != null) {
                        //検索失敗時の処理
                    } else {
                        if (objList.Count == 0) {
                            UserDataStore.Add ("MailAd", Mail.text);
                            UserDataStore.Add ("Pass", Pass.text);
                            UserDataStore.Add ("UserID", current.ObjectId);
                            UserDataStore.SaveAsync ();
                            PlayerPrefs.SetString ("MailAd", Mail.text);
                            PlayerPrefs.SetString ("Pass", Pass.text);
                        } else {
                            NCMBObject UserData = objList[0];
                            PlayerPrefs.SetString ("MailAd", (string) UserData["MailAd"]);
                            PlayerPrefs.SetString ("Pass", (string) UserData["Pass"]);
                        }
                    }
                });
                NCMBQuery<NCMBObject> BookMark = new NCMBQuery<NCMBObject> ("BookMark");

                BookMark.WhereEqualTo ("UserID", NCMBUser.CurrentUser.ObjectId);
                BookMark.FindAsync ((List<NCMBObject> objList, NCMBException er) => {
                    if (e != null) {
                        //検索失敗時の処理
                        Debug.Log ("bookmarkError");
                    } else {
                        if (objList.Count == 0) {
                            Debug.Log ("Unbookmarked");
                            NCMBObject bookobj = new NCMBObject ("BookMark");
                            bookobj.Add ("UserID", NCMBUser.CurrentUser.ObjectId);
                            List<string> List = new List<string>();
                            bookobj.Add ("Bookmarks", List);
                            bookobj.SaveAsync ();
                            return;
                        }
                    }
                });
                UnityEngine.Debug.Log ("ログインに成功！");
                //   testvoiddata();
                LoadingScene.LoadNextScene ("selection");
                //   SceneManager.LoadScene("selection");
            }
        });

    }

    public void Backtitle () {
        LoadingScene.LoadNextScene ("titlescean");
    }
}