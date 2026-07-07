using UnityEngine;

public class HeroAttackBoxScript : MonoBehaviour
{
    

   public bool InPunchRange=false;

    void Start()
    {
        
    }

   
    void Update()
    {  
        
    }

public void OnTriggerEnter2D(Collider2D collision)
{
    
    InPunchRange = true;
      
}

public void OnTriggerExit2D(Collider2D collision)
{
    
    InPunchRange = false;
    
}



}
