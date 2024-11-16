namespace TaylorWessing.Models
{

    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ClientSearchesponse
    {
     //   [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

//        [JsonPropertyName("returnedResults")]
        public int ReturnedResults { get; set; }

 //       [JsonPropertyName("filter")]
        public string Filter { get; set; }

//        [JsonPropertyName("offset")]
        public int Offset { get; set; }

  //      [JsonPropertyName("index")]
        public int Index { get; set; }

    //    [JsonPropertyName("orderBy")]
        public string OrderBy { get; set; }

      //  [JsonPropertyName("searchOrder")]
        public string SearchOrder { get; set; }

       // [JsonPropertyName("searchError")]
        public string? SearchError { get; set; }

      //  [JsonPropertyName("results")]
        public List<ClientSearchResultItem> Results { get; set; }
    }

    public class ClientSearchResultItem
    {
      //  [JsonPropertyName("clientId")]
        public Guid ClientId { get; set; }

    /// <summary>
    ///    [JsonPropertyName("name")]
    /// </summary>
        public string Name { get; set; }

    //    [JsonPropertyName("code")]
        public string Code { get; set; }

      //  [JsonPropertyName("inception")]
        public DateTime Inception { get; set; }

      //  [JsonPropertyName("matterCount")]
        public int MatterCount { get; set; }
    }


   
    public enum ClientOrderBy
    {
        NAME,
        DATE
    }

    public class ClientResult
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? Inception { get; set; }
        public int MatterCount { get; set; }
    }

    public class ClientSearchResult
    {
        public int TotalResults { get; set; }
        public int ReturnedResults { get; set; }
        public string Filter { get; set; }
        public int Offset { get; set; }
        public int Index { get; set; }
        public ClientOrderBy OrderBy { get; set; }
        public SearchOrder SearchOrder { get; set; }
        public string searchError { get; set; } = string.Empty;
        public List<ClientResult> Results { get; set; }
    }

    public class Matter
    {
        public Guid ClientId { get; set; }
        public Guid MatterId { get; set; }
        public string MatterCode { get; set; }
        public string MatterName { get; set; }
        public string MatterDescription { get; set; }
        public DateTime? MatterDate { get; set; }
    }

    public enum MatterOrderBy
    {
        NAME,
        DATE
    }

    public class MatterResult
    {
        public string ClientId { get; set; }
        public string MatterId { get; set; }
        public string MatterName { get; set; }
        public string MatterCode { get; set; }
        public DateTime? MatterDate { get; set; }
    }

    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime InceptionDate { get; set; }
        public Address Address { get; set; }
        public List<Person> People { get; set; }
        public int MatterCount { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }

    public class Person
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }




    public class MatterSearchResult
    {
        public int TotalResults { get; set; }
        public int ReturnedResults { get; set; }
        public int Offset { get; set; }
        public int Index { get; set; }
        public string OrderBy { get; set; }
        public string SearchOrder { get; set; }
        public string? SearchError { get; set; } // Nullable in case of null value
        public List<Matter> Results { get; set; } // List of matters
    }

   

    public class ProblemDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }

    public enum SearchOrder
    {
        ASCENDING,
        DESCENDING
    }



}
