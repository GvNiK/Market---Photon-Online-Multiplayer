using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Core.SocialConnectivity
{
    //TODO: Implement Firebase Login System. And get all the Credentials to the Character Stats.
    //Also create Player Coins or Currency System.
    public class LoginManager : MonoBehaviour
    {
        [SerializeField] Button signInBtn;

        #region Initialization
        private void Awake()
        {

        }

        private void OnEnable()
        {

        }

        private void Start()
        {
            signInBtn.onClick.AddListener(LoadAvatarSelectionScene);
        }
        #endregion

        private void LoadAvatarSelectionScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
