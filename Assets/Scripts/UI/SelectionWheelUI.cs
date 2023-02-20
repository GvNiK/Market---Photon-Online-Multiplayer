using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace Core.UI
{
    public class SelectionWheelUI : MonoBehaviour
    {
        [SerializeField] GameObject selectionObj;
        [SerializeField] TMP_Text selectionIconName;
        [SerializeField] List<Wheelcon> imgList = new List<Wheelcon>();

        #region Initialization
        private void Awake()
        {

        }

        private void OnEnable()
        {
        }

        private void Start()
        {
            UpdateIconList();
        }
        #endregion

        private void UpdateIconList()
        {
            foreach (Wheelcon icon in transform.GetComponentsInChildren<Wheelcon>())
            {
                imgList.Add(icon);

                for (int i = 0; i < imgList.Count; i++)
                {
                    icon.imgIndex = i;

                    icon.OnIconHoverOver += (i) =>
                    {
                        ResetIcons();
                        switch(i)
                        {
                            case 0:
                                selectionObj.transform.eulerAngles = new Vector3(0, 0, 73);
                                icon.keepHighlighted = true;
                                selectionIconName.text = icon.name;
                                break;

                            case 1:
                                selectionObj.transform.eulerAngles = new Vector3(0, 0, 37);
                                icon.keepHighlighted = true;
                                selectionIconName.text = icon.name;
                                break;

                            case 2:
                                selectionObj.transform.eulerAngles = new Vector3(0, 0, 0);
                                icon.keepHighlighted = true;
                                selectionIconName.text = icon.name;
                                break;

                            case 3:
                                selectionObj.transform.eulerAngles = new Vector3(0, 0, -39);
                                icon.keepHighlighted = true;
                                selectionIconName.text = icon.name;
                                break;

                            case 4:
                                selectionObj.transform.eulerAngles = new Vector3(0, 0, -74);
                                icon.keepHighlighted = true;
                                selectionIconName.text = icon.name;
                                break;

                            default:
                                Debug.Log("Default State.");
                                break;
                        }
                    };

                    icon.OnIconClick += (i) =>
                    {
                        switch(icon.name)
                        {
                            case "Settings":
                                break;

                            case "Emoji":
                                break;

                            case "ChatBox":
                                break;

                            case "Map":
                                break;

                            case "Exit":
                            #if UNITY_EDITOR
                                EditorApplication.isPlaying = false;
                            #endif
                                Application.Quit();
                                break;
                        }
                    };
                }
            }
        }

        private void ResetIcons()
        {
            if (imgList.Count == 0)
                return;

            foreach (Wheelcon icon in imgList)
            {
                icon.ResetIcons();
            }
        }
    }
}
