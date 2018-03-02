using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInimigo : MonoBehaviour
{

    public Transform player;

    private StatsNave nave;

    //atributos predefinidos
    private int rotSpeed;
    private float shipSpeed;

    //objetos referentes ao campo de deteção
    public float looseTargetRadius = 5f;
    public float getTargetRadius;

    //objetos referentes às armas
    public GameObject weapon01, weapon02;

    //variáveis referentes à linha de tiro
    public Transform lineBegin, lineEnd;
    private bool targetOnSight = false;

    void Start()
    {
        nave = this.GetComponent<StatsNave>();
        setStats();
        disableWeapons();
    }

    void Update()
    {
        if (player == null)
        {
           disableWeapons();
        }
        else
        {
            //encontrar jogador por tag "player"
            findPlayer();
            //mover a nave
            shipMove();
            //verificar linha de tiro e disparar
            checkShootingLine();
        }
    }

    //obter stats e defini-las
    private void setStats()
    {
        shipSpeed = nave.curShipSpeed;
        rotSpeed = nave.curShipHandling;
    }

    //verificar se o jogador se encontra no campo de visão do inimigo
	public bool lookForTarget()
    {
        bool targetAquired = Physics2D.CircleCast(this.transform.position, getTargetRadius,
                new Vector2(this.transform.position.x, this.transform.position.y), 0, 1 << LayerMask.NameToLayer("Player"));
        if (targetOnSight = false) { targetAquired = false; } //What? a linha de tiro influencia tu encontrares um target
        return targetAquired;
    }

    //verificar se o jogador se encontra na linha de tiro do inimigo e disparar
    private void checkShootingLine()
    {
        targetOnSight = Physics2D.Linecast(lineBegin.position, lineEnd.position, 1 << LayerMask.NameToLayer("Player"));
        
		weapon01.SetActive(targetOnSight);
        weapon02.SetActive(targetOnSight);       
    }

    //mover o inimigo
    private void shipMove()
    {
        //girar para a direção do jogador
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);

        //deslocamento da nave se o inimigo se encontra a uma distancia maior do que x do jogador
        if (Vector2.Distance(this.transform.position, player.position) > 1.5)
        {
            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, shipSpeed * Time.deltaTime, 0);
            pos += transform.rotation * velocity;
            transform.position = pos;
        }
        else
            return;
    }

    //encontrar o jogador pela tag
    private void findPlayer()
    {
       player = GameObject.FindWithTag("player").transform; //So o chamas quanto player não null    
    }

    private void disableWeapons()
    {
        weapon01.SetActive(false);
        weapon02.SetActive(false);
    }
}
