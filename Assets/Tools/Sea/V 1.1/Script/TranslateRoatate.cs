using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranslateRoatate : MonoBehaviour
{
    [Range (10f,100f)] 
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }

        float xAxis = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zAxis = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if (!Input.GetButton("Jump"))
        {
            transform.Translate(new Vector3(xAxis, 0, zAxis));
        }
     
        if (Input.GetButton("Jump"))
        {
            transform.Translate(new Vector3(0, 0, 0));
        }
    }
}
