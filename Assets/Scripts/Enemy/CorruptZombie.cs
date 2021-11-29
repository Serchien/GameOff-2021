using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptZombie : BaseMoverEnemy
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
    }

    public override void OnEnticipation()
    {
        targetPosition = GetDirectionToPlayer();
    }

    public override void OnMoving(Vector2 MoveDirection)
    {
        if (moveDirection.x > 0)
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
        if (collision.gameObject.GetComponent<PlayerHealthManager>())
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().DecreaseHealth(basicData.powerLevel[indexPowerLevel].damage);
        }

    }
}
