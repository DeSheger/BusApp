using System;
using System.Collections.Generic;
using System.ComponentModel;
using MaterialSkin.Controls;
using BusApp1.Models;


namespace BusApp1
{
    public partial class Form1 : MaterialForm
    {
        public List<string> Destinations;
        public List<string> DepartureTime;
        public Ticket ticket;
        public List<Ticket> tickets;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            List<string> values = ValidateFields();
            if (values.Count > 0)
            {
                int num1 = (int)MaterialMessageBox.Show("Rozwiąż następujące błędy:\n\n" + string.Join(Environment.NewLine, values));
            }
            else
            {
                ticket.Name = textBoxName.Text;
                ticket.To = comboboBoxDestination.Text;
                ticket.DateOfJourney = dateTimePickerDateOfJourney.Value;
                ticket.DepartureTime = comboboxDeparture.Text;
                ticket.NumberOfPassengers = Convert.ToInt32(textBoxNoOfPassengers.Text);
                ticket.Type = !radioButtonSingle.Checked ? radioButtonReturn.Text : radioButtonSingle.Text;
                ticket.Class = !radioButtonFirstClass.Checked ? radioButtonEconomy.Text : radioButtonFirstClass.Text;
                textBoxTotalPrice.Text = string.Format("{0} PLN", CalculateTotal());
                ticket.AmountPaid = textBoxTotalPrice.Text;
                int num2 = (int)MaterialMessageBox.Show("Kliknij 'ZAPŁAĆ' by dokonać zakupu");
            }

        }
        private int CalculateTotal()
        {
            int total = (Ticket.Price + Destinations.FindIndex(c => c == ticket.To) * 2) * ticket.NumberOfPassengers;
            if (ticket.Class == "Premium")
                total *= 2;
            if (ticket.Type == "Normalny")
                total *= 2;
            return total;
        }
        private List<string> ValidateFields()
        {
            List<string> stringList = new List<string>();
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
                stringList.Add("Podaj imię");
            if (string.IsNullOrWhiteSpace(textBoxNoOfPassengers.Text))
            {
                stringList.Add("Podaj ilość pasażerów");
            }
            else
            {
                int result = 0;
                if (!int.TryParse(textBoxNoOfPassengers.Text, out result))
                    stringList.Add("Podaj dobrą liczbę pasażerów");
            }
            if (!radioButtonSingle.Checked && !radioButtonReturn.Checked)
                stringList.Add("Wybierz rodzaj biletu");
            if (!radioButtonFirstClass.Checked && !radioButtonEconomy.Checked)
                stringList.Add("Wybierz klase podróży");
            if (dateTimePickerDateOfJourney.Value < DateTime.Now)
                stringList.Add("Podaj dobrą datę");
            return stringList;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            ticket = new Ticket();

        }

        public void ClearFields()
        {
            textBoxName.Text = string.Empty;
            comboboBoxDestination.Text = Destinations[0];
            comboboxDeparture.Text = DepartureTime[0];
            radioButtonSingle.Checked = false;
            radioButtonEconomy.Checked = false;
            radioButtonReturn.Checked = false;
            radioButtonFirstClass.Checked = false;
            textBoxNoOfPassengers.Text = string.Empty;
            textBoxSubmittedName.Text = string.Empty;
            textBoxSubmittedFrom.Text = string.Empty;
            textBoxSubmittedTo.Text = string.Empty;
            textBoxSubmittedDOJ.Text = string.Empty;
            textBoxSubmittedDeparture.Text = string.Empty;
            textBoxSubmittedType.Text = string.Empty;
            textBoxSubmittedClass.Text = string.Empty;
            textBoxSubmittedNOP.Text = string.Empty;
            textBoxSubmittedAmountPaid.Text = string.Empty;
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
                return;
            textBoxSubmittedName.Text = ticket.Name;
            textBoxSubmittedFrom.Text = ticket.From;
            textBoxSubmittedTo.Text = ticket.To;
            textBoxSubmittedDOJ.Text = ticket.DateOfJourney.ToString("dddd, dd MMMM yyyy");
            textBoxSubmittedDeparture.Text = ticket.DepartureTime;
            textBoxSubmittedType.Text = ticket.Type;
            textBoxSubmittedClass.Text = ticket.Class;
            textBoxSubmittedNOP.Text = ticket.NumberOfPassengers.ToString();
            textBoxSubmittedAmountPaid.Text = textBoxTotalPrice.Text;
            tickets.Add(ticket);
            ticket = new Ticket();
            int num = (int)MaterialMessageBox.Show("Bilet został opłacony.\nMiłej podrózy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ticket = new Ticket();
            tickets = new List<Ticket>();
            Destinations = new List<string>()
            {
            "Katowice",
            "Mysłowice",
            "Rybnik",
            "Kraków"
            };
            DepartureTime = new List<string>()
            {
            "8:00",
            "10:00",
            "12:00",
            "15:00"
            };
            comboboBoxDestination.DataSource = new BindingList<string>(Destinations);
            comboboxDeparture.DataSource = new BindingList<string>(DepartureTime);

        }

        private void buttonTicketList_Click(object sender, EventArgs e)
        {
            if (this.tickets.Count > 0)
            {
                new TicketListForm(this.tickets).ShowDialog();
            }
            else
            {
                MaterialMessageBox.Show("Nie ma jeszcze biletów", true, FlexibleMaterialForm.ButtonsPosition.Right);
            }

        }
    }
}
