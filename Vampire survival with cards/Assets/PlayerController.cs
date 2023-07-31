using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerAbilities playerAbilities;
    [SerializeField] CardManager cardManager;


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


        //// CHOOSE CARD ////
        if (Input.GetKeyDown("1"))
            cardManager.setSelectedCard(0);
        if (Input.GetKeyDown("2"))
            cardManager.setSelectedCard(1);
        if (Input.GetKeyDown("3"))
            cardManager.setSelectedCard(2);
        if (Input.GetKeyDown("4"))
            cardManager.setSelectedCard(3);
        if (Input.GetKeyDown("5"))
            cardManager.setSelectedCard(4);
        if (Input.GetKeyDown("6"))
            cardManager.setSelectedCard(5);
        if (Input.GetKeyDown("7"))
            cardManager.setSelectedCard(6);
        if (Input.GetKeyDown("8"))
            cardManager.setSelectedCard(7);
        if (Input.GetKeyDown("9"))
            cardManager.setSelectedCard(8);
        if (Input.GetKeyDown("0"))
            cardManager.setSelectedCard(9);


        //// ABILITY ////
        if (Input.GetKeyDown(KeyCode.Space)){
            // playerAbilities.useAbility(cardManager.getSelectedCard(), previousDirection);
            cardManager.useSelectedCard();
            cardManager.drawRandomCard();
        }

    }

    public void takeDamage(int damage)
    {
        health -= damage;
        // print(this.name + " health = " + health);
    }

    public Vector3 getPreviousDirection()
    {
        return previousDirection;
    }
}
