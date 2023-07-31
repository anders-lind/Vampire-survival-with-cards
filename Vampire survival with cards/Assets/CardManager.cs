using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum Card
{
    magic_orb = 0,
    nr_of_cards = 1
}

public class CardManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject player;

    //// Ability variables ////
    [SerializeField] GameObject magicOrbPrefab;
    [SerializeField] List<GameObject> magicOrbs = new List<GameObject>();
    [SerializeField] float randomSpread = 0.3f;


    //// Card variables ////
    [SerializeField] List<GameObject> cardPrefabs;

    List<Card> deck = new();
    List<Card> hand = new();

    int selectedCard {set; get;} = -1;

    public void drawRandomCard()
    {
        print("drawRandomCard");

        int max = (int)Card.nr_of_cards;
        int cardNr = Random.Range(0,max);
        Card drawnCard = (Card) cardNr;
        addCardToHand(drawnCard);
    }

    void addCardToHand(Card card)
    {
        print("addCardToHand: " + card);

        // Add to list
        hand.Add(card);

        // Add to hand
        GameObject goCard = GameObject.Instantiate(cardPrefabs[(int)card]);
        goCard.transform.SetParent(Camera.main.transform, false);
        goCard.transform.Translate(-10 + 1.1f*(hand.Count-1), -4.15f, 0);

        // Print
        print("Drew card: " + card);
    }

    public void setSelectedCard(int selection)
    {
        print("setSelectedCard: " + selection);
        selectedCard = selection;
        
        // TODO: Update selection visually
    }

    public void useSelectedCard()
    {
        print("useSelectedCard: " + selectedCard);

        if (selectedCard > hand.Count || selectedCard < 0){
            print(selectedCard);
            return;
        }

        if (hand[selectedCard] == Card.magic_orb) {
            Vector3 direction = playerController.getPreviousDirection();
            Vector3 randomDirection = new Vector3(direction.x + Random.Range(-randomSpread, randomSpread), direction.y + Random.Range(-randomSpread, randomSpread));
            Instantiate(magicOrbPrefab, player.transform.position + randomDirection*0.5f, Quaternion.FromToRotation(Vector3.up, randomDirection));
        }
        else {
            print("Invalid card: " + hand[selectedCard]);
        }
    }
}
