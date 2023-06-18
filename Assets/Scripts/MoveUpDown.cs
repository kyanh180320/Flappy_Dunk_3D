using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject endPos;
    [SerializeField] GameObject circle;
    [SerializeField] private float upDownSpeed;
    [SerializeField] private float leftSpeed;
    Vector3 targetPos;
    // Update is called once per frame

    public bool isMoveUp;
    public bool isMoveDown;
    private void Start()
    {
    }
    void Update()
    {
        transform.Translate(Vector3.left * leftSpeed * Time.deltaTime);

        if (circle != null)
        {
            if (isMoveUp)
            {

                circle.transform.position = Vector3.MoveTowards(circle.transform.position, startPos.transform.position, upDownSpeed * Time.deltaTime);

                if (circle.transform.position == startPos.transform.position)
                {
                    //print("Must moveDown");
                    isMoveUp = !isMoveUp;
                    isMoveDown = !isMoveUp;

                }

            }
            else if (isMoveDown)
            {
                //print("Move Down");
                circle.transform.position = Vector3.MoveTowards(circle.transform.position, endPos.transform.position, upDownSpeed * Time.deltaTime);
                if (circle.transform.position == endPos.transform.position)
                {
                    isMoveUp = !isMoveUp;
                    isMoveDown = !isMoveUp;
                }
            }
        }

    }
}
