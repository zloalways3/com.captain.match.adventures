using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PolicyController : MonoBehaviour
{
    public GameObject policyTextObject;
    public GameObject acceptPopupObject;
    [SerializeField]
    private AudioSource musicSource;  
    [SerializeField]
    private AudioSource soundSource;
    // Start is called before the first frame update
    private void Start()
    {
        soundSource.volume = PlayerPrefs.GetFloat("sonTa3Click", 1f);
        musicSource.volume = PlayerPrefs.GetFloat("sonTa3Leghna", 1f);

    }
    public void AcceptPolicy()
    {
        PlayerPrefs.SetInt("el9anounMa9boul", 1);
        SceneManager.LoadScene("MenuScene");
        soundSource.Play();
    }

}
