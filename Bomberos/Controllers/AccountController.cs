﻿using Bomberos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bomberos.Controllers
{
    public class AccountController : Controller
    {
        public List<Claim> claims = new List<Claim>();
        private readonly BomberoContext _context = new BomberoContext();

       

        [HttpGet("Login")]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> validate(string usuario, string password)
        {
            string pass = GetSHA256(password).ToUpper();
            var val = _context.Usuarios.Where(a => a.UsUsuario== usuario && a.UsContraseña==pass);
            if (val.Any() && val.First().Activo)
            {
                // creamos un listado de peticion
                claims.Add(new Claim("username", val.First().Nombres)); // guardamos el nombre de quien se logea
                claims.Add(new Claim(ClaimTypes.NameIdentifier, val.First().Nombres)); //guardamos el tipo de peticion 
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // asignamos esa peticicon a un esquema de cookies
                var claimprincipal = new ClaimsPrincipal(claimIdentity); // la volvemos peticion principal


                await HttpContext.SignInAsync(claimprincipal); // cremos la cookie de autentificacion

                return RedirectToAction("Index", "Home"); // redireccion a un pagina 
            }
            else
            {
                if (val.First().Activo)
                {
                    return RedirectToAction("Index", "Error", new { data = "Error de Log in", data2 = "Usuario o Contraseña invalidos" });
                    // si el usuario no es valido envia un badrequest como respuesta

                }
                else
                {
                    return RedirectToAction("Index", "Error", new { data = "Error de Log in", data2 = "Usuario Inactivo porfavor contacte a la institucion" });
                    // si el usuario no es valido envia un badrequest como respuesta

                }
            }


        }
        private string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(
     CookieAuthenticationDefaults.AuthenticationScheme); //elimina la cookie creada 
            return RedirectToAction("Index", "Home"); // regresa a una pagina especifica 
        }
    }
}
