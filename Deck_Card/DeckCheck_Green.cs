using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DeckCheck_Green : MonoBehaviourPunCallbacks {
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D box2D;
    public DeckCheckManager DeckManager;

    public GameObject CardNode_Green;
    public GameObject MovePointNode;
    public GameObject ObstacleLocationNode;
    public GameObject DeckCheckManager;
    
    public bool canInteract;
    
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        box2D = GetComponent<BoxCollider2D>();

        canInteract = !photonView.IsMine;
    }

    void Update() {
        if(DeckManager == null) {
            DeckCheckManager = GameObject.FindWithTag("DeckCheckManager");
            DeckManager = DeckCheckManager.GetComponent<DeckCheckManager>();  //역참조로 바꾸기
        }
        else {
            return;
        }

        if(MovePointNode == null) {
            DelayFindGameObject();
            Debug.Log("Waiting...");
        }
    }

    private void OnMouseDown() {
        if(canInteract) {
            DeckManager.CreateCard("G");
        }
    }

    void DelayFindGameObject() {
        CardNode_Green = GameObject.Find("CheckedCard_Green");
        MovePointNode = GameObject.Find("MovePoint");   //역참조로 바꾸기
        ObstacleLocationNode = GameObject.Find("ObstacleLocationNode");
    }
}