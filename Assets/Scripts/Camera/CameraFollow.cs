
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject darkplane;
    public GameObject target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValues, maxValues;

    private void FixedUpdate()
    {
        Follow();
    }



    void Follow()
    {
        Vector3 targetPosition = target.transform.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x,maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position,boundPosition,smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

    private void ResetPosition()
    {
        Vector3 smoothPosition = transform.position;
        transform.position = smoothPosition;
    }
}
