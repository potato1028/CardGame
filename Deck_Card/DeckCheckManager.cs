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

        CardNode_Red = GameObject.Find("CheckedCard_Red");
        CardNode_Green = GameObject.Find("CheckedCard_Green");

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

    }

    public void CreateCard(char Player) {
        int[] RandomNumber = new int[3];
        int locate = -20;
        for(int i = 0; i < 3; i++) {
            RandomNumber[i] = Random.Range(0, LenCard);
        }

        switch(Player) {
            case 'R' :
                GameObject[] newRedCard = new GameObject[3];
                for(int i = 0; i < 3; i++) {
                    newRedCard[i] = PhotonNetwork.Instantiate(Cards[RandomNumber[i]].name, new Vector3(locate, -8, 0), Quaternion.identity);
                    newRedCard[i].transform.parent = CardNode_Red.transform;
                    locate += 20;
                }
                redDeck.box2D.enabled = false;
                redDeck.spriteRenderer.color = new Color(redDeck.spriteRenderer.color.r, redDeck.spriteRenderer.color.g, redDeck.spriteRenderer.color.b, 0.5f);
                redDeck.isDelay = true;
                break;
            case 'G' :
                GameObject[] newGreenCard = new GameObject[3];
                for(int i = 0; i < 3; i++) {
                    newGreenCard[i] = PhotonNetwork.Instantiate(Cards[RandomNumber[i]].name, new Vector3(locate, -8, 0), Quaternion.identity);
                    newGreenCard[i].transform.parent = CardNode_Green.transform;
                    locate += 20;
                }
                greenDeck.box2D.enabled = false;
                greenDeck.spriteRenderer.color = new Color(greenDeck.spriteRenderer.color.r, greenDeck.spriteRenderer.color.g, greenDeck.spriteRenderer.color.b, 0.5f);
                greenDeck.isDelay = true;
                break;
        }
    }
    
    public void DeckReload(char Player) {
        switch(Player) {
            case 'R' :
                redDeck.BoutCard++;
                redDeck.box2D.enabled = true;
                redDeck.spriteRenderer.color = new Color(redDeck.spriteRenderer.color.r, redDeck.spriteRenderer.color.g, redDeck.spriteRenderer.color.b, 1.0f);
                redDeck.isDelay = false;
                break;
            case 'G' :
                greenDeck.BoutCard++;
                greenDeck.box2D.enabled = true;
                greenDeck.spriteRenderer.color = new Color(greenDeck.spriteRenderer.color.r, greenDeck.spriteRenderer.color.g, greenDeck.spriteRenderer.color.b, 1.0f);
                greenDeck.isDelay = false;
                break;
        }
    }
}
