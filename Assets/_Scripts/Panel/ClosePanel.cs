using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour
{
    //public Image uiImage;
    public Animator animator;
    public GameObject panel;
    /*void Start()
    {
        RectTransform rectTransform = uiImage.GetComponent<RectTransform>();

        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        Debug.Log("Width: " + width + ", Height: " + height);
    }*/

    public void OpenTab()
    {
        Debug.Log("Mo");
        animator.SetTrigger("Open");
    }

    public void CloseTab()
    {
        StartCoroutine(WaitCloseTab());
    }

    IEnumerator WaitCloseTab()
    {
        animator.SetTrigger("Close");
        Debug.Log("Dong");
        yield return new WaitForSeconds(1f);
        Debug.Log("XongAnim");
        panel.gameObject.SetActive(false);
    }
}
