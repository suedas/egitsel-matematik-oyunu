using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiManager: MonoBehaviour
{

    float mermiHizi = 15f;
    // Start is called before the first frame update
    //void Start()
    //{
    //    if (this.gameObject != null)
    //    {
    //        Destroy(this.gameObject, 3f);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * mermiHizi);
    }
}
