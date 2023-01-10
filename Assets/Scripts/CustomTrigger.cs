using UnityEngine;

public class CustomTrigger : MonoBehaviour
{
    [SerializeField] bool isActive = true;
    [SerializeField] Transform objectATransform;
    [SerializeField] Transform objectB;
    
    [SerializeField] float triggerRange = 4.0f;
    void OnDrawGizmos()
    {
        if (isActive)
        {
            PerformCalculations();
        }
    }

    void PerformCalculations()
    {
        Vector2 a = objectATransform.position;
        Vector2 b = objectB.position;

        Gizmos.color = new Color(255, 155, 0);
        Gizmos.DrawWireSphere(b, triggerRange);
        
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
        var sqrDistance = difference2D.x * difference2D.x + difference2D.y * difference2D.y;
        Debug.Log($"Vector difference: {difference2D}");
        Debug.Log($"Unity magnitude: {difference2D.magnitude}");
        
        // var mag = Math.Sqrt(difference2D.x * difference2D.x + difference2D.y * difference2D.y);
        // Debug.Log($"Calculated magnitude: {mag}");

        // if (mag <= triggerRange)
        // {
        //     Debug.LogWarning("Boom!");
        // }

        if (sqrDistance <= (triggerRange * triggerRange))
        {
            Debug.LogWarning("Boom!");
        }
    }
}
