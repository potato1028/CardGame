using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSelect : MonoBehaviour {
    GameObject red;
    GameObject green;

    RedPlayer redPlayer;
    GreenPlayer greenPlayer;
    DelChild delChild;

    void Start() {
        red = GameObject.FindWithTag("RedPlayer");
        green = GameObject.FindWithTag("GreenPlayer");

        redPlayer = red.GetComponent<RedPlayer>();
        greenPlayer = green.GetComponent<GreenPlayer>();
        delChild = transform.parent.GetComponent<DelChild>();
    }

    public void OnMouseDown() {
        if(transform.parent.tag == "DeckCheckRed") {
            redPlayer.ExecuteCard(this.tag);
            delChild.DeleteChild();
        }
        else {
            greenPlayer.ExecuteCard(this.tag);
            delChild.DeleteChild();
        }
    }
}
