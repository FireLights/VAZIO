using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour {

    public Transform player;

    public float shipSpeed;
    public float shipThrust;
    public float rotSpeed;
    public Quaternion rot;
    public float maxSpeed;
    public float minSpeed;
    float spd = 0;
    Vector3 velocity;
    float previousSpeed;

    private void Start()
    {
        player = this.transform;
        minSpeed = -maxSpeed / 30;
    }

    void Update () {

        shipMove();
    }

    private void shipMove()
    {

        /*  //rodar para o cursor
            var mousePos = Input.mousePosition;
            var objectPos = Camera.main.WorldToScreenPoint(player.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            var playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

            Quaternion desiredRotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));
            Quaternion rot = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
            transform.rotation = rot;
        
            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * shipSpeed * Time.deltaTime, 0);
            pos += rot * velocity;
            transform.position = pos;
        */


        //Rotação da nave
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Movimento da nave
        previousSpeed = spd;
        getSpeed();
        Vector3 pos = transform.position;
        velocity = new Vector3(0, spd, 0);
        pos += rot * velocity;
        transform.position = pos;
        checkAcceleration();
    }

    private void checkAcceleration()
    {
    /*    if (previousSpeed < spd) { Debug.Log("Aceleração Positiva"); }
        if (previousSpeed > spd) { Debug.Log("Aceleração Negativa"); }
        if (previousSpeed == spd) { Debug.Log("Aceleração Nula"); }
    */}

    private void getSpeed()
    {
         if (Input.GetAxis("Vertical") == 1  && spd < maxSpeed / 10)
         {
             spd = spd + Time.deltaTime * shipThrust;
         }
         if (Input.GetAxis("Vertical") == -1 && spd > minSpeed)
         {
             spd = spd + Time.deltaTime * shipThrust * -1;
         }

    }


    public void setShipSpeed(float sS) {
        shipSpeed = sS;
    }
    public void setRotSpeed(float rS) {
        rotSpeed = rS;
    }

}
