using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorBehaviour : MonoBehaviour
{
    ParcourManager manager;
    [SerializeField] Sprite spriteInnactive;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<ParcourManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AttackController>())
        {
            manager.parcourActive = false;
            GetComponent<SpriteRenderer>().sprite = spriteInnactive;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
