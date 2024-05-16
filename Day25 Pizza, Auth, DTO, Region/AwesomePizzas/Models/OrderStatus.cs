using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AwesomePizzas.Models;

public enum OrderStatus
{
    [EnumMember(Value = "Placed")] Placed,
    [EnumMember(Value = "Preparing")] Preparing,
    [EnumMember(Value = "OutForCheckout")] OutForCheckout,
    [EnumMember(Value = "Delivered")] Delivered,
    [EnumMember(Value = "Canceled")] Canceled
}