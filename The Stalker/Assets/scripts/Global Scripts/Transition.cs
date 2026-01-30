using UnityEditor.Rendering;
using UnityEngine;

public class Transition : MonoBehaviour
{
    CanvasGroup _canvasGroup;

    const float _fadeTime = 360f;
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        FadeIn();
    }


    public void FadeIn()
    {
        for (float i = _fadeTime; i > 0;)
        {
            i -= 1f * Time.deltaTime;
            _canvasGroup.alpha = i / _fadeTime;
        }

    }
    public void FadeOut()
    {
        for (float i = 0; i < _fadeTime;)
        {
            i -= 1f * Time.deltaTime;
            _canvasGroup.alpha = i / _fadeTime;
        }
    }
}
