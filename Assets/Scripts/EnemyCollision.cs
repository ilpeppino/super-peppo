using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    //private ParticleSystem _particleSystem;
    private float _bounce = 50f;

    private void Awake()
    {
        //_particleSystem = GetComponent<ParticleSystem>();
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




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private float _bounce = 250f;


    private void OnCollisionEnter(Collision collision)
    {

        switch (gameObject.tag)
        {
            case "Slime":
                {

                    Debug.Log(collision.gameObject.tag + " collided with " + gameObject.tag);

                    collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * Time.deltaTime * _bounce, ForceMode.Impulse);
                    return;
                }

            case "Turtle":
                {
                    Debug.Log(collision.gameObject.tag + " collided with " + gameObject.tag);

                    Vector3 dir = collision.contacts[0].point - collision.gameObject.transform.position;
                    dir = -dir.normalized;

                    collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * Time.deltaTime * _bounce, ForceMode.Impulse);

                    return;
                }
        }



    }

}
*/
