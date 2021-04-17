using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using NCMB;
using TMPro;
using Michsky.UI.ModernUIPack;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

public class DeviceViwe : MonoBehaviour
{
    public Text Midiview;
    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;
            Midiview.text = device.description.product;
            Debug.Log(string.Format("{0} ({1}) {2}",
                device.description.product, midiDevice.channel, change));
        };
    }
}
