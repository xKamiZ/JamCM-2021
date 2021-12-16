using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("REFERENCIAS")]
    [SerializeField] private InputManager m_inputManager;
    [SerializeField] private Transform refRayoSuelo;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private Rigidbody2D m_rb2d;
    [SerializeField] private Animator m_animator;
    [Header("PARAMETROS")]
    [SerializeField] private float velocidadLateral = 3;
    [SerializeField] private float fuerzaSalto = 5;
    [SerializeField] private float fuerzaTorque = 20;
    [SerializeField] private LayerMask mascaraSuelo;

    private bool enSuelo;
    private float dashCounter, dashCoolCounter, activeMoveSpeed;
    private float dashSpeed, dashLength = 0.5f, dashCooldown = 1f;

    private void Start()
    {
        activeMoveSpeed = velocidadLateral;
    }
    private void Update()
    {
        EnSuelo();
        Salto();
        Animaciones();
    }
	private void FixedUpdate()
	{
        Movimiento();
    }

    private void Movimiento()
    {
        m_rb2d.velocity = new Vector2(m_inputManager._Horizontal * activeMoveSpeed, m_rb2d.velocity.y);
        // Dash();
    }
    void Salto()
    {
        if (m_inputManager._JumpKey && enSuelo)
        {
            m_rb2d.AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    void EnSuelo()
    {
        RaycastHit2D hit = Physics2D.Raycast(refRayoSuelo.position, -transform.up, 0.3f, mascaraSuelo);
        Debug.DrawRay(refRayoSuelo.position, -transform.up * 0.3f, Color.red);
        if (hit)
        {
            enSuelo = true;
        }
        else
        {
            enSuelo = false;
        }
    }
    /*
    void Dash()
    {
        if (m_inputManager._DashKey)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = velocidadLateral;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
    */
    private void Animaciones()
    {
        m_animator.SetFloat("running", Mathf.Abs(m_inputManager._Horizontal));

		if (m_inputManager._Horizontal < 0)
		{
            m_spriteRenderer.flipX = true;
		}
		else if (m_inputManager._Horizontal > 0)
		{
            m_spriteRenderer.flipX = false;
        }
        if (m_inputManager._BasicAttack)
        {
            m_animator.SetBool("isAttacking",true);
        }
        if (!enSuelo)
        {
            m_animator.SetBool("Saltar", true);
        }
        else 
        {
            m_animator.SetBool("Saltar", false);
        }

    }
}
