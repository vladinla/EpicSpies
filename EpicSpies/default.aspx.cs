using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpicSpies
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Now.Date;
            if (!Page.IsPostBack)
            {
                Calendar2.SelectedDate = DateTime.Now.Date.AddDays(14);
                Calendar3.SelectedDate = DateTime.Now.Date.AddDays(21);
            }
        }

        protected void resultButton_Click(object sender, EventArgs e)
        {
            string spyName = spyNameTextBox.Text;
            string spyAssignment = spyAssignmentTextBox.Text;

            if ((Calendar1.SelectedDate.DayOfYear + 14) > Calendar2.SelectedDate.DayOfYear)
            {
                resultLabel.Text = "Must allow at least 2 weeks between the previous assigment and new assignment!".ToUpper();
                Calendar2.SelectedDate = DateTime.Now.Date.AddDays(14);
            }
            else if ((Calendar3.SelectedDate.DayOfYear - Calendar2.SelectedDate.DayOfYear) > 21)
            {
                double budget =
                    ((Calendar3.SelectedDate.DayOfYear - Calendar2.SelectedDate.DayOfYear)*500 + 1000);
                resultLabel.Text = String.Format("Assignment of {0} to assignment {1} is authorized. " +
                                                 "Budget total: {2:C}", spyName, spyAssignment, budget);
            }
            else
            {
                double budget =
                    ((Calendar3.SelectedDate.DayOfYear - Calendar2.SelectedDate.DayOfYear) * 500);
                resultLabel.Text = String.Format("Assignment of {0} to assignment '{1}' is authorized. " +
                                                 "Budget total: {2:C}", spyName, spyAssignment, budget);
            }
        }
    }
}