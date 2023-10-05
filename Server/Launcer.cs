using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame {
    public class Launcer : MonoBehaviourPunCallbacks {
        #region Private Serializable Fields

        [Tooltip("The maximum number of players per room. When a room is full, it cat't be joined by new players, and so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 2;

        #endregion


        #region Public Fields

        [Tooltip("The UI Panel to let the user enter name, connect and play")]
        [SerializeField]
        private GameObject controlPanel;
        [Tooltip("The UI Label to inform the user that the connection is in progress")]
        [SerializeField]
        private GameObject progressLabel;

        #endregion

        

        #region Private Fields

        string gameVersion = "0";

        bool isConnecting;

        #endregion


        #region MonoBehaviour CallBacks

        void Awake() {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start() {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }

        public override void OnConnectedToMaster() {
            if(isConnecting) {
                PhotonNetwork.JoinRandomRoom();
            }

            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        }

        public override void OnJoinRandomFailed(short returnCode, string message) {
            Debug.Log("PUN Basics Tutorial/Launcher : OnJoinRandomFailed() was called by PUN. No random available, so we create one.\nCalling : PhotonNetwork.CreateRoom");

            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom() {
            if(PhotonNetwork.CurrentRoom.PlayerCount == 1) {
                Debug.Log("We load the 'Room for 1' ");

                PhotonNetwork.LoadLevel("Room for 1");
            }
            
            Debug.Log("PUN Basics Tutorial/Launcher : OnJoinedRoom() called by PUN. Now this client is in a room.");
        }

        public override void OnDisconnected(DisconnectCause cause) {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        #endregion

        

        #region Public Methods

        public void Connect() {
            isConnecting = true;

            progressLabel.SetActive(true);
            controlPanel.SetActive(false);

            if(PhotonNetwork.IsConnected) {
                PhotonNetwork.JoinRandomRoom();
            }
            else {
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        #endregion


    }
}
