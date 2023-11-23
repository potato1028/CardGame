using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DeckCheck_Red : MonoBehaviourPunCallbacks {
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D box2D;
    public DeckCheckManager DeckManager;

    public GameObject CardNode_Red;
    public GameObject MovePointNode;
    public GameObject ObstacleLocationNode;
    public GameObject DeckCheckManager;
    
    // public bool canInteract;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        box2D = GetComponent<BoxCollider2D>();
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
        // if(canInteract)
        DeckManager.CreateCard("R");
        
    }

    void DelayFindGameObject() {
        CardNode_Red = GameObject.Find("CheckedCard_Red");
        MovePointNode = GameObject.Find("MovePoint");        //역참조로 바꾸기
        ObstacleLocationNode = GameObject.Find("ObstacleLocationNode");
    }
}