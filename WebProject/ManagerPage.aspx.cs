//Класс веб-формы
//Основная страница
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class ManagerPage : System.Web.UI.Page
    {
        private Employee currEmployee;
        private List<Tour> tourList;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CheckUser();
                DbUtils.InitConnection(SecurityUtils.GetDbStrConnection());
                currEmployee = DbUtils.GetEmloyee(SecurityUtils.currUserID);
                emplLabel.Text = $"Пользователь: {currEmployee.Surname}  {currEmployee.Name}  {currEmployee.PatrName} \nДолжность: {currEmployee.Position}";
                tourList = new List<Tour>();
                tourList = DbUtils.GetTourList();
                butOrderAdd.Enabled = false;
                butTouristAdd.Enabled = false;
                listBoxTours.Items.Clear();
                GenerateListTours();
            }
            catch
            {
                Response.Redirect("StartPage.aspx");
            }
        }
        protected void CheckUser()
        {
            if (SecurityUtils.CheckCurrID())
                return;
            throw new Exception("ВНИМАНИЕ! Срочное завершение работы!");
        }
        protected void GenerateListTours()
        {
            for (int i = 0; i < tourList.Count; i++)
                listBoxTours.Items.Add($"{tourList[i].ID}\t{tourList[i].Name}\t{tourList[i].Count}\tс {tourList[i].dateStart.ToShortDateString()} по {tourList[i].dateFinish.ToShortDateString()} Сайт: {tourList[i].LinkSite} Цена за 1 чел.: {tourList[i].Price}");
        }
        protected void butClientAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = ModelUtils.InitClient(tbClientF.Text, tbClientI.Text, tbClientO.Text, DateTime.Parse(tbClientBirt.Text), tbClientPh.Text, tbClientEm.Text, tbClientPass.Text);
                DbUtils.AddClientInDB(client);
                labelClientMessage.Text = $"Клиент {tbClientF.Text} {tbClientI.Text} зарегистрирован! Ему присвоен номер: {client.ID}";
                tbNumClient.Text = client.ID.ToString();
                butClientCheck_Click(sender, e);
            }
            catch(Exception ex)
            {
                labelClientMessage.Text += "Не удается зарегистрировать клиента! Проверьте правильность введенных данных\n";
                labelClientMessage.Text += ex.Message;
            }
        }


        protected void butTourCheck_Click(object sender, EventArgs e)
        {
            try
            {
                ModelBufer.Tour = ModelUtils.SearchInTourList(tourList, Int32.Parse(tbNumTour.Text));
                labelTourClientCheck.Text += $"Информация о туре: ID = {ModelBufer.Tour.ID} {ModelBufer.Tour.Name}\n";
                labelSelectTour.Text = $"{ModelBufer.Tour.ID} {ModelBufer.Tour.Name}";
                butTouristAdd.Enabled = true;
            }
            catch(Exception ex)
            {
                labelTourClientCheck.Text += $"Тур с номером: {tbNumTour.Text} не найден!\n";
                labelTourClientCheck.Text += ex.Message;
                tbNumTour.Text = "";
            }
        }
        protected void butClientCheck_Click(object sender, EventArgs e)
        {
            try
            {
                ModelBufer.Client = DbUtils.GetClient(Int32.Parse(tbNumClient.Text));
                labelTourClientCheck.Text += $"Клиент: {ModelBufer.Client.ID} {ModelBufer.Client.Surname} {ModelBufer.Client.Name} Дата рождения: {ModelBufer.Client.birthDate}\n";
                labelSelectClient.Text = $"{ModelBufer.Client.ID} {ModelBufer.Client.Surname} {ModelBufer.Client.Name}";
                butTouristAdd.Enabled = true;
            }
            catch(Exception ex)
            {
                labelTourClientCheck.Text += $"Клиент с номером {tbNumClient.Text} не найден!\n";
                labelTourClientCheck.Text += ex.Message;
                tbNumClient.Text = "";
            }
        }

        protected void butTouristAdd_Click(object sender, EventArgs e)
        {
            try
            { 
                Tourist tourist = ModelUtils.InitTourist(tbTouristF.Text, tbTouristI.Text, tbTouristO.Text, DateTime.Parse(tbTouristBirth.Text), tbTouristPass.Text, tbTouristInter.Text);
                DbUtils.AddTouristInDB(tourist);
                ModelBufer.TouristList.Add(tourist);
                labelTouristMessage.Text = $"Добавлен турист {tourist.Surname} {tourist.Name}. Ему присвоен номер: {tourist.ID}";
                listBoxTourist.Items.Add($"{tourist.ID} {tourist.Surname} {tourist.Name} {tourist.PatrName}");
                int price = 0;
                price += ModelBufer.Tour.Price;
                labelPrice.Text = $"{price} ";
                butOrderAdd.Enabled = true;
            }
            catch(Exception ex)
            {
                labelTouristMessage.Text += "Турист не добвавлен! Проверьте правильность введенных данных!\n";
                labelTouristMessage.Text += ex.Message;
            }
        }
        
        protected void butOrderAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = ModelUtils.InitOrder(ModelBufer.Client, ModelBufer.Tour, currEmployee, checkBoxVisa.Checked, DateTime.Now);
                DbUtils.AddTourOrderInDB(order);
                DbUtils.AddTouristOrderListInDB(ModelUtils.CreateTouristOrderList(ModelBufer.TouristList, order));
                labelOrderStatus.Text = $"Заказ успешно оформлен! Ему присвоен номер: {order.ID}";
            }

            catch(Exception ex)
            {
                labelOrderStatus.Text += "Заказ не сформировался! Проверьте правильность данных!\n";
                labelOrderStatus.Text += ex.Message;
            }
        }
    }
}