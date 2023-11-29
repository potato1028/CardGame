using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DeckManager : MonoBehaviourPunCallbacks {
    [Header("Object")]
    public GameObject RedPlayer;
    public GameObject GreenPlayer;
    public GameObject[] NormalCard = new GameObject[8];

    [Header("Script")]
    RedMove redPlayer;
    GreenMove greenPlayer;

    [Header("Var")]
    public int TurnCount;
    public PhotonView pv;
    const int LenCard = 15;

    [Header("CardVar")]
    private int[] RandomNumber = new int[3];
    private PhotonView[] cardPhotonView = new PhotonView[3];
    private int locate;
    private string CardPrefab;
    private GameObject[] card = new GameObject[3];

    public void Start() {
        redPlayer = RedPlayer.GetComponent<RedMove>();
        greenPlayer = GreenPlayer.GetComponent<GreenMove>();
        pv = this.GetComponent<PhotonView>();
    }

    public void SpawnCard(string player) {
        locate = -20;
        for(int i = 0; i < 3; i++) {
            RandomNumber[i] = Random.Range(0, LenCard);
            card[i] = PhotonNetwork.Instantiate("Cards/NormalCard/" + NormalCard[RandomNumber[i]].name, new Vector3(locate, -18, 0), Quaternion.identity);
            locate += 20;
        }
        pv.RPC("SpawnCardParent", RpcTarget.All, player);
    }

    [PunRPC]
    void SpawnCardParent(string who) {
        switch(who) {
            case "R" :
                for(int i = 0; i < 3; i++) {
                    cardPhotonView[i] = PhotonView.Find(card[i].GetPhotonView().ViewID);
                    cardPhotonView[i].gameObject.transform.parent = RedPlayer.transform;
                }
            break;
            case "G" :
                for(int i = 0; i < 3; i++) {
                    cardPhotonView[i] = PhotonView.Find(card[i].GetPhotonView().ViewID);
                    cardPhotonView[i].gameObject.transform.parent = GreenPlayer.transform;
                }
            break;
        }
    }
}