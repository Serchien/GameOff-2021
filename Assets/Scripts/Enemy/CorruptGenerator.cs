using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptGenerator : BaseMoverEnemy
{
    Vector2 targetPosition;
    [SerializeField] GameObject projectilePF;
    [SerializeField] int[] nbOfProjectiles;
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
        float angleStep = 360f / nbOfProjectiles[indexPowerLevel];
        float angle = Random.Range(0f, 360f);

        while (nbOfAttackRemaining > 0)
        {

            for(int i = 0; i <= nbOfProjectiles[indexPowerLevel] - 1; i++)
            {
                float projectileDirectionXPoisition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
                float projectileDirectionYPoisition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

                Vector2 attackDirection = new Vector2(projectileDirectionXPoisition, projectileDirectionYPoisition);

                GameObject projetile = Instantiate(projectilePF);
                projetile.transform.position = transform.position;
                projetile.GetComponent<ProjectileBehaviour>().OnInstanciate(attackDirection - (Vector2)transform.position, basicData.powerLevel[indexPowerLevel].damage);

                angle += angleStep;
            }
            yield return new WaitForSeconds(basicData.powerLevel[indexPowerLevel].timeBetweenAttacks);
            nbOfAttackRemaining--;
        }
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
