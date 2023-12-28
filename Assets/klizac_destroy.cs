using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klizac_destroy : MonoBehaviour
{

    private GameObject loptica;


    void Start()
    {
        loptica = GameObject.Find("loptica");

    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, loptica.transform.position) > 30 && transform.position.x < loptica.transform.position.x)
        {
            Destroy(gameObject);
        } 



    }
}
