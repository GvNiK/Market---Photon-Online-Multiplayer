using UnityEngine;
using UnityEngine.UI;

public class ButtonScaleOnPress : MonoBehaviour
{
    [SerializeField] float tweenTime = 1f;
    [SerializeField] float scaleValue = 0.96f;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ScaleUp);
    }

    public void ScaleUp()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject,Vector3.one * scaleValue, tweenTime).setEasePunch();
    }
}
