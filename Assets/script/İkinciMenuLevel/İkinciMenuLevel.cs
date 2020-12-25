using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class İkinciMenuLevel : MonoBehaviour
{

    [SerializeField]
    private GameObject altMenuPaneli;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClick;


    void Start()
    {
        altMenuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        altMenuPaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);

    }

    public void HangiOyun(string hangioyun)
    {
        if (PlayerPrefs.GetInt("sesDurumu") ==1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        PlayerPrefs.SetString("hangioyun", hangioyun);
        SceneManager.LoadScene("GameLevel");

    }
    public void GeriDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") ==1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("MenuLevel");
    }

}
