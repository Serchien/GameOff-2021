using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptSpitter : BaseMoverEnemy
{
    Vector2 targetPosition;
    [SerializeField] GameObject projectilePF;

    //public float speed = 1f;
    // Start is called before the first frame update

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
        int nbOfAttackRemaining = basicData.powerLevel[indexPowerLevel].NbOfAttacks;
        canAttack = false;

        while (nbOfAttackRemaining > 0)
        {
            Vector2 attackDirection = targetPosition;

            GameObject projetile = Instantiate(projectilePF);
            projetile.transform.position = transform.position;
            projetile.GetComponent<ProjectileBehaviour>().OnInstanciate(attackDirection, basicData.powerLevel[indexPowerLevel].damage);

            yield return new WaitForSeconds(basicData.powerLevel[indexPowerLevel].timeBetweenAttacks);
            currentState = State.Chase;
            anim.Play(State.Chase.ToString());

            nbOfAttackRemaining--;
        }

        yield return new WaitForSeconds(basicData.powerLevel[indexPowerLevel].cooldown);
        canAttack = true;

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
        if (canAttack) return;

        if (collision.gameObject.GetComponent<PlayerHealthManager>())
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().DecreaseHealth(basicData.powerLevel[indexPowerLevel].damage);
        }

    }

}
