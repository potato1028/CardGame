using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RedPlayer : MonoBehaviour {
    PointButton confirm;

    public GameObject Goal;
    public GameObject Enemy;

    public GameObject CheckedCardNode;
    public GameObject MovePointNode;
    public GameObject ObstacleLocationNode;
    public GameObject ObstacleNode;

    public GameObject MovePointPrefab;
    public GameObject ObstacleLocationPrefab;

    public string currentCardTag;

    private int DoubleCount;
    private bool isRelative;

    void Start() {
        Goal = GameObject.Find("Goal");
        Enemy = GameObject.Find("Green");
        CheckedCardNode = GameObject.Find("CheckedCard");
        MovePointNode = GameObject.Find("MovePoint");
        ObstacleLocationNode = GameObject.Find("ObstacleLocationNode");
        ObstacleNode = GameObject.Find("Obstacles");

        confirm = MovePointNode.GetComponent<PointButton>();
        
        DoubleCount = 0;
    }

    public void ExecuteCard() {
        if(CheckedCardNode.transform.childCount > 1) {
            Invoke("ExecuteCard", 0.01f);
        }
        else {
            currentCardTag = CheckedCardNode.transform.GetChild(0).tag;
            switch (currentCardTag) {
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
                        ExecuteCard();
                    }

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
                        ExecuteCard();
                    }

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
                        ExecuteCard();
                    }
                    
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
                        ExecuteCard();
                    }
                    
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
                        ExecuteCard();
                    }
                   
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
                        ExecuteCard();
                    }

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
                        ExecuteCard();
                    }
                    
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
                        ExecuteCard();
                    }
                    
                    break;

                case "MoveUDLR":
                    Debug.Log("UDLR");
                    UDLRPoint();

                    DoubleCount = 0;
                    break;

                case "MoveEdge":
                    Debug.Log("Edge");
                    EdgePoint();

                    DoubleCount = 0;
                    break;

                case "MoveDouble":
                    Debug.Log("Double");
                    DoubleCount += 1;

                    break;

                case "MoveBishop":
                    Debug.Log("Bishop");
                    Bishop();

                    DoubleCount = 0;
                    break;

                case "MoveKnight":
                    Debug.Log("Knight");
                    Knight();

                    DoubleCount = 0;
                    break;

                case "MoveQueen":
                    Debug.Log("Queen");
                    Queen();

                    DoubleCount = 0;
                    break;

                case "MoveRook":
                    Debug.Log("Rook");
                    Rook();

                    DoubleCount = 0;
                    break;

                case "Bind":
                    Debug.Log("Bind");

                    DoubleCount = 0;
                    break;

                case "EnemyCardCheck":
                    Debug.Log("EnemyCardCheck");

                    DoubleCount = 0;
                    break;

                case "Obstacle":
                    Debug.Log("Obstacle");
                    Obstacle();

                    DoubleCount = 0;
                    break;

                case "ScoreUp":
                    Debug.Log("ScoreUp");

                    DoubleCount = 0;
                    break;

                case "SideTel":
                    Debug.Log("SideTel");
                    SideTel();

                    DoubleCount = 0;
                    isRelative = false;
                    break;

                case "ChangeLocation":
                    Debug.Log("ChangeLocation");
                    ChangeLocation();
                    break;

                case "GhostPlayer":

                    Debug.Log("GhostPlayer");
                    break;

                case "Invertion":
                    // Invertion();
                    Debug.Log("Invertion");
                    break;

                case "RandomLocation":
                    RandomPosition(gameObject);
                    Debug.Log("RandomLocation");
                    break;

                case "TelEnemyRandom":
                    RandomPosition(Enemy);
                    Debug.Log("TelEnemy");
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
        confirm.CreateButton();
    }

    private void EdgePoint() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);
        CreatePoint(MovePointNode, MovePointPrefab, 1f, 1f);
        CreatePoint(MovePointNode, MovePointPrefab, 1f, -1f);
        CreatePoint(MovePointNode, MovePointPrefab, -1f, 1f);
        CreatePoint(MovePointNode, MovePointPrefab, -1f, -1f);
        confirm.CreateButton();
    }

    private void Bishop() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);

        BishopLine();

        confirm.CreateButton();
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
        confirm.CreateButton();
    }

    private void Rook() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);
        
        RookLine();

        confirm.CreateButton();
    }

    private void Queen() {
        CreatePoint(MovePointNode, MovePointPrefab, 0f, 0f);

        BishopLine();
        RookLine();

        confirm.CreateButton();
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

    // private void Bind() {

    // }

    // private void EnemyCardCheck() {

    // }

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

    // private void ScoreUp() {

    // }

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

        confirm.CreateButton();
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

    // private void Invertion() {
    //     float InvertionX;
    //     if(ObstacleNode.transform.childCount > 0) {
    //         for(int i = 0; i < ObstacleNode.transform.childCount; i++) {
    //             InvertionX = ObstacleNode.transform.GetChild(i).transform.position.x;
    //             ObstacleNode.transform.GetChild(i).transform.position = new Vector3(InvertionX *= -1, ObstacleNode.transform.GetChild(i).transform.position.y, 0);
    //         }
    //     }

    //     InvertionX = Enemy.transform.position.x;
    //     Enemy.transform.position = new Vector3(InvertionX *= -1, Enemy.transform.position.y, 0);
        
    //     InvertionX = this.transform.position.x;
    //     this.transform.position = new Vector3(InvertionX *= -1, this.transform.position.y, 0);

    //     InvertionX = Goal.transform.position.x;
    //     Goal.transform.position = new Vector3(InvertionX *= -1, Goal.transform.position.y, 0);
    // }

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
}