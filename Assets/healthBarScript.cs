using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Image healthBar;
    public float HeroTotalHealth=100f;
    public float healthamt=100f;
   
    public bool Dead=false;

      public float HealDelay;
  public float HealTimer=5;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealTimer < HealDelay)
        {
            HealTimer+=Time.deltaTime;
        }
        if (healthamt<HeroTotalHealth && HealTimer >= HealDelay)
        {
            heal(5f);
            HealTimer=0;
        }


       

        if (healthamt == 0)
        {
            anim.SetBool("IsDead",true);
            Dead=true;
            
        }


    }

    public void takeDamage(float Dmg)
    {
        healthamt -= Dmg;
        healthamt=Mathf.Clamp(healthamt,0,HeroTotalHealth);
        healthBar.fillAmount = healthamt/HeroTotalHealth;
    }

    public void heal(float healthPlus)
    {
        healthamt += healthPlus;
        healthamt = Mathf.Clamp(healthamt, 0, HeroTotalHealth);
        healthBar.fillAmount = healthamt / HeroTotalHealth;
    }

}
