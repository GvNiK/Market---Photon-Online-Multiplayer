using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Core.Photon
{
    public class AvatarManager : MonoBehaviour
    {
        [SerializeField] GameObject[] avatarPrefabsList;
        GameObject avatarToSpawn;


        #region Initialization
        private void Awake()
        {

        }

        private void OnEnable()
        {

        }

        private void Start()
        {
            if(!PhotonNetwork.IsConnected)
                return;

            avatarToSpawn = avatarPrefabsList[(int)PhotonNetwork.LocalPlayer.CustomProperties["AvatarStats"]];

            PhotonNetwork.Instantiate(avatarToSpawn.name, Vector3.zero, Quaternion.identity);
        }
        #endregion
    }
}
