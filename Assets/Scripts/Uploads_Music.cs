using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NCMB;
using TMPro;
using Michsky.UI.ModernUIPack;

public class Uploads_Music : MonoBehaviour
{
    public ModalWindowManager Modal;
    public Toggle toggle;
    public GameObject prefab;
    public GameObject NodeParent, parent_obj;
    public LoadingScene LoadingScene;

    // Start is called before the first frame update
    NCMBUser User = new NCMBUser();
    NCMBQuery<NCMBObject> DataStore = new NCMBQuery<NCMBObject>("MusicData");
    NCMBObject DeleteData = new NCMBObject("MusicData");
    void Start()
    {
        if (NCMBUser.CurrentUser == null)
        {
            SceneManager.LoadScene("SignScenes");
        }
        else
        {
            Debug.Log("ログイン中のユーザー: " + NCMBUser.CurrentUser.UserName);
            User = NCMBUser.CurrentUser;
            find_Uploads(User.ObjectId);
        }
    }

    public void find_Uploads(string UserID)
    {
        DataStore.WhereEqualTo("Uploader", UserID);
        DataStore.FindAsync((List<NCMBObject> objList, NCMBException error_1) =>
        {
            if (error_1 != null)
            {
                //検索失敗時の処理
                Debug.Log("UploaderError");
            }
            else
            {
                foreach (NCMBObject Data in objList)
                {
                    GameObject MusicNode = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
                    MusicNode.transform.SetParent(NodeParent.transform);
                    NodeMaster node = MusicNode.GetComponent<NodeMaster>();
                    node.ViewData((Data["Title"]).ToString(), (Data["Comment"]).ToString(), System.Convert.ToInt32(Data["PlayCount"]), System.Convert.ToInt32(Data["SoaringCount"]), System.Convert.ToInt32(Data["BookmarkCount"]), (Data["ID"]).ToString(), Modal, parent_obj, toggle);
                }
                // if (objList.Count == 0) return;
                // NCMBObject BookmarkData = objList[0];
                // // Debug.Log((BookmarkData["Bookmarks"]).Count+"bookmarks");
                // // Debug.Log((string)BookmarkData["Bookmarks"][0]);

                // // List<string> BookMarks = (List<string>)BookmarkData["Bookmarks"];
                // ArrayList BookMarks = (BookmarkData["Bookmarks"]) as ArrayList;
                // // Debug.Log(typeof(BookMarks));
                // // List<string> bookmarksid= new List<string> {};
                // // foreach(NCMBObject querydata in BookMarks){
                // //     bookmarksid.Add((string)querydata);
                // // }
                // NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("MusicData");
                // query.WhereContainedIn("ID", BookMarks);
                // query.FindAsync((List<NCMBObject> MusicList, NCMBException error_2) =>
                // {
                //     if (error_2 != null)
                //     {
                //         //検索失敗時の処理
                //     }
                //     else
                //     {
                //         foreach (NCMBObject Data in MusicList)
                //         {
                //             // GameObject MusicNode = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
                //             // MusicNode.transform.SetParent(NodeParent.transform);
                //             // NodeMaster node = MusicNode.GetComponent<NodeMaster>();
                //             // node.ViewData((Data["Title"]).ToString(), (Data["Comment"]).ToString(), System.Convert.ToInt32(Data["PlayCount"]), System.Convert.ToInt32(Data["SoaringCount"]), System.Convert.ToInt32(Data["BookmarkCount"]), (Data["ID"]).ToString(), Modal, parent_obj, toggle);
                //         }
                //     }
                // });
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeleteMusic()
    {
        DeleteData.ObjectId = Transition_to_play.ID;
        DeleteData.DeleteAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("DeleteError");
            }
            else
            {
                Debug.Log("Deleted");
                LoadingScene.LoadNextScene(SceneManager.GetActiveScene().name);
            }
        });
    }
}
