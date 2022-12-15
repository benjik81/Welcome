using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Service : MonoBehaviour
{
    [SerializeField] private WayPointsValue _wpService;
    [SerializeField] private GameObject _Jeu;
    [SerializeField] private Services _serviceSecteur;
    [SerializeField] private Image _image;

    [SerializeField] private Patient _currentPatient;


    void Start()
    {
        GameManager.Instance.OnPatientService += PatientArrive;
        _Jeu.SetActive(false);
    }

    private void PatientArrive(WayPointsValue wp, Patient p)
    {
        if (_wpService.ID == wp.ID)
        {
            _currentPatient = p;
        }
    }

    public void OnClick()
    {
        if (_currentPatient == null) return;

        GameManager.Instance.InMinigame(true);
        _Jeu.SetActive(true);
        

    }

    public void ResultMiniGame(bool win)
    {
        if(win) GameManager.Instance.ChangeScore(50);

        GameManager.Instance.InMinigame(false);
        _currentPatient.EndMiniGame(win, _serviceSecteur);
        _Jeu.SetActive(false);
        _currentPatient = null;
    }
}
