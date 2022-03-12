//Codigo de movimiento de agente actividad 3 Por Mario Cuevas Delgado y Jose Karim Sosa Perez

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
        //Se crea los enum de las direciones a las que se podra mover
        enum Direction
    {
        up,
        down,
        left,
        right
    }

    Direction direction;
    public float frameRate ;
    public float step;
    public int pasos;//los pasos que da en pantalla (60 en este caso)
    public Vector3 nextPos = Vector3.zero;

    //
    [SerializeField] Collider2D up, right, left, down, upRigth,upLeft,downRigth,downLeft;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CostumUpdate());
    }

    void Move()
    {
        //se establecen las direciones sobre las que se movera
        if (direction == Direction.down)
            nextPos = Vector3.down;
        else if (direction == Direction.up)
            nextPos = Vector3.up;
        else if (direction == Direction.left)
            nextPos = Vector3.left;
        else if (direction == Direction.right)
            nextPos = Vector3.right;
        nextPos *= step;
        transform.position += nextPos;
    }

    // Update is called once per frame

    IEnumerator CostumUpdate(){
//contador de pasos
        for(int i=0; pasos>i;i++){
             //puntos normales
            if(DOWNIsTouchingWall()){
                print ("Toco abajo voy izquierda");
                GoLeft();
            }

            else if (RIGHTIsTouchingWall()){
                print ("Toco derecha voy abajo");
                GoDown();
            }

            else if(LEFTIsTouchingWall()){
                print ("Toco izquierda voy arriba");
                GoUp();
            }

            else if (UPIsTouchingWall()){
                print ("Toco arriba voy derecha");
                GoRight();
            }

            //Esqunas seccion entera
            else if(RDisTouchingWall()){
                print ("Toco esquina voy abajo");
                GoDown();
            }

            else if(LDisTouchingWall()){
                print ("Toco esquina voy arriba");
                GoLeft();
            }

            else if(RUisTouchingWall()){
                print ("Toco esquina voy abajo");
                GoRight();
            }

            else if(LUisTouchingWall()){
                print ("Toco esquina voy derecha");
                GoLeft();
            }

            Move();
            yield return new WaitForSeconds(.5f);
        }
    }

    //de esta forma sabe en que direcion se ira 
    void GoRight(){
        direction = Direction.right;
    }
    void GoDown(){
        direction = Direction.down;
    }
    void GoUp(){
        direction = Direction.up;
    }
    void GoLeft(){
        direction = Direction.left;
    }


//colisiones clasicas
    bool UPIsTouchingWall(){
        return up.IsTouchingLayers(LayerMask.GetMask("Wall"))&&
        upRigth.IsTouchingLayers(LayerMask.GetMask("Wall")) &&
        upLeft.IsTouchingLayers(LayerMask.GetMask("Wall"));
    }

    bool RIGHTIsTouchingWall(){
        return right.IsTouchingLayers(LayerMask.GetMask("Wall"))&&
        upRigth.IsTouchingLayers(LayerMask.GetMask("Wall")) &&
        downRigth.IsTouchingLayers(LayerMask.GetMask("Wall"));
    }

    bool LEFTIsTouchingWall(){
        return left.IsTouchingLayers(LayerMask.GetMask("Wall"))&&
        upLeft.IsTouchingLayers(LayerMask.GetMask("Wall")) &&
        downLeft.IsTouchingLayers(LayerMask.GetMask("Wall"));
    }
 bool DOWNIsTouchingWall(){
        return down.IsTouchingLayers(LayerMask.GetMask("Wall"))&&
        downRigth.IsTouchingLayers(LayerMask.GetMask("Wall"))&&
        downLeft.IsTouchingLayers(LayerMask.GetMask("Wall"));
    }


//Colisiones Esquinas Seccion entera
    bool RUisTouchingWall(){
        return upRigth.IsTouchingLayers(LayerMask.GetMask("Wall"));  
    }

    bool LUisTouchingWall(){
        return upLeft.IsTouchingLayers(LayerMask.GetMask("Wall")); 
    }
    bool RDisTouchingWall(){
        return downRigth.IsTouchingLayers(LayerMask.GetMask("Wall"));
    }

    bool LDisTouchingWall(){
        return downLeft.IsTouchingLayers(LayerMask.GetMask("Wall"));
    }

}
