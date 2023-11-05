using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

namespace Com.MyCompany.MyGame {
    public class GameManager : MonoBehaviourPunCallbacks {
        
        #region Public Variables

        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerOnePrefab;
        public GameObject playerTwoPrefab;

        public Text debugTextR;
        public Text debugTextG;

        string currentSceneName;


        #endregion


        #region Photon Callbacks

        public override void OnPlayerEnteredRoom(Player other) {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName);

            if(PhotonNetwork.IsMasterClient) {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}",PhotonNetwork.IsMasterClient);
            }

            if(PhotonNetwork.CurrentRoom.PlayerCount == 2) {
                PhotonNetwork.Instantiate(this.playerOnePrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(this.playerTwoPrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
            }
            else {
                Debug.Log("Player Not Enough");
            }

        }

        public override void OnPlayerLeftRoom(Player other){
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName);

            if(PhotonNetwork.IsMasterClient) {

                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

            }

            DestroyPlayers();
        }

        public override void OnLeftRoom() {
            SceneManager.LoadScene(0);

            DestroyPlayers();
        }

        #endregion


        #region Public Methods

        public void LeaveRoom() {
            PhotonNetwork.LeaveRoom();
        }

        #endregion


        #region Private Methods
        
        #endregion


        void DestroyPlayers() {
            GameObject player_1 = GameObject.FindWithTag("playerOne");
            GameObject player_2 = GameObject.FindWithTag("playerTwo");

            Destroy(player_1);
            Destroy(player_2);
            
        }

    }
}