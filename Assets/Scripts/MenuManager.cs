using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] AudioSource sonTaaEleClick;
    [SerializeField] AudioSource sonTaaEchtihYazab;
    private float L7essTa3Son;
    private float L7essTa3Lghonya;

    void Start()
    {
        L7essTa3Son = PlayerPrefs.GetFloat("sonTa3Click", 1f);  
        L7essTa3Lghonya = PlayerPrefs.GetFloat("sonTa3Leghna", 1f);
        soundSlider.value = L7essTa3Son;
        musicSlider.value = L7essTa3Lghonya;
    }
    public void play()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void exit()
    {
        Application.Quit();
    }
    public void changeSoundVolume()
    {
        PlayerPrefs.SetFloat("sonTa3Click", soundSlider.value);
        sonTaaEleClick.volume = soundSlider.value;
    }
    public void changeMusicVolume()
    {
        PlayerPrefs.SetFloat("sonTa3Leghna", musicSlider.value);
        sonTaaEchtihYazab.volume = musicSlider.value;
    }
}
