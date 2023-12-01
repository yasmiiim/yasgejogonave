using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float initialXlimit = -5f;
    public float topYLimit = 10f;
    public float bottomYLimit = 2f;

    private void Update()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.5f);

            if (player.position.x < initialXlimit)
            {
                smoothedPosition.x = initialXlimit;
            }

            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, bottomYLimit, topYLimit);

            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
