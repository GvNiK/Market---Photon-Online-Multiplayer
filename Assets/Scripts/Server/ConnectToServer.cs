using TMPro;
using Core.UI;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.InputSystem;

namespace Core.Server
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button continueBtn;
        [SerializeField] private GameObject connectScreen;
        [SerializeField] private CharacterSelection characterSelection;

        #region Unity Methods
        private void Start()
        {
            continueBtn.gameObject.SetActive(false);
            connectScreen.SetActive(false);

            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Connecting To Server...");

            continueBtn.onClick.AddListener(LoadNextScene);
        }

        private void Update()
        {
            if (inputField.text.Length > 4 && characterSelection.isAnyAvatarSeleced)
            {
                if(Keyboard.current.enterKey.isPressed)
                {
                    LoadNextScene();
                }
                else
                {
                    continueBtn.gameObject.SetActive(true);
                }
            }
            else
            {
                continueBtn.gameObject.SetActive(false);
            }
        }
        #endregion

        private void LoadNextScene()
        {
            connectScreen.SetActive(true);
            PhotonNetwork.LocalPlayer.NickName = inputField.text;

            if(PhotonNetwork.IsConnectedAndReady)
                PhotonNetwork.JoinRandomRoom();
        }

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
            //PhotonNetwork.JoinRandomRoom();
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
            //PhotonNetwork.LoadLevel(2);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined Room");
            PhotonNetwork.LoadLevel(2);
        }
        #endregion
    }
}
