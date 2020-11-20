using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models;
using System;

namespace SPSXRiskv2.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]

    public class UtilsController : Controller
    {
        public UtilsController()
        {
        }

        [HttpPost("encrypt/{text}")]
        public ActionResult<StringModel> Encrypt(string text)
        {
            StringModel encryptedText = new StringModel();
            try
            {
                encryptedText.cadena = XRSKUtils.Encrypt(text);
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return encryptedText;
        }

        [HttpPost("decrypt/{text}")]
        public ActionResult<StringModel> Decrypt(string text)
        {
            StringModel decryptedText = new StringModel();
            try
            {
                decryptedText.cadena = XRSKUtils.Decrypt(text);
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return decryptedText;
        }
    }
}