using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoJogador : ArmaDeFogo
{
    //atributos do canhão
    public GameObject projectilePrefab;
    public GameObject nozzle;
    public float fireDelay = 0.05f;
    public int multishotChance = 10;

    //atributos do canhão
    public float rotSpeed;

    //atributos do projétil
    public int dmgType;
    public float shotSpeed;
    public float shotDissipation;
    public float shotDamage;

    //objeto da classe base
    ArmaDeFogo arma = new ArmaDeFogo();

    void Start()
    {
        arma.setProjectileAtributes(projectilePrefab, shotDamage, dmgType, shotSpeed, shotDissipation);
    }

    void Update()
    {
        arma.playerFireBullet(projectilePrefab, nozzle, fireDelay, multishotChance);


        var mousePos = Input.mousePosition;
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        var playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));
        Quaternion rot = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
        transform.rotation = rot;
    }
}
