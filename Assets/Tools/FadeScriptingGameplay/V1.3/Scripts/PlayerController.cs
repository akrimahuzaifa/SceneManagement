using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 1500f;
    Rigidbody rb;
    AudioSource source;
    [SerializeField] AudioClip soundClip;

/*    int bellCount = 0;*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
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
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "wall")
        {
            source.clip = soundClip;

            InvokeRepeating("LoopSoundInvoke", (int)source.clip.length, (int)source.clip.length);
            //StartCoroutine(LoopSound(10, (int)source.clip.length, source));
            Destroy(collision.gameObject,0.1f);  
        }

    }

    int counter;

    void LoopSoundInvoke() 
    {
        if (counter < 3)
        {
            source.Play();
            counter++;
        }
        else 
        {
            CancelInvoke("LoopSoundInvoke");
        }
    }

    public IEnumerator LoopSound(int times, int secondsToWait, AudioSource source) 
    {
        for (int i = 0; i < times; i++)
        {
            source.Play();
            yield return new WaitForSeconds(secondsToWait);
        }
    }
}
