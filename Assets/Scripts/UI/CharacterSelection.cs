using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Core.UI
{
    public class CharacterSelection : MonoBehaviour
    {
        [SerializeField] Image avatarImg; 
        [SerializeField] Transform avatarIconsParent;
        [SerializeField] List<AvatarSelectButton> avatarList = new List<AvatarSelectButton>();

        #region Initialization
        private void Awake()
        {

        }

        private void OnEnable()
        {
            avatarImg.gameObject.SetActive(false);
            UpdateAvatarList();
        }

        private void Start()
        {

        }
        #endregion


        private void UpdateAvatarList()
        {
            foreach(AvatarSelectButton btn in avatarIconsParent.GetComponentsInChildren<AvatarSelectButton>())
            {
                avatarList.Add(btn);

                for (int i = 0; i < avatarList.Count; i++)
                {
                    btn.SetButtonNumber(i);

                    btn.OnButtonClick += (i) =>
                    {
                        ResetButtons();
                        btn.buttonClick = true;

                        avatarImg.gameObject.SetActive(true);
                        avatarImg.sprite = btn.avatarSprite;
                    };
                }
            }

        }

        private void ResetButtons()
        {
            if(avatarList.Count == 0) 
                return;

            foreach(AvatarSelectButton btn in avatarList)
            {
                btn.ResetButtonToDefault();
            }
        }


        #region Getter/Setter
        public bool isAnyAvatarSeleced
        {
            get
            {
                foreach(AvatarSelectButton btn in avatarList)
                {
                    if(btn.buttonClick)
                        return true;
                }

                return false;
            }
        }
        #endregion
    }

}
