using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private TDActions controls;
    private Rigidbody2D rb;
    public Vector2 movement;
    [SerializeField, Range(0.1f, 10)] float speed = 5f;


    // Start is called before the first frame update
    void Awake()
    {
        controls = new TDActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        movement = controls.Player.Movement.ReadValue<Vector2>();

        Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //transform.up = mousePosition - (Vector2)transform.position;
    }

    private void FixedUpdate()
    {
        rb.position += movement * Time.deltaTime * speed;
        if((movement * Time.deltaTime * speed) == new Vector2())
        {
            rb.velocity = new Vector2();
        }
    }
}
