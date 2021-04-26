/*Tile sprite selection Script
 BrittanyBlair*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelect : MonoBehaviour
{
    //list of available sprites
    [SerializeField] private Sprite[] Sprites = null;
    
    //sprite renderer
    private SpriteRenderer thisSR = null;

    //sprite selected from list 

    private Sprite thisSprite = null;
    // Start is called before the first frame update
    void Start()
    {
        // grab a random sprite from list
        int ListLength = Sprites.Length;
        int RandomeSprite = Random.Range(0, ListLength);

        //apply sprite to sprite renderer
        thisSprite = Sprites[RandomeSprite];
        thisSR = GetComponent<SpriteRenderer>();
        thisSR.sprite = thisSprite;
    }

}
