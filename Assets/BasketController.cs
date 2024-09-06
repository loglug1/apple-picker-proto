using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasketController : MonoBehaviour
{
    public Text scoreCounterText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreCounter = GameObject.Find("ScoreCounter");
        TMP_Text scoreCounterText = scoreCounter.GetComponent<TMP_Text>();
        scoreCounterText.text = "0";
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 pos = transform.position;
        pos.x = Camera.main.ScreenToWorldPoint(mousePos).x;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            GameController gameController = Camera.main.GetComponent<GameController>();
            gameController.RewardPlayer();
            Debug.Log("Did thing!");
            Destroy(collidedWith);
        }
    }
}
