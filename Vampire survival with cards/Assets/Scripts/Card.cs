using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public enum CardType
    {
        not_a_card = 0,
        magic_orb = 1,
        nr_of_cards = 2
    }


    protected GameObject player;
    protected PlayerController playerController;
    public int totalUses = 1;
    public int usesLeft = 1;

    public Card(){
        cardType = CardType.not_a_card;
    }

    void Awake()
    {
        print("Awake");
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }


    protected CardType cardType;

    public CardType getCardType() {
        return cardType;
    }

    public abstract void use();

}