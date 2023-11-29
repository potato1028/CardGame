using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RedMove : MonoBehaviourPunCallbacks {

    [Header("Object")]
    public GameObject RedDeck;
    public GameObject GreenDeck;
    public GameObject Enemy;

    [Header("Script")]
    public PhotonView pv;
    public RedDeckClick redDC;
    public GreenDeckClick greenDC;

    [Header("Prefab")]
    public GameObject MovePoint;
    public GameObject Button;

    [Header("Var")]
    PhotonView childViewID;
    Vector2 newPosition;
    private bool isDouble = false;
    private PhotonView ButtonID;
    string currentTag;

    void Start() {
        redDC = RedDeck.GetComponent<RedDeckClick>();
        greenDC = GreenDeck.GetComponent<GreenDeckClick>();
    }

    public void CardTagCheck(string cardTag) {
        if(isDouble) {
            isDouble = false;
        }
        currentTag = cardTag;
        switch(cardTag) {
            case "MoveUp" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "MoveDown" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "MoveLeff" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "MoveRight" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "LuDia" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "RuDia" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "LdDia" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "RdDia" :
                pv.RPC(cardTag, RpcTarget.All);
            break;

            case "MoveDouble" :
                MoveDouble();
            break;
            
            case "MoveUDLR" :
                MoveUDLR();
            break;

            case "MoveEdge" :
                MoveEdge();
            break;

            case "MoveBishop" :
                MoveBishop();
            break;

            case "MoveRook" :
                MoveRook();
            break;

            case "MoveQueen" :
                MoveQueen();
            break;

            case "MoveKnight" :
                MoveKnight();
            break;
        }
    }


    [PunRPC]
    public void MoveUp() {
        if(transform.position.y >= 7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x, transform.position.y + 1f);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }

    [PunRPC]
    public void MoveDown() {
        if(transform.position.y <= -7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x, transform.position.y - 1f);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }

    [PunRPC]
    public void MoveLeft() {
        if(transform.position.x <= -7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x - 1f, transform.position.y);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }

    [PunRPC]
    public void MoveRight() {
        if(transform.position.x >= 7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x + 1f, transform.position.y);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }

    [PunRPC]
    public void LuDia() {
        if(transform.position.y == 7 || transform.position.x == -7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x - 1f, transform.position.y + 1f);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }

    [PunRPC]
    public void RuDia() {
        if(transform.position.y == 7 || transform.position.x == 7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x + 1f, transform.position.y + 1f);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }

    [PunRPC]
    public void LdDia() {
        if(transform.position.y == -7 || transform.position.x == -7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x - 1f, transform.position.y - 1f);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }
    
    [PunRPC]
    public void RdDia() {
        if(transform.position.y == -7 || transform.position.x == 7) {
            Debug.Log("Course Block!");
        }
        else {
            newPosition = new Vector2(transform.position.x + 1f, transform.position.y - 1f);
            transform.position = newPosition;
        }

        if(isDouble) {
            CardTagCheck(currentTag);
        }
    }

    public void MoveDouble() {
        isDouble = true;
    }

    public void MoveUDLR() {
    }

    public void MoveEdge() {
    }

    public void MoveBishop() {
    }

    public void MoveRook() {
    }

    public void MoveQueen() {
    }

    public void MoveKnight() {
    }


    #region Deck

    #endregion
}