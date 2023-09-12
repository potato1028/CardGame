using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Com.XxX {
    public class Manager : MonoBehaviourPunCallbacks {
        #region Private Serializable Fields

        #endregion

        #region Private Fields

        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 5;

        string gameVersion = "0";

       

        #endregion



        #region MonoBehaviour CallBacks

        void Awake() {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start() {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }

        #endregion

        #region Public Methods

        public void Connect() {
            

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

        #region MonoBehaviourPunCallbacks Callbacks

        public override void OnConnectedToMaster() {
            Debug.Log("PUN Basics Tutorial/Manager : OnConnectedToMaster() was called by  PUN");
            
            PhotonNetwork.JoinRandomRoom();
            
        }

        public override void OnDisconnected(DisconnectCause cause) {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);

            Debug.LogWarningFormat("PUN Basics Tutorial/Manager : OndDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message) {
            Debug.Log("PUN Basics Tutorial/Manager : OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom() {
            Debug.Log("PUN Basics Tutorial/Manager : OnJoinedRoom() called by PUN. Now this client is in a room.");
        }

        #endregion

        #region Public Fields

        [Tooltip("The UI Panel to let the user enter name, connet and play")]
        [SerializeField]
        private GameObject controlPanel;
        [Tooltip("The UI Label to inform the user that the connection is in progress")]
        [SerializeField]
        private GameObject progressLabel;

        #endregion

    }
}
