using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.LookAt(player);
    }
}
