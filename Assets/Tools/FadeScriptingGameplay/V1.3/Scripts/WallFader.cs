using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFader : MonoBehaviour
{
    /*    delegate void Mydele(int num, int num2);
        Mydele MyDelegate;*/

    /*    delegate void ColorChanger();
        ColorChanger ChangeCol;*/
    float speed = 1500f;
    Rigidbody rb;

    delegate void Fader();
    Fader FadeIin;

    delegate void Fader1();
    Fader1 FadeOout;

    Renderer rand;
    float fadeRate;
    bool status;



    void Start()
    {
        /*        MyDelegate = Sum;
        MyDelegate(4, 4);

        MyDelegate = multiply;
        MyDelegate(4, 4);*/

        /*        ChangeCol += PowerUp;
                ChangeCol += TurnRed;
                ChangeCol();*/

        rb = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        FadeIin += StartCoFadeIn;
        FadeOout += StartCoFadeOut;
    }

    private void OnDisable()
    {
        FadeIin -= StartCoFadeIn;
        FadeOout -= StartCoFadeOut;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }

    }

   
    IEnumerator FadeIn()
    {
        rand = GetComponent<Renderer>();
        Color color = rand.material.color;
        for (fadeRate = 1; fadeRate >= 0; fadeRate -= 0.1f)
        {
            color.a = fadeRate;
            rand.material.color = color;
            yield return new WaitForSeconds(0.1f);
            status = true;
        }
    }

    IEnumerator FadeOut()
    {
        rand = GetComponent<Renderer>();
        Color color = rand.material.color;
        for(fadeRate = 0; fadeRate <=1; fadeRate -= 0.1f)
        {
            color.a = fadeRate;
            rand.material.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void StartCoFadeIn()
    {
        StartCoroutine(FadeIn());
    }
    void StartCoFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Debug.Log("xhz");
            
            FadeIin?.Invoke();
            
            if (status == true)
            {


                FadeOout?.Invoke();
            }
            
        }
        
    }



    void PowerUp()
    {
        print("Player Power Up");
    }

    void TurnRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    void Sum(int operand1, int operand2)
    {
        int addition = operand1 + operand2;
        print("Addition: " + addition);
    }

    void multiply(int operand1, int operand2)
    {
        int multiply = operand1 * operand2;
        print("Multiply: " + multiply);
    }

}
