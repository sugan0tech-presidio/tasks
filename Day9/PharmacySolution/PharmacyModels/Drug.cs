namespace PharmacyModels;

// todo drug validation for age group & gender groups
public class Drug: BaseEntity
{
    /// <summary>
    /// Base Constructor.
    /// Sets PrescriptionNeeded as false by default;
    /// </summary>
    public Drug()
    {
        PrescriptionNeeded = false;
        QuantitiesWithDates = new();
    }

    /// <summary>
    /// All argument constructor.
    /// </summary>
    /// <param name="id">Drug Id, Recommended to follow Repository generated Id.</param>
    /// <param name="name">Drug Name.</param>
    /// <param name="provider">Provider or Manufacturer of that Drug.</param>
    /// <param name="expiryDate">Drug's estimated expiration.</param>
    /// <param name="qunatiy">Quantity of drug</param>
    /// <param name="price">Per quantity price</param>
    /// <param name="prescriptionNeeded">Whether it requires a Doctor's prescription.</param>
    /// <param name="classification">Classification of Current Drug</param>
    public Drug(int id, string name, string provider, DateTime expiryDate, double price, bool prescriptionNeeded, string classification): base(id)
    {
        Name = name;
        Provider = provider;
        QuantitiesWithDates = new();
        this.price = price;
        PrescriptionNeeded = prescriptionNeeded;
        Classification = classification;
    }

    public string Name { get; set; }
    public string Provider { get; set; }
    
    /// <summary>
    /// Mapped like: Expiration dates -> quantities
    /// </summary>
    public Dictionary<DateTime, int> QuantitiesWithDates { get; }
    public long Count;
    public double price { get; set; }
    public bool PrescriptionNeeded { get; set; }
    public string Classification { get; set; }
    
    /// <summary>
    /// Method updates new stash with given expiry date.
    /// </summary>
    /// <param name="expiryDate"></param>
    /// <param name="quantity"></param>
    public void AddNewStash(DateTime expiryDate, int quantity)
    {
        // If the expiration date already exists, update the quantity; otherwise, add a new entry
        if (QuantitiesWithDates.ContainsKey(expiryDate))
        {
            QuantitiesWithDates[expiryDate] += quantity;
        }
        else
        {
            QuantitiesWithDates.Add(expiryDate, quantity);
        }
    }
    
    public override bool Equals(object? obj)
    {
        var converted = obj as Drug;
        return Equals(converted ?? throw new InvalidOperationException());
    }

    private bool Equals(Drug other)
    {
        return Id == other.Id && Name == other.Name && Classification == other.Classification;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Classification);
    }

    public override string ToString()
    {
        string expiryQuantitiesString = string.Join(", ", QuantitiesWithDates.Select(kv => $"{kv.Key.ToShortDateString()}: {kv.Value}"));
        return $"\nID\t: {Id}, " +
               $"\n\tName\t: {Name}, " +
               $"\n\tManufacturer\t: {Provider}, " +
               $"\n\tExpiryQuantities\t: {{ {expiryQuantitiesString} }}, " +
               $"\n\tPrescriptionNeeded\t: {PrescriptionNeeded}, " +
               $"\n\tClassification\t: {Classification}";

    }
}