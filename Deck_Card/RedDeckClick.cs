using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RedDeckClick : MonoBehaviourPunCallbacks {
    [Header("Object")]
    public GameObject Manager;

    [Header("Script")]
    DeckManager deckManager;
    public BoxCollider2D box2D;
    public SpriteRenderer sp;

    [Header("Var")]
    Color currentColor;

    public void Start() {
        deckManager = Manager.GetComponent<DeckManager>();

        currentColor = sp.color;
        currentColor.a = 1;
        sp.color = currentColor;
        box2D.enabled = true;
    }

    public void OnMouseDown() {
        if(photonView.IsMine) {
            deckManager.SpawnCard("R");
        }
    }

    public void ChangeColor() {
        currentColor = sp.color;
        if(currentColor.a == 1) {
            currentColor.a = 0.2f;
        }
        else {
            currentColor.a = 1;
        }
        sp.color = currentColor;
    }
}