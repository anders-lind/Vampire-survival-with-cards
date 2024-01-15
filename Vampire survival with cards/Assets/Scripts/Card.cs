using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public enum CardType
    {
        not_a_card = 0,
        magic_orb,
        fireball,
        nr_of_cards
    }


    protected GameObject player;
    protected PlayerController playerController;
    protected GameObject projectilePrefab;
    public int totalUses = 1;
    public int usesLeft = 1;

    public Card(){
        cardType = CardType.not_a_card;
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }


    protected CardType cardType;

    public CardType getCardType() {
        return cardType;
    }

    public abstract void use();

    public GameObject shootProjectile(float spread = 0f)
    {
        usesLeft -= 1;

        Vector3 direction = playerController.getPreviousDirection();
        Vector3 randomDirection = new Vector3(direction.x + Random.Range(-spread, spread), direction.y + Random.Range(-spread, spread));
        
        return Instantiate(projectilePrefab, player.transform.position + randomDirection*0.5f, Quaternion.FromToRotation(Vector3.up, randomDirection));
    }

}