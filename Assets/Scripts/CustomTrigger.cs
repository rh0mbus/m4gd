using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrigger : MonoBehaviour
{
    [SerializeField] bool isActive = true;
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    
    [SerializeField] float TriggerRange = 4.0f;
    void OnDrawGizmos()
    {
        if (isActive)
        {
            PerformCalculations();
        }
    }

    void PerformCalculations()
    {
        Vector2 a = A.position;
        Vector2 b = B.position;

        Gizmos.color = new Color(255, 155, 0);
        Gizmos.DrawWireSphere(B.position, TriggerRange);
        
        // A
        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, a);
        Gizmos.DrawWireSphere(a.normalized, 0.1f);
        
        // Project B onto A
        var sProj = Vector2.Dot(a.normalized, b);
        var vProj = sProj * a.normalized;
        Gizmos.color = Color.grey;
        Gizmos.DrawSphere(vProj, 0.15f);
        
        //B
        Gizmos.color = Color.blue;
        var bNorm = b / b.magnitude;
        Gizmos.DrawWireSphere(bNorm, 0.1f);
        Gizmos.DrawLine(default, b);

        var difference2D = a + (-b);
        var mag = Math.Sqrt(difference2D.x * difference2D.x + difference2D.y * difference2D.y);

        Debug.Log($"Vector difference: {difference2D}");
        Debug.Log($"Unity magnitude: {difference2D.magnitude}");
        Debug.Log($"Calculated magnitude: {mag}");

        if (mag <= TriggerRange)
        {
            Debug.LogWarning("Boom!");
        }
    }
}
