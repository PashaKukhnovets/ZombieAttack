using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    public void VolumeOn() {
        AudioListener.volume = 1.0f;
    }

    public void VolumeOff() {
        AudioListener.volume = 0.0f;
    }
}
