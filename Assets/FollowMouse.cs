using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Vector3 offset;
    private RectTransform _rectTransform;

    // Use this for initialization
    void Start()
    {
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        var width = _rectTransform.rect.width;
        int endpoint = (int) (Input.mousePosition.x + offset.x + width);
        if (endpoint > Screen.width)
        {
            int move_back = endpoint - Screen.width;
            transform.position = new Vector3(Input.mousePosition.x + offset.x - move_back,
                Input.mousePosition.y + offset.y);
            return;
        }
        transform.position = Input.mousePosition + offset;
    }
}