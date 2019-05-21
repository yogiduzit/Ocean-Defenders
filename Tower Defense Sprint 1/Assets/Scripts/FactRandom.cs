using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FactRandom : MonoBehaviour
{
    public Text myText;

    //List of random facts.
    public string[] randomFact =
    {
    "Around 70% of industrial waste is dumped to water.",
    "80% of the water pollution is caused due to domestic sewage.",
    "More than 6 billion pounds of garbage end up in the oceans every year.",
    "Almost two million tons of human waste are exposed daily to water.",
    "The nuclear crisis created by the tsunami of 2011, unleashed 11 million liters of radioactive water into the Pacific Ocean.",
    "On average 250 million people succumb each year from diseases caused by the contaminated water.",
    "40 percent of plastic produced is packaging, used just once and then discarded.",
    "Nearly half of all plastic ever manufactured has been made since 2000.",
    "Less than a fifth of all plastic is recycled globally.",
};
    //Intializes and chooses random fact from array randomFact.
    void Start()
    {
        string myString = randomFact[Random.Range(0, randomFact.Length)];
        myText.text = myString;
    }
}
