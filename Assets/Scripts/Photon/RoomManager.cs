using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

namespace Core.Server
{
    public class RoomManager : MonoBehaviourPunCallbacks
    {
        [Tooltip("Spawns Avatar. IMP : The hierarchical Order must be same as in the Avatar Selection Menu.")]
        [SerializeField] GameObject[] avatarPrefabsList;
        GameObject avatarToSpawn;

        [SerializeField] Image playerNotifier;
        [SerializeField] private TMP_Text playerInfoText;

        #region Initialization
        private void Awake()
        {
            playerInfoText = playerNotifier.GetComponentInChildren<TMP_Text>();
            //playerNotifier.gameObject.SetActive(false);
        }

        private void Start()
        {
            if(!PhotonNetwork.IsConnected)
                return;

            avatarToSpawn = avatarPrefabsList[(int)PhotonNetwork.LocalPlayer.CustomProperties["AvatarStats"]];

            PhotonNetwork.Instantiate(avatarToSpawn.name, Vector3.zero, Quaternion.identity);
        }
        #endregion

        #region Photon Methods
        public override void OnMasterClientSwitched(global::Photon.Realtime.Player newMasterClient)
        {
            base.OnMasterClientSwitched(newMasterClient);
            PhotonNetwork.SetMasterClient(newMasterClient);
            Debug.Log("Master Client.");
        }

        public override void OnPlayerEnteredRoom(global::Photon.Realtime.Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);

            //playerNotifier.gameObject.SetActive(true);
            playerInfoText.text = "<color=red>" + newPlayer.NickName + "</color>" + " has joined the room.";
            Debug.Log(newPlayer.NickName + " has Joined the Room.");
        }
        #endregion
    }
}
