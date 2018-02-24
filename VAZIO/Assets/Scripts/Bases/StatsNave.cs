using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsNave : MonoBehaviour {

	//elementos de UI
	public Image armorBar, fisShieldBar, lsrShieldBar;

	public Text armorText, fisShieldText, lsrShieldText;

    //atributos de movimento
    public int shipSpeed = 6;
    public int shipHandling = 260;

    //atributos de combate
    public float shipArmor = 100;
    public float fisShield = 60;
    public float lsrShield = 60;

    //outros
    public enum shipClasses {LIGHT, MEDIUM, HEAVY}
	public shipClasses shipClass;

    //objetos relativos ao movimento
    public MovimentoJogador mov = new MovimentoJogador();
    public AIInimigo ai = new AIInimigo();

    public void Start()
    {
        //definir scripts
        mov = this.GetComponent<MovimentoJogador>();
        ai = this.GetComponent<AIInimigo>();

        //definir as stats
        setShipStats();
    }

    //funçao para definir as stats da nave
    private void setShipStats()
    {
        if (mov != null)
        {
            mov.setShipSpeed(shipSpeed);
            mov.setRotSpeed(shipHandling);
        }
        else return;

        if (ai != null)
        {
            ai.setShipSpeed(shipSpeed);
            ai.setRotSpeed(shipHandling);
        }
    }

}
