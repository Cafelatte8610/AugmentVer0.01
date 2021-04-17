using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class bgm_manager : MonoBehaviour
{
    public AudioSource audioSource;
    bool flag = true;
    public AudioMixer Mixer;

    public static bool bgmPlaying = false;

    float ConvertVolume2dB(float volume) => 20f * Mathf.Log10(Mathf.Clamp(volume, 0f, 1f));
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (PlayerPrefs.GetFloat("BGM", 100.0f) == 0.0f)
        {
            Mixer.SetFloat("BGMMaster", -80.0f);
        }
        else
        {
            Mixer.SetFloat("BGMMaster", ConvertVolume2dB((PlayerPrefs.GetFloat("BGM", 100.0f)) / 100.0f) - 20.0f);
        }
        Debug.Log(bgmPlaying);
        if (!bgmPlaying)
        {
            audioSource.Play();
            bgmPlaying = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HitEvent.BGMflag && flag)
        {
            audioSource.Stop();
            flag = false;
        }
        if (HitEvent.BGMflag == false && flag == false)
        {
            audioSource.Play();
            flag = true;
        }
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }
}
