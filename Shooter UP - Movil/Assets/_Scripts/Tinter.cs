using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinter : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;
    public Color tintColor;
    [SerializeField] private float timeToGoBack;

    private Color originalColot;

    private void Awake()
    {
        originalColot = _spriteRenderer.color;
    }

    public void DoTint()
    {
        _spriteRenderer.color = tintColor;
        Invoke("TintBackToOriginal", timeToGoBack );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TintBackToOriginal()
    {
        _spriteRenderer.color = originalColot;
    }
}
