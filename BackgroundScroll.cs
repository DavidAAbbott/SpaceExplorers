using UnityEngine;
using System.Collections.Generic;

public class BackgroundScroll : MonoBehaviour
{
    public float velocity = 2f;
    public float scrollspeed = 0.1f;
    private Renderer rendererBG;
    public static bool moving = true;
    public bool top = false;

    void Start()
    {
        rendererBG = GetComponent<Renderer>();
    }

    void Update()
    {
        if(moving && top)
        {
            Vector2 scroll = rendererBG.material.mainTextureOffset;
            scroll -= new Vector2(scrollspeed * velocity * Time.deltaTime, 0);
            rendererBG.material.mainTextureOffset = scroll;
        }
        if (moving && !top)
        {
            Vector2 scroll = rendererBG.material.mainTextureOffset;
            scroll += new Vector2(scrollspeed * velocity * Time.deltaTime, 0);
            rendererBG.material.mainTextureOffset = scroll;
        }
        if (!moving && top)
        {
            Vector2 scroll = rendererBG.material.mainTextureOffset;
            scroll += new Vector2((scrollspeed / 2) * (velocity / 2) * Time.deltaTime, 0);
            rendererBG.material.mainTextureOffset = scroll;
        }
        if (!moving && !top)
        {
            Vector2 scroll = rendererBG.material.mainTextureOffset;
            scroll += new Vector2((scrollspeed / 2) * (velocity / 2) * Time.deltaTime, 0);
            rendererBG.material.mainTextureOffset = scroll;
        }
    }
}
