using UnityEngine;
using System.Collections;

public class purkkainput : MonoBehaviour {
    float diry, dirx;
    public float speed = 2f;

	void Update () 
    {
        float currentY =Input.GetAxis("Vertical");
        float currentX = Input.GetAxis("Horizontal");
        diry += currentY * Time.deltaTime * speed; 
        dirx += currentX * Time.deltaTime * speed;
        diry = Mathf.Clamp(diry, -1, 1);
        dirx = Mathf.Clamp(dirx, -1, 1);

        Debug.Log("diry : " +diry+ "dirx : " + dirx);
        Debug.Log("diry*diry : " + diry * diry + "dirx*dirx : " + dirx * dirx);

        Vector2 move = new Vector2(dirx, -diry);

        //move = Vector2.ClampMagnitude(move, speed * Time.deltaTime);

        transform.Translate(move);

	}
}
