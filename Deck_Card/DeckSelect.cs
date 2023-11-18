using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DeckSelect : MonoBehaviourPunCallbacks {
    GameObject red;
    GameObject green;
    GameObject TurnCountNode;

    RedPlayer redPlayer;
    GreenPlayer greenPlayer;
    DelChild delChild;
    TurnCount turnCount;

    void Start() {
        red = GameObject.FindWithTag("RedPlayer");
        green = GameObject.FindWithTag("GreenPlayer");
        TurnCountNode = GameObject.FindWithTag("TurnCountNode");

        redPlayer = red.GetComponent<RedPlayer>();
        greenPlayer = green.GetComponent<GreenPlayer>();
        turnCount = TurnCountNode.GetComponent<TurnCount>();
    }

    public void OnMouseDown() {
        delChild = transform.parent.GetComponent<DelChild>();
        if(transform.parent.tag == "DeckCheckRed") {
            redPlayer.ExecuteCard(this.tag);
            delChild.DeleteChild();
        }
        else {
            greenPlayer.ExecuteCard(this.tag);
            delChild.DeleteChild();
        }
        turnCount.PlusCount();
    }
}