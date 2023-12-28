using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{

    private GameObject glavni_obj;
    private glavna_skripta gs;
    private GameObject loptica;
    public Canvas gameover_canvas;

    private bool lerp_bool = false;
    private int lerp_broj_djelovanja = 0;





    void Start()
    {
        glavni_obj = GameObject.Find("glavni_obj");
        loptica = GameObject.Find("loptica");
        gs = glavni_obj.GetComponent<glavna_skripta>();
        gameover_canvas.enabled = false;






    }

    void Update()
    {
        lerp_funkcija();







    }

    private void OnCollisionEnter(Collision collision)
    {
        gameover_canvas.enabled = true;





    }

    public void revive_button()
    {
        gs.ispaused = true;
        loptica.GetComponent<Rigidbody>().useGravity = false;
        if (gs.last_stap == 1) { lerp_broj_djelovanja = 1; lerp_bool = true; }
        if (gs.last_stap == 2) { lerp_broj_djelovanja = 2; lerp_bool = true; }
        if (gs.last_stap == 3) { lerp_broj_djelovanja = 3; lerp_bool = true; }
        if (gs.last_stap == 4) { lerp_broj_djelovanja = 4; lerp_bool = true; }
        gameover_canvas.enabled = false;
    }

    public void continue_button()
    {
        gs.restart();
    }

    private void lerp_funkcija()
    {
        if (lerp_bool)
        {
            if (lerp_broj_djelovanja == 1)
            {
                loptica.transform.position = Vector3.Lerp(loptica.transform.position, gs.s1.transform.GetChild(4).position, 0.25f);
                if (Vector3.Distance(loptica.transform.position, gs.s1.transform.GetChild(4).position) < 0.01f) { lerp_bool = false; gs.privucen_centar = true; gs.privucen = true; gs.privucen1 = true; gs.ispaused = false; loptica.transform.SetParent(gs.s1.krug_djelovanja.transform); }
            }
            if (lerp_broj_djelovanja == 2)
            {
                loptica.transform.position = Vector3.Lerp(loptica.transform.position, gs.s2.transform.GetChild(4).position, 0.25f);
                if (Vector3.Distance(loptica.transform.position, gs.s2.transform.GetChild(4).position) < 0.01f) { lerp_bool = false; gs.privucen_centar = true; gs.privucen = true; gs.privucen2 = true; gs.ispaused = false; loptica.transform.SetParent(gs.s2.krug_djelovanja.transform); }
            }
            if (lerp_broj_djelovanja == 3)
            {
                loptica.transform.position = Vector3.Lerp(loptica.transform.position, gs.s3.transform.GetChild(4).position, 0.25f);
                if (Vector3.Distance(loptica.transform.position, gs.s3.transform.GetChild(4).position) < 0.01f) { lerp_bool = false; gs.privucen_centar = true; gs.privucen = true; gs.privucen3 = true; gs.ispaused = false; loptica.transform.SetParent(gs.s3.krug_djelovanja.transform); }
            }
            if (lerp_broj_djelovanja == 4)
            {
                loptica.transform.position = Vector3.Lerp(loptica.transform.position, gs.s4.transform.GetChild(4).position, 0.25f);
                if (Vector3.Distance(loptica.transform.position, gs.s4.transform.GetChild(4).position) < 0.01f) { lerp_bool = false; gs.privucen_centar = true; gs.privucen = true; gs.privucen4 = true; gs.ispaused = false; loptica.transform.SetParent(gs.s4.krug_djelovanja.transform); }
            }

        }










    }

}
