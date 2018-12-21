using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAnim : MonoBehaviour
{
    public float alpha = 0.0f;
    public float alphaSpeed = 2.0f;
    public float duration = 2.0f;
    bool show = false;

    private CanvasGroup cg;

    void Start()
    {
        cg = this.transform.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (alpha != cg.alpha && show == false)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(alpha - cg.alpha) <= 0.01)
            {
                cg.alpha = alpha;
                show = true;
            }
        }

        if (cg.alpha == alpha)
        {
            Invoke("disappear", duration);
        }
    }


    void disappear()
    {
        cg.alpha = Mathf.Lerp(cg.alpha, 0.0f, alphaSpeed * Time.deltaTime);
    }
    public void Show()
    {
        alpha = 1;

        cg.blocksRaycasts = true;//可以和该UI对象交互
    }

    public void Hide()
    {
        alpha = 0;

        cg.blocksRaycasts = false;//不可以和该UI对象交互
    }
}