using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetMvc5_V1.Models;

namespace AspNetMvc5_V1.Controllers
{
    public class EmployeesController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Name2,EnrollmentDate,LeavingDate,EmployeeTag1,EmployeeTag2,AgentId,IsAgent,Rank,EmployeeType1,EmployeeType2,EmployeeType3,Language,Address1,Address2,Email,Mobile,Productivity,Password,LaborRuleId,OrganizationId,CertificationId,OnDutyDate,HomePhone1,HomePhone2,IsCanWorked,SwapGroupId,OffDuteGroupId,TimeOffGroupId,BiddingGroupId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeId = Guid.NewGuid();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Name2,EnrollmentDate,LeavingDate,EmployeeTag1,EmployeeTag2,AgentId,IsAgent,Rank,EmployeeType1,EmployeeType2,EmployeeType3,Language,Address1,Address2,Email,Mobile,Productivity,Password,LaborRuleId,OrganizationId,CertificationId,OnDutyDate,HomePhone1,HomePhone2,IsCanWorked,SwapGroupId,OffDuteGroupId,TimeOffGroupId,BiddingGroupId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        // GET: Employees/Edit/5
        public ActionResult OrgAnnounce()
        {
            return View(db.Announcement_Org.Take(3).ToList());
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





        


    }
}
