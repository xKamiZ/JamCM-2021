using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator Animator;
    public float velocidadLateral = 3, fuerzaSalto = 5, fuerzaTorque = 20;
    public float dashSpeed, dashLength = 0.5f, dashCooldown = 1f;
    public bool enSuelo;
    public LayerMask mascaraSuelo;
    public Transform refRayoSuelo;
    private float dashCounter, dashCoolCounter, activeMoveSpeed;
    public Animator Animator;


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
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * activeMoveSpeed, rb.velocity.y);
        Dash();
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
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
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.LeftShift))
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
