using Unity.VisualScripting;
using UnityEngine;

public class PegarItensController : MonoBehaviour
{
    public int qtd = 0;
    public GameObject rifle;
    public MovCamPlayerController mov;
    void Start()
    {

    }


    void Update()
    {
       if (mov.ativo1P)
       {
          rifle.SetActive(true);
       }
       else
       {
          rifle.SetActive(false);
       }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "espada")
        {
            qtd ++;
            // qtd = qtd + 1;
            Destroy(collision.gameObject);
            Debug.Log("Pegou a espada");
        }
        if (collision.gameObject.tag == "Ring")
        {
            qtd++;
            // qtd = qtd + 1;
            Destroy(collision.gameObject);
            Debug.Log("Pegou o Ring");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "espada")
        {
            qtd ++;
            Destroy(other.gameObject);
            Debug.Log("Pegou a espada");
        }
        if (other.gameObject.tag == "Ring")
        {
            qtd++;
            Destroy(other.gameObject);
            Debug.Log("Pegou a Ring");
        }

    }    
          
}   
