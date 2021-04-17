using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using NCMB;
using Michsky.UI.ModernUIPack;


public class SidePanelSc : MonoBehaviour
{
    // Start is called before the first frame update

    bool On_flag = true;

    public RectTransform SubP;

    float width = 0;

    void Start()
    {

    }

    public void Sidepanel()
    {
        if (On_flag)
        {
            On_flag = false;
            SubP.DOLocalMoveX(834.52f, 0.3f);
        }
        else
        {
            On_flag = true;
            SubP.DOLocalMoveX(1090.0f, 0.3f);
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
