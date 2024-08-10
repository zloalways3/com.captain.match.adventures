using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq;
public class GameManager : MonoBehaviour
{
    
    private GameObject _elSelectedeGrupado;
    [SerializeField]
    private GameObject _panelGamera;
    [SerializeField]
    private GameObject _diffucultadePanela;
    [SerializeField]
    private Sprite[] _elementados;
    [SerializeField]
    private GameObject _ButtunoForwarde;
    [SerializeField]
    private GameObject _PanelRbe7t;
    [SerializeField]
    private AudioSource achta7NikBabek;
    [SerializeField]
    private AudioSource SonDeClick;
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;
    private int sou3ouba = 0;
    private int spndIt3ms;
    [SerializeField]
    private AudioSource rakRbe7tyaZebi;
    private Button Item_wa7ed;
    private Button Item_Zouj;
    private int MATCHESLAZMIN_BECH_TERBAH;
    private int nambarMOUVES = 0;
    [SerializeField]
    private Text ch7almenMara_T7arekt;
    [SerializeField]
    private Text idaRbe7tCh7alMaraT7arekt;
    [SerializeField]
    private GameObject[] ElDifficultateGroup;
    // Start is called before the first frame update
    void Start()
    {
        float _volumeSound = PlayerPrefs.GetFloat("sonTa3Click", 1);
        float _volumeMusic = PlayerPrefs.GetFloat("sonTa3Leghna", 1);
        achta7NikBabek.volume = _volumeMusic;
        SonDeClick.volume = _volumeSound;
        musicSlider.value = _volumeMusic;
        soundSlider.value = _volumeSound;
    }
    public void itemClicked(Button clickedBtn)
    {
        SonDeClick.Play();
        nambarMOUVES++;
        ch7almenMara_T7arekt.text = nambarMOUVES.ToString();
        if (Item_wa7ed == null)
        {
            Item_wa7ed = clickedBtn;
            teswiraTa3Lbutton(Item_wa7ed).SetActive(true);
        }
        else if (Item_Zouj == null && clickedBtn != Item_wa7ed)
        {
            Item_Zouj = clickedBtn;
            teswiraTa3Lbutton(Item_Zouj).SetActive(true); 
            StartCoroutine(chofIdaMatchaw());
        }
    }

    public void startGame(int elWou3oura)
    {
        SonDeClick.Play();
        sou3ouba = elWou3oura;
        if (sou3ouba > 0)
        {
 
            if (sou3ouba == 1) spndIt3ms = 8;
            else if (sou3ouba == 2) spndIt3ms = 12;
            else if (sou3ouba == 3) spndIt3ms = 20;
            MATCHESLAZMIN_BECH_TERBAH = spndIt3ms / 2;
            _diffucultadePanela.SetActive(false);
            _panelGamera.SetActive(true);
            _elSelectedeGrupado = ElDifficultateGroup[sou3ouba - 1];
            _elSelectedeGrupado.SetActive(true);
            List<Sprite> vremeniSpraiti = new List<Sprite>();
            for (int i=0;i<MATCHESLAZMIN_BECH_TERBAH;i++)
            {
                var el_IndeXo = Random.Range(0,_elementados.Count()-1);
                while (vremeniSpraiti.Contains(_elementados[el_IndeXo]))
                     el_IndeXo = Random.Range(0, _elementados.Count() - 1);
                vremeniSpraiti.Add(_elementados[el_IndeXo]);
            }
            vremeniSpraiti.AddRange(vremeniSpraiti.ToArray());
            int _counter = 0;
            while (vremeniSpraiti.Count > 0)
            {
                GameObject item = _elSelectedeGrupado.transform.Find($"item{_counter + 1}").gameObject;
                GameObject imageInside = item.transform.Find($"Image").gameObject;
                int index= Random.Range(0,vremeniSpraiti.Count()-1);
                imageInside.GetComponent<Image>().sprite = vremeniSpraiti[index];
                vremeniSpraiti.RemoveAt(index);
                _counter++;
            }
        }
    }
    public void changeSoundVolume()
    {
        PlayerPrefs.SetFloat("sonTa3Click", soundSlider.value);
        SonDeClick.volume = soundSlider.value;
    }
    public void changeMusicVolume()
    {
        PlayerPrefs.SetFloat("sonTa3Leghna", musicSlider.value);
        achta7NikBabek.volume = musicSlider.value;
    }

    GameObject teswiraTa3Lbutton(Button ya3tik3asba)
    {
        return ya3tik3asba.gameObject.transform.Find("Image").gameObject;
    }

    IEnumerator chofIdaMatchaw()
    {
        yield return new WaitForSeconds(1.0f); 

        if (teswiraTa3Lbutton(Item_wa7ed).GetComponent<Image>().sprite == teswiraTa3Lbutton(Item_Zouj).GetComponent<Image>().sprite)
        {
            Item_wa7ed.gameObject.SetActive(false);
            Item_Zouj.gameObject.SetActive(false);            
            MATCHESLAZMIN_BECH_TERBAH--;
            if (MATCHESLAZMIN_BECH_TERBAH == 0)
            {
                idaRbe7tCh7alMaraT7arekt.text = nambarMOUVES.ToString();
                rakRbe7tyaZebi.Play();
                rakRbe7tyaZouba();
            }
        }
        else
        {
            teswiraTa3Lbutton(Item_wa7ed).SetActive(false);
            teswiraTa3Lbutton(Item_Zouj).SetActive(false);
        }

        Item_wa7ed = null;
        Item_Zouj = null;
    }
    void rakRbe7tyaZouba()
    {
        _panelGamera.SetActive(false);
        _PanelRbe7t.SetActive(true);
    }
    public void LoadMenu()
    {
        SonDeClick.Play();
        SceneManager.LoadScene("MenuScene");
    }
    public void NextLevel()
    {
        SonDeClick.Play();
        sou3ouba++;
        if (sou3ouba < 3)
        {
            PlayerPrefs.SetInt("RestartDifficulty", sou3ouba);
            SceneManager.LoadScene("PlayScene");
        }
        else
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}
