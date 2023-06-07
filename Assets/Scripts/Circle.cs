using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(-1, 0.5f, 0f) * speed * Time.deltaTime);
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
