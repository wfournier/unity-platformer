using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public Sprite flagClosed;
    public Sprite flagOpened;

    public bool active;

    private SpriteRenderer spriteRenderer;
        
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!active && other.CompareTag("Player"))
        {
            spriteRenderer.sprite = flagOpened;
            active = true;
        }
    }

}
