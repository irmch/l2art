namespace L2Art.Domain.Auctions
{
    public record ItemMetaData(
        long CommissionId,
        long PricePerUnit, 
        int CommissionItemType, 
        int DurationInDays, 
        int EpochSecondEndTime, 
        string SellerName, 
        short TypeOfModification);
}