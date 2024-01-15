using BusinessModels;
using DataAccessLayer.Repository.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TransactionController : ControllerBase
    {
        private ITransactionDaoImpl transactionDaoImpl;

        public TransactionController(ITransactionDaoImpl transactionDaoImpl)
        {
            this.transactionDaoImpl = transactionDaoImpl;
        }


        [HttpGet]
        [Route("{id}/all")]
        public IActionResult GetAllAccountDetails(int id)
        {
            //string userid = User.Claims.First().Value;
            //int id = int.Parse(userid);

            var fetchedData = transactionDaoImpl.FetchAllAccount(id);
            return this.Ok(fetchedData);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FetchAccountById(int id)
        {

            var fetchedData = transactionDaoImpl.FetchAccountById(id);
            return this.Ok(fetchedData);
        }



        [HttpPost]
        [Route("{id}")]
        public IActionResult AddTransaction([FromBody] TransactionModel transaction, int id)
        {
            //string userid = User.Claims.First().Value;
            //int id = int.Parse(userid);
            var result = transactionDaoImpl.InsertAccountField(transaction, id);
            return this.CreatedAtAction(
                "AddTransaction",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = transaction
                }
                );
        }


        [HttpGet]
        [Route("cred/{id}/{status}")]
        public IActionResult FetchAccountByStatus(string status, int id)
        {
            //string userid = User.Claims.First().Value;
            //int id = int.Parse(userid);
            var fetchedData = transactionDaoImpl.FetchAccountBystatus("Done", id);
            return this.Ok(fetchedData);
        }

        [HttpPut]
        [Route("{customerId}")]
        public IActionResult UpdateAccount(TransactionModel transaction, int customerId)
        {
            var result = transactionDaoImpl.UpdateAccountField(transaction, customerId);

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


        [HttpPut]
        [Route("payment/{id}")]
        [AllowAnonymous]
        public IActionResult ProceedAccount(int id)
        {
            var result = transactionDaoImpl.ProceedTransaction(id);

            return this.CreatedAtAction(
                "ProceedAccount",
                new
                {
                    StatusCode = 201,
                    Response = result,

                    Data = id
                }
                );
        }

        [HttpDelete]
        [Route("{customerId}")]
        public IActionResult DeleteAccount(int customerId)
        {
            var result = transactionDaoImpl.DeleteAccountFieldbyID(customerId);
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
