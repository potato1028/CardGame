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
        
        // void LoadArena() {
        //     if(!PhotonNetwork.IsMasterClient) {
        //         Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        //         return;
        //     }
        //     Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        //     PhotonNetwork.LoadLevel("Room for " + 1);
        // }
        
        #endregion


        void DestroyPlayers() {
            GameObject player_1 = GameObject.FindWithTag("playerOne");
            GameObject player_2 = GameObject.FindWithTag("playerTwo");

            Destroy(player_1);
            Destroy(player_2);
            
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.L)) {
                GameObject redPlayer = GameObject.FindWithTag("playerOne");

                PhotonView photonViewR = redPlayer.GetComponent<PhotonView>();
                if(photonViewR != null) {
                    string messageR = "PhotonView ID of RedPlayer : " + photonViewR.ViewID;
                    Debug.Log(messageR);
                    debugTextR.text = messageR;
                }
                else {
                    Debug.Log("no");
                }
                
                GameObject greenPlayer = GameObject.FindWithTag("playerTwo");

                PhotonView photonViewG = greenPlayer.GetComponent<PhotonView>();
                if(photonViewG != null) {
                    string messageG = "PhotonView ID of GreenPlayer : " + photonViewG.ViewID;
                    Debug.Log(messageG);
                    debugTextG.text = messageG;
                }
                else {
                    Debug.Log("no");
                }
                
            }
        }

    }
}