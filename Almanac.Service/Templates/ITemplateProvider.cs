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
            return
                "Upcoming school event for Vikrant in {6} days under theme '{5}'. Date : {0}, Event : {1} ,DressCode : {2}, Material : {3}, Activity : {4}";
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