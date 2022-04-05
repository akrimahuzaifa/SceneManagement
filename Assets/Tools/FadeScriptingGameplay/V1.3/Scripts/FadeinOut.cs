using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeinOut : MonoBehaviour
{
    Renderer rand;
    float fadeRate;
    bool status;

    // Start is called before the first frame update
    void Start()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }


        if (status)
        {
            StartCoroutine(FadeOut());
            status = false;
        }


        //----------Logic in building--------------------------
        /*        if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(FadeIn());
                }
                if (status == true)
                {
                    StartCoroutine(FadeOut());
                    status = false;
                }*/

        //--------------Logic in building---------------------------------------



        //========RayCast MousePointer=========================
        /*        if (status2 == true)
                {
                    if (status == true)
                    {
                        StartCoroutine(FadeIn());
                        StopCoroutine(FadeIn());
                        status = false;
                        status2 = true;
                    }

                    else if (status == false)
                    {
                        StartCoroutine(FadeOut());
                        StopCoroutine(FadeOut());
                        status = true;
                        status2 = false;
                    }

                }*/
        //========RayCast MousePointer=========================







        //------Keys Ooperations one by one----------------------
        /*        if (Input.GetKeyDown("i"))
                {
                    StartCoroutine(FadeIn());  
                }
                else if (Input.GetKeyDown("o"))
                {
                    StartCoroutine(FadeOut());
                }*/
        //------------Keys Ooperations one by one----------------------


        //========RayCast MousePointer=========================
        /*        if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Debug.Log(status);
                    Debug.DrawRay(transform.position, Vector3.forward * );
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(ray);
                        Debug.Log(hit);
                        if (hit.transform.name == "Cube")
                        {

        *//*                    status = true;
                            status2 = true;*//*
                        }
                    }
                }*/
        //========RayCast MousePointer=========================
    }
    GameObject objToFind;

    private void OnMouseDown()
    {
        objToFind = GameObject.FindGameObjectWithTag("Cube");
        Debug.Log("The (\"" + objToFind.name + "\") is Clicked");
       
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        rand = GetComponent<Renderer>();
        Color c = rand.material.color;
        fadeRate = 1f;
        for (fadeRate = 1f; fadeRate >= 0f; fadeRate -= 0.1f)
        {
            c.a = fadeRate;
            rand.material.color = c;
            Debug.Log("FadeIn");
            yield return new WaitForSeconds(0.05f);
        }
        status = true;
    }
    IEnumerator FadeOut()
    {
        rand = GetComponent<Renderer>();
        Color c = rand.material.color;
        for (fadeRate = 0; fadeRate <= 1f; fadeRate += 0.1f)
        {
            c.a = fadeRate;
            rand.material.color = c;
            Debug.Log("FadeOut");            
            yield return new WaitForSeconds(0.05f);
        }
    }
}
