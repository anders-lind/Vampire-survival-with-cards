using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 1, attackCooldown = 1;
    float damageFlashDuration = 0.1f;

    [SerializeField]
    int health = 1, attack = 1;

    float timeAtLastAttack = 0;
    float damageFlashStartTime = 0;
    bool damageFlashing = false;
    bool isDead = false;

    Color damageFlashColor = new Color(0.8f, 0f, 0f);
    Color deadColor = new Color(0.2f, 0.2f, 0.2f);

    SpriteRenderer spriteRenderer;
    GameObject player;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead){
            return;
        }
        //// HEALTH ////
        if (health <= 0){
            Die();
        }

        //// MOVEMENT ////
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
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

        //// Damage color flash ////
        if (damageFlashing){
            if (Time.time - damageFlashStartTime >= damageFlashDuration) {
                spriteRenderer.color = Color.white;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        beginDamageFlash();

        if (health <= 0){
            Die();
        }
    }

    private void beginDamageFlash()
    {
        damageFlashing = true;
        damageFlashStartTime = Time.time;
        spriteRenderer.color = damageFlashColor;
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (isDead){
            return;
        }
        float timeSinceLastAttack = Time.time - timeAtLastAttack;

        if (timeSinceLastAttack >= attackCooldown){
            
            if (other.gameObject.tag == "Player"){
                timeAtLastAttack = Time.time;
                other.GetComponent<PlayerController>().takeDamage(attack);
            }   
        }
    }

    void Die()
    {
        isDead = true;
        playerController.gainExperiance(1);
        spriteRenderer.color = deadColor;
        // Destroy(this.gameObject);
    }
}
