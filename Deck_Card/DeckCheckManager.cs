using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DeckCheckManager : MonoBehaviourPunCallbacks {
    [Header("Deck")]
    GameObject RD;
    GameObject GD;
    DeckCheck_Red redDeck;
    DeckCheck_Green greenDeck;

    [Header("Player")]
    GameObject RP;
    GameObject GP;
    RedPlayer redPlayer;
    GreenPlayer greenPlayer;

    [Header("Node")]
    public GameObject CardNode_Red;
    public GameObject CardNode_Green;
    public GameObject MovePointNode;
    public GameObject ObstacleLocationNode;

    [Header("Card")]
    public GameObject MoveUpPrefab;
    public GameObject MoveDownPrefab;
    public GameObject MoveLeftPrefab;
    public GameObject MoveRightPrefab;

    public GameObject LuDiaPrefab;
    public GameObject LdDiaPrefab;
    public GameObject RuDiaPrefab;
    public GameObject RdDiaPrefab;

    public GameObject UDLRPrefab;
    public GameObject MEdgePrefab;
    public GameObject DoublePrefab;
    public GameObject KinghtPrefab;
    public GameObject RookPrefab;
    public GameObject BishopPrefab;
    public GameObject QueenPrefab;

    public GameObject BindPrefab;
    public GameObject EnemyCardCheckPrefab;
    public GameObject ObstaclePrefab;
    public GameObject ScoreUpPrefab;
    public GameObject SideTelPrefab;

    public GameObject TelEnemyRandomPrefab;
    public GameObject ChangeLocationPrefab;
    public GameObject InvertionPrefab;
    public GameObject RandomLocationPrefab;
    public GameObject GhostPlayerPrefab;

    [Header("Variable")]
    private const int LenCard = 25;
    private GameObject[] Cards;

    private void Start() {
        RP = GameObject.FindWithTag("RedPlayer");
        GP = GameObject.FindWithTag("GreenPlayer");

        RD = GameObject.FindWithTag("playerOne");
        GD = GameObject.FindWithTag("playerTwo");

        redPlayer = RP.GetComponent<RedPlayer>();
        greenPlayer = GP.GetComponent<GreenPlayer>();

        redDeck = RD.GetComponent<DeckCheck_Red>();
        greenDeck = GD.GetComponent<DeckCheck_Green>();

        CardNode_Red = GameObject.FindWithTag("DeckCheckRed");
        CardNode_Green = GameObject.FindWithTag("DeckCheckGreen");

        MovePointNode = GameObject.Find("MovePoint");
        ObstacleLocationNode = GameObject.Find("ObstacleLocationNode");

        Cards = new GameObject[LenCard];

        Cards[0] = MoveUpPrefab;
        Cards[1] = MoveDownPrefab;
        Cards[2] = MoveLeftPrefab;
        Cards[3] = MoveRightPrefab;
        Cards[4] = LuDiaPrefab;
        Cards[5] = LdDiaPrefab;
        Cards[6] = RuDiaPrefab;
        Cards[7] = RdDiaPrefab;

        Cards[8] = UDLRPrefab;
        Cards[9] = MEdgePrefab;
        Cards[10] = DoublePrefab;
        Cards[11] = KinghtPrefab;
        Cards[12] = RookPrefab;
        Cards[13] = BishopPrefab;
        Cards[14] = QueenPrefab;

        Cards[15] = BindPrefab;
        Cards[16] = EnemyCardCheckPrefab;
        Cards[17] = ObstaclePrefab;
        Cards[18] = ScoreUpPrefab;
        Cards[19] = SideTelPrefab;

        Cards[20] = TelEnemyRandomPrefab;
        Cards[21] = ChangeLocationPrefab;
        Cards[22] = InvertionPrefab;
        Cards[23] = RandomLocationPrefab;
        Cards[24] = GhostPlayerPrefab;

        ContactPlayer();
    }

    public void CreateCard(string Player) {
        int[] RandomNumber = new int[3];
        int locate = -25;
        for(int i = 0; i < 3; i++) {
            RandomNumber[i] = Random.Range(0, LenCard);
        }

        SqawnCards(Player, RandomNumber, locate);
    }
    
    void SqawnCards(string Player, int[] RandomNumber, int locate) {
        switch(Player) {
            case "R" :
                SqawnCardsHelper(RandomNumber, locate, CardNode_Red);
                redDeck.box2D.enabled = false;
                redDeck.spriteRenderer.color = new Color(redDeck.spriteRenderer.color.r, redDeck.spriteRenderer.color.g, redDeck.spriteRenderer.color.b, 0.5f);
                break;

            case "G" :
                SqawnCardsHelper(RandomNumber, locate, CardNode_Green);
                greenDeck.box2D.enabled = false;
                greenDeck.spriteRenderer.color = new Color(greenDeck.spriteRenderer.color.r, greenDeck.spriteRenderer.color.g, greenDeck.spriteRenderer.color.b, 0.5f);
                break;
        }
    }

    void SqawnCardsHelper(int[] RandomNumber, int locate, GameObject Parent) {
        for(int i = 0; i < 3; i++) {
            GameObject newCard = PhotonNetwork.Instantiate(Cards[RandomNumber[i]].name, new Vector3(locate, -20, 0), Quaternion.identity);
            photonView.RPC("CardsParent", RpcTarget.All, newCard.GetPhotonView().ViewID, Parent.GetPhotonView().ViewID);
            locate += 25;
        }
    }

    [PunRPC]
    void CardsParent(int newCard, int Parent) {
        PhotonView newCardPhoton = PhotonView.Find(newCard);
        PhotonView parentPhoton = PhotonView.Find(Parent);

        if(newCardPhoton != null && parentPhoton != null) {
            newCardPhoton.TransferOwnership(parentPhoton.Owner);
            newCardPhoton.transform.SetParent(parentPhoton.transform);
        }
    }
    
    [PunRPC]
    public void DeckReload(string Player) {
        switch(Player) {
            case "R" :
                greenDeck.box2D.enabled = true;
                greenDeck.spriteRenderer.color = new Color(greenDeck.spriteRenderer.color.r, greenDeck.spriteRenderer.color.g, greenDeck.spriteRenderer.color.b, 1.0f);
                Debug.Log("ReLoad Green Deck");
                break;
            case "G" :
                redDeck.box2D.enabled = true;
                redDeck.spriteRenderer.color = new Color(redDeck.spriteRenderer.color.r, redDeck.spriteRenderer.color.g, redDeck.spriteRenderer.color.b, 1.0f);
                Debug.Log("ReLoad Red Deck");
                break;
        }
    }

    public void ContactPlayer() {
        redPlayer.Enemy = GP;
        greenPlayer.Enemy = RP;
    }
}