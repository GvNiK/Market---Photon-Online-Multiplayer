using UnityEngine;
using Photon.Pun;

namespace Core.UI
{
    public class PlayerBillboard : MonoBehaviour
    {
        [SerializeField] Camera cam;
        [SerializeField] PhotonView PV;
        [SerializeField] Vector3 offset;
        //[SerializeField] GameObject cameraHolder;

        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
            PV = transform.root.GetComponent<PhotonView>();
        }

        private void LateUpdate() 
        {
            transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
        }
    }
}
