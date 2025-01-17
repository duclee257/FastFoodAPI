﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FastFoodAPI.Models;

namespace FastFoodAPI.Controllers.api
{
    public class BannersController : ApiController
    {
        private FastFoodAppEntities1 db = new FastFoodAppEntities1();

        // GET: api/Banners
        public IQueryable<Banner> GetBanner()
        {
            return db.Banner;
        }

        // GET: api/Banners/5
        [ResponseType(typeof(Banner))]
        public IHttpActionResult GetBanner(int id)
        { 
            Banner banner = db.Banner.Find(id);
            if (banner == null)
            {
                return NotFound();
            }

            return Ok(banner);
        }

        // PUT: api/Banners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBanner(int id, Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != banner.IDbanner)
            {
                return BadRequest();
            }

            db.Entry(banner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Banners
        [ResponseType(typeof(Banner))]
        public IHttpActionResult PostBanner(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Banner.Add(banner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = banner.IDbanner }, banner);
        }

        // DELETE: api/Banners/5
        [ResponseType(typeof(Banner))]
        public IHttpActionResult DeleteBanner(int id)
        {
            Banner banner = db.Banner.Find(id);
            if (banner == null)
            {
                return NotFound();
            }

            db.Banner.Remove(banner);
            db.SaveChanges();

            return Ok(banner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BannerExists(int id)
        {
            return db.Banner.Count(e => e.IDbanner == id) > 0;
        }
    }
}