using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public delegate void EnemyDie(GameObject corpose);

    public event EnemyDie OnEnemyDie;
    
    public delegate void ScoreChanged(int updateScore);

    public event ScoreChanged OnScoreChanged;
    
    

    
    [SerializeField] private PlayerController player;

    [HideInInspector]
    public PlayerController Player
    {
        get { return player; }
    }

    private int _playerScore;
    public int PlayerScore
    {
        get
        {
            return _playerScore;
        }


        private set
        {
            _playerScore = value;
            if (OnScoreChanged != null)
            {
                OnScoreChanged.Invoke(_playerScore);
            }
        }
    }



    private void Awake()
    {
        Instance = this;
    }


    public void OnDie(GameObject deadObject, int score = 0)
    {
        PlayerScore += score;

        Debug.LogFormat("GameCotroller: the object {0} Assig score {1}, total: {2}", deadObject.name, score,PlayerScore );
        
        player.AddToPowerLevel(1);


        if (OnEnemyDie!=null)
        {
            OnEnemyDie.Invoke(deadObject);
        }
 
    }

    public void OnPickedUp(PickUpController pickup)
    {
        Debug.LogFormat("Picked up {0}!!", pickup);
        PlayerScore += pickup.config.score;
        player.UnlockSpecial(pickup.config);
    }

    public void OnPlayerDie()
    {
        Debug.Log("***** Player Died *****");
       

    }
}
