using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager {
    public partial class FrmEvaulation : Form {
        public FrmEvaulation(Student selectStudent) {
            InitializeComponent();
            student = selectedStudent;
        }

        private void SetFormText() {
            Text = student.FirstName + " " + Student.LastName;
        }

        private void cboActivities_SelectedIndexChange(object sender, EventArgs e) {
            var currentActivity = cboActivities.SelectedItem as Activity;
            txtActivityDescription.Text = currentActivity.Description;
            txtMinForGrade.Text = currentActivity.MinPointsForGrade + "/" + currentActivity.MaxPoints;
            txtMinForSignature.Text = currentActivity.MinPointsForSignature + "/" + currentActivity.MaxPoints;

            numPoints.Minimum = 0;
            numPoints.MaximumSize = currentActivity.MaxPoints;
        }
    }
}
