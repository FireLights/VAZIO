using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoInimigo : ArmaDeFogo
{


    //atributos do canhão
    public GameObject projectilePrefab;
    public GameObject nozzle;
    public float fireDelay = 0.05f;
    public int multishotChance = 10;

    //atributos do projétil
    public int dmgType;
    public float shotSpeed;
    public float shotDissipation;
    public float shotDamage;

    //objeto da classe base
    ArmaDeFogo canhao = new ArmaDeFogo();

    void Start()
    {
        canhao.setProjectileAtributes(projectilePrefab, shotDamage, dmgType, shotSpeed, shotDissipation);
    }

    void Update()
    { 
        canhao.npcFireBullet(projectilePrefab, nozzle, fireDelay, multishotChance);
    }
}
