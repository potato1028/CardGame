using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;
using Photon.Realtime;

public class GreenPlayer : MonoBehaviourPunCallbacks {
    PointButton confirm;
    DeckCheckManager deckCheck;

    public GameObject Goal;
    public GameObject Enemy;

    public GameObject CheckedCardNode;
    public GameObject MovePointNode;
    public GameObject ObstacleLocationNode;
    public GameObject ObstacleNode;
    public GameObject DeckCheckManagerNode;

    public GameObject MovePointPrefab;
    public GameObject ObstacleLocationPrefab;

    public string currentCardTag;

    private int DoubleCount;
    private bool isRelative;

    void Start() {
        Goal = GameObject.Find("Goal");
        CheckedCardNode = GameObject.Find("CheckedCard_Green");
        MovePointNode = GameObject.Find("MovePoint");
        ObstacleLocationNode = GameObject.Find("ObstacleLocationNode");
        ObstacleNode = GameObject.Find("Obstacles");
        Enemy = GameObject.Find("RedPlayer");

        confirm = MovePointNode.GetComponent<PointButton>();
        
        DoubleCount = 0;
    }

    public void ExecuteCard(string cardTag) {
        if(CheckedCardNode.transform.childCount > 3) {
            Invoke("ExecuteCard", 0.01f);
        }
        else {
            switch (cardTag) {
                case "MoveUp":
                    Debug.Log("Up");

                    if(transform.position.y >= 7) {
                        Debug.Log("Course Block!!");
                    }
                    else if(ObstacleNode.transform.childCount > 0) {
                        ObstacleMove("UP", transform.position);
                    }
                    else {
                        transform.position += new Vector3(0, 1, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "MoveDown":
                    Debug.Log("Down");

                    if(transform.position.y <= -7) {
                        Debug.Log("Course Block!!");
                    }
                    else if(ObstacleNode.transform.childCount > 0) {
                        ObstacleMove("DOWN", transform.position);
                    }
                    else {
                        transform.position += new Vector3(0, -1, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "MoveLeft":
                    Debug.Log("Left");

                    if(transform.position.x <= -7) {
                        Debug.Log("Course Block!!");
                    }
                    else if(ObstacleNode.transform.childCount > 0) {
                        ObstacleMove("LEFT", transform.position);
                    }
                    else {
                        transform.position += new Vector3(-1, 0, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "MoveRight":
                    Debug.Log("Right");

                    if(transform.position.x >= 7) {
                        Debug.Log("Course Block!!");
                    }
                    else if(ObstacleNode.transform.childCount > 0) {
                        ObstacleMove("RIGHT", transform.position);
                    }
                    else {
                        transform.position += new Vector3(1, 0, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "LuDia":
                    Debug.Log("Lu");

                    if(transform.position.y == 7 || transform.position.x == -7) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(-1, 1, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "LdDia":
                    Debug.Log("Ld");

                    if(transform.position.y == -7 || transform.position.x == -7) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(-1, -1, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "RuDia":
                    Debug.Log("Ru");

                    if(transform.position.y == 7 || transform.position.x == 7) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(1, 1, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "RdDia":
                    Debug.Log("Rd");

                    if(transform.position.y == -7 || transform.position.x == 7) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(1, -1, 0);
                    }

                    if(DoubleCount == 1) {
                        DoubleCount = 0;
                        ExecuteCard(cardTag);
                    }
                    DeckReload();
                    break;

                case "MoveUDLR":
                    DoubleCount = 0;
                    Debug.Log("UDLR");
                    UDLRPoint();
                    break;

                case "MoveEdge":
                    DoubleCount = 0;
                    Debug.Log("Edge");
                    EdgePoint();
                    break;

                case "MoveDouble":
                    Debug.Log("Double");
                    DoubleCount += 1;
                    DeckReload();
                    break;

                case "MoveBishop":
                    DoubleCount = 0;
                    Debug.Log("Bishop");
                    Bishop();
                    break;

                case "MoveKnight":
                    DoubleCount = 0;
                    Debug.Log("Knight");
                    Knight();
                    break;

                case "MoveQueen":
                    DoubleCount = 0;
                    Debug.Log("Queen");
                    Queen();
                    break;

                case "MoveRook":
                    DoubleCount = 0;
                    Debug.Log("Rook");
                    Rook();
                    break;

                case "Bind":
                    DoubleCount = 0;
                    Debug.Log("Bind");
                    DeckReload();
                    break;

                case "EnemyCardCheck":
                    DoubleCount = 0;
                    Debug.Log("EnemyCardCheck");
                    DeckReload();
                    break;

                case "Obstacle":
                    DoubleCount = 0;
                    Debug.Log("Obstacle");
                    Obstacle();
                    DeckReload();
                    break;

                case "ScoreUp":
                    DoubleCount = 0;
                    Debug.Log("ScoreUp");
                    DeckReload();
                    break;

                case "SideTel":
                    DoubleCount = 0;
                    Debug.Log("SideTel");
                    SideTel();
                    isRelative = false;
                    break;

                case "ChangeLocation":
                    DoubleCount = 0;
                    Debug.Log("ChangeLocation");
                    ChangeLocation();
                    DeckReload();
                    break;

                case "GhostPlayer":
                    DoubleCount = 0;
                    Debug.Log("GhostPlayer");
                    DeckReload();
                    break;

                case "Invertion":
                    DoubleCount = 0;
                    Debug.Log("Invertion");
                    DeckReload();
                    break;

                case "RandomLocation":
                    DoubleCount = 0;
                    RandomPosition(gameObject);
                    Debug.Log("RandomLocation");
                    DeckReload();
                    break;

                case "TelEnemyRandom":
                    DoubleCount = 0;
                    RandomPosition(Enemy);
                    Debug.Log("TelEnemy");
                    DeckReload();
                    break;
            }
        }
    }

    private void UDLRPoint() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 1f);
        CreatePoint(MovePointNode, MovePointPrefab, 0f, -1f);
        CreatePoint(MovePointNode, MovePointPrefab, 1f, 0f);
        CreatePoint(MovePointNode, MovePointPrefab, -1f, 0f);
        confirm.CreateButton("G");
    }

    private void EdgePoint() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);
        CreatePoint(MovePointNode, MovePointPrefab, 1f, 1f);
        CreatePoint(MovePointNode, MovePointPrefab, 1f, -1f);
        CreatePoint(MovePointNode, MovePointPrefab, -1f, 1f);
        CreatePoint(MovePointNode, MovePointPrefab, -1f, -1f);
        confirm.CreateButton("G");
    }

    private void Bishop() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);

        BishopLine();

        confirm.CreateButton("G");
    }

    private void Knight() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);
        CreatePoint(MovePointNode, MovePointPrefab, -2f, 1f);
        CreatePoint(MovePointNode, MovePointPrefab, -2f, -1f);
        CreatePoint(MovePointNode, MovePointPrefab, -1f, 2f);
        CreatePoint(MovePointNode, MovePointPrefab, -1f, -2f);
        CreatePoint(MovePointNode, MovePointPrefab, 1f, 2f);
        CreatePoint(MovePointNode, MovePointPrefab, 1f, -2f);
        CreatePoint(MovePointNode, MovePointPrefab, 2f, 1f);
        CreatePoint(MovePointNode, MovePointPrefab, 2f, -1f);
        confirm.CreateButton("G");
    }

    private void Rook() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);
        
        RookLine();

        confirm.CreateButton("G");
    }

