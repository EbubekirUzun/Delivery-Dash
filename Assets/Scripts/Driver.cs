using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{

    [SerializeField] float CurrentSpeed = .5f;
    [SerializeField] float SteerSpeed = .15f;
    [SerializeField] float BoostedSpeed = 10f;
    [SerializeField] float ReturnedSpeed = .5f;
    [SerializeField] TMP_Text BoostText;

    void Start()
    {
        BoostText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Boost"))
            {
                CurrentSpeed = BoostedSpeed;
                BoostText.gameObject.SetActive(true);
                Destroy(collision.gameObject);
            }
     }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        CurrentSpeed = ReturnedSpeed;
        BoostText.gameObject.SetActive(false);
        
    }
    void Update()
    {

        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }


        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }


        float moveAmountThisFrame = CurrentSpeed * Time.deltaTime;
        float steerAmountThisFrame = SteerSpeed * Time.deltaTime;
        
        transform.Translate(0, move * moveAmountThisFrame, 0);
        transform.Rotate(0, 0, steer * steerAmountThisFrame);
    }
}
