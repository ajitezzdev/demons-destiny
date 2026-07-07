using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject Vraak;
    private float offset=1;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(Vraak.transform.position.x,Vraak.transform.position.y+offset,transform.position.z);
    }
}
