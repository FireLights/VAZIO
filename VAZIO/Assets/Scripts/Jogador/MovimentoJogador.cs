using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour {

    public Transform player;

    public float shipSpeed;
    public float rotSpeed;
    public float turboMultiplier = 1.5f;
    public Quaternion rot;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update () {

        shipMove();
    }

    private void shipMove()
    {
        /*	
            Quaternion rot = transform.rotation;
            float z = rot.eulerAngles.z;
            z += (Input.GetAxis("Horizontal") * -1) * rotSpeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;
        */

        //Rotação da nave
        var mousePos = Input.mousePosition;
        var objectPos = Camera.main.WorldToScreenPoint(player.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        var playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));
        Quaternion rot = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
        transform.rotation = rot;


        //Movimento da nave
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * shipSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;
      
        //Turbo
        if (Input.GetButtonDown("Turbo")) shipSpeed = shipSpeed * turboMultiplier;
        if (Input.GetButtonUp("Turbo")) shipSpeed = shipSpeed / turboMultiplier;

    }

    public float getShipSpeed()
    {
        return shipSpeed;
    }

    public void setShipSpeed(float _shipSpeed)
    {
        shipSpeed = _shipSpeed;
    }

    public float getRotSpeed()
    {
        return rotSpeed;
    }

    public void setRotSpeed(float _rotSpeed)
    {
        rotSpeed = _rotSpeed;
    }

}
