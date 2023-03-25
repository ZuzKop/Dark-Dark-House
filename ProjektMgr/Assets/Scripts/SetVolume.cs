using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("Vol", 1f);
    }

    public void SetLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("Vol", sliderValue);
        mixer.SetFloat("VolumeSetting", Mathf.Log10(sliderValue)*20);
    }

}
