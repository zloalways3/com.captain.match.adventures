using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingManager : MonoBehaviour
{
    public Slider zok3ablaSlider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(load());
    }
    IEnumerator load()
    {
        var privacarAcceptado = PlayerPrefs.GetInt("el9anounMa9boul", 0);
        yield return new WaitForSeconds(0.25f);
        zok3ablaSlider.value = 0.55f;
        yield return new WaitForSeconds(0.1562f);
        zok3ablaSlider.value = 0.74f;
        yield return new WaitForSeconds(0.15f);
        zok3ablaSlider.value = 0.92f;
        if (privacarAcceptado == 1)
        {
            zok3ablaSlider.value = 1;
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            SceneManager.LoadScene("PolicyScene");
            zok3ablaSlider.value = 1;
        }
    }
}
