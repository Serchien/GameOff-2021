using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseMoverEnemy>())
        {
            Vector2 dir = collision.transform.position - transform.position;
            Debug.Log(dir);
            collision.GetComponent<BaseMoverEnemy>().DoKnockBack(dir);
            collision.GetComponent<BaseMoverEnemy>().KnockBackState(dir);
        }
    }
}
