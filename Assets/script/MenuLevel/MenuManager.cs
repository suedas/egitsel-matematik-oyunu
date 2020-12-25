using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject menuPaneli;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClick;
    [SerializeField]
    private GameObject sesPaneli;
    bool sesPaneliAcikMi ;
    void Start()
    {
        sesPaneliAcikMi=false;
        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3(-8, -35, 0);

        menuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);




    }
    public void ikinciLevelEkran()
    {
        if (PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        
        SceneManager.LoadScene("İkinciMenuLevel");
    }
    public void Ayarlar()
    {

        if (PlayerPrefs.GetInt("sesDurumu") ==1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        if (!sesPaneliAcikMi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-154, 0.5f);
            sesPaneliAcikMi = true;
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-61, 0.5f);
            sesPaneliAcikMi = false;
        }

    }
    public void OyundaCık()
    {
        if (PlayerPrefs.GetInt("sesDurumu") ==1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        Application.Quit();
    }


    void Update()
    {
        
    }
}
