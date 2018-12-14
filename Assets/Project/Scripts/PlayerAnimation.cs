﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Sprite[] Sprites;
    public float framesPerSec;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rig;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.x != 0)
        {
            int index = (int)(Time.time * framesPerSec) % Sprites.Length;
            spriteRenderer.sprite = Sprites[index];
        }
    }
}