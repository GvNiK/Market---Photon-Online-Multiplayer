using TMPro;
using Photon.Pun;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Core.Player;
using Core.UI;

namespace Core.Photon
{
    public class AvatarSetup : MonoBehaviour
    {
        #region Private Members
        private Camera cam;
        private Rigidbody rb;
        [SerializeField] private Animator anim;
        private PhotonView PV;
        [SerializeField] private AudioListener audioListener;
        private CinemachineVirtualCamera cineCam;
        [SerializeField] private GameObject selectionWheelUI;

        private PlayerInputBroadcaster playerInputBroadcaster;
        private PlayerMovement playerMovement;
        private CharacterController characterController;
        #endregion

        #region Exposed Members
        [SerializeField] Sprite avatarDisplaySprite;
        [SerializeField] Image avatarDisplayImage;
        [SerializeField] TMP_Text avatarName;
        #endregion

        #region Initialization
        private void Awake()    //Get all Components.
        {
            cam = GetComponentInChildren<Camera>();
            PV = GetComponent<PhotonView>();

            AddAndSetComponents();  //Adds & Sets PhotonTransfowmView & CharacterController.

            rb = gameObject.AddComponent<Rigidbody>();
            rb.freezeRotation = true;

            anim = GetComponent<Animator>();
            audioListener = gameObject.AddComponent<AudioListener>();
            cineCam = GetComponentInChildren<CinemachineVirtualCamera>();

            //selectionWheelUI = GameObject.FindGameObjectWithTag("SelectionWheelUI");
            selectionWheelUI.SetActive(false);

            playerInputBroadcaster = new PlayerInputBroadcaster();
            playerMovement = new PlayerMovement(playerInputBroadcaster, transform.GetChild(1).gameObject, characterController,
                                playerInputBroadcaster.PlayerInputs, anim, this.transform);

            if(!PV.IsMine)
                return;

            playerMovement.Awake();
        }

        private void OnEnable() //Set Avatar Stats.
        {
            // if(!PV.IsMine)
            //     return;

            avatarName.text = PV.Owner.NickName;
            if (string.IsNullOrEmpty(avatarName.text))
            {
                avatarName.text = "Avatar " + Random.Range(0, 20);
            }
            avatarDisplayImage.sprite = avatarDisplaySprite;
        }

        private void Start()    //Check for PhotonView & Initilization.
        {
            if(!PV.IsMine)
            {
                cam.enabled = false;
                cineCam.enabled = false;
                audioListener.enabled = false;
                Destroy(rb);
                return;
            }
            playerMovement.Start();

            playerInputBroadcaster.Callbacks.OnPlayerPausePressed += () =>
            {
                playerInputBroadcaster.EnableAction(ControlType.Pause);
                selectionWheelUI.SetActive(true);
            };

            playerInputBroadcaster.Callbacks.OnPlayerReturnPressed += () =>
            {
                playerInputBroadcaster.EnableAction(ControlType.Player);
                selectionWheelUI.SetActive(false);
            };
        }
        #endregion

        #region Updates & Rigidbody
        private void FixedUpdate()
        {

        }

        private void Update()
        {
            if (!PV.IsMine)
                return;

            playerMovement.Update();
        }

        private void LateUpdate()
        {
            if (!PV.IsMine)
                return;

            playerMovement.LateUpdate();
        }
        #endregion

        private void AddAndSetComponents()
        {
            // PhotonTransformView transformView = gameObject.AddComponent<PhotonTransformView>();
            // transformView.m_SynchronizePosition = true;
            // transformView.m_SynchronizeRotation = true;

            //PhotonAnimatorView photonAnimatorView = gameObject.AddComponent<PhotonAnimatorView>();

            characterController = gameObject.AddComponent<CharacterController>();
            characterController.stepOffset = 0.25f;
            characterController.skinWidth = 0.02f;
            characterController.minMoveDistance = 0.0f;
            characterController.center = new Vector3(0, 0.98f, 0);
            characterController.radius = 0.25f;
        }
    }
}
