using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DelChild : MonoBehaviourPunCallbacks {
    void Update() {
        if(transform.childCount > 1) {
            Destroy(transform.GetChild(0).gameObject);
        }

        if(PhotonNetwork.CurrentRoom.PlayerCount <= 1 && transform.childCount > 1) {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}