    private void Queen() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);

        BishopLine();
        RookLine();

        confirm.CreateButton("G");
    }

    private void BishopLine() {
        float k;
        for(int i = 0; i < 4; i++) {
            switch(i) {
                case 0:
                    for(float num = 1f; num < 15f; num++) {
                        k = num;
                        CreatePoint(MovePointNode, MovePointPrefab, k, k);
                    }

                    break;

                case 1:
                    for(float num = 1f; num < 15f; num++) {
                        k = num;
                        CreatePoint(MovePointNode, MovePointPrefab, k *= -1f, k);
                    }

                    break;

                case 2:
                    for(float num = 1f; num < 15f; num++) {
                        k = num;
                        CreatePoint(MovePointNode, MovePointPrefab, k *= -1f, k *= -1f);
                    }

                    break;

                case 3:
                    for(float num = 1f; num < 15f; num++) {
                        k = num;
                        CreatePoint(MovePointNode, MovePointPrefab, k, k *= -1f);
                    }

                    break;
            }
        }
    }

    private void RookLine() {
        for(int i = 0; i < 2; i++) {
            switch(i) {
                case 0:
                    for(float num_1 = -14f; num_1 < 15f; num_1++) {
                        if(num_1 == 0f) {
                            continue;
                        }
                        else {
                            CreatePoint(MovePointNode, MovePointPrefab, 0f, num_1);
                        }
                    }
                    break;
                
                case 1:
                    for(float num_2 = -14f; num_2 < 15f; num_2++) {
                        if(num_2 == 0f) {
                            continue;
                        }
                        else {
                            CreatePoint(MovePointNode, MovePointPrefab, num_2, 0f);
                        }
                    }
                    break;
            }
        }
    }

    private void Obstacle() {
        Vector3 playerLocation = gameObject.transform.position;
        Vector3 goalLocation = Goal.transform.position;
        Vector3 enemyLocation = Enemy.transform.position;

        for(int i = -7; i < 8; i++) {
            for(int k = -7; k < 8; k++) {

                if((i == playerLocation.x && k == playerLocation.y) || (i == goalLocation.x && k == goalLocation.y) || (i == enemyLocation.x && k == enemyLocation.y)) {
                    continue;
                }
                else {
                    GameObject ObstacleBlock = Instantiate(ObstacleLocationPrefab, new Vector3(i, k, 0), Quaternion.identity);
                    ObstacleBlock.transform.parent = ObstacleLocationNode.transform;   
                }

            }
        }
    }

    private void SideTel() {
        isRelative = true;
        for(int i = -2; i < 3; i++) {
            if(i == -2 || i == 2) {
                for(int k = -2; k < 3; k++) {
                    CreatePoint(MovePointNode, MovePointPrefab, Goal.transform.position.x + i, Goal.transform.position.y + k);
                }
            }
            else {
                CreatePoint(MovePointNode, MovePointPrefab, Goal.transform.position.x + i, Goal.transform.position.y + 2f);
                CreatePoint(MovePointNode, MovePointPrefab, Goal.transform.position.x + i, Goal.transform.position.y + -2f);
            }
        }

        confirm.CreateButton("G");
    }

    private void ObstacleMove(string dir, Vector3 position) {
        switch(dir) {
            case "UP" :
                position.y += 1;
                for(int i = 0; i < ObstacleNode.transform.childCount; i++) {
                    if(position == ObstacleNode.transform.GetChild(i).position) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(0, 1, 0); 
                    }
                }
                position.y -= 1;
                break;

            case "DOWN" :
                position.y -= 1;
                for(int i = 0; i < ObstacleNode.transform.childCount; i++) {
                    if(position == ObstacleNode.transform.GetChild(i).position) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(0, -1, 0); 
                    }
                }
                position.y += 1;
                break;

            case "LEFT" :
                position.x -= 1;
                for(int i = 0; i < ObstacleNode.transform.childCount; i++) {
                    if(position == ObstacleNode.transform.GetChild(i).position) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(-1, 0, 0); 
                    }
                }
                position.x += 1;
                break;

            case "RIGHT" :
                position.x += 1;
                for(int i = 0; i < ObstacleNode.transform.childCount; i++) {
                    if(position == ObstacleNode.transform.GetChild(i).position) {
                        Debug.Log("Course Block!!");
                    }
                    else {
                        transform.position += new Vector3(1, 0, 0); 
                    }
                }
                position.x -= 1;
                break;
        }
    }

    private void ChangeLocation() {
        Vector3 replace = transform.position;
        transform.position = Enemy.transform.position;
        Enemy.transform.position = replace;
    }

    private void RandomPosition(GameObject who) {
        System.Random random = new System.Random();
        Vector3 RandomLocation = Vector3.zero;

        while(true) {
            int X = random.Next(-7, 8);
            int Y = random.Next(-7, 8);
            RandomLocation = new Vector3(X, Y, 0);

            if(Enemy.transform.position != RandomLocation &&
               Goal.transform.position != RandomLocation &&
               this.transform.position != RandomLocation) {
                bool obstacleOverlap = false;

                for(int i = 0; i < ObstacleNode.transform.childCount; i++) {
                    if(ObstacleNode.transform.GetChild(i).transform.position == RandomLocation) {
                        obstacleOverlap = true;
                        break;
                    }
                }
                if(!obstacleOverlap) {
                    break;
                }
            }
        }

        who.transform.position = RandomLocation;
    }

    private void CreatePoint(GameObject ParentNode, GameObject CardPrefab, float X, float Y) {
        if(!isRelative) {
            X += transform.position.x;
            Y += transform.position.y;
        }

        if((X >= -7 && X <= 7) && (Y >= -7 && Y <= 7)) {
            GameObject PointCard = Instantiate(CardPrefab, new Vector3(X, Y, 0), Quaternion.identity);
            Debug.Log("PointCard");
            PointCard.transform.parent = ParentNode.transform;
        }
    }

    private void DeckReload() {
        if(DeckCheckManagerNode == null) {
            DeckCheckManagerNode = GameObject.FindWithTag("DeckCheckManager");
            deckCheck = DeckCheckManagerNode.GetComponent<DeckCheckManager>();
        }
        
        deckCheck.photonView.RPC("DeckReload", RpcTarget.All, "G");
    }
}