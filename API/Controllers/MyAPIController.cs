using API.Models;
using API.MYDATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MyAPIController : ApiController
    {
        
      //  [Route("mode")]
        public List<EmployeeModel>GETAmirAPI()
        {
            List<EmployeeModel> Model = new List<EmployeeModel>();
            EmpDataEntities entities = new EmpDataEntities();
            var res = entities.table_employee.ToList();
            foreach (var item in res)
            {
                Model.Add(new EmployeeModel

                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    City = item.City



                }); 

            }

            return Model;
        }
       // [HttpPost]
        public object PostData(EmployeeModel model)
        {

            EmpDataEntities entities = new EmpDataEntities();
            table_employee table = new table_employee();
            table.Id = model.Id;
            table.Name = model.Name;
            table.Email = model.Email;
            table.City = model.City;
           
             if (model.Id == 0 )
             {

                entities.table_employee.Add(table);
                entities.SaveChanges();
             }
             else
             {
                entities.Entry(table).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();


             }
            return table;

        }
        public void delete (int id)
        {

            EmpDataEntities entities = new EmpDataEntities();
            var del = entities.table_employee.Where(m => m.Id == id).First();
            entities.table_employee.Remove(del);
            entities.SaveChanges();


        }



    }
}