using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRamming : MonoBehaviour
{
    [SerializeField] private Transform targetPositionTransform;

    private EnemyShipDriver carDriver;
    private GameObject player;
    private Vector3 targetPosition;

    private void Awake()
    {
        carDriver = GetComponent<EnemyShipDriver>();
        player = GameObject.Find("Player");
        targetPositionTransform = player.transform;
    }

    private void Update()
    {
        SetTargetPosition(targetPositionTransform.position);

        float forwardAmount = 0f;
        float turnAmount = 0f;

        float reachedTargetDistance = 0f;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distanceToTarget > reachedTargetDistance)
        {
            // Still too far, keep going
            Vector3 dirToMovePosition = (targetPosition - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, dirToMovePosition);

            if (dot > 0)
            {
                // Target in front
                forwardAmount = 1f;

                float stoppingDistance = 0f;
                float stoppingSpeed = 0f;
                if (distanceToTarget < stoppingDistance && carDriver.GetSpeed() > stoppingSpeed)
                {
                    // Within stopping distance and moving forward too fast
                    forwardAmount = -1f;
                }
            }
            else
            {
                // Target behind
                float reverseDistance = 25f;
                if (distanceToTarget > reverseDistance)
                {
                    // Too far to reverse
                    forwardAmount = 1f;
                }
                else
                {
                    forwardAmount = -1f;
                }
            }

            float angleToDir = Vector3.SignedAngle(transform.forward, dirToMovePosition, Vector3.up);

            if (angleToDir > 0)
            {
                turnAmount = 1f;
            }
            else
            {
                turnAmount = -1f;
            }
        }
        else
        {
            // Reached target
            if (carDriver.GetSpeed() > 15f)
            {
                forwardAmount = -1f;
            }
            else
            {
                forwardAmount = 0f;
            }
            turnAmount = 0f;
        }

        carDriver.SetInputs(forwardAmount, turnAmount);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
