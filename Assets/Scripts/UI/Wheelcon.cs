using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Core.UI
{
    public class Wheelcon : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] Image image;
        public int imgIndex;
        public bool keepHighlighted;

        private RectTransform rectTransform;
        [SerializeField] private Color defaultColor;

        public Action<int> OnIconHoverOver;
        public Action<int> OnIconClick;

        #region Initialization
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {

        }

        private void Start()
        {
            defaultColor = image.color;
        }
        #endregion

        #region Updates & Rigidbody
        private void FixedUpdate()
        {

        }

        private void Update()
        {
            if (!keepHighlighted)
            {
                SetTweenScale(1.0f, 1.0f);
                image.color = defaultColor;
            }
        }

        private void LateUpdate()
        {

        }
        #endregion

        #region Button Events
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetTweenScale(1.1f, 1.1f);
            image.color = Color.white;
            OnIconHoverOver?.Invoke(imgIndex);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnIconClick?.Invoke(imgIndex);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // OnIconHoverOver?.Invoke(imgIndex);

            // if(keepHighlighted)
            //     return;

            // SetTweenScale(1.0f, 1.0f);
            // image.color = defaultColor;
            // Debug.Log("Exited.");
        }
        #endregion


        private void SetTweenScale(float scaleX, float scaleY)
        {
            LeanTween.scale(rectTransform, new Vector2(scaleX, scaleY), 0.1f).setEase(LeanTweenType.linear);
        }

        public void ResetIcons()
        {
            keepHighlighted = false;
        }
    }
}
