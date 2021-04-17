using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Setting_script : MonoBehaviour
{
    public LoadingScene LoadingScene;

    public Slider slider;

    public AudioMixer Mixer;

    public Toggle ScreenT;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("BGM", 100.0f);
        ScreenT.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("Screen", 1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    float ConvertVolume2dB(float volume) => 20f * Mathf.Log10(Mathf.Clamp(volume, 0f, 1f));

    public void BGMVolium()
    {
        PlayerPrefs.SetFloat("BGM", slider.value);
        if (slider.value == 0.0f)
        {
            Mixer.SetFloat("BGMMaster", -80.0f);
        }
        else
        {
            Mixer.SetFloat("BGMMaster", ConvertVolume2dB(((float)slider.value) / 100.0f) - 20.0f);
        }
    }

    public void backselect()
    {
        LoadingScene.LoadNextScene("selection");
    }

    public void ChangeScreen()
    {
        if (!ScreenT.isOn)
        {
            Debug.Log("Window");
            Screen.SetResolution(1920, 1080, false);
            PlayerPrefs.SetInt("Screen", 0);
        }
        else
        {
            Debug.Log("FullScreen");
            Screen.SetResolution(1920, 1080, true);
            PlayerPrefs.SetInt("Screen", 1);
        }
    }
}
