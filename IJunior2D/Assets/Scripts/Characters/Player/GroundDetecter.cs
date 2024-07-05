using UnityEngine;

public class GroundDetecter : MonoBehaviour
{
    public bool IsGrounded()
    {
        int divider = 2;
        float radius = 0.1f;
        float positionY = transform.position.y - transform.localScale.y / divider;
        Vector3 point = new Vector3(transform.position.x, positionY, 0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius);

        foreach (Collider2D collider in colliders)
            if (collider.TryGetComponent(out Ground _))
                return true;

        return false;
    }
}