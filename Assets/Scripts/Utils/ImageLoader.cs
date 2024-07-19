using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : Singleton<ImageLoader>
{
    private Dictionary<string, Object> resourceCache = new Dictionary<string, Object>();
    public string imagePath = "Images/myImage";

    void Start()
    {
    }
    public string skillAttrImagePath = "Images/SkillAttrImage/";
    public Sprite getSkillAttr(string attrName)
    {
        if (attrName.Length <= 0)
        {
            Debug.LogWarning("Image not found at path: " + path);
            return null;
        }
        string path = skillAttrImagePath + attrName;
        if (resourceCache.TryGetValue(path, out Object obj))
        {
            return obj as Sprite;
        }
        Texture2D texture = Resources.Load<Texture2D>(path);
        if (texture == null)
        {
            Debug.LogWarning("Image not found at path: " + path);
            return null;
        }

        // 创建一个Sprite并应用到UI的Image组件上

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        resourceCache.Add(path, sprite);
        return sprite;
    }
}
