using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointConfirm : MonoBehaviour {
    PointButton pointButton;

    void Start() {
        pointButton = transform.parent.GetComponent<PointButton>();
    }

    void OnMouseDown() {
        pointButton.ChildDel();
    }
}
