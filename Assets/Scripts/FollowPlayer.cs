using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset;
    [SerializeField]
    public Vector3 minValue, maxValue;

    private void Start()
    {
        offset = transform.position - target.transform.position; 
    }

    private void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        //Verify if the targetPosition is out of bound or not
        //Limit it to the min and max values
        transform.position = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValue.y, maxValue.z));
    }
}
