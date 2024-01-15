using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour
{
    public float speed = 8;
    public float aliveTime = 3;
    public int damage = 1;
    
    float startTime;


    protected void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    protected void Update()
    {
        this.transform.position += speed * this.transform.up * Time.deltaTime;

        if (Time.time - startTime  > aliveTime){
            Destroy(this.gameObject);
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy"){
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }
}
