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

    public Sprite greenLock;

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
        if(other.gameObject.CompareTag("Key"))
        {
            Transform circle = other.transform.parent;
            Transform lockTrans = circle.Find("Lock");
            SpriteRenderer lockRender = lockTrans.GetComponent<SpriteRenderer>();
            SpriteRenderer keyRender = other.gameObject.GetComponentInChildren<SpriteRenderer>();
            lockRender.sprite = greenLock;
            keyRender.sprite = greenLock;
            Transform barrier = circle.Find("Barrier");
            Destroy(barrier.gameObject);
        }
        if (other.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("Dead Zone collide " + other.gameObject.name);
            GameManager.instance.SetStateGame(false);
        }
        if (other.gameObject.CompareTag("UpCircle"))
        {
            print("va cham tren");
            collisionDetection = true;
            GameManager.instance.SetStateGame(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("DownScoreCircle"))
        {
            GameManager.instance.Plus10Score();
        }
        if (other.gameObject.CompareTag("DownFeverCircle"))
        {
            GameManager.instance.Plus5XScore();
        }
        if (other.gameObject.CompareTag("DownCircle") && collisionDetection)
        {
            print("va cham duoi va va cham tren");
            GameManager.instance.SetStateGame(true);
            GameManager.instance.IncreamentXScore(1);

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
            rb.useGravity = false;  
            rb.mass = 0f;
            GameManager.instance.SetStateGame(false);
            GameManager.instance.LooseUIActive();
        }
    }

    //done
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.instance.SetStateGame(false);
            GameManager.instance.LooseUIActive();
        }
        if (collision.gameObject.CompareTag("Circle"))
        {
            collisionCircle = true;
        }
        if (collision.gameObject.CompareTag("SpaceChallenge"))
        {
            GameManager.instance.SetStateGame(false);
            GameManager.instance.LooseUIActive();
        }
        if (collision.gameObject.CompareTag("LockBarrier"))
        {
            GameManager.instance.SetStateGame(false);
            GameManager.instance.LooseUIActive();
        }
    }
}
