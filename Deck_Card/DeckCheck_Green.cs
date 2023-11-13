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
    GameObject DeckCheckManager;
    
    public bool isDelay;
    public bool canInteract;

    public int BoutCard = 0;

    
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        box2D = GetComponent<BoxCollider2D>();

        isDelay = false;
        canInteract = !photonView.IsMine;
    }

    void Update() {
        if(DeckManager == null) {
            DeckCheckManager = GameObject.FindWithTag("DeckCheckManager");
            DeckManager = DeckCheckManager.GetComponent<DeckCheckManager>();
        }
        else {
            return;
        }

        if(MovePointNode == null) {
            DelayFindGameObject();
            Debug.Log("Waiting...");
        }
        else {
            if(MovePointNode.transform.childCount > 0 || ObstacleLocationNode.transform.childCount > 0) {
                box2D.enabled = false;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
            }
            else if((MovePointNode.transform.childCount < 1 && box2D.enabled != true && !isDelay) || (ObstacleLocationNode.transform.childCount < 1 && box2D.enabled != true && !isDelay)) {
                box2D.enabled = true;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            }
        }
    }

    private void OnMouseDown() {
        if(canInteract) {
            DeckManager.CreateCard('G');
        }
    }

    // IEnumerator DisableCard() {
    //     yield return new WaitForSeconds(0.5f);
    //     box2D.enabled = true;
    //     spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
    //     isDelay = false;
    // }

    void DelayFindGameObject() {
        CardNode_Green = GameObject.Find("CheckedCard_Green");
        MovePointNode = GameObject.Find("MovePoint");
        ObstacleLocationNode = GameObject.Find("ObstacleLocationNode");
    }
}