using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DelChild : MonoBehaviourPunCallbacks {
    public void DeleteChild() {
        foreach(Transform child in transform) {
            PhotonNetwork.Destroy(child.gameObject);
        }
    }
}