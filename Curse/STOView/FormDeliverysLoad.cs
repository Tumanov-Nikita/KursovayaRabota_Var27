using STOService.BindingModel;
using STOService.ImplementationsBD;
using STOService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace STOView
{
    public partial class FormDeliverysLoad : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IReportService service;
        private readonly IDeliveryService serviceS ;
        public FormDeliverysLoad(IReportService service, IDeliveryService ServiceS)
        {
            InitializeComponent();
            this.service = service;
            this.serviceS = ServiceS;
        }

        private void FormDeliverysLoad_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = service.GetDeliverysLoad();
                if (dict != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        foreach (var listElem in elem.Resources)
                        {
                            dataGridView1.Rows.Add(new object[] { elem.deliveryName, listElem.Item1, listElem.Item2 });
                        }                  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    service.SaveDeliverysLoad(new ReportBindingModel
                    {
                        FileName = sfd.FileName
                        
                    });
                    /*
                    service.SaveDeliverysLoad(new ReportBindingModel
                    {
                        FileName = "D://deliverys.xls"

                    });*/
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


       
    }
}
