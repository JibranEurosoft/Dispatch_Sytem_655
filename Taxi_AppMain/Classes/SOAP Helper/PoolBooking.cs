using System.ComponentModel;
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
[global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.PoolBooking")]


public partial class PoolBooking
{

    public long? PoolJobId;
    public long? JobId;
    public string JobProviderDefaultClientId;
    public string JobProviderClientName;
    public string JobAcceptorDefaultClientId;
    public string JobAcceptorClientName;
    public decimal JobPrice;
    public string JobStatus;
    public string PickupDatetime;
    public string PickupLocation;
    public string BookingJson;
    public string JobAcceptorConnectionString;
    public EventType EventType;
    public int SubCompanyId;
    public int VehicleTypeId;
    public string JobProviderClientCompanyNumber;
    public string VehicleName;
    public string UserName;

}


public enum EventType
{
    UpdateBid = 0,
    AssignJob = 1,
    TransferredJob = 2,
    OfferedJob = 3,
    SendBackToOriginator = 4,
    UpdateJob = 5,
    CancelJob = 6,
    TrackDriver = 7
}