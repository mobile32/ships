using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ships.Models;

namespace Ships.Controllers
{
    public class HomeController : Controller
    {
        private ShipsContext db = new ShipsContext();

        // GET: Home
        public ActionResult Index()
        {
            var session = new Session();

            session.PlayerA.Board = CommonCode.RandomBoard();
            session.PlayerB.Board = CommonCode.RandomBoard();

            db.Sessions.Add(session);
            db.SaveChanges();

            ViewBag.LastPlayer = session.PlayerA.Id;
            return View(session);
        }

        [HttpPost]
        public ActionResult Index(string xPosition, string yPosition, Guid lastSession, Guid lastPlayer)
        {     
            var session = db.Sessions.Single(s => s.Id == lastSession);

            if (session.PlayerA.Id == lastPlayer)
            {
                switch (session.PlayerB.Board[Convert.ToInt32(xPosition), Convert.ToInt32(yPosition)])
                {
                    case 1:
                        session.PlayerB.Board[Convert.ToInt32(xPosition), Convert.ToInt32(yPosition)] = 2;
                        break;
                    case 0:
                        session.PlayerB.Board[Convert.ToInt32(xPosition), Convert.ToInt32(yPosition)] = 3;
                        break;
                }

                ViewBag.LastPlayer = session.PlayerB.Id;
            }
            else
            {
                switch (session.PlayerA.Board[Convert.ToInt32(xPosition), Convert.ToInt32(yPosition)])
                {
                    case 1:
                        session.PlayerA.Board[Convert.ToInt32(xPosition), Convert.ToInt32(yPosition)] = 2;
                        break;
                    case 0:
                        session.PlayerA.Board[Convert.ToInt32(xPosition), Convert.ToInt32(yPosition)] = 3;
                        break;
                }
                ViewBag.LastPlayer = session.PlayerA.Id;
            }

            db.Sessions.Single(s => s.Id == lastSession).PlayerA = session.PlayerA;
            db.Sessions.Single(s => s.Id == lastSession).PlayerB = session.PlayerB;

            db.SaveChanges();

            return View(session);
        }
    }
}