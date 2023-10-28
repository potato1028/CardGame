using UnityEngine;
using Photon.Pun;

public class NetworkedObject : MonoBehaviourPun, IPunObservable {
    private Vector3 latestPos;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        if(!photonView.IsMine) {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting) {
            stream.SendNext(rb.position);
        }
        else {
            latestPos = (Vector2)stream.ReceiveNext();
        }
    }

    private void Update() {
        if(!photonView.IsMine) {
            rb.MovePosition(Vector2.Lerp(rb.position, latestPos, 0.1f));
        }
    }
}
