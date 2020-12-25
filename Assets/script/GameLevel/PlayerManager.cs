using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;
    
    //float acı;
    //float donushizi = 5f;
    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private GameObject[] mermiPrefab;

    float ikitopArasıSüre = 200f;
    float sonrakiAtis;
    private Vector2 direction;
    public bool rotasabit;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip topClick;
    private void Start()
    {
        rotasabit = false;
    }
    void Update()
    {
        if (rotasabit==true)
        {
            RotateDegistir();
        }
       

    }
    void RotateDegistir()


    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);




        //Quaternion rotasyon= Quaternion.LookRotation(gun2.transform.position, Camera.main.WorldToScreenPoint(Input.mousePosition));

        //gun2.transform.rotation = rotasyon;
        //Debug.Log(Input.mousePosition);
        //Debug.Log(transform.position);
    
        //    direction = Camera.main.WorldToScreenPoint(Input.mousePosition) - gun.transform.position;
        //    acı = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -60f;





        //if (acı < 45 && acı > -45)
        //{

        //Quaternion roatiton = Quaternion.AngleAxis(acı, Vector3.forward);
        //    gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, roatiton, donushizi * Time.deltaTime);

        //}
        if (Input.GetMouseButtonDown(0))
        {

            if (Time.time > sonrakiAtis)
            {
                sonrakiAtis = Time.time + ikitopArasıSüre / 1000;
                MermiAt();
            }


        }




    }
    void MermiAt()
    {
        if (PlayerPrefs.GetInt("sesDurumu") ==1)
        {
            audioSource.PlayOneShot(topClick);
        }
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0, mermiPrefab.Length)], mermiYeri.position, mermiYeri.rotation) as GameObject;
    }
}
