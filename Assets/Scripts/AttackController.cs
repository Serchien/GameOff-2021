using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private BoxCollider2D basicAttackCollider;
    private Animator animator;
    private ParticleSystem weaponTrail;

    private SpriteRenderer swordSprite;
    [SerializeField] Color transparent;

    private Vector2 lastAttackDirection;
     //Color normalColor;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        basicAttackCollider = GetComponent<BoxCollider2D>();
        weaponTrail = GetComponentInChildren<ParticleSystem>();
        swordSprite = GetComponentInChildren<SpriteRenderer>();
        basicAttackCollider.enabled = false;
        weaponTrail.Stop();
        swordSprite.color = new Color(255, 255, 255, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackEnd()
    {
        animator.Play("Idle");
        swordSprite.color = new Color(255, 255, 255, 0);
        weaponTrail.Stop();
    }

    public void NewAnimation(string anim, Vector2 direction)
    {
        weaponTrail.Stop();
        weaponTrail.Play();
        swordSprite.color = new Color(255, 255, 255, 0.8f);

        lastAttackDirection = direction;
        transform.up = direction;
        animator.Play(anim);

    }

    public IEnumerator DoAttack()
    {
        basicAttackCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        basicAttackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.GetComponent<BaseEnemy>())
            {
                collision.GetComponent<BaseEnemy>().TakeDamage(AbilityData.basicAttackDamage);
                if (collision.GetComponent<BaseMoverEnemy>())
                {
                    collision.GetComponent<BaseMoverEnemy>().DoKnockBack(lastAttackDirection);
                    collision.GetComponent<BaseMoverEnemy>().KnockBackState(lastAttackDirection);
                }

            }
        }
    }
}
