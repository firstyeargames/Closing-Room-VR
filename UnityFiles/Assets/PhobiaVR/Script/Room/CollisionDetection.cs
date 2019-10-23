using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{


    Rigidbody rb;

    //made into a public static element which can now be called within WallMovement
    bool resetFurniture = false;

    public Rigidbody furnitureObject;
    public float distanceWallFurniture;
    public GameObject wall;

    bool collisionMetBackWall = false;
    bool collisionMetFrontWall = false;
    bool collisionMetLeftWall = false;
    bool collisionMetRightWall = false;
    public GameObject ResetObject;

    public Vector3 objPosition;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        objPosition = rb.transform.position;
    }

  


    private void Update()
    {
        FurnitureMoving();
        FurnitureStopping();
        distanceWallFurniture = Vector3.Distance(wall.transform.position, ResetObject.transform.position);


        if( distanceWallFurniture > 5){
            furnitureObject.transform.position = objPosition;
            furnitureObject.velocity = Vector3.zero;
        }

        if(resetFurniture == true){
            furnitureObject.transform.position = objPosition;
            furnitureObject.velocity = Vector3.zero;
        }
    }


    void FurnitureMoving(){
        if (collisionMetBackWall == true)
        {
            furnitureObject.transform.position += new Vector3(0.5f, 0, 0) * Time.deltaTime;

        }

        if (collisionMetFrontWall == true)
        {
            furnitureObject.transform.position += new Vector3(-0.5f, 0, 0) * Time.deltaTime;
        }

        if (collisionMetLeftWall == true)
        {
            furnitureObject.transform.position += new Vector3(0, 0, 0.25f) * Time.deltaTime;
        }

        if (collisionMetRightWall == true)
        {
            furnitureObject.transform.position += new Vector3(0, 0, -0.25f) * Time.deltaTime;
        }
    }


    void FurnitureStopping(){
        
        if (collisionMetBackWall == false && collisionMetFrontWall == false &&
            collisionMetLeftWall == false && collisionMetRightWall == false)
        {
            furnitureObject.velocity = Vector3.zero;
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "BackWall")
        {
            collisionMetBackWall = true;
            resetFurniture = false;
        }
        if (col.gameObject.name == "FrontWall") {
            collisionMetFrontWall = true;
            resetFurniture = false;
        }

        if (col.gameObject.name == "LeftWall")
        {
            collisionMetLeftWall = true;
            resetFurniture = false;
        }

        if (col.gameObject.name == "RightWall")
        {
            collisionMetRightWall = true;
            resetFurniture = false;
        }

        if (col.gameObject.name == "Shredder")
        {
            furnitureObject.transform.position = objPosition;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        collisionMetBackWall = false;
        collisionMetFrontWall = false;
        collisionMetLeftWall = false;
        collisionMetRightWall = false;

    }

   

}
