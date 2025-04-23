using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJeu : MonoBehaviour
{
    public float pointageTemps;
    public TextMeshProUGUI textScore;
    public TMP_InputField inputNom;
    public TextMeshProUGUI textScorePanneau;
    [SerializeField] private GameObject panneauRecord;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        pointageTemps = 0;
    }

    private void Update()
    {
        textScore.text = pointageTemps.ToString("00.00");
    }

    public void  TraiterMort()
    {
        float recordActuel = PlayerPrefs.GetFloat("meilleurScore", 0f);
        print("defaite");
        if (pointageTemps >= recordActuel)
        {
            Invoke("MontrePanneauNouveauRecord", 3f);
        }
    }

    void MontrePanneauNouveauRecord()
    {
        print("NvR");
        panneauRecord.SetActive(true);
        textScorePanneau.text = textScore.text;
    }

    public void EnregistrerNomRecord()
    {
        string nom = inputNom.text;
        PlayerPrefs.SetString("Nom", nom);

        //Redemarre la scene actuler
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
