using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

public class SMTP
{
  SmtpClient SmtpMail = new SmtpClient();
  protected bool _IsHTML=false;
  /// <summary>
  /// 
  /// </summary>
  public SMTP()
  {
    SmtpMail = new SmtpClient();
    SmtpMail.UseDefaultCredentials=true ;
  }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="Host"></param>
  /// <param name="port"></param>
  /// <param name="UserName"></param>
  /// <param name="Password"></param>
  public SMTP(string Host, int Port, string UserName, string Password, bool EnableSSL, bool AuthenticationRequired)
  {
    SmtpMail = new SmtpClient();
    SmtpMail.Port = Port;
    SmtpMail.Host = Host;
    if (EnableSSL)
    {
      SmtpMail.EnableSsl=true;
    }

    if (AuthenticationRequired)
    {
      SmtpMail.Credentials = new NetworkCredential(UserName, Password);
    }
    
  }
 

  /// <summary>
  /// 
  /// </summary>
  /// <param name="From"></param>
  /// <param name="To"></param>
  /// <param name="Subject"></param>
  /// <param name="Body"></param>
  /// <returns></returns>
  public bool SendEmail(string From, string To, string Subject, string Body)
  {
    return SendEmail(From, "", To, "", "", Subject, Body,false );
  }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="From"></param>
  /// <param name="FromDisplayName"></param>
  /// <param name="To"></param>
  /// <param name="Cc"></param>
  /// <param name="Bcc"></param>
  /// <param name="Subject"></param>
  /// <param name="Body"></param>
  /// <returns></returns>
  public bool  SendEmail(string From,string FromDisplayName, string To, string Cc, string Bcc, string Subject, string Body,bool SendMailInBackGround)
  {
    MailAddress _MailAddress = new MailAddress(From, FromDisplayName);
    MailMessage EmailMessage = new MailMessage();
    EmailMessage.From=_MailAddress;
    AddAddress(EmailMessage.To,To);
    AddAddress(EmailMessage.CC, Cc);
    AddAddress(EmailMessage.Bcc , Bcc );
    EmailMessage.Subject = Subject;
    EmailMessage.Body = Body;
    EmailMessage.IsBodyHtml = IsHTML;
    if (SendMailInBackGround)
    {
      SmtpMail.SendAsync(EmailMessage, null);
    }
    else
    {
      SmtpMail.Send(EmailMessage);

    }
    return true;
   
  }

  public bool IsHTML 
  {
    get 
    {
      return _IsHTML;
    }
    set 
    {
      _IsHTML = value;
    }
  }
 /// <summary>
 /// 
 /// </summary>
 /// <param name="aMailAddressCollection"></param>
 /// <param name="Addreses"></param>
  private void AddAddress(MailAddressCollection aMailAddressCollection,string Addreses)
  {
    string[] Temp = Addreses.Split(',');
    MailAddress itm;
    if (Temp == null)
    {
      return;
    }
    for (int i = 0; i < Temp.Length; i++)
    {
      if (Temp[i].Trim()!="")
      {
      itm=new MailAddress(Temp[i]);
      aMailAddressCollection.Add(itm);
      }
    }

  }
}

