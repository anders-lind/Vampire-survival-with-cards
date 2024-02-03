using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CardManager cardManager;


    [SerializeField] float speed; 
    [SerializeField] int health;
    float damageFlashDuration = 0.1f;


    [SerializeField] private int experiance;

    Color damageFlashColor = new Color(0.8f, 0, 0);

    Vector3 previousDirection;
    private bool damageFlashing;
    private float damageFlashStartTime;
    


    // Update is called once per frame
    void Update()
    {
        //// HEALTH /////
        if (health <= 0){
            Destroy(this.gameObject);
        }


        //// Damage color flash ////
        if (damageFlashing){
            if (Time.time - damageFlashStartTime >= damageFlashDuration) {
                spriteRenderer.color = Color.white;
            }
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
        // 
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
            cardManager.selectCard(0);
        if (Input.GetKeyDown("2"))
            cardManager.selectCard(1);
        if (Input.GetKeyDown("3"))
            cardManager.selectCard(2);
        if (Input.GetKeyDown("4"))
            cardManager.selectCard(3);
        if (Input.GetKeyDown("5"))
            cardManager.selectCard(4);
        if (Input.GetKeyDown("6"))
            cardManager.selectCard(5);
        if (Input.GetKeyDown("7"))
            cardManager.selectCard(6);
        if (Input.GetKeyDown("8"))
            cardManager.selectCard(7);
        if (Input.GetKeyDown("9"))
            cardManager.selectCard(8);
        if (Input.GetKeyDown("0"))
            cardManager.selectCard(9);


        //// ABILITY ////
        if (Input.GetKeyDown(KeyCode.Space)){
            // playerAbilities.useAbility(cardManager.getSelectedCard(), previousDirection);
            cardManager.useSelectedCard();
        }
    
        //// DRAW CARD ////
        if (Input.GetKeyDown(KeyCode.F)){
            cardManager.drawRandomCard();
        }

    }

    public void takeDamage(int damage)
    {
        health -= damage;
        print(this.name + " health = " + health);
        beginDamageFlash();
    }

    public void gainExperiance(int exp)
    {
        experiance += exp;
        print("exp=" + experiance);
    }

    public Vector3 getPreviousDirection()
    {
        return previousDirection;
    }

    private void beginDamageFlash()
    {
        damageFlashing = true;
        damageFlashStartTime = Time.time;
        spriteRenderer.color = damageFlashColor;
    }
}
