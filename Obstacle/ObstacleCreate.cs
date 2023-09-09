using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreate : MonoBehaviour {
    DelObstacleLocation del;

    public GameObject ObstacleBlockPrefab;

    public GameObject ObstacleNode;

    void Start() {
        del = transform.parent.GetComponent<DelObstacleLocation>();

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
        GameObject Obstacle = Instantiate(ObstacleBlockPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Obstacle.transform.parent = ObstacleNode.transform;
        del.ChildDel();
    }
}
