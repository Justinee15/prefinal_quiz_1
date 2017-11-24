using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using PREFINAL_QUIZ1.Models;
using PREFINAL_QUIZ1.App_Code;

namespace PREFINAL_QUIZ1.Controllers
{
    public class TitlesController : Controller
    {
        //
        // GET: /Titles/
        public ActionResult Index()
        {
            List<TitlesModel> list = new List<TitlesModel>();

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT t.titleID, p.pubName, a.authorFN, a.authorLN, 
                                t.titleName, t.titlePrice, t.titlePubDate,                                
                                t.titleNotes FROM titles t
                                INNER JOIN publishers p ON t.pubID = p.pubID
                                INNER JOIN authors a ON t.authorID = a.authorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(data);
                        foreach (DataRow dr in dt.Rows)
                        {
                            var title = new TitlesModel();
                            title.titleID = Convert.ToInt32(dr["titleID"].ToString());
                            title.pubName = dr["pubName"].ToString();
                            title.authorFN = dr["authorFN"].ToString();
                            title.authorLN = dr["authorLN"].ToString();
                            title.titleName = dr["titleName"].ToString();
                            title.titlePrice = dr["titlePrice"].ToString();
                            title.titlePubDate = DateTime.Parse(dr["titlePubDate"].ToString());
                            title.titleNotes = dr["titleNotes"].ToString();
                            list.Add(title);

                        }

                    }
                }
            }

            return View(list);
        }

        public List<SelectListItem> GetpublisherNames()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT pubID, pubName FROM publishers
                                ORDER BY pubName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = data["pubName"].ToString(),
                                Value = data["pubID"].ToString()
                            });
                        }
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> GetauthorNames()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT authorID, authorLN FROM authors
                                ORDER BY authorLN";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = data["authorLN"].ToString(),
                                Value = data["authorID"].ToString()
                            });
                        }
                    }
                }
            }
            return items;
        }

        public ActionResult Add()
        {
            TitlesModel title = new TitlesModel();
            title.publisherNames = GetpublisherNames();
            title.authorNames = GetauthorNames();
            return View(title);
        }

        [HttpPost]
        public ActionResult Add(TitlesModel title)
        {
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"INSERT INTO titles VALUES(@pubID, @authorID, @titleName, @titlePrice, @titlePubDate,
                @titleNotes)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@pubID", title.pubID);
                    cmd.Parameters.AddWithValue("@authorID", title.authorID);
                    cmd.Parameters.AddWithValue("@titleName", title.titleName);
                    cmd.Parameters.AddWithValue("@titlePrice", title.titlePrice);
                    cmd.Parameters.AddWithValue("@titlePubDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@titleNotes", title.titleNotes);

                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");


                }
            }

        }


        //
        // GET: /Titles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Titles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Titles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Titles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Titles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Titles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Titles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
