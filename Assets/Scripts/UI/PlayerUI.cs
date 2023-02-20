using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using ReadyPlayerMe;

namespace Core.UI
{
    public class PlayerUI : MonoBehaviour
    {
        // [Header("Player Name : --------------------------------------------------------------------")]
        // [SerializeField] TMP_Text playerName;

        [Space(2f)]
        [Header("Voice Properties : --------------------------------------------------------------------")]
        [SerializeField] Image voiceFXImg;
        [SerializeField] Image panelImg;
        [SerializeField] Image voiceIcon;
        [SerializeField] Sprite muteIcon;

        [Space(2f)]
        [Header("Room Properties : --------------------------------------------------------------------")]
        [SerializeField] TMP_Text playersInRoom;


        [Space(2f)]
        [Header("UI Properties : --------------------------------------------------------------------")]
        [SerializeField] Canvas playerDisplayCanvas;


        private VoiceHandler voiceHandler;
        private AudioSource source;
        private AudioClip audioClip;

        #region Initialization
        private void Awake()
        {
            voiceHandler = transform.root.GetComponent<VoiceHandler>();
        }

        private void OnEnable()
        {
            voiceIcon.gameObject.SetActive(false);
            voiceFXImg.gameObject.SetActive(false);

            // playerName.text = PhotonNetwork.LocalPlayer.NickName;
            // if(string.IsNullOrEmpty(playerName.text))
            // {
            //     playerName.text = "Avatar";
            // }
        }

        private void Start()
        {
            voiceHandler.OnAudioSourceCreated += (audioSource) =>
            {
                source = audioSource;
                audioClip = source.clip;
            };

            Canvas.ForceUpdateCanvases();
        }
        #endregion

        #region Updates & Rigidbody
        private void FixedUpdate()
        {

        }

        private void Update()
        {
            voiceFXImg.rectTransform.sizeDelta = panelImg.rectTransform.sizeDelta + new Vector2(8f, 8f);

            if(voiceHandler.GetAmplitude() > 0.05)
            {
                voiceIcon.gameObject.SetActive(true);
                voiceFXImg.gameObject.SetActive(true);
            }
            else
            {
                voiceIcon.gameObject.SetActive(false);
                voiceFXImg.gameObject.SetActive(false);
            }

            playersInRoom.text = PhotonNetwork.PlayerList.Length.ToString();
        }

        private void LateUpdate()
        {

        }
        #endregion
    }
}
