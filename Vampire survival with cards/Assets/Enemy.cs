using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 1;

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
}
