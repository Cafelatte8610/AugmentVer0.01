using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NCMB;
using TMPro;
using Michsky.UI.ModernUIPack;

public class activeUser : MonoBehaviour
{
    public Text login_username;
    // Start is called before the first frame update
    void Start()
    {
        login_username.text = "Online : "+NCMBUser.CurrentUser.UserName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
