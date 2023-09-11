using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Manager : MonoBehaviourPunCallbacks {
    public Text StatusText;
    public InputField NickNameInput;
    public GameObject Cube;
    public string gameVersion = "0.1";

    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start() {
        PhotonNetwork.GameVersion = this.gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    override public void OnConnectedToMaster() {
        PhotonNetwork.JoinRandomRoom();
    }

    override public void OnJoinedRoom() {
        PhotonNetwork.Instantiate("Player2", Cube.transform.position, Quaternion.identity);
    }

    override public void OnJoinRandomFailed(short returnCode, string message) {
        this.CreateRoom();
    }

    public void CreateRoom() {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 5 });
    }
}
