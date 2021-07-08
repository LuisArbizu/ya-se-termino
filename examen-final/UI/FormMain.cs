﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppUCA.Context;
using AppUCA.Entities;
using AppUCA.Repository;
using AppUCA.Repository.Services;
using AppUCA.ViewModels;
using Microsoft.VisualBasic.ApplicationServices;

namespace AppUCA.UI
{
    public partial class FormMain : Form
    {
        private InscriptionServices inscriptions;
        private CourseServices courses;
        
        public FormMain()
        {
            InitializeComponent();

            inscriptions = new InscriptionServices();
            courses = new CourseServices();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
            // insertando los datos de las inscripciones en el data grid view
            dgvInscriptionShow.DataSource = null;
            var newDs = inscriptions.GetAll();
            var mappedDS1 = new List<InscriptionVm>();
            newDs.ForEach(i => mappedDS1.Add(PFMapper.MapInscriptionToInscriptionVm(i)));
            dgvInscriptionShow.DataSource = mappedDS1;
            //insertando los datos de los cursos en el data grid view
            dgvCourseShow.DataSource = null;
            var newDsc = courses.GetAll();
            var mappedDS2 = new List<CourseVm>();
            newDsc.ForEach(c => mappedDS2.Add(PFMapper.MapCourseToCourseVm(c)));
            dgvCourseShow.DataSource = mappedDS2;
            
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            //Agregando datos sobre el curso a la base de datos.
            bool confirm =
                txtCourseTitleAdd.Text.Length < 50 &&
                txtCourseTopicAdd.Text.Length < 50 &&
                txtCourseAuthorAdd.Text.Length < 50 &&
                txtCourseDurationAdd.Text.Length < 50 &&
                txtCourseModuleAdd.Text.Length < 50 &&
                txtCourseScheduleAdd.Text.Length < 50;
                

            if (confirm) {
                
                var db = new AppGuiContext();
                
                Course nuevo = new Course( txtCourseTitleAdd.Text, Convert.ToInt32(txtCourseModuleAdd.Text), 
                txtCourseTopicAdd.Text, txtCourseAuthorAdd.Text,txtCourseDurationAdd.Text, txtCourseScheduleAdd.Text );
                
                db.Add(nuevo);
                db.SaveChanges();
                
                MessageBox.Show(text: "Curso agregado exitosamente!", caption: "Inscripcion de Cursos UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);   
                
            }
            else
                MessageBox.Show(text: "Datos no validos!", caption: "Inscripcion de Cursos UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInscriptionAdd_Click(object sender, EventArgs e)
        {
            //Agregando datos sobre inscripciones a la base de datos.
            bool confirm =
                txtInscriptionName.Text.Length < 50 &&
                txtInscriptionMail.Text.Length < 50 &&
                txtInscriptionPhone.Text.Length < 13;
                
            
            if (confirm) {
                var db = new AppGuiContext();
                
                Inscription nuevo = new Inscription( txtInscriptionName.Text, txtInscriptionMail.Text, 
                txtInscriptionPhone.Text);
                
                db.Add(nuevo);
                db.SaveChanges();
                
                MessageBox.Show(text: "Usuario creado exitosamente!", caption: "Inscripcion de Cursos UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);   
                
            }
            else
                MessageBox.Show(text: "Datos no validos!", caption: "Inscripcion de Cursos UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
