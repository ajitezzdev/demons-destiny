using UnityEngine.UI;
using UnityEngine;

public class RakHealthBarManager : MonoBehaviour
{
    public float RakTotalHealth=100f;
  public float RakHealth=100f;
  public Image RakHealthBar;

  public float HealDelay;
  public float HealTimer=5;
  public bool Dead=false;


[SerializeField] private Animator anim;


    void Start()
    {
        
    }

   
    void Update()
    {
        if (HealTimer < HealDelay)
        {
            HealTimer+=Time.deltaTime;
        }
        if (RakHealth<RakTotalHealth && HealTimer >= HealDelay && Dead==false)
        {
            heal(5f);
            HealTimer=0;
        }

         if (RakHealth == 0)
        {
            anim.SetBool("IsDead",true);
            Dead=true;
            
        }




        if (Input.GetKeyDown(KeyCode.B))
        {
            RakDamage(10);
        }
    }

    public void RakDamage(float Dmg)
    {
        RakHealth-=Dmg;
        Mathf.Clamp(RakHealth,0,RakTotalHealth);
        RakHealthBar.fillAmount=RakHealth/RakTotalHealth;
    }

    public void heal(float healthPlus)
    {
        RakHealth += healthPlus;
        RakHealth = Mathf.Clamp(RakHealth, 0, RakTotalHealth);
        RakHealthBar.fillAmount = RakHealth / RakTotalHealth;
    }


}
