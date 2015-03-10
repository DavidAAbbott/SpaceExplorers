using UnityEngine;
using System.Collections;

public class Wrap : MonoBehaviour
{
    private Renderer[] renderers;
    private bool isWrappingY = false;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        rigidbody2D.AddForce(30f * new Vector2(-1, 0));
    }

    void FixedUpdate()
    {
        ScreenWrap();
    }

    void ScreenWrap()
    {
        bool isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingY = false;
            return;
        }

        if (isWrappingY)
        {
            return;
        }

        Vector3 newPosition = transform.position;

        if(newPosition.y > 1 || newPosition.y < 0)
        {
            newPosition.y = -newPosition.y;
            isWrappingY = true;
        }

        transform.position = newPosition;
    }

    bool CheckRenderers()
    {
        foreach(Renderer renderer in renderers)
        {
            if(renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }
}
