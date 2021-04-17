using System.Collections;
using System.Collections.Generic;
// using System.Convert;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using NCMB;
using TMPro;
using Michsky.UI.ModernUIPack;

public class UseMIDIkeybord : MonoBehaviour
{
    // public bool midistates;
    // public static bool MIDIkeybordflag=false;

    public GameObject toggle;

    public void changeflag()
    {
        MicSpectrumAnalyz.MIDIStatus = toggle.GetComponent<Toggle>().isOn;
        PlayerPrefs.SetInt("Midi_toggle", System.Convert.ToInt32(toggle.GetComponent<Toggle>().isOn));
        PlayerPrefs.Save();
        // MIDIkeybordflag = toggle.GetComponent<Toggle>().isOn;
        // if(toggle.GetComponent<Toggle>().isOn){
        //     MIDIkeybordflag = true;
        // }
        // else{
        //     MIDIkeybordflag = false;
        // }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Midi_toggle", 1));
        MicSpectrumAnalyz.MIDIStatus =  System.Convert.ToBoolean(PlayerPrefs.GetInt("Midi_toggle", 1));
        toggle.GetComponent<Toggle>().isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("Midi_toggle", 1));
        // MIDIkeybordflag = toggle.GetComponent<Toggle>().isOn;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
