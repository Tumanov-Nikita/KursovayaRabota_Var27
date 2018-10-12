using STOService.BindingModel;
using STOService.BindingModels;
using STOService.Interfaces;
using STOService.ViewModels;
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
    public partial class FormClients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IClientService client;
        private readonly IReportService service;
        private readonly IDeliveryService serviceS;
        private int? id;

        private List<ClientViewModel> serviceClients;

        public FormClients(IClientService client, IReportService service, IDeliveryService serviceS)
        {
            InitializeComponent();
            this.client = client;
            this.service = service;
            this.serviceS = serviceS;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Заблокировать пользователя?", "Потверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex).blocked = true;
                        var form = serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);

                        ClientBindingModel element = new ClientBindingModel
                        {
                            id = form.id,
                            clientFirstName = form.clientFirstName,
                            clientSecondName = form.clientSecondName,
                            number = form.number,
                            mail = form.mail,
                            password = form.password,
                            blocked = form.blocked
                        };

                        client.UpdElement(element);
                        MessageBox.Show("Пользователь заблокирован", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ClientViewModel view = client.GetElement(id.Value);
                    if (view != null)
                    {
                        LoadData();
                    }



                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                serviceClients = client.GetList();
                if (serviceClients != null)
                {
                    dataGridView.DataSource = serviceClients;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex).blocked = false;
                    var form = serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);

                    ClientBindingModel element = new ClientBindingModel
                    {
                        id = form.id,
                        clientFirstName = form.clientFirstName,
                        clientSecondName = form.clientSecondName,
                        number = form.number,
                        mail = form.mail,
                        password = form.password,
                        blocked = form.blocked,
                        sanction = form.sanction
                    };

                    client.UpdElement(element);
                    MessageBox.Show("Пользователь разблокирован", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Начислить пользователю " + textBox1.Text + " бонусов?", "Потверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex).sanction += Convert.ToInt32(textBox1.Text);
                        var form = serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);

                        ClientBindingModel element = new ClientBindingModel
                        {
                            id = form.id,
                            clientFirstName = form.clientFirstName,
                            clientSecondName = form.clientSecondName,
                            number = form.number,
                            mail = form.mail,
                            password = form.password,
                            blocked = form.blocked,
                            sanction = form.sanction
                        };

                        client.UpdElement(element);
                        MessageBox.Show("Пользователю начислены бонусы", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Начислить пользователю " + textBox2.Text + " штрафных баллов?", "Потверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex).sanction -= Convert.ToInt32(textBox2.Text);
                        var form = serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);

                        ClientBindingModel element = new ClientBindingModel
                        {
                            id = form.id,
                            clientFirstName = form.clientFirstName,
                            clientSecondName = form.clientSecondName,
                            number = form.number,
                            mail = form.mail,
                            password = form.password,
                            blocked = form.blocked,
                            sanction = form.sanction
                        };

                        client.UpdElement(element);
                        MessageBox.Show("Пользователю начислен штраф", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    service.SaveDeliverysLoad(new ReportBindingModel
                    {
                        FileName = "D:\\deliverys.xls"
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string mail = serviceClients.ElementAt(dataGridView.SelectedRows[0].Cells[0].RowIndex).mail;
                if (!string.IsNullOrEmpty(mail))
                {
                    if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                    {
                        MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    serviceS.SendEmail(mail, "Оповещение по заказам",
                    string.Format("Отчет по доставкам"));
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
