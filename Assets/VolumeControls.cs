using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour
{
    public Slider music;
    public TextMeshProUGUI musicValue;
    public Slider SFX;
    public TextMeshProUGUI SFXValue;

    private void Update()
    {
        musicValue.text = music.value.ToString() + "%";
        SFXValue.text = SFX.value.ToString() + "%";
    }
}
