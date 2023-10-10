using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame {
    public class PlayerManager : MonoBehaviourPun {
        #region MonoBehaviour Callbacks

        void Update() {
            if(photonView.IsMine == false && PhotonNetwork.IsConnected == true) {
                return;
            }
        }

        #endregion
    }
}