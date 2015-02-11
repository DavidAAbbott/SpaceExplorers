using UnityEngine;
using System.Collections;

[System.Serializable]
public class ScrollingObject
{
    public GameObject obj;
    public float speed;
}
public class ScrollingManagerScript : MonoBehaviour
{
    public ScrollingObject[] scrollingObj;
    public ScrollingObject lastScrollingObj;
    public Vector3 startPos;
    // Use this for initialization
    void Start()
    {
        startPos = lastScrollingObj.obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scrollingObj.Length; ++i)
        {
scrollingObj[i].obj.transform.position -= Vector3.right * scrollingObj[i].speed * Time.deltaTime;
        }

         for (int i = 0; i < scrollingObj.Length; ++i)
        {
            if (scrollingObj[i].obj.transform.position.x <= -14.4f)
            {
                scrollingObj[i].obj.transform.position = new Vector3(lastScrollingObj.obj.transform.position.x + lastScrollingObj.obj.renderer.bounds.size.x, scrollingObj[i].obj.transform.position.y);
                lastScrollingObj = scrollingObj[i];
        }
            }
        }
    }