using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource fonMusic;

    private void Start()
    {
        slider.value = 0.5f;
        fonMusic.volume = slider.value;
    }

    private void Update()
    {
        fonMusic.volume = slider.value;
    }
}
