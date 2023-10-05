using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame {
    public class GameManager : MonoBehaviourPunCallbacks {
        #region Photon Callbacks

        public override void OnPlayerEnteredRoom(Player other) {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName);

            if(PhotonNetwork.IsMasterClient) {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}",PhotonNetwork.IsMasterClient);

                LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Player other){
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName);

            if(PhotonNetwork.IsMasterClient) {

                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

                LoadArena();
            }
        }

        public override void OnLeftRoom() {
            SceneManager.LoadScene(0);
        }

        #endregion


        #region Public Methods

        public void LeaveRoom() {
            PhotonNetwork.LeaveRoom();
        }

        #endregion


        #region Private Methods
        
        void LoadArena() {
            if(!PhotonNetwork.IsMasterClient) {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
                return;
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
        }
        #endregion
    }
}