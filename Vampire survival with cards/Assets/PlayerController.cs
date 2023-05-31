using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerAbilities playerAbilities;
    [SerializeField] float speed = 4.0f;
    Vector3 direction;
    Vector3 previousDirection;


    // Update is called once per frame
    void Update()
    {
        //// MOVEMENT ////
        Vector3 movement = Vector3.zero;
        
        // UP
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)){
            movement += new Vector3(0, speed, 0);
        }

        // LEFT
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
            movement += new Vector3(-speed, 0, 0);
        }

        // DOWN
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)){
            movement += new Vector3(0, -speed, 0);
        }

        // RIGHT
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
            movement += new Vector3(speed, 0, 0);
        }

        // Apply movement
        this.transform.position += movement * Time.deltaTime;
        
        // Set direction
        if (movement.magnitude != 0){
            direction = movement.normalized;
            previousDirection = direction;
        }
        else {
            direction = previousDirection;
        }
        


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
            print("use");
            playerAbilities.useAbility("magic orb", direction);
        }
    }
}
