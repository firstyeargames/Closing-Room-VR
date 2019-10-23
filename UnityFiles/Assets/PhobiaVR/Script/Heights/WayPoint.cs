using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class WayPoint : MonoBehaviour {
    
    public AudioSource windSound;

    public Transform[] target;
    public float speed;
    public int current;

    public GameObject plane;
    Vector3 position;

    Vector3 startingPosition;
    bool isFlying = false;
    bool restAll = false;


    private void Start()
    {

        //audio 
        windSound = GetComponent<AudioSource>();

        startingPosition = plane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (isFlying == true)
        {

            //play audio
            windSound.Play();
           

            //moving the object untill we reach the current waypoint (if its not equal to the way point)
            if (transform.position != target[current].position)
            {

                // take current position, move towards target at speed * time 
                position = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(position);
            }
            else current = (current + 1) % target.Length;



            if (current == 2)
            {
                plane.transform.Rotate(0.0f, -5.0f * Time.deltaTime, 0.0f);

            }

            if (current == 3)
            {
                plane.transform.Rotate(0.5f * Time.deltaTime, -10.0f * Time.deltaTime, 0.0f);

            }

            if (current == 4)
            {
                plane.transform.Rotate(0.0f, 2.0f * Time.deltaTime, 0.0f);

            }

            if (current == 5)
            {
                plane.transform.Rotate(-0.3f * Time.deltaTime, 2.0f * Time.deltaTime, 0.0f);

            }
            if (current >= 6)
            {
                plane.transform.Rotate(-0.1f * Time.deltaTime, 0.0f, 0.0f);

            }

            if (current >= 8)
            {
                plane.transform.Rotate(0.5f * Time.deltaTime, -8.0f * Time.deltaTime, 0.5f * Time.deltaTime);

            }

            if (current >= 11)
            {
                plane.transform.Rotate(0.5f * Time.deltaTime, -5.0f * Time.deltaTime, 1.0f * Time.deltaTime);

            }

            if (current == 15)
            {

                plane.transform.Rotate(0.5f * Time.deltaTime, 10.0f * Time.deltaTime, 1.0f * Time.deltaTime);

            }


            if (current == 16)
            {
                plane.transform.rotation = Quaternion.Euler(new Vector3(0, 275, 0));

            }

            if (current >= 17)
            {
                plane.transform.rotation = Quaternion.Euler(new Vector3(0, 275, 0));

            }

            if (current == 20)
            {
                plane.transform.Rotate(0.0f, 0.0f, -50f);

            }

            if (current == 21)
            {
                plane.transform.Rotate(0.0f, 0.0f, -50f);

            }
            if (current == 22)
            {
                plane.transform.Rotate(0.0f, 0.0f, 0.5f);

            }
            if (current == 23)
            {
                plane.transform.Rotate(0.0f, 0.0f, 0.0f);
            }

            if(current == 24){
                restAll = true;
            }
        }


        if(isFlying == false){
            //stop audio
            windSound.Stop();

            position = Vector3.zero;   
        }

        if(restAll == true){

            //stop audio
            windSound.Stop();

            plane.transform.rotation = Quaternion.Euler(new Vector3(0, 175, 0));
            position = Vector3.zero;
            plane.transform.position = startingPosition;

        }
    }


    public void Fly(){
        isFlying = true;
    }

    public void StopFlying(){
        isFlying = false;
    }

    public void RestAll(){
        restAll = true;
    }

    public void mainMenu(){
        SceneManager.LoadScene(0);
    }

}
