/*  This file is part of the "Simple IAP System" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using System.Collections;

namespace SIS
{
    /// <summary>
    /// script that listens to purchases and other IAP events,
    /// here we tell our game what to do when these events happen
    /// <summary>
    public class IAPListener : MonoBehaviour
    {
        /// <summary>
        /// whether this script should print debug messages
        /// </summary>
        public bool debug;


        //subscribe to the most important IAP events
        void OnEnable()
        {
            IAPManager.inventoryRequestFailedEvent += HandleFailedInventory;
            IAPManager.purchaseSucceededEvent += HandleSuccessfulPurchase;
            IAPManager.purchaseFailedEvent += HandleFailedPurchase;
            ShopManager.itemSelectedEvent += HandleSelectedItem;
            ShopManager.itemDeselectedEvent += HandleDeselectedItem;
        }


        //unsubscribe from IAP events on destruction
        void OnDisable()
        {
            IAPManager.inventoryRequestFailedEvent -= HandleFailedInventory;
            IAPManager.purchaseSucceededEvent -= HandleSuccessfulPurchase;
            IAPManager.purchaseFailedEvent -= HandleFailedPurchase;
            ShopManager.itemSelectedEvent -= HandleSelectedItem;
            ShopManager.itemDeselectedEvent -= HandleDeselectedItem;
        }


        /// <summary>
        /// handle purchases, for real money or ingame currency
        /// </summary>
        public void HandleSuccessfulPurchase(string id)
        {
            //differ between ids set in the IAP Settings editor
            if (debug) Debug.Log("HandleSuccessfulPurchase: " + id);
            //get instantiated shop item based on the IAP id
            IAPItem item = null;
            if (ShopManager.GetInstance())
                item = ShopManager.GetIAPItem(id);

            //if the purchased item was non-consumable,
            //additionally block further purchase of the shop item
            if (item != null &&
                (item.type == IAPType.nonConsumable ||
                item.type == IAPType.nonConsumableVirtual ||
                item.type == IAPType.subscription))
                item.Purchased(true);

            switch (id)
            {
                //section for in app purchases

                case "bann_coins":
                    gameParameters.currentCharacter = "Bann";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Bann!");
                    break;

                case "bella_coins":
                    gameParameters.currentCharacter = "Bella";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Bella!");
                    break;

                case "blane_coins":
                    gameParameters.currentCharacter = "Blane";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Blane!");
                    break;

                case "damien_coins":
                    gameParameters.currentCharacter = "Damien";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Damien!");
                    break;

                case "finnikin_coins":
                    gameParameters.currentCharacter = "Finnikin";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Finnikin!");
                    break;

                case "gwyn_coins":
                    gameParameters.currentCharacter = "Gwyn";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Gwyn!");
                    break;

                case "hector_coins":
                    gameParameters.currentCharacter = "Hector";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Hector!");
                    break;

                case "katsa_coins":
                    gameParameters.currentCharacter = "Katsa";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Katsa!");
                    break;

                case "mather_coins":
                    gameParameters.currentCharacter = "Mather";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Mather!");
                    break;

                case "pifoo_coins":
                    gameParameters.currentCharacter = "Pifoo";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Pifoo!");
                    break;

                case "rylan_coins":
                    gameParameters.currentCharacter = "Rylan";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Rylan!");
                    break;

                case "sothe_coins":
                    gameParameters.currentCharacter = "Sothe";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Sothe!");
                    break;

                case "wesker_coins":
                    gameParameters.currentCharacter = "Wesker";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Wesker!");
                    break;

                case "yuki_coins":
                    gameParameters.currentCharacter = "Yuki";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    ShowMessage("You can now play with Yuki!");
                    break;
            }
        }

        //just shows a message via our ShopManager component,
        //but checks for an instance of it first
        void ShowMessage(string text)
        {
            if (ShopManager.GetInstance())
                ShopManager.ShowMessage(text);
        }

        //called when an purchaseFailedEvent happens, here we forward
        //the error message to ShopManager's error window (if present)
        void HandleFailedInventory(string error)
        {
            if (ShopManager.GetInstance())
                ShopManager.ShowMessage(error);
        }

        //called when an purchaseFailedEvent happens,
        //we do the same here
        void HandleFailedPurchase(string error)
        {
            if (ShopManager.GetInstance())
                ShopManager.ShowMessage(error);
        }


        //called when a purchased shop item gets selected
        void HandleSelectedItem(string id)
        {
            if (debug) Debug.Log("Selected: " + id);

            switch (id)
            {
                case "bann_coins":
                    gameParameters.currentCharacter = "Bann";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "bella_coins":
                    gameParameters.currentCharacter = "Bella";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "blane_coins":
                    gameParameters.currentCharacter = "Blane";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "damien_coins":
                    gameParameters.currentCharacter = "Damien";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "finnikin_coins":
                    gameParameters.currentCharacter = "Finnikin";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "gwyn_coins":
                    gameParameters.currentCharacter = "Gwyn";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "hector_coins":
                    gameParameters.currentCharacter = "Hector";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "katsa_coins":
                    gameParameters.currentCharacter = "Katsa";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "mather_coins":
                    gameParameters.currentCharacter = "Mather";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "pifoo_coins":
                    gameParameters.currentCharacter = "Pifoo";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "rylan_coins":
                    gameParameters.currentCharacter = "Rylan";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "sothe_coins":
                    gameParameters.currentCharacter = "Sothe";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "wesker_coins":
                    gameParameters.currentCharacter = "Wesker";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;

                case "yuki_coins":
                    gameParameters.currentCharacter = "Yuki";
                    PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
                    break;
            }
        }


        //called when a selected shop item gets deselected
        void HandleDeselectedItem(string id)
        {
            if (debug) Debug.Log("Deselected: " + id);
        }
    }
}