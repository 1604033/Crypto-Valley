using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{
    public Collider flyingArea; // The collider representing the flying area
    public float speed = 2f; // Speed of the butterfly
    public float changeDirectionInterval = 2f; // Interval for changing direction
    public float stopDuration = 5f; // Duration to stop before changing direction

    private Vector3 targetPosition;

    void Start()
    {
        SetNewTargetPosition();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    private void SetNewTargetPosition()
    {
        Bounds bounds = flyingArea.bounds;
        targetPosition = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            StartCoroutine(WaitBeforeSettingNewTarget());
        }
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionInterval);
            StartCoroutine(WaitBeforeSettingNewTarget());
        }
    }

    private IEnumerator WaitBeforeSettingNewTarget()
    {
        yield return new WaitForSeconds(stopDuration);
        SetNewTargetPosition();
    }
}
