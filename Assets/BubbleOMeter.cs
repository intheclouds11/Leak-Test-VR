using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class BubbleOMeter : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _initialPosition;
    public float speed = 0.1f;
    private IEnumerator _animateBubble;
    public float bubbleHeight = 0.5f;
    private bool isBubbling;

    private void OnEnable()
    {
        ValveTrigger.ValveAtLeakPressure += StartBubbleUp;
        ValveTrigger.ValveAtZeroPressure += StopBubbleUp;
    }

    private void OnDisable()
    {
        ValveTrigger.ValveAtLeakPressure -= StartBubbleUp;
        ValveTrigger.ValveAtZeroPressure -= StopBubbleUp;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _initialPosition = transform.localPosition;
    }

    void StartBubbleUp()
    {
        if (!isBubbling)
        {
            Debug.Log("bubble up started");
            _animateBubble = AnimateBubble();
            StartCoroutine(_animateBubble);
        }
    }

    public void StopBubbleUp()
    {
        isBubbling = false;
        Debug.Log("stopped bubble up");
        StopCoroutine(_animateBubble);
    }

    IEnumerator AnimateBubble()
    {
        isBubbling = true;
        while (transform.localPosition.y <= bubbleHeight)
        {
            var transformLocalPosition = transform.localPosition;
            transformLocalPosition.y += speed * Time.deltaTime;
            transform.localPosition = new Vector3(_initialPosition.x, transformLocalPosition.y, _initialPosition.z);
            yield return null;
        }

        transform.localPosition = _initialPosition;
        isBubbling = false;
        yield return AnimateBubble();
    }
}