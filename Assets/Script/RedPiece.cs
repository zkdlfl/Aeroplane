using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPiece : ChessPiece
{
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        pieceColor = "Red";
        SetupComponents();
    }

     private void SetupComponents()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/redplane");

        // CircleCollider2D setup
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
        circleCollider.radius = 0.5f;
    }
}

