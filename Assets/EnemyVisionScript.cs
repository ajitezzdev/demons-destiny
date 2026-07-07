using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    
    public bool heroInSight=false;
    public Transform HeroRef;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        heroInSight=true;
        HeroRef=collision.transform;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        
        heroInSight=false;
        HeroRef=null;
    }



}
