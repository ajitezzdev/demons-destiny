using UnityEngine;

public class Vraakscript : MonoBehaviour
{
    public GameObject Vraak;
    public Rigidbody2D rigid;
    public float movespeed;
    public float jumpspeed;
    public float dirc;

    //parameters
    public float Damage;


    public healthBarScript healthBar;
    public HeroAttackBoxScript AttBox;
    public RakHealthBarManager RakHealth;
    

    private float PlayerHalfHeight;

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;

    private float timer=0;
    private float delay=0.4f;
    private bool punchstart=false;
    public bool isdead;
    
    void Start()
    {
        
        PlayerHalfHeight = sr.bounds.extents.y;
    }

    
    void Update()
    {
        isdead=healthBar.Dead;

        if (timer < delay)
        {
            timer += Time.deltaTime;
        }



        dirc = Input.GetAxisRaw("Horizontal");
        rigid.linearVelocity = new Vector2(dirc * movespeed, rigid.linearVelocityY);
        if (dirc == 1 && isdead==false)
        {
            sr.flipX = false;
            AttBox.transform.localScale=new Vector3(1,1,1);
        }
        if (dirc == -1 && isdead==false)
        {
            sr.flipX = true;
            AttBox.transform.localScale=new Vector3(-1,1,1);
        }
        if (dirc != 0)
        {
            anim.SetFloat("xVel", 1);
        }
        if(dirc == 0)
        {
            anim.SetFloat("xVel", 0);
        }


        if (Input.GetButtonDown("Jump") && IsGrounded() )
        {
            Jump();

        }
            
       if (rigid.linearVelocityY != 0)
        {
            anim.SetBool("IsJumping", true);
            
        }    

       if(rigid.linearVelocityY == 0)
        {
            anim.SetBool("IsJumping", false);
        }


       if (Input.GetButtonDown("Punch") && timer>=delay)
        {
            punchstart= true;
            timer = 0;
            anim.SetBool("IsPunching", true);
        }

        if (timer > delay && punchstart==true)
        {
            anim.SetBool("IsPunching", false);
            punchstart = false;
        }

        if (isdead == true)
        {
            rigid.linearVelocity= new Vector2(0,0);
        }
        
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, PlayerHalfHeight+0.05f, LayerMask.GetMask("Ground"));
    }
    
        

    private void Jump()
    {
        rigid.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
    }

    public void InPunchingRange()
    {
        if (AttBox.InPunchRange)
        {
            RakHealth.RakDamage(Damage);
        }
    }
    

}
