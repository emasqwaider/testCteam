using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDash : Abilities
{
    [SerializeField]
    private int boostPercentage;
    [SerializeField]
    private CarController playerMove;
    public ParticleSystem pp;
    private float boostAsPercent;
    private void Start()
    {
        playerMove = GetComponent<CarController>();
        boostAsPercent = (100 + boostPercentage) / 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (playerMove.player1 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                AbilityEffect();
                abilityTimer = Time.time + cooldown;
            }
        }
        if (playerMove.player2 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AbilityEffect();
                abilityTimer = Time.time + cooldown;
            }
        }
    }

    private void AbilityEffect()
    {

        playerMove.Boost(boostAsPercent);
        pp.Play();
        Invoke("ResetAbility", duration);
    }

    private void ResetAbility()
    {
        pp.Stop();
        playerMove.ResetBoost(boostAsPercent);
    }
}
