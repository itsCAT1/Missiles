using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string removeAds = "com.game2d.missiles.removeads";
    private string add25000Coin = "com.game2d.missiles.add25000coin";
    private string add80000Coin = "com.game2d.missiles.add80000coin";
    private string add150000Coin = "com.game2d.missiles.add150000coin";

    public void OnPurchaseCompleted(Product product)
    {
        if (product.definition.id == removeAds)
        {
            Debug.Log("Remove ADS");
        }
        else if (product.definition.id == add25000Coin)
        {
            Debug.Log("Add 25000 coin");
        }
        else if (product.definition.id == add80000Coin)
        {
            Debug.Log("Add 80000 coin");
        }
        else if (product.definition.id == add150000Coin)
        {
            Debug.Log("Add 150000 coin");
        }
    }
}