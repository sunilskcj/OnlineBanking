using BusinessModels;
using DataAccessLayer.Repository.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PayeeController : ControllerBase
    {
        private IPayeeDaoImpl payeeDaoImpl;

        public PayeeController(IPayeeDaoImpl payeeDaoImpl)
        {
            this.payeeDaoImpl = payeeDaoImpl;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAllAccountDetails(int id)
        {

            //string userid = User.Claims.First().Value;
            //int id = int.Parse(userid);
            var fetchedData = payeeDaoImpl.FetchAllAccount(id);
            return this.Ok(fetchedData);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult FetchAccountById(int id)
        //{

        //    var fetchedData = payeeDaoImpl.FetchAccountById(id);
        //    return this.Ok(fetchedData);
        //}
        [HttpPost]
        [Route("{id}")]
        public IActionResult AddAccount(PayeeModel transaction, int id)
        {
            //string userid = User.Claims.First().Value;
            //int id = int.Parse(userid);
            var result = payeeDaoImpl.InsertAccountField(transaction, id);
            return this.CreatedAtAction(
                "AddAccount",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = transaction
                }
                );
        }


        [HttpPut]
        [Route("{customerId}")]
        public IActionResult UpdateAccount(PayeeModel transaction, int customerId)
        {
            var result = payeeDaoImpl.UpdateAccountField(transaction, customerId);

            return this.CreatedAtAction(
                "UpdateAccount",
                new
                {
                    StatusCode = 201,
                    Response = result,

                    Data = transaction
                }
                );
        }

        [HttpDelete]
        [Route("{customerId}")]
        public IActionResult DeleteAccount(int customerId)
        {
            var result = payeeDaoImpl.DeleteAccountFieldbyID(customerId);
            return this.CreatedAtAction(
                "DeleteAccount",
                new
                {
                    StatusCode = 201,
                    Response = result,

                }
                );
        }

    }
}
