using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CardTagToss : MonoBehaviourPunCallbacks {

    RedMove redSc;
    GreenMove greenSc;

    public void OnMouseDown() {
        if(transform.parent.tag == "RedPlayer" && photonView.IsMine) {
            redSc = transform.parent.GetComponent<RedMove>();
            redSc.CardTagCheck(this.tag);
        }
        else {
            greenSc = transform.parent.GetComponent<GreenMove>();
            greenSc.CardTagCheck(this.tag);
        }
    }
}