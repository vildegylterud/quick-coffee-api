namespace quick_coffee_api;

/// <summary>
/// Settings to connect to Cosmos DB.
/// </summary>
public class CosmosSettings
{
 
    public string EndPoint { get; set; }
    
    public string AccessKey { get; set; }
    
    public string DatabaseName { get; set; }
    
    public bool EnableMigration { get; set; }
    
    public string DocumentToCheck { get; set; }
}
