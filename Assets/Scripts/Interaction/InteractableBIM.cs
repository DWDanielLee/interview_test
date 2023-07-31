using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json;

// Use Newtonsoft.Json to serialize & deserialize
#region Serialize json

#endregion

//BIM : Building Information Modelling
public class InteractableBIM : Interactable
{
    public bool ispanelOpen;
    Animator animator;
    GameObject BIPanel;
    [SerializeField] private string animationName = "Button_Push";

    //get json data from api
    private string url = "https://api.yugy.org/api/v1/buildings/unity/";

    //to classify each building num.
    [SerializeField] private string _pk;

    #region reference to put in BIpanel content's inspector
    [HideInInspector]
    public TextMeshProUGUI _name = null;
    [HideInInspector]
    public TextMeshProUGUI _location = null;
    [HideInInspector]
    public TextMeshProUGUI _detailed_location = null;
    [HideInInspector]
    public TextMeshProUGUI _completion_date = null;
    [HideInInspector]
    public TextMeshProUGUI _floor_area = null;
    [HideInInspector]
    public TextMeshProUGUI _structure = null;
    [HideInInspector]
    public TextMeshProUGUI _construction_cost = null;
    [HideInInspector]
    public TextMeshProUGUI _en_rating = null;
    [HideInInspector]
    public TextMeshProUGUI _en_saving = null;
    [HideInInspector]
    public TextMeshProUGUI _attribute_passive = null;
    [HideInInspector]
    public TextMeshProUGUI _attribute_active = null;
    [HideInInspector]
    public TextMeshProUGUI _attribute_renewableenergy = null;
    [HideInInspector]
    public RawImage _realbuildingRawImage = null;
    private string _realbuildingRawImageText = null;
    #endregion

    public override void Start()
    {
        base.Start();
        BIPanel = GameObject.FindGameObjectWithTag("IngameCanvas").transform.GetChild(0).gameObject;

        if (BIPanel.activeSelf == true)
        {
            BIPanel.SetActive(false);
        }
        else
        {
            return;
        }

        _name = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _location = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        _detailed_location = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        _completion_date = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(7).GetComponent<TextMeshProUGUI>();
        _floor_area = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(9).GetComponent<TextMeshProUGUI>();
        _structure = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(11).GetComponent<TextMeshProUGUI>();
        _construction_cost = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(13).GetComponent<TextMeshProUGUI>();
        _en_rating = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(15).GetComponent<TextMeshProUGUI>();
        _en_saving = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(17).GetComponent<TextMeshProUGUI>();
        _attribute_passive = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(20).GetComponent<TextMeshProUGUI>();
        _attribute_active = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(22).GetComponent<TextMeshProUGUI>();
        _attribute_renewableenergy = BIPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(24).GetComponent<TextMeshProUGUI>();
        _realbuildingRawImage = BIPanel.transform.GetChild(0).GetComponent<RawImage>();

        ispanelOpen = false;
        animator = GetComponent<Animator>();
    }

    protected override void Interaction()
    {
        base.Interaction();

        if (!ispanelOpen)
        {
            OpenPanel();
        }
        else
        {
            ClosePanel();
        }
    }

    public void OpenPanel()
    {
        animator.Play(animationName, 0, 0.0f);
        BIPanel.SetActive(true);
        StartCoroutine(GetBuildingInfo());
        ispanelOpen = !ispanelOpen;
    }

    public void ClosePanel()
    {
        animator.Play(animationName, 0, 0.0f);
        CloseBuildingInformation();
        BIPanel.SetActive(false);
        ispanelOpen = !ispanelOpen;
    }


    // Use RestAPI(Get) to get information from url + _pk
    // IEnumerator GetBuildingInfo()
    // {

    // }

    //LoadBuildingImage is performed in GetBuildingInfo end of line
    // IEnumerator LoadBuildingImage()
    // {

    // }

    public void CloseBuildingInformation()
    {
        _name.text = null;
        _location.text = null;
        _detailed_location.text = null;
        _completion_date.text = null;
        _floor_area.text = null;
        _structure.text = null;
        _construction_cost.text = null;
        _en_rating.text = null;
        _en_saving.text = null;
        _attribute_passive.text = null;
        _attribute_active.text = null;
        _attribute_renewableenergy.text = null;
        _realbuildingRawImageText = null;
    }

    public string NumChange(int value)
    {
        var stringNum = string.Format("{0:N0}", value);
        return stringNum + "원";
    }

}
