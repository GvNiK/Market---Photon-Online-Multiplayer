using TMPro;
using UnityEngine;
using System.Collections;

namespace Core.UI
{
    public class LoadingDotAnimation : MonoBehaviour
    {
        [SerializeField] private TMP_Text inputText;
        [SerializeField] private string textData;
        [SerializeField] private float animSpeedRate = 0.5f;

        #region Initialization
        private void Awake()
        {

        }

        private void OnEnable()
        {

        }

        IEnumerator Start()
        {
            //InvokeRepeating("DotAnimation", 0.5f, 0.5f);
            while(this.gameObject.activeSelf)
            {
                StartCoroutine("DotAnimation");
                yield return new WaitForSeconds(1f);
            }
        }
        #endregion


        IEnumerator DotAnimation()
        {
            inputText.text = textData + "";
            yield return new WaitForSeconds(animSpeedRate);

            inputText.text = textData + ".";
            yield return new WaitForSeconds(animSpeedRate);

            inputText.text = textData + "..";
            yield return new WaitForSeconds(animSpeedRate);

            inputText.text = textData + "...";
            yield return new WaitForSeconds(animSpeedRate);
        }

        #region Decommissioning
        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            //StopAllCoroutines();
        }
        #endregion
    }
}
