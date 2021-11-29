using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMoverEnemy : BaseEnemy
{
    public bool canMove = true;
    [SerializeField] Sprite damagedSprite;
    public enum State
    {
        Idle,
        Chase,
        Attack,
        knockback
    }

    public State currentState;
    public Vector2 moveDirection;
    public override void StartChildren()
    {
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        EvaluateBehaviour();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void KnockBackState(Vector2 dir)
    {
        StartCoroutine(DoKnockBack(dir));
    }

    public IEnumerator DoKnockBack(Vector2 dir)
    {
        Sprite previousImage = sprite.sprite;
        sprite.sprite = damagedSprite;
        canMove = false;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForFixedUpdate();
            //rb.AddForce(dir * 3);
            rb.velocity = dir.normalized * 2.5f;
        }
        rb.velocity = new Vector2();
        sprite.sprite = previousImage;
        canMove = true;

    }
    void EvaluateBehaviour()
    {
        switch (currentState)
        {
            case State.Idle:
                {
                    if (isActivated)
                    {
                        currentState = State.Chase;
                    }
                    break;
                }
            case State.Chase:
                {
                    moveDirection = GetDirectionToPlayer();
                    break;
                }
            case State.Attack:
                {
                    //AttackState(); 
                    break;
                }
            case State.knockback:
                {
                    //KnockBackState();
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
    public Vector2 GetDirectionToPlayer()
    {
        Vector2 dir = PlayerManager.Player.transform.position - transform.position;
        dir = dir.normalized;
        return dir;
    }
    void Move()
    {
        if (currentState == State.Chase && isActivated && canMove)
        {
            if (CheckInRange() && canAttack)
            {
                EnticipationState();
                currentState = State.Attack;
                rb.velocity = new Vector2();
                //rb.MovePosition((Vector2)transform.position + moveDirection * speed);
            }
            else
            {
                rb.velocity = moveDirection * speed;
                OnMoving(moveDirection);
            }
        }
    }

    bool CheckInRange()
    {
        float dist = Vector2.Distance(PlayerManager.Player.transform.position, transform.position);
        if (dist < basicData.powerLevel[indexPowerLevel].range)
        {
            return true;
        }
        return false;
    }

    void EnticipationState()
    {
        OnEnticipation();

        anim.speed = basicData.powerLevel[indexPowerLevel].enticipationTime;
        anim.Play(State.Attack.ToString());
    }

    public abstract void OnEnticipation();
    public abstract void OnMoving(Vector2 moveDirection);
}
