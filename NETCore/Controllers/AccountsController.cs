using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NETCore.Base;
using NETCore.Models;
using NETCore.Repository.Data;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        public IConfiguration configuration;
        public AccountsController(IConfiguration config, AccountRepository repository) : base(repository)
        {
            this.accountRepository = repository;
            this.configuration = config;
        }

        [HttpPost("Login")]

        public ActionResult Login(LoginVM loginVM)
        {
            string NIK = accountRepository.CheckEmail(loginVM.Email);
            if (string.IsNullOrEmpty(NIK))
            {
                return NotFound(new JWTokenVm { Token = null, Messages = "Login Gagal" });
                //return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "Data tidak ada didatabase" });
            }
            else if (accountRepository.CheckPassword(NIK, loginVM.Password))
            {
                string[] roles = accountRepository.GetRole(NIK);
                var claims = new List<Claim>();
                claims.Add(new Claim("NIK", NIK));
                claims.Add(new Claim("email", loginVM.Email));
                foreach (string role in roles) 
                {
                    claims.Add(new Claim("roles", role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                return Ok(new JWTokenVm { Token = new JwtSecurityTokenHandler().WriteToken(token), Messages = "Login Berhasil" });
                //return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = new JwtSecurityTokenHandler().WriteToken(token)});
            }
            else
            {
                return Ok(new JWTokenVm { Token = null, Messages = "anggap saja Login Berhasil" });
                //return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Password salah" });
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
}
