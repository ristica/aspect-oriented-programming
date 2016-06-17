using System.Runtime.Serialization;
using AOPSampleApp.Aspects;

namespace AOPSampleApp.DataContracts
{
    ///// <summary>
    ///// comment this in to see what happenes if 
    ///// you forget to add DataMemeber attributes to FirstName and LastName
    ///// => there are no FirstName and LastName in console output window
    ///// AND COMMENT OUT THIS ENTRY IN PropertyInfo CLASS: 
    /////[assembly: DataContractAspect(AttributeTargetTypes = "AOPSampleApp.DataContracts.*")]
    ///// </summary>
    //[DataContract]
    //public class Person
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }

    //    [DataMember]
    //    public string Email { get; set; }
    //}





    /// <summary>
    /// comment this in to see what happenes if you attach the DataContract aspect
    /// => it adds DAtaMemeber attribute to all proerties of Person class
    /// => it adds DataContract attribute to the Person class
    /// COMMENT IN THIS ENTRY IN PropertyInfo CLASS: 
    /// [assembly: DataContractAspect(AttributeTargetTypes = "AOPSampleApp.DataContracts.*")]
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // the EMAIL property is going to be ignored by aspect!!!
        [NotADataMemberAttributeAspect]
        public string Email { get; set; }
    }
}