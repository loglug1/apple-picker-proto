using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public float speedMultiplier = 1.2f;
    public float dropIntervalMultiplier = 0.9f;
    public float directionChangeMultiplier = 1.1f;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreCounter = GameObject.Find("ScoreCounter");
        scoreCounter.GetComponent<TMP_Text>().text = "Score: 0";
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tempBasket = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tempBasket.transform.position = pos;
            basketList.Add(tempBasket);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PunishPlayer() {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples) {
            Destroy(apple);
        }
        int basketIndex = basketList.Count-1;
        GameObject basketToDelete = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketToDelete);
        if (basketIndex == 0) {
            GameOver();
        }
    }

    public void RewardPlayer() {
        GameObject scoreCounter = GameObject.Find("ScoreCounter");
        TMP_Text scoreCounterText = scoreCounter.GetComponent<TMP_Text>();
        score += 100;
        scoreCounterText.text = "Score: " + score;
        if (score > HighScoreController.score) {
            HighScoreController.score = score;
        }
        if (score % 1000f == 0f) {
            IncreaseDifficulty();
        }
    }

    public void IncreaseDifficulty() {
        TreeController appleTree = GameObject.Find("AppleTree").GetComponent<TreeController>();
        appleTree.speed *= speedMultiplier;
        appleTree.secondsBetweenFruitDrops *= dropIntervalMultiplier;
        appleTree.chanceToChangeDirection *= directionChangeMultiplier;
    }
    public void GameOver() {
        SceneManager.LoadScene("GameOverScreen");
    }
}
