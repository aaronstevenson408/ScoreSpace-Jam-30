using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Canvas_VolumeControls : MonoBehaviour
{
    public TextMeshProUGUI soundValue;
    public TextMeshProUGUI musicValue;

    public Slider soundSlider;
    public Slider musicSlider;


    private void Update()
    {
        soundValue.text = Mathf.Round(soundSlider.value).ToString() + "%;";
        musicValue.text = Mathf.Round(musicSlider.value).ToString() + "%;";
    }
}
