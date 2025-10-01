using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    public static TextPanel inst;
    public float TimeToHide = 1.5f;
    private TMP_Text text;
    public void Start()
    {
        inst = this;
        text = GetComponentInChildren<TMP_Text>();
        Hide();
    }
    public void Show(string t)
    {
        text.text = t;
        gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(HideAfterShow());
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private IEnumerator HideAfterShow()
    {
        yield return new WaitForSeconds(TimeToHide);
        Hide();
    }
}
