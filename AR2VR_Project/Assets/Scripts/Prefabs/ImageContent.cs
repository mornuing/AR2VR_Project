using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageContent : MonoBehaviour
{
    [SerializeField] private Image contentImg;
    [SerializeField] private TMP_Text imgIdText;

    public void SetContent(Sprite targetSprite, string imgId)
    {
        contentImg.sprite = targetSprite;
        imgIdText.text = imgId;
    }
}
