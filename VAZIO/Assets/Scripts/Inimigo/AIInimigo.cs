using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInimigo : MonoBehaviour {

    public Transform player;
    private int rotSpeed = 180;
    private int speed = 4;
	
	void Update () {

        //encontrar jogador por tag "player"
        findPlayer();
        //mover a nave
        shipMove();

    }

    void shipMove()
    {
        //girar para a direção do jogador
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);

        //deslocamento da nave
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    void findPlayer()
    {
        if (player == null)
        {
            GameObject go = GameObject.FindWithTag("player");
            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player == null) return;
    }

    public void setRotSpeed(int _rotSpeed)
    {
        rotSpeed = _rotSpeed;
    }

    public int getRotSpeed()
    {
        return rotSpeed;
    }

    public void setShipSpeed(int _speed)
    {
        speed = _speed;
    }

    public int GetShipSpeed()
    {
        return speed;
    }
}
