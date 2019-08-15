namespace Almanac.Service.Templates
{
    public interface ITemplateProvider
    {
        string GetTemplate(ChannelType channelType);
    }

    public class DefaultTemplateProvider : ITemplateProvider
    {
        public string GetTemplate(ChannelType channelType)
        {
            switch (channelType)
            {
                case ChannelType.WhatsApp:
                    return
                        "Your appointment is coming up on / in {0} day(s) for Vikrant at DPS E-City EventDate : {1},Event : {2},DressCode : {3}, Material : {4}, Activity : {5} ";
                default:
                    return
                        "Upcoming school event for Vikrant in {6} days under theme '{5}'. Date : {0}, Event : {1} ,DressCode : {2}, Material : {3}, Activity : {4}";
            }
            
        }
    }
   
    public enum ChannelType
    {
        Email=0,
        Sms=1,
        WhatsApp=2,
        Console=3
    }
}