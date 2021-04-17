using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class tapeffect : MonoBehaviour
{
    public AudioClip click_s;
    public AudioSource audioSource;

    public Slider slider;

    void Start()
    {
        if(slider!=null){
            slider.value = PlayerPrefs.GetFloat("Volume", 1.0f)*100;
        }
        audioSource.volume=PlayerPrefs.GetFloat("Volume", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //　マウスの左ボタンを押した時この1フレームだけの判定
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("tap");
            audioSource.Play();
        }
    }

    public void ChangeV(){
        PlayerPrefs.SetFloat("Volume", (float)slider.value/100.0f);
        PlayerPrefs.Save();
    }
}
