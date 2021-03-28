using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Web.Mvc;
using Networking312190796_318855038.DalFolder;
using Networking312190796_318855038.Models;

namespace Networking312190796_318855038.Controllers
{
    public class TicketsController : Controller
    {
        public static List<Tickets> ticketxss=new List<Tickets>();
        public static Tickets tmp=new Tickets();
        // GET: Admin
        public ActionResult BuyTicket(string name,string dates,string hours,string HallNums)
        {
            tmp.Name = name;
            tmp.date = dates;
            tmp.hour = hours;
            tmp.HallNum = HallNums;
            Session["name"] = name;
            Session["Date"] = dates;
            Session["Hour"] = hours;
            Session["Hallnum"] = HallNums;
            return View("BuyTicket");
        }
        public ActionResult Submit()
        {
            Tickets.number++;
            tmp.ticketnum = Tickets.number.ToString();
            tmp.row = Request.Form["Row"].ToString();
            tmp.seat = Request.Form["Seat"].ToString();
            if (ModelState.IsValid)
            {
                try
                {
                    Dal dal = new Dal();
                    dal.tickets.Add(tmp);
                    dal.SaveChanges();
                    Session["Result"] = "Your Purchase Completed!";
                }
                catch (DbUpdateException e)
                         when (e.InnerException?.InnerException is SqlException sqlEx &&
                            (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {
                Session["Result"] = "There Was An Error Ticket Purchase Not Completed!...";
            }
        }
            return View("BuyTicket");
        }
        public ActionResult addToCart(string name, string dates, string hours, string HallNums)
        {
            Tickets.number++;
            tmp.ticketnum = Tickets.number.ToString();
            tmp.row = Request.Form["Row"].ToString();
            tmp.seat = Request.Form["Seat"].ToString();
            Tickets tmp1 = new Tickets();
            tmp1.Name = tmp.Name;
            tmp1.date = tmp.date;
            tmp1.hour = tmp.hour;
            tmp1.HallNum = tmp.HallNum;
            tmp1.ticketnum = tmp.ticketnum;
            tmp1.row = tmp.row;
            tmp1.seat = tmp.seat;
            if (Session["login"] != null)
            {
                ticketxss.Add(tmp1);
                Session["status"] = "Ticket add to your Cart";
                return View("../Users/HomePage");
            }
            else
            {
                Session["status"] = "You need to login before insert ticket to the shoping cart";
            }
            return View("BuyTicket");
        }
        public ActionResult Remove(string name, string dates, string hours, string HallNums)
        {
            for(int i=0;i<ticketxss.Count;i++)
            {
                if(ticketxss[i].Name.Equals(name)&&ticketxss[i].date.Equals(dates)&&ticketxss[i].hour.Equals(hours)&&ticketxss[i].HallNum.Equals(HallNums))
                {
                    ticketxss.Remove(ticketxss[i]);
                }
            }
            return View("../Users/ShopingCart");
        }
    }
}
