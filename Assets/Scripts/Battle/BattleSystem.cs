using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public TextMeshProUGUI DialogueText;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public Transform player2BattleStation;
    public Transform enemy2BattleStation;

    Enemy playerUnit;
    Enemy enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public GameObject panel;
    public GameObject EnemyHUD;
    public GameObject PlayerHUD;
    public GameObject GameOver;
    public string levelName;

    public static bool isDead = false;

    public BattleState state;
    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Enemy>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Enemy>();

        DialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    IEnumerator PlayerAttack()
    {

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.CurrentHP);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            enemyHUD.SetHP(enemyUnit.CurrentHP);

            yield return new WaitForSeconds(1f);
            StartCoroutine(EnemyTurn());
        }

    }
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        state = BattleState.ENEMYTURN;

        playerHUD.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(2f);

        StartCoroutine(EnemyTurn());
    }
    IEnumerator EnemyTurn()
    {
        panel.SetActive(false);
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.CurrentHP);
        yield return new WaitForSeconds(1f);


        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        panel.SetActive(false);
        EnemyHUD.SetActive(false);
        PlayerHUD.SetActive(false);
        if (state != BattleState.LOST)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            GameOver.SetActive(true);
        }
    }

    void PlayerTurn()
    {
        panel.SetActive(true);
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
    }
}

