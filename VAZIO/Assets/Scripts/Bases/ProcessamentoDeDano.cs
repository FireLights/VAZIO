using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessamentoDeDano : MonoBehaviour {

    private float shipArmor;
    private float fisShield;
    private float lsrShield;

    private float shotDamage;
    private int dmgType;
	public GameObject explosion;
    public string tag;
    public enum tags { friendlyprojectile, enemyprojectile}
    public tags targetTag;

    StatsNave nave = new StatsNave();

    void Start () {

        nave = this.GetComponent<StatsNave>();
        resetShipStats();
        setTargetTag();
    }
	
	void Update () {
        checkDeath();
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == tag)
        {
            shotDamage = other.gameObject.GetComponent<Projetil>().damage;
            dmgType = other.gameObject.GetComponent<Projetil>().dmgType;
            calculateDamage();
        }
    }

    void setTargetTag()
    {
        tag = targetTag.ToString();
    } 

    void resetShipStats()
    {
        shipArmor = nave.shipArmor;
        fisShield = nave.fisShield;
        lsrShield = nave.lsrShield;
    }

    void checkDeath()
    {
		if (shipArmor <= 0)
			destroy ();
    }

    void calculateDamage()
    {
        if (dmgType == 0) {
            if (fisShield > 0) { fisShield = fisShield - shotDamage; }
            else if (fisShield <= 0) { shipArmor = shipArmor - shotDamage; } 
        }
        else if (dmgType == 1) {
            if (lsrShield > 0) { lsrShield = lsrShield - shotDamage; }
            else if (lsrShield <= 0) { shipArmor = shipArmor - shotDamage; }
        }
    }

	void destroy() 
	{
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
		
}
