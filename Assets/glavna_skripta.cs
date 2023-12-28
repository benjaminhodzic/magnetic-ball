using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class glavna_skripta : MonoBehaviour
{
    public GameObject stap_prefab1;
    public GameObject stap_prefab2;
    public GameObject stap_prefab3;
    public GameObject stap_prefab4;
    public GameObject stap1;
    public GameObject stap2;
    public GameObject stap3;
    public GameObject stap4;
    // stapovi 
    public float duzina_stapova = 5;
    public float max_ugao = 45;
    public float brzina_stapovi = 500;
    public float razdaljina_stapova = 19.9f;
    public float razdaljina_unistenja = 20;
    public float last_spawn_stap_x;
    public float postotak_usporavanja = 30;
    public float vrh_wait_time = 0.1f;
    public float krug_djelovanja = 3;
    public float krug_djelovanja_stvarni = 3.2f;
    public GameObject last_instantiate_stap;
    public float broj_spawnovanih_stapova;
    public float zabranjeni_ugao_spawna = 20;
    //
    public Camera kamera;
    public GameObject glavna_loptica;
    public float velicina_loptice = 0.7f;
    //poveznice za sve stap skripte
    public stap1 s1;
    public stap2 s2;
    public stap3 s3;
    public stap4 s4;
    private camera_script cs;
    //
    public bool privucen = false;
    public bool privucen1 = false;
    public bool privucen2 = false;
    public bool privucen3 = false;
    public bool privucen4 = false;
    public float jacina_lansiranja = 10;

    public bool privucen_centar = false;

    public Vector3 dir;
    public float brzina_centar;
    public int last_stap = 4;
    public float nakon = 0.2f;
    public GameObject krug_djelovanja_prefab;
    public float boik; // brzina okretanja imaginarnog kruga

    public int broj_greda = 0;
    public int broj_tla = 0;
    public float greda_spawn_x = 0;
    public float tlo_spawn_x = 0;

    public GameObject klizac_prefab;
    private float klizacminus = -0.13f;

    public Text screen_score;
    public int screen_score_int = 0;
    private bool click_check = false;

    public bool ispaused = false;




    void Start()
    {
        cs = kamera.GetComponent<camera_script>();
        //Debug.Log("started");
        glavna_loptica.transform.localScale = new Vector3(velicina_loptice, velicina_loptice, 0.7f);
        stap1 = Instantiate(stap_prefab1, new Vector3(0,5,0), Quaternion.identity) as GameObject;
        Instantiate(klizac_prefab, new Vector3(stap1.transform.position.x, stap1.transform.position.y - klizacminus, 21), Quaternion.identity);
        last_spawn_stap_x += razdaljina_stapova;
        stap2 = Instantiate(stap_prefab2, new Vector3(last_spawn_stap_x, 5, 0), Quaternion.identity) as GameObject;
        Instantiate(klizac_prefab, new Vector3(stap2.transform.position.x, stap2.transform.position.y - klizacminus, 21), Quaternion.identity);
        last_spawn_stap_x += razdaljina_stapova;
        stap3 = Instantiate(stap_prefab3, new Vector3(last_spawn_stap_x, 5, 0), Quaternion.identity) as GameObject;
        Instantiate(klizac_prefab, new Vector3(stap3.transform.position.x, stap3.transform.position.y - klizacminus, 21), Quaternion.identity);
        last_spawn_stap_x += razdaljina_stapova;
        stap4 = Instantiate(stap_prefab4, new Vector3(last_spawn_stap_x, 5, 0), Quaternion.identity) as GameObject;
        Instantiate(klizac_prefab, new Vector3(stap4.transform.position.x, stap4.transform.position.y - klizacminus, 21), Quaternion.identity);

        screen_score.enabled = false;

    }

    private void Update()
    {
        if (screen_score_int > 0) screen_score.enabled = true;
        screen_score.text = screen_score_int.ToString();
        // lansiranje
        if (Input.GetMouseButtonUp(0) && privucen && privucen1)
        {
            privucen_centar = false;
            glavna_loptica.GetComponent<Rigidbody>().useGravity = true;
            privucen = false; glavna_loptica.transform.parent = null;
            //glavna_loptica.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0.5f, 0) * s1.smijer * jacina_lansiranja);
            glavna_loptica.GetComponent<Rigidbody>().AddForce(s1.brzina * jacina_lansiranja * 100);
            //Debug.Log(s1.brzina * jacina_lansiranja);
            privucen1 = false;
            dir = new Vector3(0, 0, 0);
            last_stap = 1;
            click_check = true;
        }

        if (Input.GetMouseButtonUp(0) && privucen && privucen2)
        {
            privucen_centar = false;
            glavna_loptica.GetComponent<Rigidbody>().useGravity = true;
            privucen = false; glavna_loptica.transform.parent = null;
            //glavna_loptica.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0.5f, 0) * s1.smijer * jacina_lansiranja);
            glavna_loptica.GetComponent<Rigidbody>().AddForce(s2.brzina * jacina_lansiranja * 100);
            //Debug.Log(s2.brzina * jacina_lansiranja);
            privucen2 = false;
            dir = new Vector3(0, 0, 0);
            last_stap = 2;
            click_check = true;
        }

        if (Input.GetMouseButtonUp(0) && privucen && privucen3)
        {
            privucen_centar = false;
            glavna_loptica.GetComponent<Rigidbody>().useGravity = true;
            privucen = false; glavna_loptica.transform.parent = null;
            glavna_loptica.GetComponent<Rigidbody>().AddForce(s3.brzina * jacina_lansiranja * 100);
            privucen3 = false;
            dir = new Vector3(0, 0, 0);
            last_stap = 3;
            click_check = true;
        }

        if (Input.GetMouseButtonUp(0) && privucen && privucen4)
        {
            privucen_centar = false;
            glavna_loptica.GetComponent<Rigidbody>().useGravity = true;
            privucen = false; glavna_loptica.transform.parent = null;
            glavna_loptica.GetComponent<Rigidbody>().AddForce(s4.brzina * jacina_lansiranja * 100);
            privucen4 = false;
            dir = new Vector3(0, 0, 0);
            last_stap = 4;
            click_check = true;
        }


        if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(1))
        {
            //Application.LoadLevel(0);
            SceneManager.LoadScene(0);

        }


    }




    void FixedUpdate()
    {
        
        //delete object i instantiate
        {
            if (Vector3.Distance(glavna_loptica.transform.position, stap1.transform.position) > razdaljina_unistenja && glavna_loptica.transform.position.x > stap1.transform.position.x)
            {   Destroy(stap1); last_spawn_stap_x += razdaljina_stapova; stap1 = Instantiate(stap_prefab1, new Vector3(last_spawn_stap_x, 5, 0), Quaternion.identity) as GameObject;
                Instantiate(klizac_prefab, new Vector3(stap1.transform.position.x, stap1.transform.position.y - klizacminus, 21), Quaternion.identity);
                last_instantiate_stap = stap1;
            }

            if (Vector3.Distance(glavna_loptica.transform.position, stap2.transform.position) > razdaljina_unistenja && glavna_loptica.transform.position.x > stap2.transform.position.x)
            {   Destroy(stap2); last_spawn_stap_x += razdaljina_stapova; stap2 = Instantiate(stap_prefab2, new Vector3(last_spawn_stap_x, 5, 0), Quaternion.identity) as GameObject;
                Instantiate(klizac_prefab, new Vector3(stap2.transform.position.x, stap2.transform.position.y - klizacminus, 21), Quaternion.identity);
                last_instantiate_stap = stap2;
            }

            if (Vector3.Distance(glavna_loptica.transform.position, stap3.transform.position) > razdaljina_unistenja && glavna_loptica.transform.position.x > stap3.transform.position.x)
            {   Destroy(stap3); last_spawn_stap_x += razdaljina_stapova; stap3 = Instantiate(stap_prefab3, new Vector3(last_spawn_stap_x, 5, 0), Quaternion.identity) as GameObject;
                Instantiate(klizac_prefab, new Vector3(stap3.transform.position.x, stap3.transform.position.y - klizacminus, 21), Quaternion.identity);
                last_instantiate_stap = stap3;
            }

            if (Vector3.Distance(glavna_loptica.transform.position, stap4.transform.position) > razdaljina_unistenja && glavna_loptica.transform.position.x > stap4.transform.position.x)
            {   Destroy(stap4); last_spawn_stap_x += razdaljina_stapova; stap4 = Instantiate(stap_prefab4, new Vector3(last_spawn_stap_x, 5, 0), Quaternion.identity) as GameObject;
                Instantiate(klizac_prefab, new Vector3(stap4.transform.position.x, stap4.transform.position.y - klizacminus, 21), Quaternion.identity);
                last_instantiate_stap = stap4;
            }

        }

        //skripta load
        {
            s1 = stap1.GetComponent<stap1>();
            s2 = stap2.GetComponent<stap2>();
            s3 = stap3.GetComponent<stap3>();
            s4 = stap4.GetComponent<stap4>();
        }

        //mehanizam privlacenja

        {
            // 1
            if (Vector3.Distance(glavna_loptica.transform.position, s1.krug_djelovanja.transform.position) < krug_djelovanja_stvarni / 2 && Input.GetMouseButton(0) && last_stap == 4)
            {
                glavna_loptica.GetComponent<Rigidbody>().useGravity = false; privucen = true; privucen1 = true;
                glavna_loptica.transform.position = Vector3.Lerp(glavna_loptica.transform.position, s1.krug_djelovanja.transform.position, 0.5f + (0.5f * (1 - (1 / 1.5f * (Vector3.Distance(glavna_loptica.transform.position, s1.krug_djelovanja.transform.position))))));
                if (Vector3.Distance(glavna_loptica.transform.position, s1.krug_djelovanja.transform.position) < 0.2f)
                {
                    glavna_loptica.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    glavna_loptica.transform.position = s1.krug_djelovanja.transform.position;
                    privucen_centar = true;
                    addscore();
                    glavna_loptica.transform.SetParent(s1.krug_djelovanja.transform);
                }

            }



            // 2
            if (Vector3.Distance(glavna_loptica.transform.position, s2.krug_djelovanja.transform.position) < krug_djelovanja_stvarni / 2 && Input.GetMouseButton(0) && last_stap == 1)
            {
                glavna_loptica.GetComponent<Rigidbody>().useGravity = false; privucen = true; privucen2 = true;
                glavna_loptica.transform.position = Vector3.Lerp(glavna_loptica.transform.position, s2.krug_djelovanja.transform.position, 0.5f + (0.5f * (1 - (1 / 1.5f * (Vector3.Distance(glavna_loptica.transform.position, s2.krug_djelovanja.transform.position))))));
                if (Vector3.Distance(glavna_loptica.transform.position, s2.krug_djelovanja.transform.position) < 0.2f)
                {
                    glavna_loptica.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    glavna_loptica.transform.position = s2.krug_djelovanja.transform.position;
                    privucen_centar = true;
                    addscore();
                    glavna_loptica.transform.SetParent(s2.krug_djelovanja.transform);
                }

            }



            // 3
            if (Vector3.Distance(glavna_loptica.transform.position, s3.krug_djelovanja.transform.position) < krug_djelovanja_stvarni / 2 && Input.GetMouseButton(0) && last_stap == 2)
            {
                glavna_loptica.GetComponent<Rigidbody>().useGravity = false; privucen = true; privucen3 = true;
                glavna_loptica.transform.position = Vector3.Lerp(glavna_loptica.transform.position, s3.krug_djelovanja.transform.position, 0.5f + (0.5f * (1 - (1 / 1.5f * (Vector3.Distance(glavna_loptica.transform.position, s3.krug_djelovanja.transform.position))))));
                if (Vector3.Distance(glavna_loptica.transform.position, s3.krug_djelovanja.transform.position) < 0.1f)
                {
                    glavna_loptica.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    glavna_loptica.transform.position = s3.krug_djelovanja.transform.position;
                    privucen_centar = true;
                    addscore();
                    glavna_loptica.transform.SetParent(s3.krug_djelovanja.transform);
                }

            }



            // 4
            if (Vector3.Distance(glavna_loptica.transform.position, s4.krug_djelovanja.transform.position) < krug_djelovanja_stvarni / 2 && Input.GetMouseButton(0) && last_stap == 3)
            {
                glavna_loptica.GetComponent<Rigidbody>().useGravity = false; privucen = true; privucen4 = true;
                glavna_loptica.transform.position = Vector3.Lerp(glavna_loptica.transform.position, s4.krug_djelovanja.transform.position, 0.5f + (0.5f * (1 - (1 / 1.5f * (Vector3.Distance(glavna_loptica.transform.position, s4.krug_djelovanja.transform.position))))));
                if (Vector3.Distance(glavna_loptica.transform.position, s4.krug_djelovanja.transform.position) < 0.1f)
                {
                    glavna_loptica.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    glavna_loptica.transform.position = s4.krug_djelovanja.transform.position;
                    privucen_centar = true;
                    addscore();
                    glavna_loptica.transform.SetParent(s4.krug_djelovanja.transform);
                }

            }



        }



        //kamera.transform.position = new Vector3((glavna_loptica.transform.position.x + 5), 0, -10);
        //if (Input.GetKeyDown("space"))

        


        cs.pokreni_kameru();
    }

    public void addscore()
    {
        if (click_check) screen_score_int++;
        click_check = false;
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator privuci_centar(GameObject koji_krug)
    {
        yield return new WaitForSeconds(nakon);
        glavna_loptica.transform.position = koji_krug.transform.position + new Vector3(0, 0, -0.1f);
    }



    // main
}
