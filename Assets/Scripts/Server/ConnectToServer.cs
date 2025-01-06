using TMPro;
using Core.UI;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.InputSystem;
using System;

namespace Core.Server
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button continueBtn;
        [SerializeField] private GameObject connectScreen;
        [SerializeField] private CharacterSelection characterSelection;

        private TouchScreenKeyboard keyboard;

        #region Unity Methods
        private void Start()
        {
            continueBtn.gameObject.SetActive(false);
            connectScreen.SetActive(false);

            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Connecting To Server...");

            continueBtn.onClick.AddListener(LoadNextScene);
            inputField.onSelect.AddListener(InputFieldSelected);
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


        private void InputFieldSelected(string arg)
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            Debug.Log("OPen Keuboard.");
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
            // AppSettings appSettings = new AppSettings();
            // appSettings.FixedRegion = "in";
            PhotonNetwork.CreateRoom("PlayArea", roomOptions);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Successufully Created Room.");
            //PhotonNetwork.LoadLevel(2);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined Room.");
            PhotonNetwork.LoadLevel(2);
        }
        #endregion
    }
}
