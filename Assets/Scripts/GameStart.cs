using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using NCMB;
using TMPro;
using Michsky.UI.ModernUIPack;


public class GameStart : MonoBehaviour
{
    public ModalWindowManager Modal;

    public LoadingScene LoadingScene;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Screen", 1) == 0)
        {
            Screen.SetResolution(1920, 1080, false);
            PlayerPrefs.SetInt("Screen", 0);
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
            PlayerPrefs.SetInt("Screen", 1);
        }
        Modal.OpenWindow();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartScenes()
    {
        NCMBUser currentUser = NCMBUser.CurrentUser;
        if (currentUser != null)
        {
            LoadingScene.LoadNextScene("selection");
        }
        else
        {
            LoadingScene.LoadNextScene("SignScenes");
        }
    }
}
