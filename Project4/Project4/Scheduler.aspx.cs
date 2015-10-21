using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Project4
{
    public partial class Scheduler : System.Web.UI.Page
    {
        Stack<Course> courses;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["addedCount"] = 0;
                PopulateCourses();
                testConflict();
            }
        }

        protected void PopulateCourses()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Courses"].ConnectionString);
            string qry = "select distinct CourseNumber from schedule";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "CourseNumber");
            lbCourses.DataSource = ds.Tables["CourseNumber"];
            lbCourses.DataTextField = "coursenumber";
            lbCourses.DataValueField = "coursenumber";
            lbCourses.DataBind();
            conn.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {   
            string courseNum = lbCourses.SelectedValue;
            int count = Convert.ToInt16(Session["addedCount"]);

            if (lbCourses.SelectedIndex >= 0)
            {
                if (count < 4)
                {
                    lblInfo.Text = "";
                    lbCourses.Items.RemoveAt(lbCourses.SelectedIndex);
                    lbAdded.Items.Add(courseNum);
                    count++;
                }
                else
                {
                    lblInfo.Text = "Cannot have more than 4 courses";
                }
            }
            else
            {
                lblInfo.Text = "Please select a course to add.";
            }
            Session["addedCount"] = count;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            string courseNum = lbAdded.SelectedValue;
            int count = Convert.ToInt16(Session["addedCount"]);

            if (lbAdded.SelectedIndex >= 0)
            {
                lblInfo.Text = "";
                lbAdded.Items.RemoveAt(lbAdded.SelectedIndex);
                lbCourses.Items.Add(courseNum);
                count--;
            }
            else
            {
                lblInfo.Text = "Please select a course to remove.";
            }
            Session["addedCount"] = count;
        }

        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt16(Session["addedCount"]);
            if (count == 4)
            {
                CreateCourseStack();
                Stack<Class> schedule = new Stack<Class>();
                schedule = AddCourse(schedule);
                displaySchedule(schedule);
            }
            else
            {
                lblInfo.Text = "You must have 4 classes selected";
            }
        }

        protected void CreateCourseStack()
        {
            courses = new Stack<Course>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Courses"].ConnectionString);
            while(lbAdded.Items.Count > 0){
                Course currentCourse = new Course();
                string item = lbAdded.Items[0].ToString();
                string qry = "select * from Schedule where CourseNumber=@number";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@number", item);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class currentClass = new Class();
                    currentClass.CRN = reader["CRN"].ToString();
                    currentClass.courseNumber = reader["CourseNumber"].ToString();
                    currentClass.sectionNumber = reader["SectionNumber"].ToString();
                    currentClass.startTime = Convert.ToInt16(reader["StartTime"]);
                    currentClass.endTime = Convert.ToInt16(reader["EndTime"]);
                    string days = reader["Days"].ToString();
                    for (int i = 0; i < days.Length; i++)
                    {
                        currentClass.days.Add(days.Substring(i,1));
                    }
                    currentCourse.Classes.Push(currentClass);
                }
                courses.Push(currentCourse);
                lbAdded.Items.RemoveAt(0);
                conn.Close();
            }
        }

        protected Stack<Class> AddCourse(Stack<Class> schedule)
        {
            Course currentCourse;
            Stack<Class> classes;

            if (courses.Count > 0)
            {
                currentCourse = courses.Pop();
                classes = currentCourse.Classes;
            }
            else return schedule;

            while (classes.Count > 0 && schedule.Count < 4)
            {
                schedule.Push(classes.Pop());
                if (noConflict(schedule))
                {
                    schedule = AddCourse(schedule);
                }
                else schedule.Pop();
            }

            if (schedule.Count < 4 && schedule.Count > 0)
            {
                schedule.Pop();
                courses.Push(currentCourse);
            }
            return schedule;
        }

        protected Boolean noConflict(Stack<Class> schedule)
        {
            Queue<Class> currentSchedule = new Queue<Class>(schedule);
            Class newItem = currentSchedule.Dequeue();
            while (currentSchedule.Count > 0)
            {
                Class oldItem = currentSchedule.Dequeue();
                if(newItem.days.Contains("M") && oldItem.days.Contains("M") ||
                   newItem.days.Contains("T") && oldItem.days.Contains("T") ||
                   newItem.days.Contains("W") && oldItem.days.Contains("W") ||
                   newItem.days.Contains("R") && oldItem.days.Contains("R") ||
                   newItem.days.Contains("F") && oldItem.days.Contains("F"))
                {
                    if (newItem.startTime >= oldItem.startTime && newItem.startTime <= oldItem.endTime)
                    {
                        return false;
                    }
                    else if (newItem.endTime >= oldItem.startTime && newItem.endTime <= oldItem.endTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected void displaySchedule(Stack<Class> schedule)
        {
            if (schedule.Count > 0)
            {
                DataTable dt = new DataTable("Schedule");
                dt.Columns.Add("Course Number", typeof(string));
                dt.Columns.Add("Section");
                dt.Columns.Add("Days");
                dt.Columns.Add("Start Time");
                dt.Columns.Add("End Time");
                while (schedule.Count > 0)
                {
                    string days = "";
                    Class newClass = schedule.Pop();
                    DataRow dr = dt.NewRow();
                    dr[0] = newClass.courseNumber;
                    dr[1] = newClass.sectionNumber;
                    foreach (String day in newClass.days)
                    {
                        days = days + day;
                    }
                    dr[2] = days;
                    dr[3] = newClass.startTime;
                    dr[4] = newClass.endTime;
                    dt.Rows.Add(dr);
                }
                gvSchedule.DataSource = dt;
                gvSchedule.DataBind();
            }
            else lblInfo.Text = "Unable to make schedule with those classes";
        }

        protected void testConflict()
        {
            Stack<Class> schedule = new Stack<Class>();
            Class firstClass = new Class();
            Class secondClass = new Class();
            Class thirdClass = new Class();

            firstClass.startTime = 1000;
            firstClass.endTime = 1050;
            firstClass.days.Add("M");
            firstClass.days.Add("W");
            firstClass.days.Add("F");

            secondClass.startTime = 1000;
            secondClass.endTime = 1050;
            secondClass.days.Add("T");
            secondClass.days.Add("R");

            thirdClass.startTime = 1000;
            thirdClass.endTime = 1050;
            thirdClass.days.Add("M");
            thirdClass.days.Add("W");
            thirdClass.days.Add("F");

            schedule.Push(firstClass);
            schedule.Push(secondClass);
            schedule.Push(thirdClass);

            if (noConflict(schedule))
            {
                Response.Write("hello");
            }
        }
    }
}