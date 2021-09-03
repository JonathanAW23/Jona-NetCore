using NETCore.Context;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NETCore.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public string CheckEmail(string Email)
        {
            var checkLoginemail = (from p in myContext.Persons where p.Email == Email select new GetPersonVM { NIK = p.NIK }).ToList();
            if (checkLoginemail.Count == 0) 
            {
                return null;
            }
            else 
            {
                return checkLoginemail[0].NIK;
            }    
        }
        public bool CheckPassword(string NIK, string password)
        {
            var checkLoginemail = (from p in myContext.Persons
                                   join a in myContext.Accounts on p.NIK equals a.NIK
                                   where p.NIK == NIK
                                   select new GetPersonVM
                                   {
                                       NIK = p.NIK,
                                       Password = a.Password
                                   }).ToList();
            if (BCrypt.Net.BCrypt.Verify(password, checkLoginemail[0].Password))
                return true;
            else
                return false;
        }
        public string ResetPasswordGenerator()
        {
            Guid g = Guid.NewGuid();
            string password = g.ToString();
            return password;
        }
        public string Email(string password)//tambah string email kalo mau kirim email sesuai email yg di input di model forgot password
        {
            try
            {
                DateTime today = DateTime.Now;
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("email pengirim");//email pengirim
                message.To.Add("email penerima atau variable email yang dibuat");//email penerima (email testing atau string email yg disebut diatas)
                message.Subject = $"Reset Password Request From NETCoreTester {today}"; 
                message.Body = $"Password anda sudah kami reset menjadi {password}";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("email pengirim", "password email pengirim"); //self explanatory
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return "Email berhasil Dikirim";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
