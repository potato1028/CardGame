using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DeckCheck_Green : MonoBehaviourPunCallbacks {
    SpriteRenderer spriteRenderer;
    BoxCollider2D box2D;

    GreenPlayer greenPlayer;

    public GameObject CardNode;
    public GameObject MovePointNode;
    public GameObject ObstacleLocationNode;
    public GameObject Player_2;

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
    
    private int CardOrder;
    private bool isDelay;
    private const int LenCard = 8;
    private bool canInteract;

    public int BoutCard = 0;

    private GameObject[] NormalCard;

    // private GameObject[] EpicCard;
    // private GameObject[] LegendCard;
    // private GameObject[] CrazyCard;
    
    void Start() {
        greenPlayer = Player_2.GetComponent<GreenPlayer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        box2D = GetComponent<BoxCollider2D>();

        NormalCard = new GameObject[LenCard];

        NormalCard[0] = MoveUpPrefab;
        NormalCard[1] = MoveDownPrefab;
        NormalCard[2] = MoveLeftPrefab;
        NormalCard[3] = MoveRightPrefab;
        NormalCard[4] = LuDiaPrefab;
        NormalCard[5] = LdDiaPrefab;
        NormalCard[6] = RuDiaPrefab;
        NormalCard[7] = RdDiaPrefab;

        // NormalCard[8] = UDLRPrefab;
        // NormalCard[9] = MEdgePrefab;
        // NormalCard[10] = DoublePrefab;
        // NormalCard[11] = KinghtPrefab;
        // NormalCard[12] = RookPrefab;
        // NormalCard[13] = BishopPrefab;
        // NormalCard[14] = QueenPrefab;

        // NormalCard[15] = BindPrefab;
        // NormalCard[16] = EnemyCardCheckPrefab;
        // NormalCard[17] = ObstaclePrefab;
        // NormalCard[18] = ScoreUpPrefab;
        // NormalCard[19] = SideTelPrefab;

        // NormalCard[20] = TelEnemyRandomPrefab;
        // NormalCard[21] = ChangeLocationPrefab;
        // NormalCard[22] = InvertionPrefab;
        // NormalCard[23] = RandomLocationPrefab;
        // NormalCard[24] = GhostPlayerPrefab;

        StartCoroutine(DelayFindGameObject());

        CardOrder = 0;
        isDelay = false;
        canInteract = !photonView.IsMine;
    }

    void Update() {
        if(MovePointNode == null) {
            Debug.Log("Waiting...");
        }
        else {
            if(MovePointNode.transform.childCount > 0 || ObstacleLocationNode.transform.childCount > 0) {
                box2D.enabled = false;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
            }
            else if((MovePointNode.transform.childCount < 1 && box2D.enabled != true && !isDelay) || (ObstacleLocationNode.transform.childCount < 1 && box2D.enabled != true && !isDelay)) {
                box2D.enabled = true;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            }
        }
    }

    private void CreateCard(GameObject CardPrefab, float X, float Y) {
        GameObject newCard = PhotonNetwork.Instantiate(CardPrefab.name, new Vector3(-17 + X, -2 + Y, 0), Quaternion.identity);
        newCard.transform.parent = CardNode.transform;
        SpriteRenderer order = newCard.GetComponent<SpriteRenderer>();
        order.sortingOrder = CardOrder;
        CardOrder++;
    }

    private void OnMouseDown() {
        if(canInteract) {
            int RandomNumber = Random.Range(0, LenCard);
        
            float RandomX = Random.Range(-1f, 2f);
            float RandomY = Random.Range(-1f, 2f);

            CreateCard(NormalCard[RandomNumber], RandomX, RandomY);

            box2D.enabled = false;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
            isDelay = true;
            StartCoroutine(DisableCard());

            greenPlayer.ExecuteCard();

            BoutCard++;
        }
    }

    IEnumerator DisableCard() {
        yield return new WaitForSeconds(0.5f);

        box2D.enabled = true;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        isDelay = false;
    }

    IEnumerator DelayFindGameObject() {
        yield return new WaitForSeconds(0.5f);

        CardNode = GameObject.Find("CheckedCard_Green");
        MovePointNode = GameObject.Find("MovePoint");
        ObstacleLocationNode = GameObject.Find("ObstacleLocationNode");
    }
}