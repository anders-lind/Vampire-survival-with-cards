using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAbilities playerAbilities;
    [SerializeField] float speed = 4.0f;


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

        this.transform.position += movement * Time.deltaTime;


        //// ORIENTATION ////
        // UP
        if (movement.y > 0){
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        // DOWN
        if (movement.y < 0){
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        // RIGHT
        if (movement.x > 0){
            this.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        // LEFT
        if (movement.x < 0){
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        }


        //// ABILITY ////
        if (Input.GetKeyDown(KeyCode.Space)){
            print("use");
            playerAbilities.useAbility("magic orb");
        }
    }
}
