using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.UI
{
    public class AvatarSelectButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [Header("Button Properties -------------------------------------------------")]
        [SerializeField] private int buttonNumber;
        public bool buttonClick;

        [Space(2f)]
        [Header("Image Properties -------------------------------------------------")]
        [SerializeField] private Image selectImg;
        [SerializeField] private Image outlineImg;
        [SerializeField] Color defaultColor;
        [SerializeField] Color selectionColor;
        public Sprite avatarSprite;

        public Action<int> OnButtonClick;
        private RectTransform rectTransform;

        #region Initialization
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            selectImg.gameObject.SetActive(false);
        }

        private void Start()
        {
            //continueBtn.onCLick
        }
        #endregion

        #region Updates & Rigidbody
        private void FixedUpdate()
        {

        }

        private void Update()
        {
            if(buttonClick)
                SetTweenScale(1.1f, 1.1f);

        }

        private void LateUpdate()
        {

        }
        #endregion


        #region Button Events
        public void OnPointerEnter(PointerEventData eventData)
        {
            outlineImg.color = selectionColor;
            SetTweenScale(1.1f, 1.1f);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke(buttonNumber);
            selectImg.gameObject.SetActive(true);           
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            outlineImg.color = defaultColor;

            if(!buttonClick)
                SetTweenScale(1.0f, 1.0f);
        }
        #endregion

        private void SetTweenScale(float scaleX, float scaleY)
        {
            LeanTween.scale(rectTransform, new Vector2(scaleX, scaleY), 0.1f).setEase(LeanTweenType.linear);
        }

        #region Getter/Setter
        ///<summary>
            //Sets unique individual number for each button.
        ///<summary>
        public void SetButtonNumber(int value)
        {
            buttonNumber = value;
            this.gameObject.name = "Avatar " + value;
        }

        ///<summary>
            //Reset button to default..
        ///<summary>
        public void ResetButtonToDefault()
        {
            outlineImg.color = defaultColor;
            selectImg.gameObject.SetActive(false);
            buttonClick = false;
            SetTweenScale(1.0f, 1.0f);
        }
        #endregion
    }
}
