﻿using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager.Models {
    public class Student : Person {
        public int Grade { get; set; }

        public List<Evaluation> GetEvaluations() {
            return EvaluationRepository.GetEvaluations(this);
        }

        public int CalculateTotalPoints() {
            int totalPoints = 0;
            foreach (var evaluation in GetEvaluations()) {
                totalPoints += evaluation.Points;
            }
            return totalPoints;
        }

        private bool IsEvaluationComplete() {
            var evaluations = GetEvaluations();
            var activities = ActivitiesRepository.GetActivities();

            return evaluations.Count == activities.Count;
        }

        public bool HasSignature() {
            bool hasSignature = true;
            if (IsEvaluationComplete() == true) {
                foreach (var evaluation in GetEvaluations()) {
                    if (evaluation.IsSufficientForSignature() == false) {
                        hasSignature = false;
                        break;
                    }
                }
            } else {
                hasSignature = false;
            }
            return hasSignature;
        }

        public bool HasGrade() {
            bool hasGrade = true;
            if (IsEvaluationComplete() == true) {
                foreach (var evaluation in GetEvaluations()) {
                    if (evaluation.IsSufficientForGrade() == false) {
                        hasGrade = false;
                        break;
                    }
                }
            } else {
                hasGrade = false;
            }
            return hasGrade;
        }

        public int CalculateGrade() {
            int grade = 0;
            if (HasGrade() == true) {

                int totalPoints = CalculateTotalPoints();

                if (totalPoints >= 91) {
                    grade = 5;
                }
                if (totalPoints >= 81) {
                    grade = 4;
                }
                if (totalPoints >= 71) {
                    grade = 3;
                }
                if (totalPoints >= 61) {
                    grade = 2;
                } else { grade = 1; }
            }
        }
    }
}
