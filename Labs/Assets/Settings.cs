using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider vslider = null;
    [SerializeField] private TMP_Text volumetext = null;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("volumevalue", 1.0f);
        LoadValues();
    }

    // Update is called once per frame
    public void Slider(float volume)
    {
        volumetext.text = volume.ToString("0.0");
    }
    public void SaveButton()
    {
        float volumeValue = vslider.value;
        Debug.Log("kkk" + volumeValue.ToString());
        PlayerPrefs.SetFloat("volumevalue", volumeValue);
        LoadValues();
        float v = PlayerPrefs.GetFloat("volumevalue");
        Debug.Log("jjj" + v.ToString());
    }
    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumevalue");
        vslider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
