using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public int X;
    public int Y;

    // Start is called before the first frame update
    void Start()
    {
        X = Mathf.RoundToInt(gameObject.transform.position.x);
        Y = Mathf.RoundToInt(gameObject.transform.position.z);
        Debug.Log($"tile behavior start ({X}, {Y})");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log($"touched me ({X}, {Y})");
    }
}
