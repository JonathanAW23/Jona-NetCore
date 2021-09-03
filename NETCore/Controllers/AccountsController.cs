using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Base;
using NETCore.Models;
using NETCore.Repository.Data;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        public AccountsController(AccountRepository repository) : base(repository)
        {
            this.accountRepository = repository;
        }

        [HttpPost("Login")]

        public ActionResult Login(LoginVM loginVM)
        {
            string NIK = accountRepository.CheckEmail(loginVM.Email);
            if (string.IsNullOrEmpty(NIK))
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "Data tidak ada didatabase" });
            }
            else if (accountRepository.CheckPassword(NIK, loginVM.Password))
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Berhasil login" });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Password salah" });
            }
        }

        [HttpPut("ForgotPassword")]

        public ActionResult ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            string NIK = accountRepository.CheckEmail(forgotPasswordVM.Email);
            if (string.IsNullOrEmpty(NIK))
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "Data tidak ada didatabase" });
            }
            else 
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                string password = accountRepository.ResetPasswordGenerator();
                Account account = new Account();
                account.NIK = NIK;
                account.Password = BCrypt.Net.BCrypt.HashPassword(password,salt);
                update(account);
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = accountRepository.Email(password) });
            }
        }

        [HttpPut("ChangePassword")]

        public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            string NIK = accountRepository.CheckEmail(changePasswordVM.Email);
            if (string.IsNullOrEmpty(NIK))
            {
                return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "Data tidak ada didatabase" });
            }
            else if (accountRepository.CheckPassword(NIK, changePasswordVM.OldPassword))
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                Account account = new Account();
                account.NIK = NIK;
                account.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordVM.NewPassword,salt);
                update(account);
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Sukses Ganti Password" });
            }
            else 
            {
                return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Password salah" });
            }
        }
    }
}//
