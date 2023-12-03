using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    [SerializeField] private bool isPlayerInside;
    [SerializeField] private GameObject InventoryParent;
    [SerializeField] private GameObject ToolBar;

    private void Awake() {
        InventoryParent = GameObject.FindWithTag("Inventory");
        ToolBar = GameObject.FindWithTag("ToolBar");
    }

    private void Update() {
        if(InventoryParent == null){
            InventoryParent = GameObject.FindWithTag("Inventory");
            ToolBar = GameObject.FindWithTag("ToolBar");
        }

        if (Input.GetKey("e") && isPlayerInside){
            InventoryParent.SetActive(true);
            InventoryParent.GetComponent<RectTransform>().localPosition = new Vector3(0, -126, 0);
            ToolBar.SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

}