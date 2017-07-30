using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChequeConverter.Controllers
{
    public class ChequeController : ApiController
    {
        private IConverter converter;

        public ChequeController()
        {
            //default controller constructor
            this.converter = new ChequeConverter();
        }

        public ChequeController(IConverter conv)
        {
            //for IOC container injection
            this.converter = conv;
        }

        [HttpGet]
        [Route("api/cheque/convert/{amount?}")]
        public IHttpActionResult GetChequeInWords(decimal amount=0)
        {
            //validate the data
            if (amount < 0)
            {
                return InternalServerError();
            }
            if (amount == 0)
            {
                return Ok("Zero dollar");
            }
            
            return Ok(converter.NumberToWords(amount));
        }

    }
}
