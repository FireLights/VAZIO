using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentoJogador : MonoBehaviour {

    private Transform player;
    private StatsNave nave;
    private Quaternion rot;
    private Vector3 velocity;
    public Text velocityUI;

    public float shipThrust;
    public float rotSpeed;
    public float maxSpeed;
    public float minSpeed;
    private float spd = 0;
    

    private void Start()
    {
        player = transform;
        nave = player.GetComponent<StatsNave>();
        setStats();
        minSpeed = -maxSpeed / 30;
        maxSpeed = maxSpeed / 10;
    }

    void Update () {

        shipMove();
        updateUI();
    }

    private void setStats()
    {
        maxSpeed = nave.curShipSpeed;
        rotSpeed = nave.curShipHandling;
    }

    private void shipMove()
    {

        /*  
         *  OBSOLETO
         *  
         *  //rodar para o cursor
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
        getSpeed();
        Vector3 pos = transform.position;
        velocity = new Vector3(0, spd, 0);
        pos += rot * velocity;
        transform.position = pos;
    }

    private void getSpeed()
    {
         if (Input.GetAxis("Vertical") == 1  && spd < maxSpeed)
         {
             spd = spd + Time.deltaTime * shipThrust;
            if (spd > maxSpeed)
                spd = maxSpeed;
        }
         if (Input.GetAxis("Vertical") == -1 && spd >= 0)
         {
             spd = spd + Time.deltaTime * shipThrust * -1;
            if (spd < 0)
                spd = 0;
         }

    }

    private void updateUI()
    {
        velocityUI.text = "Velocidade: " + Mathf.RoundToInt(((spd / maxSpeed)*100)) + "%";
        if (velocityUI.text == "Velocidade: 100%")
            velocityUI.color = Color.red;
        if (velocityUI.text != "Velocidade: 100%")
            velocityUI.color = Color.green;
    }

}
