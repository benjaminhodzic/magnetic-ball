using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    public Transform glavna_loptica;

    public float smoothspeed = 10;
    public Vector3 offset = new Vector3(0,0,-10);

    private void Start()
    {
        //smoothspeed = 1000f;
        smoothspeed = 3000f;
    }

    /*
    private void LateUpdate()
    {
        Vector3 desiredposition = glavna_loptica.position + offset;
        //Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, 0.25f );
        //if (transform.position.x < (smoothedposition.x + 5)) 
        {
            transform.position = new Vector3(smoothedposition.x + 1, 0, -10);
        }


    }
    */

    public void pokreni_kameru()
    {
        Vector3 desiredposition = glavna_loptica.position + offset;
        //Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, 0.15f);
        //if (transform.position.x < (smoothedposition.x + 5)) 
        {
            transform.position = new Vector3(smoothedposition.x + 0.75f, 0, -10);
        }
    }


















}
