using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    int damage = 0;
    [SerializeField, Range(10f, 250f)] float speed = 1;
    [SerializeField] int nbBounces = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void OnInstanciate(Vector2 dir, int _damage)
    {
        rb = GetComponent<Rigidbody2D>();

        direction = dir.normalized;
        damage = _damage;
        rb.AddForce(dir.normalized * speed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CompositeCollider2D>())
        {
            if (nbBounces > 0)
            {
                nbBounces--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.GetComponent<BaseEnemy>())
            {
                collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(AbilityData.secondaryAttackDamage);
                Destroy(gameObject);
            }
        }
    }

}
