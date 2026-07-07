using UnityEngine;

public class RakAttackScript : MonoBehaviour
{
   public bool InAttackRange=false;
   public Animator anim;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

public void OnTriggerEnter2D(Collider2D collision)
    {
        InAttackRange=true;
        
    }
public void OnTriggerExit2D(Collider2D collision)
    {
        InAttackRange=false;
        
    }

}
