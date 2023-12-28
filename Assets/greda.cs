using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greda : MonoBehaviour
{

    public GameObject greda_prefab;
    private float greda_k = 17.04f;
    private float tlo_k = 17.4f;
    public GameObject loptica;
    private GameObject glavni_obj;
    private glavna_skripta gs;
    private bool moja_greda;
    
    void Start()
    {
        loptica = GameObject.Find("loptica");
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();
        moja_greda = true;
    }

    
    void Update()
    {
        
        if(transform.tag == "greda")
        {
            if (Vector3.Distance(transform.position, loptica.transform.position) < 30 && gs.broj_greda < 4 && moja_greda && gs.greda_spawn_x == transform.position.x)
            {
                Instantiate(greda_prefab, new Vector3(transform.position.x + greda_k, 0, 0), Quaternion.identity);
                gs.broj_greda++;
                moja_greda = false;
                gs.greda_spawn_x += greda_k;
            }

            if (Vector3.Distance(transform.position, loptica.transform.position) > 50)
            {
                Destroy(gameObject);
                gs.broj_greda--;
            }
        }

        if (transform.tag == "tlo")
        {
            if (Vector3.Distance(transform.position, loptica.transform.position) < 30 && gs.broj_greda < 4 && moja_greda && gs.tlo_spawn_x == transform.position.x)
            {
                Instantiate(greda_prefab, new Vector3(transform.position.x + tlo_k, 0, 0), Quaternion.identity);
                gs.broj_tla++;
                moja_greda = false;
                gs.tlo_spawn_x += tlo_k;
            }

            if (Vector3.Distance(transform.position, loptica.transform.position) > 50)
            {
                Destroy(gameObject);
                gs.broj_tla--;
            }
        }



    }
















}
