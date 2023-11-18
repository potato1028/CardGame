using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelTimer : MonoBehaviour {
    GameObject TurnCountNode;

    TurnCount turnCount;

    int initCount;

    void Start() {
        TurnCountNode = GameObject.FindWithTag("TurnCountNode");

        turnCount = TurnCountNode.GetComponent<TurnCount>();
        turnCount.delTimer = this.gameObject.GetComponent<DelTimer>();

        initCount = turnCount.count;
        initCount += 10;
    }

    public void CheckCount(int nowCount) {
        if(initCount == nowCount) {
            Destroy(gameObject);
        }
    }
}