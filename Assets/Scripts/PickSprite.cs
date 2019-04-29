using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSprite : MonoBehaviour
{
    public Sprite[] sprites;


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteComp = GetComponent<SpriteRenderer>();
        spriteComp.sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
}
