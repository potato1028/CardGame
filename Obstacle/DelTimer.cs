using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelTimer : MonoBehaviour {
    DeckCheck_Red deckR;
    DeckCheck_Green deckG;

    public GameObject[] Deck = new GameObject[2];

    public int[] CardNumber = new int[2];
    public int[] FirstNumber = new int[2];

    void Start() {
        Deck[0] = GameObject.Find("MainDeck_Red");
        Deck[1] = GameObject.Find("MainDeck_Green");

        deckR = Deck[0].GetComponent<DeckCheck_Red>();
        deckG = Deck[1].GetComponent<DeckCheck_Green>();

        FirstNumber[0] = deckR.BoutCard;
        FirstNumber[1] = deckG.BoutCard;

        FirstNumber[0] += 5;
        FirstNumber[1] += 5;
    }

    void Update() {
        if(FirstNumber[0] == deckR.BoutCard) {
            Destroy(gameObject);
        }
        if(FirstNumber[1] == deckG.BoutCard) {
            Destroy(gameObject);
        }
    }
}
