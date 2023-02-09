using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private MeshRenderer mesh;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }
    public void AddForce(Vector3 force)
    {
        _rigidbody.AddForce(force);  
    }
    public void ChangeColor(Color color)
    {
        mesh.material.color = color;
        transform.tag = color == Color.red ? "Red" : "Blue";
    }
    
}
