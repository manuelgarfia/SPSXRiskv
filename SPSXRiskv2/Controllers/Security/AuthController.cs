using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace SPSXRiskv2.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : Controller
    {
        private readonly UserManager<XRSKUser> _userManager;

        public static string MD5Hash(string input)
        {

            // Step 1, calculate MD5 hash from input
            MD5 md5 =MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
          
        }

        [HttpGet("users")]
        public List<XRSKFocUsuarios> GetUsers()
        {
            XRSKFocUsuarios usuariosItems = new XRSKFocUsuarios();
            List<XRSKFocUsuarios> usuariosList = new List<XRSKFocUsuarios>();

            try
            {
                usuariosList = usuariosItems.GetSimpleList();
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }
            return usuariosList;
        }

        [HttpGet("usergroup")]
        public List<XRSKFocUsuariosGrupos> GetUsersGroups()
        {
            XRSKFocUsuariosGrupos userGroupItems = new XRSKFocUsuariosGrupos();
            List<XRSKFocUsuariosGrupos> userGroupList = new List<XRSKFocUsuariosGrupos>();

            try
            {
                userGroupList = userGroupItems.GetSimpleList();
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }
            return userGroupList;
        }

        [HttpGet("securityObject")]
        public List<XRSKSecurityObject> GetSecurityObject()
        {
            XRSKSecurityObject securityObjectItems = new XRSKSecurityObject();
            List<XRSKSecurityObject> securityObjectList = new List<XRSKSecurityObject>();

            try
            {
                securityObjectList = securityObjectItems.GetList();
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }
            return securityObjectList;
        }

        public AuthController(UserManager<XRSKUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            try
            {
                XRSKFocUsuarios user = new XRSKFocUsuarios();

                model.Password = MD5Hash(model.Password);

                user.Find(model);
                
               // var user1 = await this._userManager.FindByNameAsync(model.Username);

                if (user.usuari == null)
                {
                    return BadRequest(new { message = "¡Usuario o password incorrectos!" });
                }

                //if (await this._userManager.CheckPasswordAsync(user, model.Password))
                //{
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySp$cialPassw0rd"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.nombre.ToString()),
                    new Claim("username", model.Username)
                };

                //De moment, com que no tenim rols a la taula, els empinyem.
                List<string> roles = new List<string>();

                if (user.usuari == "xrisk")
                {
                   // roles.Add("users");
                    claims.Add(new Claim(ClaimTypes.Role, "users"));
                }
                else if (user.usuari == "portal") {
                   // roles.Add("admin");
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                }

                //foreach (String rol in roles)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, rol));
                //}


                var token = new JwtSecurityToken(
                        issuer: "https://localhost:44327",
                        audience: "https://localhost:44327",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(300),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


                    return Ok(new
                    {
                        Token = tokenString,
                        ExpiresIn = token.ValidTo,
                        Username = user.usuari
                    });
                //}

            }
            catch (Exception e)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySp$cialPassw0rd"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:44327",
                    audience: "https://localhost:44327",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


                return Ok(new
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Username = "bhaidar"
                });

            }


            return Unauthorized();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var user = new XRSKUser { UserName = model.Username, NormalizedUserName = model.Name, Email = model.Email };
            ////var user = new XRSKFocUsuarios { usuari = model.us }
            //var result = await _userManagerFoc.CreateAsync(user, model.Password);

            //if (!result.Succeeded) return BadRequest(result.Errors);


            //await _userManagerFoc.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
            //await _userManagerFoc.AddClaimAsync(user, new System.Security.Claims.Claim("name", user.NormalizedUserName));
            //await _userManagerFoc.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
            //await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Roles.));

           // return Ok(new LoginModel(user));
            return null;
        }

    }
}