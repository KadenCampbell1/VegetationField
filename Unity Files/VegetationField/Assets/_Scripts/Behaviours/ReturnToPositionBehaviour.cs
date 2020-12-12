using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class ReturnToPositionBehaviour : MonoBehaviour
{
    public float speed, percentComplete;
    private float startTime;
    private Vector3 startPosition, endPosition;

    private WaitForFixedUpdate wffu;

    private void Start()
    {
        wffu = new WaitForFixedUpdate();
        startPosition = gameObject.transform.position;
        endPosition = gameObject.transform.position;
    }

    private IEnumerator ReturnToStartPosition()
    {
        
        if (percentComplete >= 1)
        {
            percentComplete = 1;
        }
    
        while (percentComplete <= 1)
        {
            percentComplete += speed * Time.deltaTime;
            transform.position = Vector3.Lerp(endPosition, startPosition, percentComplete);
            // transform.rotation = Quaternion.Lerp(endPosition.rotation, startPosition.rotation, percentComplete);
            yield return wffu;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        percentComplete = 0;
        endPosition = gameObject.transform.position;
        StartCoroutine(ReturnToStartPosition());
    }
}
