using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NutriManager.Services.Models;
using NutriManager.Interfaces.Business;
using NutriManager.Services.Helpers;
using NutriManager.Services.Util;

namespace NutriManager.Services.Controllers
{
    public class PacientController : ApiController
    {
        //private DataContext db = new DataContext();
        private IPacientBusiness _business = Root.GetPacientBusiness();

        //// GET api/Pacient
        //public IQueryable<PacientModel> GetPacientModels()
        public IHttpActionResult GetPacientModels()
        {
            return Json<PacientModel>(new PacientModel());
            //return db.PacientModels;
        }

        // GET api/Pacient/5
        //[ResponseType(typeof(PacientModel))]
        //public IHttpActionResult GetPacientModel(Guid id)
        //{
        //    PacientModel pacientmodel = db.PacientModels.Find(id);
        //    if (pacientmodel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(pacientmodel);
        //}

        // PUT api/Pacient/5
        public IHttpActionResult PutPacientModel(Guid id, PacientModel pacientmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != pacientmodel.Id)
                return BadRequest();

            try
            {
                Save(pacientmodel);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PacientModelExists(id))
                //    return NotFound();
                //else
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Pacient
        [ResponseType(typeof(PacientModel))]
        public IHttpActionResult PostPacientModel(PacientModel pacientmodel)
        {
            //HEAD
            //User-Agent: Fiddler
            //Host: localhost:1678
            //Content-Length: 194
            //Content-Type: application/json
            
            //BODY
            //{"Id":"00000000-0000-0000-0000-000000000000","Email":"dgenius@gmail.com","FirstName":"Douglas","LastName":"Costa","BornDate":"1985-08-26T00:00:00","Weight":"71.0","Height":"1.71","Version":null}
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //try
            //{
                Save(pacientmodel);
            //}
            //catch (DbUpdateException)
            //{
            //    //if (PacientModelExists(pacientmodel.Id))
            //    //    return Conflict();
            //    //else
            //        throw;
            //}

            return CreatedAtRoute("DefaultApi", new { id = pacientmodel.Id }, pacientmodel);
        }

        // DELETE api/Pacient/5
        //[ResponseType(typeof(PacientModel))]
        //public IHttpActionResult DeletePacientModel(Guid id)
        //{
        //    PacientModel pacientmodel = db.PacientModels.Find(id);
        //    if (pacientmodel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PacientModels.Remove(pacientmodel);
        //    db.SaveChanges();

        //    return Ok(pacientmodel);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PacientModelExists(Guid id)
        //{
        //    return db.PacientModels.Count(e => e.Id == id) > 0;
        //}

        private void Save(PacientModel pacientmodel)
        {
            Entities.Pacient pacient = MapperHelper.Map<PacientModel, Entities.Pacient>(pacientmodel);
            _business.Save(pacient);
        }
    }
}