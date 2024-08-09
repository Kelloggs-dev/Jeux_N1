using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{
    public float MouveSpeed;
    public float MouveSpeedMax;

    public float JumpForce;

    public bool Est_En_Jump;
    public bool Est_Au_Sol;

    public Transform CheckGauche;
    public Transform CheckDroite;

    public Rigidbody2D rb;
    public Animator Animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D Colision_Player;

    private Vector3 Velocity = Vector3.zero;

    public static Player_Movement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Player_Movement dans la scene ");
            return;
        }

        instance = this;
    }

    void Start()
    {
         
    }

   

    void FixedUpdate()
    {
        Est_Au_Sol = Physics2D.OverlapArea(CheckGauche.position,CheckDroite.position);
        float HorizontalMouve = Input.GetAxis("Horizontal") * MouveSpeed * Time.fixedDeltaTime;
        if (Input.GetButton("Jump") && Est_Au_Sol) {
            Est_En_Jump = true;
        }

        MouvePlayer(HorizontalMouve);

        Flip(rb.velocity.x);

        float CharacterVelocity = Mathf.Abs(rb.velocity.x);
        Animator.SetFloat("Speed", CharacterVelocity);
    }

    void MouvePlayer(float P_HorizontalMouve)
    {

        Vector3 TargetVelocity = new Vector2(P_HorizontalMouve, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, TargetVelocity, ref Velocity, 0.05f, MouveSpeedMax);

        if(Est_En_Jump == true) {
            Est_En_Jump = false;
            rb.AddForce(new Vector2(0f, JumpForce));
            
        }
        

    }
    void Flip(float P_Velocity)
    {
        if(P_Velocity > 0.1f) {
            spriteRenderer.flipX = false;
        } else {
            if(P_Velocity < -0.1f) {
                spriteRenderer.flipX = true;
            }
        }
    }
}
