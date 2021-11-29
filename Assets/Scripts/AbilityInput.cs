using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInput : MonoBehaviour
{
    public bool isDashing = false;
    public bool inShield = false;
    [SerializeField] int dashCost = 2;

    [SerializeField] int secondaryDamage = 2;
    [SerializeField] int secondaryCost = 3;
    [SerializeField] int shieldCost = 5;


    [SerializeField] GameObject projectilePF;
    [SerializeField] SpriteRenderer shieldSprite;

    private TDActions controls;
    private AttackController attController;
    RAMBarManager ram;

    PlayerMovement movement;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new TDActions();
        attController = GetComponentInChildren<AttackController>();
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controls.Player.BasicAttack.performed += _ => PlayerBasicAttack();
        controls.Player.Dash.performed += _ => PlayerDash();
        controls.Player.SecondaryAttack.performed += _ => PlayerSecondaryAttack();
        controls.Player.Shield.performed += _ => PlayerShield();
        ram = PlayerManager.playerRAM;

    }

    private void PlayerBasicAttack()
    {
        Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        attController.NewAnimation("Basic-Attack", mousePosition - (Vector2)transform.position);
    }

    void PlayerDash()
    {
        if (AbilityData.isDashActive)
        {
            if(ram.currentRAM - dashCost > 0)
            {
                ram.DecreaseRAM(dashCost);
                StartCoroutine(PlayerDashRoutine());
            }
        }
    }

    void PlayerShield()
    {
        if (!AbilityData.isShieldActive) return;
        if (inShield) return;

        if (ram.currentRAM - shieldCost > 0)
        {
            StartCoroutine(PlayShield());
        }
    }

    IEnumerator PlayShield()
    {
        inShield = true;
        shieldSprite.enabled = true;
        shieldSprite.GetComponent<CircleCollider2D>().enabled = true;
        ram.DecreaseRAM(shieldCost);

        yield return new WaitForSeconds(AbilityData.shieldTime);
        inShield = false;
        shieldSprite.enabled = false;
        shieldSprite.GetComponent<CircleCollider2D>().enabled = false;

    }

    void PlayerSecondaryAttack()
    {
        if (!AbilityData.isSecondaryAttackActive) return;
        if (ram.currentRAM - secondaryCost > 0)
        {
            ram.DecreaseRAM(dashCost);
            GameObject projectile = Instantiate(projectilePF);
            projectile.transform.position = transform.position;
            Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            projectile.GetComponent<PlayerProjectile>().OnInstanciate(mousePosition - (Vector2)transform.position, secondaryDamage);
        }

    }

    private IEnumerator PlayerDashRoutine()
    {
        isDashing = true;
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForFixedUpdate();
            //rb.AddForce(dir * 3);
            rb.velocity = movement.movement.normalized * 10f;
        }
        rb.velocity = new Vector2();


        isDashing = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
