using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private shake shake;
    public GameObject left_arm;
    public GameObject right_arm;
    Collider fistL;
    Collider fistR;
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
        fistL = left_arm.GetComponent<Collider>();
        fistR = right_arm.GetComponent<Collider>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
