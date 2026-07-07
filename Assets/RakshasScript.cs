using UnityEngine;

public class RakshasScript : MonoBehaviour
{   private float walktimer=0;
    public float walkTime;
    public float standTime;
    public float walkspeed;
    private bool walkRight=true;
    public float attackColliderOffset;
    public float EneHitDist=0.4f;

    public bool Punching=false;
    public float punchDelay;
    public float punchTimer;
    public float punchStopDelay;




   private EnemyVisionScript EneVis;
   private healthBarScript healthBar;
   private RakAttackScript EneAttk;
   [SerializeField] private Rigidbody2D rigid;
   [SerializeField] private SpriteRenderer sr;
   [SerializeField] private Animator anim;
    

    void Start()
    {
     standTime+=walkTime;   
     EneVis=FindAnyObjectByType<EnemyVisionScript>();
     EneAttk=FindAnyObjectByType<RakAttackScript>();
     healthBar=FindAnyObjectByType<healthBarScript>();
    }

    
    void Update()
    {
      if(punchTimer < punchDelay)
    {
      rigid.linearVelocity = Vector2.zero;
      punchTimer+=Time.deltaTime;
    }
    else if (punchTimer >= punchDelay)
    {
      Punching=false;
    }
    if (punchTimer > punchStopDelay)
    {
      anim.SetBool("IsPunch",false);
    }
      
      
    if (EneVis.heroInSight == false && Punching==false)
    {
      mindlessWalk();
    }
    else if (EneVis.heroInSight == true && EneAttk.InAttackRange == false && Punching==false)
    {
      chase();
    }
    else if(EneAttk.InAttackRange == true && Punching == false)
    {
      punch();
      Punching=true;
      punchTimer=0;
    }


    if (rigid.linearVelocityX > 0 && Punching==false)
    {
      sr.flipX=false;
      EneAttk.transform.localScale= new Vector3(1,1,1);
    }
    if (rigid.linearVelocityX < 0 && Punching==false)
    {
      sr.flipX=true;
      EneAttk.transform.localScale= new Vector3(-1,1,1);
    }
    if (rigid.linearVelocityX != 0)
    {
      anim.SetFloat("xVel",1);
    }
    else if (rigid.linearVelocityX == 0)
    {
      anim.SetFloat("xVel",0);
    }

    
    


    }




    public void mindlessWalk()
    { if (walktimer < walkTime && walkRight==true)
        {
            rigid.linearVelocity= Vector2.right*walkspeed;
            walktimer+=Time.deltaTime;
        }
      if (walktimer < walkTime && walkRight==false)
        {
            rigid.linearVelocity= Vector2.left*walkspeed;
            walktimer+=Time.deltaTime;
        }

      if (walktimer >= walkTime && walktimer < standTime)
        { rigid.linearVelocity= Vector2.zero;
          walktimer+=Time.deltaTime;
            
        }
      if( walktimer >= standTime)
        {walktimer=0;
        if (walkRight==true)
      {
        walkRight=false;
      }
      else
      {
        walkRight=true;
      }
            
        }

        
    }

    public void chase()
  { float dist= EneVis.HeroRef.position.x-transform.position.x;
  


    if (Mathf.Abs(dist)>=EneHitDist && dist < 0)
    {
      rigid.linearVelocity= Vector2.left*walkspeed;
    }
    if (Mathf.Abs(dist)>=EneHitDist && dist > 0)
    {
      rigid.linearVelocity= Vector2.right*walkspeed;
    }
    
  }

  public void punch()
  {
   anim.SetBool("IsPunch",true);
  }

  public void checkForDamage()
  {
    if (EneAttk.InAttackRange)
    {
      healthBar.takeDamage(10);
    }
  }

    

}
