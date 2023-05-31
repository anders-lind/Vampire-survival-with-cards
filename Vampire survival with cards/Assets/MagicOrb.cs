using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    [SerializeField] float speed = 8;
    [SerializeField] float aliveTime = 3.0f;    // seconds
    
    float startTime;


    void Start()
    {
        print("A");
        startTime = Time.time;
    }




    // Update is called once per frame
    void Update()
    {
        this.transform.position += speed * this.transform.up * Time.deltaTime;

        if (Time.time - startTime  > aliveTime){
            Destroy(this.gameObject);
        }

    }
}
