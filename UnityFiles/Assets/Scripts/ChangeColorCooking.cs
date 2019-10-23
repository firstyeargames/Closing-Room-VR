using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCooking : MonoBehaviour
{


    public Material[] materials;
    public Renderer Rend;
    public GameObject oil;
    public GameObject smoke;

    Vector3 pos = new Vector3(32.4f, 7f, 5.98f);


    // Use this for initialization
    void Start()
    {

        Rend.GetComponents<Renderer>();
        Rend.enabled = true;
        Rend.sharedMaterial = materials[0];
        smoke.SetActive(false);

    }

    // taking the time and adding to it.
    void Update()
    {
       

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("oil"))
        {
            smoke.SetActive(true);
            Invoke("brown", 5.0f);  
            Invoke("cooked", 8.0f);
           


        }

    }

    void brown()
    {

        Rend.sharedMaterial = materials[1];
    }

    void black()
    {
        Rend.sharedMaterial = materials[2];
        smoke.SetActive(true);
    }

    void cooked(){
        if (Rend.sharedMaterial == materials[1])
        {
            gameObject.transform.position = new Vector3(25, 6.6f, 0.5f);
        }
    }

    void inTheBin(){
        smoke.SetActive(false);
        Destroy(gameObject);
    }

}
