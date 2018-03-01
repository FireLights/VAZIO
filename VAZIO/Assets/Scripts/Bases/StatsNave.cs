using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsNave : MonoBehaviour {


	public Image armorBar, fisShieldBar, lsrShieldBar;
	public Text armorText, fisShieldText, lsrShieldText;

	public float baseShipSpeed = 6, baseShipThrust = 0.2f;
    public int baseShipHandling = 270;

    public float curShipSpeed, curShipThrust;
    public int curShipHandling;

    public float baseShipArmor = 50;
    public float baseFisShield = 60;
    public float baseLsrShield = 60;

	public float curShipArmor, curFisShield, curLsrShield;

	//classe da nave
    public enum shipClasses {LIGHT, MEDIUM, HEAVY}
	public shipClasses shipClass;

    private MovimentoJogador mov = new MovimentoJogador();
	private  AIInimigo ai = new AIInimigo();

    public void Awake()
    {
        //definir scripts
        mov = this.GetComponent<MovimentoJogador>();
        ai = this.GetComponent<AIInimigo>();

        //definir as stats
		resetStatsToBaseStats();
    }

	public void resetStatsToBaseStats() 
	{
		curShipSpeed = baseShipSpeed;
		curShipHandling = baseShipHandling;
        curShipThrust = baseShipThrust;
		curShipArmor = baseShipArmor;
		curFisShield = baseLsrShield;
		curLsrShield = baseLsrShield;
	}

	//Setters para atributos base
	public void setBaseShipSpeed(int bsp) {
		baseShipSpeed = bsp;
	}
	public void setBaseShipHandliing(int bsh) {
		baseShipHandling = bsh;
	}
	public void setBaseShipArmor(float bsa) {
		baseShipArmor = bsa;
	}
	public void setBaseFisShield(float bfs) {
		baseFisShield = bfs;
	}
	public void setBaseLsrShield(float bls) {
		baseLsrShield = bls;
	}
	public void setAllBaseStats(int bsp, int bsh, float btm, float bsa, float bfs, float bls) {
		baseShipSpeed = bsp;
		baseShipHandling = bsh;
        baseShipArmor = bsa;
		baseFisShield = bfs;
		baseLsrShield = bls;
	}

	//Setters para atributos atuais
	public void setCurShipSpeed(int csp) {
		curShipSpeed = csp;
	}
	public void setCurShipHandliing(int csh) {
		curShipHandling = csh;
	}
    public void setCurShipArmor(float csa) {
		curShipArmor = csa;
	}
	public void setCurFisShield(float cfs) {
		curFisShield = cfs;
	}
	public void setCurLsrShield(float cls) {
		curLsrShield = cls;
	}
	public void setAllCurStats(int csp, int csh, float ctm, float csa, float cfs, float cls) {
		curShipSpeed = csp;
		curShipHandling = csh;
		curShipArmor = csa;
		curFisShield = cfs;
		curLsrShield = cls;
	}
}
