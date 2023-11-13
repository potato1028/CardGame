using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick_Red : MonoBehaviour {
    public GameObject Player;
    public GameObject ObstacleNode;

    void Start() {
        Player = GameObject.Find("Red");

        ObstacleNode = GameObject.Find("Obstacles");

        if(ObstacleNode.transform.childCount >= 1) {
            for(int i = 0; i < ObstacleNode.transform.childCount; i++) {
                if(transform.position == ObstacleNode.transform.GetChild(i).transform.position) {
                    Destroy(gameObject);
                }
                else {
                    continue;
                }
            }
        }

    }

    void OnMouseDown() {
        Player.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
