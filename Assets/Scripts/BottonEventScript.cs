using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using NCMB;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BottonEventScript : MonoBehaviour {
    NCMBQuery<NCMBObject> BookMark = new NCMBQuery<NCMBObject> ("BookMark"), musicquery = new NCMBQuery<NCMBObject> ("MusicData");

    NCMBObject musicdata = new NCMBObject ("MusicData");
    public static bool ChangeReady = false;

    int idkey = 0;

    void Update () {

    }

    public void BookmarkEvent () {
        string ID = Transition_to_play.ID;
        if (ChangeReady) {
            RegistBookmark (ID);
        }
    }

    void RegistBookmark (string ID) {
        BookMark.WhereEqualTo ("UserID", NCMBUser.CurrentUser.ObjectId);
        BookMark.FindAsync ((List<NCMBObject> objList, NCMBException e) => {
            if (e != null) {
                //検索失敗時の処理
                Debug.Log ("bookmarkError");
            } else {
                if (objList.Count == 0) {
                    Debug.Log("Unbookmarked");
                    NCMBObject bookobj = new NCMBObject ("BookMark");
                    bookobj.Add ("UserID", NCMBUser.CurrentUser.ObjectId);
                    ArrayList bmArray = new ArrayList();
                    bmArray.Add (ID);
                    bookobj.Add ("Bookmarks", bmArray);
                    bookobj.SaveAsync ();
                    musicquery.WhereEqualTo ("ID", ID);
                    musicquery.FindAsync ((List<NCMBObject> MusicList, NCMBException Er) => {
                        NCMBObject MusicData = MusicList[0];
                        int b_count = Transition_to_play.BookCount;
                        MusicData["BookmarkCount"] = b_count + 1;
                        MusicData.SaveAsync ();
                    });
                    Debug.Log("Saved");
                    return;
                }
                NCMBObject BookmarkData = objList[0];
                if (BookmarkData == null) Debug.Log ("BookmarkData==null");
                // Debug.Log((BookmarkData["Bookmarks"]).Count+"bookmarks");
                // Debug.Log((string)BookmarkData["Bookmarks"][0]);

                // List<string> BookMarks = (List<string>)BookmarkData["Bookmarks"];
                ArrayList BookMarksArray = (BookmarkData["Bookmarks"]) as ArrayList;
                List<string> BookMarks = new List<string> ((string[]) BookMarksArray.ToArray (typeof (string)));
                if (BookMarks == null) {
                    musicquery.WhereEqualTo ("ID", ID);
                    musicquery.FindAsync ((List<NCMBObject> MusicList, NCMBException Er) => {
                        NCMBObject MusicData = MusicList[0];
                        int b_count = Transition_to_play.BookCount;
                        MusicData["BookmarkCount"] = b_count + 1;
                        MusicData.SaveAsync ();
                    });
                    //             musicdata.ObjectId = ID;
                    //             musicdata.FetchAsync((NCMBException error) =>
                    // {
                    //     if (error != null)
                    //     {
                    //         Debug.Log("Error");
                    //     }
                    //     else
                    //     {
                    //         int b_count = (int)musicdata["BookmarkCount"];
                    //         musicdata["BookmarkCount"] = b_count + 1;
                    //         musicdata.SaveAsync();
                    //     }
                    // });
                    // Debug.Log("BookMarks==null");
                    List<string> newbookmarks = new List<string> { ID };
                    // BookMarks.Sort();
                    BookmarkData["Bookmarks"] = newbookmarks;
                    BookmarkData.SaveAsync ();
                } else {
                    // Debug.Log("BookMarks!=null");
                    if (BinarySearch (BookMarks, ID)) {
                        BookMarks.RemoveAt (idkey);
                        musicquery.WhereEqualTo ("ID", ID);
                        musicquery.FindAsync ((List<NCMBObject> MusicList, NCMBException Er) => {
                            NCMBObject MusicData = MusicList[0];
                            int b_count = Transition_to_play.BookCount;
                            MusicData["BookmarkCount"] = b_count - 1;
                            MusicData.SaveAsync ();
                        });
                        //             musicdata.ObjectId = ID;
                        //             musicdata.FetchAsync((NCMBException error) =>
                        // {
                        //     if (error != null)
                        //     {
                        //         Debug.Log("Error");
                        //     }
                        //     else
                        //     {
                        //         int b_count = (int)musicdata["BookmarkCount"];
                        //         musicdata["BookmarkCount"] = b_count - 1;
                        //         musicdata.SaveAsync();
                        //     }
                        // });
                        Debug.Log ("RemoveBookmark");
                    } else {
                        musicquery.WhereEqualTo ("ID", ID);
                        musicquery.FindAsync ((List<NCMBObject> MusicList, NCMBException Er) => {
                            NCMBObject MusicData = MusicList[0];
                            int b_count = Transition_to_play.BookCount;
                            MusicData["BookmarkCount"] = b_count + 1;
                            MusicData.SaveAsync ();
                        });
                        BookMarks.Add (ID);
                        BookMarks.Sort ();
                        //             musicdata.ObjectId = ID;
                        //             musicdata.FetchAsync((NCMBException error) =>
                        // {
                        //     if (error != null)
                        //     {
                        //         Debug.Log("Error");
                        //     }
                        //     else
                        //     {
                        //         int b_count = (int)musicdata["BookmarkCount"];
                        //         musicdata["BookmarkCount"] = b_count + 1;
                        //         musicdata.SaveAsync();
                        //     }
                        // });
                        Debug.Log ("RegistBookmark");
                    }
                    BookmarkData["Bookmarks"] = BookMarks;
                    BookmarkData.SaveAsync ();
                }
                // Debug.Log("BookMarks==null");    
                // Debug.Log(BookMarks.Count);
                // BookMarks.Sort();

            }
        });
    }

    public bool BinarySearch (List<string> array, string target) //二分探索
    {
        int left = 0;
        int right = array.Count - 1;
        while (left <= right) {
            var mid = left + (right - left) / 2;
            string mid_id = array[mid];
            int val = mid_id.CompareTo (target);
            if (mid_id == target) {
                idkey = mid;
                return true;
            } else if (val == -1) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return false;
    }

    // public void HeartEvent(){
    //      if(Heart_Filed.GetComponent<Image>().color.a==1){
    //          Debug.Log("Full");
    //      }
    //      else{

    //      }
    // }
}