using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public GameObject player;
    public SpriteRenderer sp_r;
    public Rigidbody rb;//Rigidbody de este objeto
    public Animator anim_zombie;
    public float velocidad = 50;
    //public float dist_max = 2.027f;
    public float dist_max = 2.5f;
    public Vector3 heading;
    public float distance;
    //public Vector3 direction;
    public float cont;
    //public bool attacking;
    //public Enemy script_enemy;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        heading = player.transform.position - gameObject.transform.position;
        distance = heading.magnitude;
        //Debug.Log("Distance: " + distance);

        //if ((player.transform.position - gameObject.transform.position).magnitude <= dist_max)
        if (distance <= dist_max)
        {
            anim_zombie.SetBool("Avanzar", true);
            rb.velocity = new Vector3(0, rb.velocity.y, 0);//Quita la aceleración
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                sp_r.flipX = false;
                rb.AddForce(new Vector3(-velocidad * Time.deltaTime, 0, 0), ForceMode.Impulse);
            }
            else
            {
                sp_r.flipX = true;
                rb.AddForce(new Vector3(velocidad * Time.deltaTime, 0, 0), ForceMode.Impulse);
            }
            //script_enemy.Func_show_life_bar();//Muestra la barra de vida cuando el jugador está cerca
        }
        else
        {
            anim_zombie.SetBool("Avanzar", false);
            //script_enemy.Func_no_show_life_bar();//Deja de mostrar la barra de vida cuando el jugador está lejos
        }

    }
}
