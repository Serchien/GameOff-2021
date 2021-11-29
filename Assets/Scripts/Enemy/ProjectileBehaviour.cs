using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    Vector2 direction;
    int damage;

    [SerializeField] bool attackPlayer;
    [SerializeField, Range(0.01f, 5f)] float speed = 1;
    [SerializeField] int nbBounces = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = (Vector2)transform.position + (direction * Time.deltaTime * speed);
    }
    public void OnInstanciate(Vector2 dir, int _damage)
    {
        direction = dir.normalized;
        damage = _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() || collision.tag == "Shield")
        {
            Destroy(gameObject);
            
        }

        if (attackPlayer)
        {
            if (collision.GetComponent<PlayerHealthManager>() && !collision.GetComponent<AbilityInput>().isDashing)
            {
                collision.GetComponent<PlayerHealthManager>().DecreaseHealth(damage);
                Destroy(gameObject);
            }

        }
        else
        {
            if (collision.GetComponent<BaseEnemy>())
            {

            }
        }

    }

}
