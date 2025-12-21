using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSpriteManager : SingletonMonoBehaviour<GameSpriteManager>
{
    [SerializeField] private ImageSet contentImgSet;
    
    /// <summary>
    /// Get Random imgs for display
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentException"></exception>
    public List<Sprite> GetRandomImgs(int amount)
    {
        if(contentImgSet.Images.Count < amount)
            throw new System.ArgumentException("Input amount is more than image set");
        return contentImgSet.Images
                            .OrderBy(_=>Random.value)
                            .Take(amount)
                            .ToList();
    }
}
