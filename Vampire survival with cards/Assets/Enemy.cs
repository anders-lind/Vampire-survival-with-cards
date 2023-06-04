using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float walkSpeed, attackCooldown, timeAtLastAttack;

    [SerializeField]
    int health, attack;

    SpriteRenderer spriteRenderer;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //// HEALTH ////
        if (health <= 0){
            Destroy(this.gameObject);
        }


        //// DIRECTION ////
        Vector3 direction = (player.transform.position - this.transform.position).normalized;


        //// MOVEMENT ////
        Vector3 movement = direction * walkSpeed * Time.deltaTime;
        this.transform.Translate(movement);


        //// ORIENTATION ////
        // RIGHT
        if (direction.x > 0){
            spriteRenderer.flipX = true;
        }
        // LEFT
        if (direction.x < 0){
            spriteRenderer.flipX = false;
        }
    }


    public void takeDamage(int damage)
    {
        health -= damage;
        print(this.name + " health = " + health);
    }


    void OnTriggerStay2D(Collider2D other)
    {
        float timeSinceLastAttack = Time.time - timeAtLastAttack;

        if (timeSinceLastAttack >= attackCooldown){
            
            if (other.gameObject.tag == "Player"){
                timeAtLastAttack = Time.time;
                other.GetComponent<PlayerController>().takeDamage(attack);
        }
        }
        
    }
}
