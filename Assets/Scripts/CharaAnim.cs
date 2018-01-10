using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnim : MonoBehaviour {
    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    public int spriteSetIndex = 0;

    public List<SpriteSet> spriteSets = new List<SpriteSet>();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public void SetSprite(SpriteDir dir, int step = 0)
    {
        spriteRenderer.sprite = SpriteFromDir(dir, step);
    }

    public Sprite SpriteFromDir(SpriteDir dir, int step = 0)
    {
        if (step > 2 || step < 0) step = 0;

        var sprite = SpriteFromIndex(3 * (int)dir + step);

        //default to the still sprite if no steps are set
        if(sprite == null) sprite = SpriteFromIndex(3 * (int)dir);

        return sprite;
    }

    public Sprite SpriteFromIndex(int index)
    {
        if(spriteSets.Count <= spriteSetIndex || spriteSetIndex < 0) return null;

        var s = spriteSets[spriteSetIndex];

        switch(index)
        {
            case 0: return s.upStill;
            case 1: return s.upStep1;
            case 2: return s.upStep2;
            case 3: return s.rightStill;
            case 4: return s.rightStep1;
            case 5: return s.rightStep2;
            case 6: return s.downStill;
            case 7: return s.downStep1;
            case 8: return s.downStep2;
            case 9: return s.leftStill;
            case 10: return s.leftStep1;
            case 11: return s.leftStep2;
            default: return s.downStill;
        }
    }
}

[System.Serializable]
public struct SpriteSet
    {
        public string name;

        #region Sprites
        [Header("Facing Up")]
        public Sprite upStill;
        public Sprite upStep1;
        public Sprite upStep2;

        [Header("Facing Right")]
        public Sprite rightStill;
        public Sprite rightStep1;
        public Sprite rightStep2;

        [Header("Facing Down")]
        public Sprite downStill;
        public Sprite downStep1;
        public Sprite downStep2;

        [Header("Facing Left")]
        public Sprite leftStill;
        public Sprite leftStep1;
        public Sprite leftStep2;
        #endregion

    }

public enum SpriteDir
{
    None = -1,
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
}