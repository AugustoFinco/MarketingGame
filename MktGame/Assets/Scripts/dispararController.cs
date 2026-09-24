using UnityEngine;

public class dispararController : MonoBehaviour
{
    Rigidbody fis;
    public float force = 1000f;
    void Start()
    {
        fis = GetComponent<Rigidbody>();
        fis.AddForce(transform.forward * force);
        Destroy(gameObject, 2f);
    }

    
    void Update()
    {
        
    }
}
