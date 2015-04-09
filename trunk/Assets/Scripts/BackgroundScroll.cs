using UnityEngine;
using System.Collections.Generic;

public class BackgroundScroll : MonoBehaviour
{
    private Vector2 velocity;
    public float scrollspeed = 0.1f;
    private Rigidbody2D player;
    private Renderer rendererBG;
    public bool moving = true;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rendererBG = GetComponent<Renderer>();
    }

    void Update()
    {
        if(moving)
        {
            velocity = player.velocity;
            Vector2 scroll = rendererBG.material.mainTextureOffset;
            scroll += new Vector2(scrollspeed * velocity.x * Time.deltaTime, 0);
            rendererBG.material.mainTextureOffset = scroll;
        }
    }
}
