using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stap1 : MonoBehaviour
{
    private GameObject glavni_obj;
    private glavna_skripta gs;
    public float faktor_brzine;
    public int smijer = 1;
    private bool delay1 = true; 
    private bool delay2 = true;
    public GameObject krug_djelovanja;
    public bool kd_iskoristen;
    private int boik_smijer;

    private Vector3 sadpozicija;
    private Vector3 proslapozicija = new Vector3(0,0,0);
    public Vector3 brzina;

    private float imaginarni_ugao_stapa;
    private float imaginarni_ugao_prethodnog_stapa;

    

    void Start()
    {
        
        kd_iskoristen = false;
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();

        //krug_djelovanja = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        krug_djelovanja = Instantiate(gs.krug_djelovanja_prefab, new Vector3(0, 5, 0), Quaternion.identity) as GameObject;
        //krug_djelovanja.transform.localEulerAngles = new Vector3(0, 0, 360 - gs.max_ugao);
        krug_djelovanja.transform.localScale = new Vector3(gs.krug_djelovanja / 3, gs.krug_djelovanja / 3, 0.2f);
        krug_djelovanja.transform.position = transform.position - new Vector3(0, gs.duzina_stapova, 0);
        krug_djelovanja.transform.SetParent(transform);

        if (gs.broj_spawnovanih_stapova < 2) transform.localEulerAngles = new Vector3(0, 0, 360 - gs.max_ugao);

        transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(1).GetComponent<SphereCollider>().enabled = false;

        gs.broj_spawnovanih_stapova++;
        /*
        if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < gs.max_ugao + 1) {
        while (transform.localEulerAngles.z + 10 > gs.last_instantiate_stap.transform.localEulerAngles.z && transform.localEulerAngles.z - 10 < gs.last_instantiate_stap.transform.localEulerAngles.z) 
            { transform.localEulerAngles = new Vector3(0, 0, Random.Range(0.0f, gs.max_ugao)); }
        }

        if (transform.localEulerAngles.z < 360 && transform.localEulerAngles.z > gs.max_ugao - 1) {
            while (transform.localEulerAngles.z + 10 < gs.last_instantiate_stap.transform.localEulerAngles.z && transform.localEulerAngles.z - 10 > gs.last_instantiate_stap.transform.localEulerAngles.z)
            { transform.localEulerAngles = new Vector3(0,0,Random.Range((360 - gs.max_ugao), 360)); }
        }
        
        //while (transform.localEulerAngles.z + 10 > gs.last_instantiate_stap.transform.localEulerAngles.z && transform.localEulerAngles.z - 10 < gs.last_instantiate_stap.transform.localEulerAngles.z)
        if (gs.broj_spawnovanih_stapova != 1)
        {
        */
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(-gs.max_ugao, gs.max_ugao));
        /*
            if (transform.localEulerAngles.z < 360.1f && transform.localEulerAngles.z > 200) { transform.localEulerAngles = new Vector3(0, 0, 360 + transform.localEulerAngles.z); imaginarni_ugao_stapa = 360 + transform.localEulerAngles.z; }
            if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 91 || transform.localEulerAngles.z == 0) imaginarni_ugao_stapa = transform.localEulerAngles.z;

            if (gs.last_instantiate_stap.transform.localEulerAngles.z > 0 && gs.last_instantiate_stap.transform.localEulerAngles.z < 91 || gs.last_instantiate_stap.transform.localEulerAngles.z == 0) imaginarni_ugao_prethodnog_stapa = gs.last_instantiate_stap.transform.localEulerAngles.z;
            if (gs.last_instantiate_stap.transform.localEulerAngles.z < 360 && gs.last_instantiate_stap.transform.localEulerAngles.z > 200) imaginarni_ugao_prethodnog_stapa = 360 - gs.last_instantiate_stap.transform.localEulerAngles.z;

            if (imaginarni_ugao_stapa - gs.zabranjeni_ugao_spawna < imaginarni_ugao_prethodnog_stapa && imaginarni_ugao_stapa + gs.zabranjeni_ugao_spawna > imaginarni_ugao_prethodnog_stapa) transform.localEulerAngles += new Vector3(0, 0, gs.zabranjeni_ugao_spawna + 1);
            if (imaginarni_ugao_stapa + gs.zabranjeni_ugao_spawna > gs.max_ugao) transform.localEulerAngles -= new Vector3(0, 0, gs.zabranjeni_ugao_spawna + 2);
        }
        //if (gs.broj_spawnovanih_stapova ) 

        
        //Debug.Log(gs.broj_spawnovanih_stapova);
        
        //if (gs.broj_spawnovanih_stapova == 0 || gs.broj_spawnovanih_stapova == 1) transform.localEulerAngles = new Vector3(0,0,359-gs.max_ugao);
        //if (gs.broj_spawnovanih_stapova > 1 && transform.localEulerAngles.z + 10 > gs.last_instantiate_stap.transform.localEulerAngles.z && transform.localEulerAngles.z - 10 < gs.last_instantiate_stap.transform.localEulerAngles.z)

        else transform.localEulerAngles = new Vector3(0, 0, 359 - gs.max_ugao);
        //Debug.Log(transform.localEulerAngles);
        //Debug.Log("kurvo");

        
        */

    }

    void FixedUpdate()
    {
        if (!gs.ispaused)
        {

            sadpozicija = transform.GetChild(2).position;
            brzina = sadpozicija - proslapozicija;
            proslapozicija = sadpozicija;


            krug_djelovanja.transform.eulerAngles += new Vector3(0, 0, gs.boik * boik_smijer);
            //faktor brzine
            {
                if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 100) { faktor_brzine = (1 - (1 / gs.max_ugao) * transform.eulerAngles.z); }
                if (transform.eulerAngles.z > (360 - gs.max_ugao - 1) && transform.eulerAngles.z < 360) { faktor_brzine = (gs.max_ugao - (360 - transform.eulerAngles.z)) * (1 / gs.max_ugao); }
                if (faktor_brzine < 0) faktor_brzine = 0;
            }

            if (transform.eulerAngles.z > gs.max_ugao && transform.eulerAngles.z < 100 && delay1) { StartCoroutine(delay_vrha1()); delay2 = true; }
            if (transform.eulerAngles.z < (360 - gs.max_ugao) && transform.eulerAngles.z > 100 && delay2) { StartCoroutine(delay_vrha2()); delay1 = true; }
            {
                transform.eulerAngles += (new Vector3(0, 0, ((gs.brzina_stapovi * (0.01f * gs.postotak_usporavanja)) + ((100 - gs.postotak_usporavanja) * 0.01f * faktor_brzine * gs.brzina_stapovi))) * smijer * Time.deltaTime);
                //prethodni
                //transform.eulerAngles += (new Vector3(0, 0, faktor_brzine * ((gs.brzina_stapovi * (0.01f * gs.postotak_usporavanja))  )) * smijer * Time.deltaTime);
                //transform.eulerAngles += new Vector3(0,0,1) * smijer;
                //

            }

        }

    }


    IEnumerator delay_vrha1()
    {
        boik_smijer = -1;
        smijer = 0;
        yield return new WaitForSeconds(gs.vrh_wait_time);
        smijer = -1;
        delay1 = false;
    }
    IEnumerator delay_vrha2()
    {
        boik_smijer = 1;
        smijer = 0;
        yield return new WaitForSeconds(gs.vrh_wait_time);
        smijer = 1;
        delay2 = false;
    }














    //main
}
