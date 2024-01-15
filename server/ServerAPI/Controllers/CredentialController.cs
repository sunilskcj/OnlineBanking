using DataAccessLayer.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        
        private ICredentialsDaoImpl credentialsDao;

        public CredentialController(ICredentialsDaoImpl credentialsDao)
        {
            this.credentialsDao = credentialsDao;
        }

        [HttpGet]
        public IActionResult GetAllAccountDetails()
        {

            var fetchedData = credentialsDao.FetchAllAccountCredential();
            return this.Ok(fetchedData);
        }

        [HttpGet]
        [Route("cred/cust/{id}")]

        public IActionResult FetchAccountById(int id)
        {
            //string userid = User.Claims.First().Value;
            //int id = int.Parse(userid);
            var fetchedData = credentialsDao.FetchAccountById(id);
            return this.Ok(fetchedData);
        }



        [HttpPost]
        [Route("{id}")]
        public IActionResult AddCredentials(int id)
        {

            var result = credentialsDao.InsertAccountCredential(id);
            return this.CreatedAtAction(
                "AddCredentials",
                new
                {
                    StatusCode = 201,
                    Response = result,

                });
        }





    
    }
}
