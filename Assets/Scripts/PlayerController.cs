using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] private float force;
    bool collisionDetection;
    bool collisionCircle;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GetStateGame()) return;
        if (Input.GetMouseButtonDown(0))
        {
            rb.useGravity = true;
            rb.velocity = Vector3.up * force;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            GameManager.instance.SetStateGame(false);

        }
        if (other.gameObject.CompareTag("UpCircle"))
        {
            print("va cham tren");
            collisionDetection = true;
            GameManager.instance.SetStateGame(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("DownCircle") && collisionDetection)
        {
            print("va cham duoi va va cham tren");
            GameManager.instance.SetStateGame(true);
            GameManager.instance.IncreamentXScore();

            if (collisionCircle)
            {
                GameManager.instance.ResetXXXScore();
            }
            GameManager.instance.PraiseActive();
            GameManager.instance.IncreamentScoreText();

            Destroy(other.transform.parent.gameObject);
            collisionCircle = false;
            collisionDetection = false;
        }
        //done
        else if (other.gameObject.CompareTag("DownCircle") && !collisionDetection)
        {
            print("Va cham duoi nhung khong va cham tren");
            GameManager.instance.SetStateGame(false);

        }
    }

    //done
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.instance.SetStateGame(false);
        }
        if (collision.gameObject.CompareTag("Circle"))
        {
            collisionCircle = true;
        }
    }
}
