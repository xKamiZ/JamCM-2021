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
    [SerializeField] private Transform m_bounceTriggerTransform;
    [Header("PARAMETROS")]
    [SerializeField] private float velocidadLateral = 3;
    [SerializeField] private float fuerzaSalto = 5;
    [SerializeField] private LayerMask mascaraSuelo;

    private bool enSuelo, m_isSpriteFlipped;
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
    }
    private void Salto()
    {
        if (m_inputManager._JumpKey && enSuelo)
        {
            m_rb2d.AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    private void EnSuelo()
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
        if (!enSuelo)
        {
            m_animator.SetBool("Saltar", true);
        }
        else 
        {
            m_animator.SetBool("Saltar", false);
        }
    }
    /*
    private void RotateBounce()
	{
		if (m_spriteRenderer.flipX)
		{
            m_bounceTriggerTransform.transform.Rotate(m_bounceTriggerTransform.transform.rotation.x, 180.0f, m_bounceTriggerTransform.transform.rotation.z);
        }
    }
    */
}
