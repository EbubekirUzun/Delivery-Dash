using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float delay = 0.1f;
    bool hasPackage = false;
    void OnTriggerEnter2D(Collider2D collision) {

        
        if (collision.CompareTag("Package") && hasPackage == false) {
            Debug.Log("Delivery acquired");
            GetComponent<ParticleSystem>().Play();
            hasPackage = true;
            Destroy(collision.gameObject, delay);
        }
        
        
        if (collision.CompareTag("Customer") && hasPackage == true) {
            Debug.Log("Delivered to customer");
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, delay);
            hasPackage = false;
        }


        
    }

    
}   


