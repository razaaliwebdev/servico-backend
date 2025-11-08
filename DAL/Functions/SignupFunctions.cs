using DAL.DataContext;
using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DAL.Functions
{
    public class SignupFunctions : ISignup
    {
        public async Task<Signup> AddSignup(string firstname, string lastname, string email, string phone, string password, string type, string document1, string document2, string extra, string verify)
        {

           
            Signup newUser = new Signup

            {
                firstname = firstname,
                lastname=lastname,
                email=email,
                phone=phone,
                password=password,
                type=type,
                document1=document1,
                document2=document2,
                extra=extra,
                verification=verify
                
                


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.signups.FirstOrDefault(x=>x.email== email);
                if (get != null)
                {
                    Signup obj = new Signup();
                    return obj;
                }
                else
                {
                    await context.signups.AddAsync(newUser);
                    await context.SaveChangesAsync();
                }
              
            }

            var emails = new MimeMessage();
            emails.From.Add(MailboxAddress.Parse("info@servico.ae"));
            emails.To.Add(MailboxAddress.Parse(email));
            emails.Subject = "Servico - Email Password";
            var url = "http://64.20.61.114/MASAB2B/api/Settings/confirm/?email=" + email;
            emails.Body = new TextPart(TextFormat.Html) { Text = "<body style='margin: 0; padding: 0; background-color: #ffffff;'><table width='100%' cellpadding='0' cellspacing='0' border='0' style='font-family: Arial, sans-serif;'><tr><td align='center'><table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color: #ffffff; padding: 20px;'><tr><td align='center' style='padding: 40px 0;'><table cellpadding='0' cellspacing='0' border='0' style='background-color: #00b6b6; border-radius: 6px;'><tr><td style='padding: 10px 20px;'><h1 style='color: #ffffff; font-size: 24px; margin: 0;'>SERVICO</h1></td></tr></table></td></tr><tr><td align='center' style='font-size: 18px; padding: 0 0 10px;'>Hello From Servico,</td></tr><tr><td align='center' style='font-size: 16px; padding: 0 0 30px;'>Just a friendly reminder to verify your email address.</td></tr><tr><td align='center'><table width='100%' cellpadding='0' cellspacing='0' border='0' style='background-color: #f3f3f3; border-radius: 10px; padding: 20px;'><tr><td align='center' style='padding: 40px 20px;'><img src='https://img.icons8.com/ios-filled/100/user.png' alt='User Icon' width='60' height='60' style='margin-bottom: 20px; display: block;' /><p style='font-size: 14px; color: #555555; margin: 0 0 20px;'>To prepare your account for use, we kindly request you to confirm your email address. Please complete the verification within 15 days of signing up to prevent your account from being deleted.</p><a href='#' style='display: inline-block; margin-top: 20px; padding: 10px 20px; background-color: #00b6b6; color: #ffffff; text-decoration: none; border-radius: 5px;'>Verify email address</a></td></tr></table></td></tr><tr><td align='center' style='padding: 30px 0;'><a href='#'><img src='https://img.icons8.com/ios-filled/50/facebook--v1.png' alt='Facebook' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/google-logo.png' alt='Google' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/tiktok--v1.png' alt='TikTok' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/linkedin.png' alt='LinkedIn' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/instagram-new.png' alt='Instagram' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/whatsapp.png' alt='WhatsApp' width='24' style='margin: 0 5px; display: inline-block;' /></a></td></tr><tr><td align='center' style='font-size: 12px; color: #777777; padding: 10px 0;'>Copyright © 2025<br/>Servico<br/>Servico Together</td></tr></table></td></tr></table></body>\r\n" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("mail.servico.ae", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("info@servico.ae", "Dubai@123D");
            smtp.Send(emails);
            smtp.Disconnect(true);
            return newUser;
        }



        public async Task<List<Signup>> GetAllSignup()
        {
            List<Signup> Signup = new List<Signup>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Signup = await context.signups.OrderByDescending(s => s.id).ToListAsync();

            }
            return Signup;
        }

        public async Task<Signup> UpdateSignup(string id,string firstname, string lastname, string email, string phone, string password, string type, string document1, string document2, string extra, string verification)
        {
            Signup newUser = new Signup

            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                phone = phone,
                password = password,
                type = type,
                document1 = document1,
                document2 = document2,
                extra = extra,
                verification = verification


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.signups.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.firstname = firstname;
                get.lastname = lastname;
                get.email = email;
                get.phone = phone;
                get.password = password;
                get.type = type;
                get.document1 = document1;
                get.document2 = document2;
                get.extra = extra;
                get.verification = verification;
                context.signups.Update(get);
                await context.SaveChangesAsync();
            }
            var emails = new MimeMessage();
            emails.From.Add(MailboxAddress.Parse("info@servico.ae"));
            emails.To.Add(MailboxAddress.Parse(email));
            emails.Subject = "Servico - Email Password";
            var url = "http://64.20.61.114/MASAB2B/api/Settings/confirm/?email=" + email;
            emails.Body = new TextPart(TextFormat.Html) { Text = "<body style='margin: 0; padding: 0; background-color: #ffffff;'><table width='100%' cellpadding='0' cellspacing='0' border='0' style='font-family: Arial, sans-serif;'><tr><td align='center'><table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color: #ffffff; padding: 20px;'><tr><td align='center' style='padding: 40px 0;'><table cellpadding='0' cellspacing='0' border='0' style='background-color: #00b6b6; border-radius: 6px;'><tr><td style='padding: 10px 20px;'><h1 style='color: #ffffff; font-size: 24px; margin: 0;'>SERVICO</h1></td></tr></table></td></tr><tr><td align='center' style='font-size: 18px; padding: 0 0 10px;'>Hello From Servico,</td></tr><tr><td align='center' style='font-size: 16px; padding: 0 0 30px;'>Just a friendly reminder to verify your email address.</td></tr><tr><td align='center'><table width='100%' cellpadding='0' cellspacing='0' border='0' style='background-color: #f3f3f3; border-radius: 10px; padding: 20px;'><tr><td align='center' style='padding: 40px 20px;'><img src='https://img.icons8.com/ios-filled/100/user.png' alt='User Icon' width='60' height='60' style='margin-bottom: 20px; display: block;' /><p style='font-size: 14px; color: #555555; margin: 0 0 20px;'>To prepare your account for use, we kindly request you to confirm your email address. Please complete the verification within 15 days of signing up to prevent your account from being deleted.</p><a href='#' style='display: inline-block; margin-top: 20px; padding: 10px 20px; background-color: #00b6b6; color: #ffffff; text-decoration: none; border-radius: 5px;'>Verify email address</a></td></tr></table></td></tr><tr><td align='center' style='padding: 30px 0;'><a href='#'><img src='https://img.icons8.com/ios-filled/50/facebook--v1.png' alt='Facebook' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/google-logo.png' alt='Google' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/tiktok--v1.png' alt='TikTok' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/linkedin.png' alt='LinkedIn' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/instagram-new.png' alt='Instagram' width='24' style='margin: 0 5px; display: inline-block;' /></a><a href='#'><img src='https://img.icons8.com/ios-filled/50/whatsapp.png' alt='WhatsApp' width='24' style='margin: 0 5px; display: inline-block;' /></a></td></tr><tr><td align='center' style='font-size: 12px; color: #777777; padding: 10px 0;'>Copyright © 2025<br/>Servico<br/>Servico Together</td></tr></table></td></tr></table></body>\r\n" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("mail.servico.ae", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("info@servico.ae", "Dubai@123D");
            smtp.Send(emails);
            smtp.Disconnect(true);


            return newUser;

        }


        public Signup getbyidSignup(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.signups.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public Signup GetLogin(Signup obj)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {

                var getbyID = context.signups.FirstOrDefault(x => x.email == obj.email && x.password == obj.password );
                if (getbyID !=null)
                {
                    return getbyID;
                }
                else
                {
                    Signup emptyobj = new Signup();
                    return emptyobj;
                }
                


            }
        }
        public string ForgotPassword(Signup obj)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {

                var getbyID = context.signups.FirstOrDefault(x => x.email == obj.email);
                if (getbyID != null)
                {
                    var emails = new MimeMessage();
                    emails.From.Add(MailboxAddress.Parse("info@servico.ae"));
                    emails.To.Add(MailboxAddress.Parse(obj.email));
                    emails.Subject = "Servico - Email Password";
                    var url = "http://64.20.61.114/MASAB2B/api/Settings/confirm/?email=" + obj.email;
                    emails.Body = new TextPart(TextFormat.Html) { Text = "<body style=\"margin: 0; padding: 0; font-family: Arial, sans-serif; background-color: #ffffff; text-align: center;\"><div style=\"padding: 40px 0;\"><div style=\"background-color: #00b6b6; padding: 10px 20px; display: inline-block; border-radius: 6px;\"><h1 style=\"color: white; font-size: 24px; margin: 0;\">SERVICO</h1></div></div><p style=\"font-size: 18px; margin: 0 0 20px 0;\">Hello User,</p><p style=\"font-size: 16px; margin: 0 0 30px 0;\">Just a friendly reminder to<br>verify your email address.</p><div style=\"max-width: 500px; margin: 0 auto; padding: 20px;\"><div style=\"background-color: #f3f3f3; padding: 40px 20px; border-radius: 10px;\"><img src=\"https://cdn-icons-png.fl\r\n" };

                    // send email
                    using var smtp = new SmtpClient();
                    smtp.Connect("mail.servico.ae", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("info@servico.ae", "Dubai@123D");
                    smtp.Send(emails);
                    smtp.Disconnect(true);
                    return "true";
                }
                else
                {
                    Signup emptyobj = new Signup();
                    return "false";
                }



            }
        }
        
        public string DeleteSignup(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.signups.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                if (getbyID != null)
                {
                    context.Remove(getbyID);
                    context.SaveChanges();


                    return "true";

                }
                else
                {
                    return "false";
                }



            }
        }

    }
}
