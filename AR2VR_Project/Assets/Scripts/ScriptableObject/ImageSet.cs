using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Image Set", menuName = "ScriptableObject/ImageSet", order = 1)]
public class ImageSet : ScriptableObject
{
    public List<Sprite> Images = new List<Sprite>();
}
