using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movehandler : MonoBehaviour
{
    Vector2 moveValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMove(InputValue input)
    {
        Debug.Log("Got a move input!");
        moveValue = input.Get<Vector2>();
        moveValue *= 3;
        Debug.Log($"X: {moveValue.x}, Y: {moveValue.y}");
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        Vector3 f = transform.forward;
        Vector3 m = new Vector3(moveValue.x * t, 0.0f, moveValue.y * t);
        transform.position += m;
    }
}
