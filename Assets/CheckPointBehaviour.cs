using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CheckPointBehaviour : MonoBehaviour
{
    public bool isActive = false;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite active;
    [SerializeField] Sprite off;

    CheckPointManager manager;
    Light2D light;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        manager = GetComponentInParent<CheckPointManager>();
        light = GetComponentInChildren<Light2D>();
    }

    void Activate()
    {
        isActive = true;
        spriteRenderer.sprite = active;
        light.enabled = true;

    }

    public void DeActivate()
    {
        isActive = false;
        spriteRenderer.sprite = off;
        light.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            Activate();
            manager.ChangeCurrentCheckpoint(this);
        }
    }
}
