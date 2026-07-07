using UnityEngine;

public class backgroundscript : MonoBehaviour
{
    public Transform Vraak;
    public float parallax;

    private float InitPosX;
    void Start()
    {
        InitPosX=gameObject.transform.position.x;
    }

    
    void Update()
    {
        float NewX=InitPosX + (Vraak.position.x*parallax);
        transform.position=new Vector3(NewX,transform.position.y,transform.position.z);
    }
}
