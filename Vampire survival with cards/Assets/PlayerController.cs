using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerAbilities playerAbilities;


    [SerializeField] float speed; 
    [SerializeField] int health;

    Vector3 previousDirection;


    // Update is called once per frame
    void Update()
    {
        //// HEALTH /////
        if (health <= 0){
            Destroy(this.gameObject);
        }


        //// DIRECTION ////
        Vector3 direction = Vector3.zero;

        // UP
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)){
            direction += new Vector3(0, 1, 0);
        }
        // LEFT
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
            direction += new Vector3(-1, 0, 0);
        }
        // DOWN
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)){
            direction += new Vector3(0, -1, 0);
        }
        // RIGHT
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
            direction += new Vector3(1, 0, 0);
        }

        if (direction.magnitude != 0){
            direction = direction.normalized;
            previousDirection = direction;
        }


        //// MOVEMENT ////
        transform.position += direction * speed * Time.deltaTime;
        

        //// ORIENTATION ////
        // RIGHT
        if (direction.x > 0){
            spriteRenderer.flipX = true;
        }
        // LEFT
        if (direction.x < 0){
            spriteRenderer.flipX = false;
        }


        //// ABILITY ////
        if (Input.GetKeyDown(KeyCode.Space)){
            playerAbilities.useAbility("magic orb", previousDirection);
        }
    }


    public void takeDamage(int damage)
    {
        health -= damage;
        print(this.name + " health = " + health);
    }
}
