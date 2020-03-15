using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var movement = new Vector3(inputX * Time.deltaTime * 10f, 0f, 0f);

        transform.position += movement;
    }
}
