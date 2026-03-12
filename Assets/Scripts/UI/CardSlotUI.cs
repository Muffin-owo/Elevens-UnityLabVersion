using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;
using TMPro;
using Elevens.Core;

public class CardSlotUI : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private TextMeshProUGUI cardText;

    [SerializeField]
    private Image background;

    private int slotIndex = -1;

    private ElevensUnityUI owner;

    public void SetCard(CardSlotUI card , int index , ElevensUnityUI uiOwner)
    {
        slotIndex = index;
        owner = uiOwner;

        gameObject.SetActive(true);
        cardText.text = card.ToString();
        button.interactable = true;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => owner.onCardClicked(slotIndex));

        SetSelected(false);
    }

    public void SetSelected(bool selected) {
        if(background != null) { 
            background.color = selected ? new Color(1f, 0.9f, 0.3f, 1f) : Color.White;
        }
    }

    public void Clear()
    {
        slotIndex = -1;
        owner = null;
        cardText.text = "";
        button.onClick.RemoveAllListeners();
        button.interactable = false;
        SetSelected(false);
        gameObject.SetActive(false);
    }

}