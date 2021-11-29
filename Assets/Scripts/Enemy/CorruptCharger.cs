using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptCharger : BaseMoverEnemy
{
    Vector2 targetPosition;

    //public float speed = 1f;
    // Start is called before the first frame update
    public override void StartChildren()
    {
    }

    
    #region Move/Chase


    #endregion

    public void AttackState()
    {
        anim.speed = 1;
        if (!canAttack)
        {
            return;
        }
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        canAttack = false;
        Vector3 attackDirection = targetPosition;

        for(int i = 0; i < 20; i++)
        {
            yield return new WaitForFixedUpdate();
            transform.position += attackDirection * 1.5f /20;
        }

        yield return new WaitForSeconds(0.1f);
        currentState = State.Chase;
        anim.Play(State.Chase.ToString());

        yield return new WaitForSeconds(basicData.powerLevel[indexPowerLevel].cooldown);
        canAttack = true;
    }
    public override void OnEnticipation()
    {
        targetPosition = GetDirectionToPlayer();
    }

    public override void OnMoving(Vector2 MoveDirection)
    {
        if(moveDirection.x > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the charger can attack, then it means he is not attacking
        if (canAttack) return;

        if (collision.gameObject.GetComponent<PlayerHealthManager>())
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().DecreaseHealth(basicData.powerLevel[indexPowerLevel].damage);
        }

    }

}
