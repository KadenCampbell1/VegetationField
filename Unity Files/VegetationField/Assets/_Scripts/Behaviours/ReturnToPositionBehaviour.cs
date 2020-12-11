using UnityEditor;
using UnityEngine;

public class ReturnToPositionBehaviour : MonoBehaviour
{
    public float speed;
    private float startTime, journeyLength;
    private Vector3 startPosition, endPosition;
    
    private void Start()
    {
        startPosition = gameObject.transform.position;
    }

    public void ReturnToPosition()
    {
        startTime = Time.time;
        var distanceCovered = (Time.time - startTime) * speed;
        var journeyFraction = distanceCovered / journeyLength;

        transform.position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
    }

    private void OnTriggerExit(Collider other)
    {
        endPosition = gameObject.transform.position;
        journeyLength = Vector3.Distance(startPosition, endPosition);
        ReturnToPosition();
    }
}
