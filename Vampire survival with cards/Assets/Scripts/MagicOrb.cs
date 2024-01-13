using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    [SerializeField] public float speed = 8;
    [SerializeField] public float aliveTime = 3;
    [SerializeField] public int damage = 1;
    
    float startTime;


    void Start()
    {
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy"){
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }
}
