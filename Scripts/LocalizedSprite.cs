using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LocalizedSprite : AbstractLocalizedSprite
{
    private SpriteRenderer _spriteRenderer;

    private SpriteRenderer spriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }

    public override Sprite sprite
    {
        get
        {
            return spriteRenderer.sprite;
        }
    }

    public override void UpdateSprite()
    {
        spriteRenderer.sprite = LocalizationManager.Instance.GetSprite(key);
    }
}
