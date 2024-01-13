using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject player;

    //// Abilities ////
    [SerializeField] GameObject cardMagicOrbPrefab;


    //// Card variables ////
    [SerializeField] List<GameObject> cardPrefabs;
    List<Card> deck = new();
    List<GameObject> hand = new();

    int selectedCard {set; get;} = -1;


    void Update()
    {
        for (int i = 0; i < hand.Count; i++){
            if (hand[i].GetComponent<Card>().usesLeft < 1)
                removeCardFromHand(i);
        }
    }

    public void removeCardFromHand(int cardNr)
    {
        if (cardNr == selectedCard)
            deselectCard();

        Destroy(hand[cardNr]);
        hand.RemoveAt(cardNr);

        for (int i = cardNr; i < hand.Count; i++){
            hand[i].transform.Translate(-1.1f, 0, 0);
        }
    }

    public void drawRandomCard()
    {
        print("drawRandomCard");

        int max = (int)Card.CardType.nr_of_cards;
        int cardNr = Random.Range(1,max);
        GameObject drawnCard;
        
        if (cardNr == (int) Card.CardType.magic_orb)
            drawnCard = GameObject.Instantiate(cardMagicOrbPrefab);
        else {
            print("Invalid card nr: " + cardNr);
            return;
        }

        addCardToHand(drawnCard);
    }

    void addCardToHand(GameObject card)
    {
        // Add to list
        hand.Add(card);

        // Add to hand
        card.transform.SetParent(Camera.main.transform, false);
        card.transform.Translate(-10 + 1.1f*(hand.Count-1), -4.15f, 0);
    }

    public void selectCard(int selection)
    {
        // Card number does not correlate to a card in hand
        if (selection+1 > hand.Count || selection < 0){
            print("You do not have " + (int)(selection+1) + " cards in your hand");
            return;
        }

        // Deselect card
        if (selection == selectedCard){
            deselectCard();
            return;
        }
            
        print("Selected Card " + selection);
        selectedCard = selection;
        
        // Update selection visually
        for (int i = 0; i < hand.Count; i++){
            hand[i].transform.localScale = new Vector3(1,1,1);
        }
        hand[selection].transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }

    public void deselectCard(){
        selectedCard = -1;

        for (int i = 0; i < hand.Count; i++){
            hand[i].transform.localScale = new Vector3(1,1,1);
        }
    }

    public void useSelectedCard()
    {
        // Card number does not correlate to a card in hand
        if (selectedCard < 0 || hand.Count < selectedCard){
            return;
        }

        hand[selectedCard].GetComponent<Card>().use();
    }
}
