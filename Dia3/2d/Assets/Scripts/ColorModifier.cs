using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ColorModifier : MonoBehaviour 
{
    public float blinkTime = 0.1f;
    public Color initialColor = Color.white;
    public Color finalColor = Color.white;
    public LayerMask spritesLayers;
    public List<SpriteRenderer> spritesList;
    private bool shining;

    void Awake()
    {
        if (spritesList.Count == 0)
        {
            LoadSprites();
        }
    }

    public void Blink()
    {
        if (!shining)
        {
            foreach (SpriteRenderer sr in spritesList)
            {
                sr.color = finalColor;
            }
            shining = true;
            Invoke("RemoveBlink", blinkTime);
        }
    }

    public void RemoveBlink()
    {
        foreach (SpriteRenderer sr in spritesList)
        {
            sr.color = initialColor;
        }
        shining = false;
    }

    public void SetColor(Color color)
    {
        foreach (SpriteRenderer sr in spritesList)
        {
            sr.color = color;
        }
    }

    public void ScaleColor(float value)
    {
        print(value);
        SetColor(Color.Lerp(initialColor, finalColor, value));
    }

    [ContextMenu("Restore Color")]
    public void RestoreColor()
    {
        SetColor(initialColor);
    }

    [ContextMenu("Color test")]
    public void ColorTest()
    {
        SetColor(finalColor);
    }

    [ContextMenu("Load Sprites")]
    private void LoadSprites()
    {
        List<SpriteRenderer> spritesInObj = GetComponentsInChildren<SpriteRenderer>().ToList();
        spritesList = spritesInObj.FindAll(t => spritesLayers == (spritesLayers | (1 << t.gameObject.layer)));
    }
}
