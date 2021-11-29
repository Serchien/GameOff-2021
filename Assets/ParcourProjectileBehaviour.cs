using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcourProjectileBehaviour : MonoBehaviour
{
    Vector2 direction;
    int damage;
    float speed = 1;
    ParcourManager manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)transform.position + (direction * Time.deltaTime * speed);
    }
    public void OnInstanciate(Vector2 dir, int _damage, ParcourManager _manager, float _speed)
    {
        direction = dir.normalized;
        damage = _damage;
        manager = _manager;
        speed = _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() || collision.tag == "Shield")
        {
            Destroy(gameObject);
        }
        if (collision.GetComponent<PlayerHealthManager>() && !collision.GetComponent<AbilityInput>().isDashing)
            {
                collision.GetComponent<PlayerHealthManager>().DecreaseHealth(damage);
                manager.GoToCheckpoint(collision.gameObject);
                Destroy(gameObject);
            }
    }
}
