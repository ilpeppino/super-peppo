using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private ParticleSystem _particleSystem;
    private float _bounce = 50f;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            //_particleSystem.Play();

            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * Time.deltaTime * _bounce, ForceMode.Impulse);

            

        }

    }

}
