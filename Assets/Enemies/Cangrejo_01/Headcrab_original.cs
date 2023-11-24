using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headcrab_original : MonoBehaviour {

    public GameObject player;
    public SpriteRenderer sp_r;
    public Rigidbody rb;//Rigidbody de este objeto
    public Animator anim_hedcrab;
    //public float dist_max = 2.027f;
    public float dist_max = 2.5f;
    public bool jumping;
    public Vector3 heading;
    public float distance;
    public Vector3 direction;
    public float corrimiento;
    public float cont;
    //public bool starting_Jump;

    /*
     Si un punto en el espacio es restado de otro entonces el resultado
     es un vector que “apunta” de un objeto al otro.
    // Obtiene un vector que apunta desde la posición del jugador a la del objetivo.
    var heading = target.position - player.position;

     * Además de apuntar en la dirección del objeto de destino,
     la magnitud de este vector es igual a la distancia entre las dos posiciones.
     Es común necesitar un vector normalizado dando la dirección al objeto destino
     y también la distancia al objeto destino (digamos para direccionar un proyectil).
     La distancia entre los objetos es igual a la magnitud del vector en cabeza
     y este vector puede ser normalizado dividiéndolo por su magnitud:-
    var distance = heading.magnitude;
    var direction = heading / distance; // This is now the normalized direction.
     */


    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(jumping == false)//Inicia el contador si no está saltando
        {
            cont += Time.deltaTime;
        }
        Debug.Log("Player: " + player.transform.position);
        Debug.Log("Cangrejo: " + gameObject.transform.position);

        heading = player.transform.position + new Vector3(0, corrimiento + 0.6f, 0) - gameObject.transform.position;
        distance = heading.magnitude;
        Debug.Log("Distance: " + distance);

        //if ((player.transform.position - gameObject.transform.position).magnitude <= dist_max)
        if (distance <= dist_max)
        {
            Debug.Log("En rango");
            //Funciona
            //heading = player.transform.position + new Vector3(0, corrimiento + 0.6f, 0) - gameObject.transform.position;
            //distance = heading.magnitude;
            //direction = heading / distance;
            //

            //
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                sp_r.flipX = false;
            }
            else
            {
                sp_r.flipX = true;
            }
            if ((jumping == false) && (cont >= 3))//Puede saltar si no está saltando y si pasaron más de 3 segundos desde el ultimo salto
            {
                anim_hedcrab.SetTrigger("Start_Jump");
                //Hace los calculos para la trayectoria
                //heading = player.transform.position + new Vector3(0, corrimiento + 0.6f, 0) - gameObject.transform.position;
                //distance = heading.magnitude;
                direction = heading / distance;
                //
                rb.AddForce(direction * 7, ForceMode.Impulse);
                jumping = true;
                //starting_Jump = true;
            }
        }
        /*
        else//Si no está en el rango
        {
            jumping = false;
        }
        */
        //Debug.Log(player.transform.position - gameObject.transform.position);
        //Debug.Log((player.transform.position - gameObject.transform.position).magnitude);//Distancia entre dos objetos
    }
    private void OnCollisionEnter(Collision obj)
    {
        if(jumping == true)//Si está saltando y si
        {
            anim_hedcrab.SetTrigger("Fall_Jump");
            if (obj.gameObject.layer == 8)
            {
                anim_hedcrab.SetTrigger("Finish_Jump");
                jumping = false;
                cont = 0;
            }
        }
    }
}
