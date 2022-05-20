using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public bool Interact { get; private set; }
    public Player Player { get; private set; }
    [SerializeField] private Transform InteractGraphic;

    // Start is called before the first frame update
    void Start()
    {
        ResetInteract();
    }

    public void SetInteract(Player player)
    {
        Interact = true;
        Player = player;
    }
    public void ShowGFX()
    {
        InteractGraphic.gameObject.SetActive(true);
    }
    public void ResetInteract()
    {
        if (Interact)
        {
            Interact = false;
            Player = null;
        }
        InteractGraphic.gameObject.SetActive(false);
    }
}
