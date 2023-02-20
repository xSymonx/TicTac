public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public Country Country { get; set; }
}

public enum Country
{
    USA,
    Canada,
    Mexico,
    Japan,
    China,
    UK,
    France,
    Germany,
    Italy,
    Spain
}
