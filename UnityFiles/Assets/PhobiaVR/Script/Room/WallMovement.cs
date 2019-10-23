using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class WallMovement :  MonoBehaviour
{

    //furniture 
    public GameObject[] furniture;
    private Vector3[] furniturePos = new Vector3[10];

    //audio 
    public AudioClip movingWall;
    public float audioVolume = 1.0f;

    public AudioSource soundWall;

    //back and front wall
    public Rigidbody backWallRb;
    public Rigidbody frontWallRb;
    public float distanceBackFront;

    Vector3 backPos;
    Vector3 frontPos;

    //left and right wall
    public Rigidbody leftWallRb;
    public Rigidbody rightWallRb;
    public float distanceLeftRight;
    Vector3 leftPos;
    Vector3 rightPos;

     bool isMoving = false;

    private void Awake()
    {
        soundWall.Stop();

    }

    void Start()
    {

        //get furniture position
        for(int i = 0; i < furniture.Length; i++)
        {
            furniturePos[i] = furniture[i].transform.position;
        }

        //audio 
        soundWall = GetComponent<AudioSource>();

        //walls
        backWallRb = GetComponent<Rigidbody>();

        backPos = backWallRb.transform.position;
        frontPos = frontWallRb.transform.position;

        leftPos = leftWallRb.transform.position;
        rightPos = rightWallRb.transform.position;
    }

    private void Update()
    {
        

        distanceBackFront = Vector3.Distance(backWallRb.transform.position, frontWallRb.transform.position);
        distanceLeftRight = Vector3.Distance(leftWallRb.transform.position, rightWallRb.transform.position); 


        soundWall.volume += 0.015f * Time.deltaTime;


        if(distanceBackFront < 2.5f){
            isMoving = false;
        }
        if(distanceLeftRight < 2.5f){
            isMoving = false;
        }

        if (isMoving == true)
        {
            // using AddForce, increase movement speed a lot. 
            // backWallRb.AddForce(transform.forward * 0.5f);
            // frontWallRb.AddForce(transform.forward * -0.5f);

         

            //this methods moves wall per frame
            backWallRb.transform.position += new Vector3(0.5f, 0, 0) * Time.deltaTime;
            frontWallRb.transform.position += new Vector3(-0.5f, 0, 0) * Time.deltaTime;
            leftWallRb.transform.position += new Vector3(0, 0, 0.25f)*Time.deltaTime; 
            rightWallRb.transform.position += new Vector3(0, 0, -0.25f)*Time.deltaTime; 
        }

        if (isMoving == false)
        {
            //stop audio
            soundWall.Stop();

            //stop movement 
            backWallRb.velocity = Vector3.zero;
            frontWallRb.velocity = Vector3.zero;
            leftWallRb.velocity = Vector3.zero;
            rightWallRb.velocity = Vector3.zero;

        }
    }



    public void Move()
    {
        isMoving = true;
        //new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);

        //play audio 

        soundWall.Play();
        //AudioSource.PlayClipAtPoint(movingWall,backWallRb.transform.position , audioVolume);


    }

    public void Stop(){
        isMoving = false;
       
        //stop audio ;
        //AudioSource.PlayClipAtPoint(movingWall, backWallRb.transform.position, 1f);
        soundWall.Stop();


    }

    public void Reset()
    {
        isMoving = false;
        backWallRb.transform.position = backPos;
        frontWallRb.transform.position = frontPos;

        leftWallRb.transform.position = leftPos;
        rightWallRb.transform.position = rightPos;

        furnitureReset();
    }

    void furnitureReset()
    {
        for (int i = 0; i < furniture.Length; i++)
        {
            furniture[i].transform.position = furniturePos[i];
        }

    }


}