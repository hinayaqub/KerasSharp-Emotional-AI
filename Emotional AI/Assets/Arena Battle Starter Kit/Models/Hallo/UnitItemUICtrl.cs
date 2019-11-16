using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitItemUICtrl : MonoBehaviour {

    /* component refs */
    public SpriteRenderer BottomCircle;
    public Transform NavigationCircle;
    public TextMeshPro NameText;
  

    public SpriteRenderer EnergyFiller;
    public SpriteRenderer FoodBar;
    Animator AnimeZombie;
    /* private vars */
    private Color _energyFillerDefaultColor;
    private float _energyFillerFullWidth;
    private Color _FoodFillerDefaultColor;
    private float _FoodFillerFullWidth;

    private void Start()
    {
        AnimeZombie = this.GetComponent<Animator>();

        this.NameText.text = "Agent";
       this.EnergyFiller.color = Color.yellow;
       
        this.NavigationCircle.gameObject.SetActive(true);

        this._energyFillerDefaultColor = this.EnergyFiller.color;
        this._energyFillerFullWidth = this.EnergyFiller.size.x;
        this._FoodFillerDefaultColor = this.FoodBar.color;
        this._FoodFillerFullWidth = this.FoodBar.size.x;

    }

    public void Update()
    {
        Vector3 direction = this.AnimeZombie.transform.position;
        direction = this.AnimeZombie.transform.position + new Vector3(-1f, 0, 0f);
        this.NavigationCircle.position = (this.transform.position + new Vector3(direction.x, 0, direction.y).normalized);


    }
    public void SetEnergyBarProgress(float val)
    {
        this.EnergyFiller.size = new Vector2(this._energyFillerFullWidth * val, this.EnergyFiller.size.y);
        if (val < 0.5f)
            this.EnergyFiller.color = Color.red;
        else
            this.EnergyFiller.color = _energyFillerDefaultColor;
    }
}
