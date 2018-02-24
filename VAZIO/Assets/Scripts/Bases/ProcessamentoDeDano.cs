using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessamentoDeDano : MonoBehaviour {

	//elementos de UI
	private Image armorBar, fisShieldBar, lsrShieldBar;
	private Text armorText, fisShieldText, lsrShieldText;

	//atributos iniciais
	private float startShipArmor, startFisShield, startLsrShield;

	//atributos atuais
	private float shipArmor, fisShield, lsrShield;

    private float shotDamage;
    private int dmgType;
	public GameObject explosion;
    public string tag;
    public enum tags { friendlyprojectile, enemyprojectile}
    public tags targetTag;

    StatsNave nave = new StatsNave();

    void Start () {

        nave = this.GetComponent<StatsNave>();
		setUI();
		setStartingStats();
        resetShipStats();
        setTargetTag();
    }
	
	void Update () {
        checkDeath();
		updateUI();
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

	private void updateUI() {
		armorBar.fillAmount = shipArmor / startShipArmor;
		fisShieldBar.fillAmount = fisShield / startFisShield;
		lsrShieldBar.fillAmount = lsrShield / startLsrShield;

		armorText.text = shipArmor.ToString () + " / " + startShipArmor.ToString ();
		fisShieldText.text = fisShield.ToString () + " / " + startFisShield.ToString ();
		lsrShieldText.text = lsrShield.ToString () + " / " + startLsrShield.ToString ();
	}

	void setUI() 
	{
		armorBar = nave.armorBar;
		fisShieldBar = nave.fisShieldBar;
		lsrShieldBar = nave.lsrShieldBar; 

		armorText = nave.armorText;
		fisShieldText = nave.fisShieldText;
		lsrShieldText = nave.lsrShieldText;
	}

    void setTargetTag()
    {
        tag = targetTag.ToString();
    } 

	void setStartingStats() 
	{
		startShipArmor = nave.shipArmor;
		startFisShield = nave.fisShield;
		startLsrShield = nave.lsrShield;
	}

    void resetShipStats()
    {
		shipArmor = startShipArmor;
		fisShield = startFisShield;
		lsrShield = startLsrShield;
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
