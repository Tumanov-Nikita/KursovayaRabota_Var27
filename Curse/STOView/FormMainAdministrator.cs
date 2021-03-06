﻿using STOService.BindingModels;
using STOService.Interfaces;
using STOService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace STOView
{
    public partial class FormMainAdministrator : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClientService serviceC;
        private readonly IMainService service;
        private readonly IResourceService serviceR;

        public int Id { set { id = value; } }
        private int delId = 1;
        private int? id;
        private int idC=1;

        public FormMainAdministrator(IMainService service, IResourceService serviceR, IClientService serviceC)
        {
            InitializeComponent();
            this.service = service;
            this.serviceR = serviceR;
            this.serviceC = serviceC;
        }
        private void FormMainAdministrator_Load(object sender, EventArgs e)
        {
            LoadDataOrders();
            LoadDataResources();
        }

        private void LoadDataOrders()
        {
            try
            {
                List<OrderViewModel> list = service.getMagic();
                if (list != null)
                {
                    dataGridViewOrders.DataSource = list;
                    dataGridViewOrders.Columns[1].Visible = false;
                    dataGridViewOrders.Columns[3].Visible = false;
                    dataGridViewOrders.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataResources()
        {
            try
            {
                List<ResourceViewModel> list = serviceR.GetList();
                if (list != null)
                {
                    dataGridViewResources.DataSource = list;
                    dataGridViewResources.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.FinishOrder(id);
                    LoadDataOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRenew_Click(object sender, EventArgs e)
        {
            LoadDataOrders();
            LoadDataResources();
        }

        private void ресурсыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormResources>();
            form.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServices>();
            form.ShowDialog();
        }

        private void сформироватьЗаявкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMakeDelivery>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDataResources();
            }
        }

        private void заявкиНаРесурсыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDeliverysLoad>();
            form.ShowDialog();
        }

        private void отчетПоЗаказамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClientOrders>();
            form.ShowDialog();
        }

        private void отчетПоЗаявкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAdminDeliverys>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }
    }
}
