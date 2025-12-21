using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentScene : MonoBehaviour
{
    [SerializeField] private Transform contentImgParent;

    [SerializeField] private ImageContent imgContentPrefab;

    private const int MAX_INITIATE_AMOUNT = 25;

    void Start()
    {
        List<Sprite> randomSprites = GameSpriteManager.Instance.GetRandomImgs(MAX_INITIATE_AMOUNT);
        GenerateContents(randomSprites);
    }
    /// <summary>
    /// Put all sprite on scroll view
    /// </summary>
    /// <param name="sprites"></param>
    private void GenerateContents(List<Sprite> sprites)
    {
        foreach(Sprite sprite in sprites)
        {
            ImageContent imageContent = Instantiate(imgContentPrefab, contentImgParent);
            imageContent.SetContent(sprite, sprite.name);
        }
    }

}
