using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    int hitPoints;
    [SerializeField, Range(0.05f, 1f)] public float speed;
    public EnemyData basicData;
    public int indexPowerLevel = 0;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    public HealthBarManager healthBar;
    public EncounterManager manager;

   // public bool isAttacking = false;
    public bool canAttack = true;
    public bool isActivated = true;
    //public float range = 2f;

    public void ChangeHitPoints(int value)
    {
        hitPoints += value;
    }

 /*   public void KnockBack(Vector2 attackDirection)
    {

    }*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        healthBar = GetComponentInChildren<HealthBarManager>();

        hitPoints = basicData.powerLevel[indexPowerLevel].maxHitPoint;
        healthBar.SetHealth(hitPoints);

        StartChildren();
    }

    public void TakeDamage(int value)
    {
        hitPoints -= value;
        healthBar.DecreaseHealth(value);

        if(hitPoints < 1)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        manager.RemoveEnemy();
        Destroy(gameObject);
    }

    public abstract void StartChildren();

    // Update is called once per frame
    void Update()
    {
        
    }
}
