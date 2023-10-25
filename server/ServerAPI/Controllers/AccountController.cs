using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessModels;
using DataAccessLayer;
using DataAccessLayer.Repository.Implementation;
using Microsoft.AspNetCore.Authorization;
using Server.BusinessModels;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountsController : ControllerBase
    {
        private IAccountFieldDao _accountFieldDao;


        public AccountsController(IAccountFieldDao accountFieldDao)
        {
            _accountFieldDao = accountFieldDao;
        }

        [HttpGet]

        public IActionResult GetAllAccountDetails()
        {

            var fetchedData = _accountFieldDao.FetchAllAccount();
            return this.Ok(fetchedData);
        }

        [HttpGet]

        [Route("acc/{status}")]
        public IActionResult FetchAccountByStatus(string status)
        {

            var fetchedData = _accountFieldDao.FetchAccountByStatus(status);
            return this.Ok(fetchedData);
        }

        [HttpGet]
        [Route("id")]

        public IActionResult FetchAccountById()
        {

            string userid = User.Claims.First().Value;
            int id = int.Parse(userid);
            var fetchedData = _accountFieldDao.FetchAccountById(id);
            return this.Ok(fetchedData);
        }

        [HttpGet]
        [Route("admin/{id}")]

        public IActionResult FetchAccountById(int id)
        {


            var fetchedData = _accountFieldDao.FetchAccountById(id);
            return this.Ok(fetchedData);
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddAccount([FromBody] AccountModel account)
        {

            var result = _accountFieldDao.InsertAccountField(account);
            return this.CreatedAtAction(
                "AddAccount",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = account
                }
                );
        }


        [HttpPut]
        public IActionResult UpdateAccount(AccountModel account)
        {
            string userid = User.Claims.First().Value;
            int id = int.Parse(userid);
            var result = _accountFieldDao.UpdateAccountField(account, id);

            return this.CreatedAtAction(
                "UpdateAccount",
                new
                {
                    StatusCode = 201,
                    Response = result,

                    Data = account
                }
                );
        }

        [HttpDelete]
        [Route("{customerId}")]
        public IActionResult DeleteAccount(int customerId)
        {
            var result = _accountFieldDao.DeleteAccountFieldbyID(customerId);
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
