using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PointButton : MonoBehaviourPunCallbacks {
    DeckCheckManager deckCheck;

    public GameObject ButtonSprite;
    public GameObject DeckCheckManagerNode;

    public string Player;

    public void CreateButton(string p) {
        GameObject ClickButton = Instantiate(ButtonSprite, new Vector3(-17f, 8f, 0), Quaternion.identity);
        ClickButton.transform.parent = transform;
        Player = p;
    }

    public void ChildDel() {
        foreach(Transform child in this.transform) {
            DeckCheckManagerNode = GameObject.FindWithTag("DeckCheckManager");
            deckCheck = DeckCheckManagerNode.GetComponent<DeckCheckManager>();
            deckCheck.DeckReload(Player);
            Destroy(child.gameObject);
        }
    }
}
