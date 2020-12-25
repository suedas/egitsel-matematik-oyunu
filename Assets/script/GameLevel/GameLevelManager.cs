using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameLevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, puanText;

    [SerializeField]
    private Text SoruText, birinciSonucText, ikinciSonucText, üçüncüSonucText;

    string hangioyun;
    int birinciCarpan;
    int ikinciCarpan;
    int dogruSonuc;
    int yanlisSonucbir;
    int yanlisSonucİki;

    public int dogruAdet, yanlisAdet, toplamPuan;
    

    PlayerManager  playerManager;
    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerManager>();
    }



    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;



        if (PlayerPrefs.HasKey("hangioyun"))
        {
           hangioyun= PlayerPrefs.GetString("hangioyun");

        }
        StartCoroutine(baslayazi());

    }
    IEnumerator baslayazi()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);
        OyunaBasla();

    }
    void OyunaBasla()
    {
        playerManager.rotasabit = true;
        SoruyuYazdır(); 

    }
    void BirinciCarpaniAyarla()
    {
        switch (hangioyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;
            case "üç":
                birinciCarpan = 3;
                break;
            case "dört":
                birinciCarpan = 4;
                break;
            case "beş":
                birinciCarpan = 5;
                break;
            case "altı":
                birinciCarpan = 6;
                break;
            case "yedi":
                birinciCarpan = 7;
                break;
            case "sekiz":
                birinciCarpan = 8;
                break;
            case "dokuz":
                birinciCarpan = 9;
                break;
            case "on":
                birinciCarpan = 10;
                break;
            case "karisik":
                birinciCarpan = Random.Range(2,11);
                break;
        }
       
    }
    void SoruyuYazdır()
    {
        BirinciCarpaniAyarla();

        ikinciCarpan = Random.Range(2, 11);

        int rastgeleDeger = Random.Range(1, 100);

        if (rastgeleDeger<=50)
        {
            SoruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();

        }
        else
        {
            SoruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();
        }
        dogruSonuc = birinciCarpan * ikinciCarpan;
        SonuclariYazdir();
    }
    void SonuclariYazdir()
    {
        yanlisSonucbir = dogruSonuc + Random.Range(2, 10);

        if (dogruSonuc>10)
        {
            yanlisSonucİki = dogruSonuc - Random.Range(2, 8);

        }
        else
        {
            yanlisSonucİki = Mathf.Abs(dogruSonuc - Random.Range(1, 5));
        }
        int rastgele = Random.Range(1, 100);

        if (rastgele<=33)
        {
            birinciSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = yanlisSonucbir.ToString();
            üçüncüSonucText.text = yanlisSonucİki.ToString();
        }
        else if (rastgele<=66)
        {
           ikinciSonucText.text = dogruSonuc.ToString();
           birinciSonucText.text = yanlisSonucbir.ToString();
           üçüncüSonucText.text = yanlisSonucİki.ToString();

        }
        else
        {
            üçüncüSonucText.text = dogruSonuc.ToString();
            birinciSonucText.text = yanlisSonucİki.ToString();
            ikinciSonucText.text = yanlisSonucbir.ToString();
        }
    } 
    public void SonucuKontrolEt(int textSonuc)
    {    //İlk başta kapanmıyor ve çok büyüyor
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonuc==dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 10;
            dogruImage.GetComponent<RectTransform>().DOScale(0.2f, 0.1f);
        }
        else
        {
            yanlisAdet++;
          yanlisImage.GetComponent<RectTransform>().DOScale(0.2f, 0.1f);
        }
        dogruAdetText.text = dogruAdet.ToString();
        yanlisAdetText.text = yanlisAdet.ToString() ;
        puanText.text = toplamPuan.ToString() ;
        SoruyuYazdır();
    }
}
