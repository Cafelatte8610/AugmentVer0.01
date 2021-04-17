using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using NCMB;
using Michsky.UI.ModernUIPack;

public class IconAlphaManager : MonoBehaviour
{
    public Image Icon, full;
    // Color c;
    // Start is called before the first frame update
    void Start()
    {   
        // c = Icon.color;
    }

    public void ChangeAlpha_tabs()
    {
        if (full.color.a == 0)
        {
            // c.a = 0;
            Icon.enabled = false;
        }
        else
        {
            // c.a = 1;
            Icon.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
