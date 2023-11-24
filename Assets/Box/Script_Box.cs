using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Box : MonoBehaviour {

    public int life = 100;
    //public Rigidbody2D rb;//Rigidbody de este objeto
    //public BoxCollider2D bc;
    public Rigidbody rb;//Rigidbody de este objeto
    public BoxCollider bc;
    //public SpriteRenderer sp_r;
    public MeshRenderer mr;
    public GameObject partes;
    public float cont = 0;
    public bool activar_cont = false;

    /*
	// Use this for initialization
	void Start ()
    {

    }
    */

    // Update is called once per frame
    void Update ()
    {
		if(activar_cont)
        {
            cont += Time.deltaTime;
            if(cont >= 0.5)
            {
                gameObject.SetActive(false);
            }
        }
	}
    
    public void Func_Restar_vida(int daño)
    {
        life -= daño;
        if(life <= 0)
        {
            //rb.freezeRotation = true;
            //rb.gravityScale = 0;
            //rb.simulated = false;
            bc.enabled = false;//Box Collider
            //sp_r.enabled = false;
            mr.enabled = false;//Mesh Renderer
            partes.SetActive(true);
            activar_cont = true;
            Destroy(rb);//Se destruye el Rigidbody
            //gameObject.AddComponent<Rigidbody>();//Se agrega un Rigidbody al objeto actual
        }
    }
}
