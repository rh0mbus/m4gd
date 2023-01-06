using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflections : MonoBehaviour
{
    [SerializeField] Transform LaserShooter;
    [SerializeField] float RayDistance = 5.0f;
    void OnDrawGizmos()
    {
        RaycastHit hit;

        if (Physics.Raycast(LaserShooter.position, LaserShooter.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(LaserShooter.position, LaserShooter.forward * RayDistance, Color.red);
        }
    }
}
