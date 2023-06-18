using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpaceChallengeObject : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float downUpYAxis;
    public float downDownYAxis;
    public float upUpYAxis;
    public float upDownYAxis;

    public float moveTime;

    public bool isLive;

    private void Awake()
    {
        isLive = false;
    }

    private void Update()
    {
        var temp = transform.position;
        temp.x = player.position.x + 2;
        transform.position = temp;
    }

    public void DownMoveUp()
    {
        transform.DOMoveY(downUpYAxis, moveTime);
        StartCoroutine(DownCoroutine());
    }
    
    public void DownMoveDown()
    {
        transform.DOMoveY(downDownYAxis, moveTime);
    }
    
    public void UpMoveDown()
    {
        transform.DOMoveY(upDownYAxis, moveTime);
        StartCoroutine(UpCoroutine());
    }
    
    public void UpMoveUp()
    {
        transform.DOMoveY(upUpYAxis, moveTime);
    }

    private IEnumerator DownCoroutine()
    {
        isLive = true;
        yield return new WaitForSeconds(4.5f * 5f);
        isLive = false;
        DownMoveDown();
    }
    
    private IEnumerator UpCoroutine()
    {
        isLive = true;
        yield return new WaitForSeconds(4.5f * 5f);
        isLive = false;
        UpMoveUp();
    }
}
