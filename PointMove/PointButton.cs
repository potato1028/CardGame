using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointButton : MonoBehaviour {
    public GameObject ButtonSprite;

    public void CreateButton() {
        GameObject ClickButton = Instantiate(ButtonSprite, new Vector3(-17f, 8f, 0), Quaternion.identity);
        ClickButton.transform.parent = transform;
    }

    public void ChildDel() {
        foreach(Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }
}
