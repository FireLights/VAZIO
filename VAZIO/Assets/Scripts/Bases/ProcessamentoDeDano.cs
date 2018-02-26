using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessamentoDeDano : MonoBehaviour {

	//elementos de UI
	private Image armorBar, fisShieldBar, lsrShieldBar;
	private Text armorText, fisShieldText, lsrShieldText;

	//atributos iniciais
	private float totalShipArmor, totalFisShield, totalLsrShield;
	private int dmgType;

	//atributos atuais
	private float curShipArmor, curFisShield, curLsrShield;
    private float shotDamage;

	//objeto da explosão
	public GameObject explosion;

	//tags
    private string tag;
    public enum tags {friendlyprojectile, enemyprojectile}
    public tags targetTag;

	//objeto dos atributos da nave
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
		
		armorBar.fillAmount = curShipArmor / totalShipArmor;
		fisShieldBar.fillAmount = curFisShield / totalFisShield;
		lsrShieldBar.fillAmount = curLsrShield / totalLsrShield;

        if (armorText != null || fisShieldText != null || lsrShieldText != null) {
            armorText.text = curShipArmor.ToString () + " / " + totalShipArmor.ToString ();
		    fisShieldText.text = curFisShield.ToString () + " / " + totalFisShield.ToString ();
		    lsrShieldText.text = curLsrShield.ToString () + " / " + totalFisShield.ToString ();
        }
		
	}

	private void setUI() 
	{
		armorBar = nave.armorBar;
		fisShieldBar = nave.fisShieldBar;
		lsrShieldBar = nave.lsrShieldBar; 

		armorText = nave.armorText;
		fisShieldText = nave.fisShieldText;
		lsrShieldText = nave.lsrShieldText;
	}

    private void setTargetTag()
    {
        tag = targetTag.ToString();
    } 

	private void setStartingStats() 
	{
		totalShipArmor = nave.curShipArmor;
		totalFisShield = nave.curFisShield;
		totalLsrShield = nave.curLsrShield;
	}

    private void resetShipStats()
    {
		curShipArmor = totalShipArmor;
		curFisShield = totalFisShield;
		curLsrShield = totalLsrShield;
    }

    void checkDeath()
    {
		if (curShipArmor <= 0)
			destroy ();
    }

    void calculateDamage()
    {
        if (dmgType == 0) {
			if (curFisShield > 0) { curFisShield -= shotDamage; }
			else if (curFisShield <= 0) { curShipArmor -= shotDamage; } 
        }
        else if (dmgType == 1) {
			if (curLsrShield > 0) { curLsrShield -= shotDamage; }
			else if (curLsrShield <= 0) { curShipArmor -= shotDamage; }
        }
    }

	void destroy() 
	{
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
		
}
