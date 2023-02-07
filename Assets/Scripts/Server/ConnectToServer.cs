using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Core.Server
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        #region Unity Methods
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Connecting To Server...");
        }
        #endregion

        #region Photon Methods
        public override void OnConnectedToMaster() 
        {
            PhotonNetwork.JoinLobby();    
            Debug.Log("Connected to Server.");
            Debug.Log("Joining Lobby...");
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Joined Lobby.");
            PhotonNetwork.JoinRandomRoom();
        }

        private void OnClickConnect()
        {
            PhotonNetwork.NickName = "User";
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("Join Room Failed.");
            CreateRoom();
        }

        private void CreateRoom()   //Room Setup (w/Settings)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 20;
            roomOptions.PublishUserId = true;
            PhotonNetwork.CreateRoom("PlayArea", roomOptions);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Successufully Created Room");
        }

        public override void OnJoinedRoom()
        {
            //PhotonNetwork.LoadLevel(1);
            Debug.Log("Joined Room");
        }
        
        #endregion
    }
}
