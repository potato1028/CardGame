using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelTimer : MonoBehaviour {
    DeckCheck deck;

    public GameObject Deck;

    public int CardNumber;
    public int FirstNumber;

    void Start() {
        Deck = GameObject.Find("MainDeck");

        deck = Deck.GetComponent<DeckCheck>();

        FirstNumber = deck.BoutCard;

        FirstNumber += 5;
    }

    void Update() {
        if(FirstNumber == deck.BoutCard) {
            Destroy(gameObject);
        }
    }
}
