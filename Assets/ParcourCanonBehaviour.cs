using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcourCanonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject projectilePF;
    Vector2 attackDirection;
    ParcourManager manager;

    [SerializeField, Range(0.01f, 5)] float cooldown = 1f;
    [SerializeField, Range(1, 10)] int damage = 1;
    [SerializeField, Range(0.1f, 5)] float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        attackDirection = transform.up;
        manager = GetComponentInParent<ParcourManager>();
        CallRoutine();
    }

    void CallRoutine()
    {
        if (!manager.parcourActive) return;
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(cooldown);
        GameObject projectile = Instantiate(projectilePF);
        projectile.transform.position = transform.position;
        projectile.GetComponent<ParcourProjectileBehaviour>().OnInstanciate(attackDirection, damage, manager, speed);
        CallRoutine();

    }

}
