using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DiceRoll : MonoBehaviour
{
    int[] dice = new int[51];

    public int[] blockDice;
    public int[] attackDice;

    //first round powerups
    public int[] gamblerDice = { 1, 1, 10, 20, 20 };
    public int[] nerdDice = {7,8,9};


    //second round powerups
    public bool addictdice = false;
    public bool gymBroDice = false;



    public int[] AboodAttackDice;
    public int[] AboodBlockDice;

    public int[] jeffAttackDice;
    public int[] jeffBlockDice;

    public int[] shawermaAttackDice;
    public int[] shamermaBuffDice;
    public int[] shawermaDebuffDice;
    public int[] shawermaHealDice;

    public int[] bossDice;

    public List<int[]> attackList = new List<int[]>();
    public List<int[]> blockList = new List<int[]>();

    public static DiceRoll Instance { get; private set; }

    public bool isHealing = false; 
    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        print("Start buddy");
        for (int i = 0; i <= 50; i++)
        {
            dice[i] = i;
        }

        attackDice = dice[5..12];
        blockDice = dice[6..11];

        AboodAttackDice = dice[2..9];
        AboodBlockDice = dice[1..9];

        jeffAttackDice = dice[4..10];
        jeffBlockDice = dice[1..10];

        shawermaAttackDice = dice[4..8];
        shamermaBuffDice = dice[1..3];
        shawermaDebuffDice = dice[1..6];
        shawermaHealDice = dice[1..6];

        bossDice = dice[8..16];

        attackList.Add(AboodAttackDice);
        attackList.Add(jeffAttackDice);
        attackList.Add(shawermaAttackDice);
        attackList.Add(bossDice);

        blockList.Add(AboodBlockDice);
        blockList.Add(jeffBlockDice);

    }

    public int Roll(int[] dice)
    {
        int roll = dice[Random.Range(0, dice.Length)];
        return roll;
    }

    public void setGambler()
    {
        attackDice = gamblerDice;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setNerd()
    {
        attackDice = nerdDice;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setGymBro()
    {
        // same as enemy, + 1
        int[] newAttackDice = new int[attackDice.Length];
        int[] newBlockDice = new int[blockDice.Length];

        for (int i = 0; i < attackDice.Length; i++)
        {
            newAttackDice[i] = attackDice[i] + 2;
        }
        for (int i = 0; i < blockDice.Length; i++)
        {
            newBlockDice[i] = blockDice[i] + 2;
        }

        attackDice = newAttackDice;
        blockDice = newBlockDice;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setDrugAddict()
    {
        // block becomes heal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void resetDice()
    {
        attackDice = dice[5..12];
        blockDice = dice[1..11];
    }
}
