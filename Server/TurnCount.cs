using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TurnCount : MonoBehaviourPunCallbacks {
    public int count = 0;

    public DelTimer delTimer;
    public DeckSelect deckSelect;

    public void PlusCount() {
        count++;
        if(delTimer != null) {
            delTimer.CheckCount(count);
        }
    }
}
