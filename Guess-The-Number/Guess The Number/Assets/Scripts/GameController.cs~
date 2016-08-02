using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public InputField input;

    private int num;
    private int countGuess;

    [SerializeField] // force unity to visible private field in editor
    private Text text;

    public GameObject mybutton;

    void Awake(){
        //input = GameObject.Find("InputField").GetComponent<InputField>();
        num = Random.Range(1, 100);
        text.text = "Guess A Number Between 1 and 100";
        countGuess = 0;
    }

    public void GetInput(string guess){
        CompareGuesses(int.Parse(guess));
        Debug.Log(num);
        input.text = "";
        countGuess++;
    }

    void CompareGuesses(int guess){
        if(num == guess){
            text.text = "You Guessed Correctly The Number Was " + num + " It Took you "+countGuess+ " Guesses";
            mybutton.SetActive(true);
        }
        else if(guess < num){
            text.text = "Your Guessed Number Is Less Than The Number";
        }
        else if(guess > num){
            text.text = "Your Guessed Number Is Greater Than The Number";
        }
    }

    public void PlayAgain(){
        num = Random.Range(1, 100);
        text.text = "Guess A Number Between 1 and 100";
        countGuess = 0;
        mybutton.SetActive(false);
    }

}
