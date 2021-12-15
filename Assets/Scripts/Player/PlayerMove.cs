using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("REFERENCIAS")]
    [SerializeField] private InputManager m_inputManager;
    [SerializeField] private Transform refRayoSuelo;
    [Header("PARAMETROS")]
    [SerializeField] private float velocidadLateral = 3;
    [SerializeField] private float fuerzaSalto = 5;
    [SerializeField] private float fuerzaTorque = 20;
    [SerializeField] private LayerMask mascaraSuelo;

    private bool enSuelo;
    private float dashCounter, dashCoolCounter, activeMoveSpeed;
    private Animator Animator;
    private Rigidbody2D rb;

    private float dashSpeed, dashLength = 0.5f, dashCooldown = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = velocidadLateral;
        Animator = GetComponent<Animator>();
    }
    void Update()
    {
        EnSuelo();
        Salto();
        Movimiento();
        Animaciones();
    }
    void Movimiento()
    {
        rb.velocity = new Vector2(m_inputManager._Horizontal * activeMoveSpeed, rb.velocity.y);
        Dash();
        if (m_inputManager._Vertical > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (m_inputManager._Horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void Salto()
    {
        if (m_inputManager._JumpKey && enSuelo)
        {
            rb.AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);
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
    void Animaciones()
    {
        Animator.SetFloat("running", Mathf.Abs(rb.velocity.x));
    }
}
