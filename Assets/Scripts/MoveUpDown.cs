using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    Vector3 endPos;
    Vector3 targetPos;
    [SerializeField] private float upDownSpeed;
    [SerializeField] private float leftSpeed;
    void Start()
    {
        startPos = new Vector3(transform.position.x, -1, 0);
        endPos = new Vector3(transform.position.x, 1, 0);
        targetPos = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, upDownSpeed * Time.deltaTime);
        transform.Translate(Vector3.left * leftSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            if (targetPos == endPos)
            {
                targetPos = startPos;
            }
            else
            {
                targetPos = endPos;
            }
        }
    }
}
