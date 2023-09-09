using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelObstacleLocation : MonoBehaviour
{
    public void ChildDel() {
        foreach(Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }
}
