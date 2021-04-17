using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NCMB;
using TMPro;
using Michsky.UI.ModernUIPack;

public class Soaring_Music : MonoBehaviour
{
    public ModalWindowManager Modal;
    public Toggle toggle;

    public GameObject prefab;
    public GameObject NodeParent, parent_obj;
    // public TextMeshPro Search_text;
    void Start()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("MusicData");
        query.OrderByDescending("SoaringCount");
        query.Limit = 100;
        query.FindAsync((List<NCMBObject> MusicList, NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("検索失敗時の処理");
                //検索失敗時の処理
            }
            else
            {
                foreach (NCMBObject Data in MusicList)
                {
                    // Debug.Log(Data["Title"]);
                    // Debug.Log(Data["Comment"]);
                    // Debug.Log(Data["PlayCount"]);
                    GameObject MusicNode = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
                    MusicNode.transform.SetParent(NodeParent.transform);
                    NodeMaster node = MusicNode.GetComponent<NodeMaster>();
                    node.ViewData((Data["Title"]).ToString(), (Data["Comment"]).ToString(), System.Convert.ToInt32(Data["PlayCount"]), System.Convert.ToInt32(Data["SoaringCount"]), System.Convert.ToInt32(Data["BookmarkCount"]), (Data["ID"]).ToString(), Modal, parent_obj, toggle);
                    // Node.ViewData(Data["Title"].ToString(),Data["Comment"].ToString(),(int)Data["PlayCount"]);
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
