using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Almanac.Service.Logging;
using Almanac.Service.Model;
using Almanac.Service.Templates;

namespace Almanac.Service.Channels
{
   public  class EmailChannel : BaseChannel
   {
      
       public EmailChannel(ITemplateProvider templateProvider, ILog logger,ISettingsProvider settingsProvider) : base(templateProvider,logger,settingsProvider)
       {

       }
       protected override void Send( Event e)
       {
           Send(GetSettings("receivers"), "Upcoming event for Vikrant", string.Format(GetTemplate(ChannelType.Email), e.EventDate, e.Celebration, e.DressCode.IfEmptyThen("NONE"), e.Material.IfEmptyThen("NONE"), e.TypeOfActivity.IfEmptyThen("NONE"), e.Theme, e.DaysRemaining));
       }

        private  bool Send(string receiverEmail,  string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            MailAddress mailAddress = new MailAddress("almanac@gmail.com", "DPS Almanac"); // abc@gmail.com = input Sender Email Address 
            mailMessage.From = mailAddress;


            mailMessage.To.Add(receiverEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = false;

            var mailSender = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("myalmanac2019@gmail.com", "Almanac@123")  
            };


            try
            {
                mailSender.Send(mailMessage);
                LogInfo($"Mail sent successfully to {mailMessage.To}");
                return true;
            }
            catch (SmtpFailedRecipientException ex)
            {
                LogException(ex);
            }
            catch (SmtpException ex)
            {
                LogException(ex);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            finally
            {
                mailSender = null;
                mailMessage.Dispose();
            }
            return false;
        }

       
   }
}
