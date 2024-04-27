namespace ECommerceApp.Entities;

public class Bill : BaseEntity
{
    public Cart Cart { get; set; }

    public override string ToString()
    {
        var res = $"Bill Id\t: {Id}" +
                  $"\n\tTotal Items\t: {Cart.Items.Count}" +
                  $"\n\tPrice\t: ${Cart.TotalPrice}";
        if (Cart.ShippingCharge > 0)
        {
            return res + $"\n\tShipping Charge: ${Cart.ShippingCharge}" +
                   $"\n\tTotal: ${(Cart.TotalPrice + Cart.ShippingCharge):F2}";
        }

        if (Cart.Discount > 0)
        {
            return res + $"\n\tDiscount\t: -${Cart.Discount:F2}" +
                   $"\n\tTotal: ${(Cart.TotalPrice - Cart.Discount):F2}";
        }

        return res;
    }
}