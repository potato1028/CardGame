using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelChild : MonoBehaviour {
    void Update() {
        if(transform.childCount > 1) {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}