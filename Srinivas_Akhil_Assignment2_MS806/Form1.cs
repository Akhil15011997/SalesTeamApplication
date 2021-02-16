using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Srinivas_Akhil_Assignment2_MS806
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Date_Picker.Value = DateTime.Now.AddDays(1);
            //ToolTips for Necessary Buttons
            toolTip.SetToolTip(Display_Button, "Press to display the details of the Booking");
            toolTip.SetToolTip(ClearButton, "Press to Clear form for the next user");
            toolTip.SetToolTip(ExitButton, "Press to Exit the Application");
            toolTip.SetToolTip(BookButton, "Press to Book");
            toolTip.SetToolTip(No_Thanks_Hotel__Radio_Button, "Press to cancel the hotel booking");
            
        }
        //Limiting DatePicker Value
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            Date_Picker.MinDate = DateTime.Now.AddDays(1);
            Date_Picker.MaxDate = DateTime.Now.AddDays(90);
        }
        //Declaring Global Variables 
        decimal DestinationRate, hotelvaluerate, TotalAddOnCost, TotalTripCost;
        string hotelSelected;
        //Declaring Constant Variables
        const decimal cliffsofMoher = 55m, kylemore = 50m, belmullet = 99m, bunratty = 75m, burren = 45m, connemara = 75m;
        const decimal sevenAMdiscount = 0.20m, eightAMdiscount = 0.10m, nineAMdiscount = 0.05m, onePMdiscount = 0.25m, noDiscount = 0m;
        const decimal OverAlldiscount = 0.075m;
        const decimal foodrate = 11.50m;
        const decimal threestarhotelrate = 55m, fourstarhotelrate = 75m, fivestarhotelrate = 100m;
        private void Display_Button_Click(object sender, EventArgs e)
        {
            decimal TripDiscountPercentageBySelectedTime;
            //try block for GuestNumber
            try
            {
                int GuestNumber = int.Parse(Guest_Number_TextBox.Text);
                //Condition statement for GuestNumber greater than 0
                if (GuestNumber > 0)
                {
                //Condition statement for Destination List Box not Null
                    if (Destination_List_Box.SelectedIndex != -1)
                    {
                //Condition statement for Time List Box not Null
                        if (Time_ListBox.SelectedIndex != -1)
                        {
                            decimal NumberOfGuests = Convert.ToDecimal(GuestNumber);
                //switch statement for Destination Selection
                            switch (Destination_List_Box.SelectedIndex)
                            {
                                case 0:
                                    DestinationRate = cliffsofMoher;
                                    DestinationNameDisplayLabel.Text = "Cliffs of Moher";
                                    break;
                                case 1:
                                    DestinationRate = kylemore;
                                    DestinationNameDisplayLabel.Text = "Kylemore Abbey";
                                    break;
                                case 2:
                                    DestinationRate = belmullet;
                                    DestinationNameDisplayLabel.Text = "Belmullet";
                                    break;
                                case 3:
                                    DestinationRate = bunratty;
                                    DestinationNameDisplayLabel.Text = "Bunratty";
                                    break;
                                case 4:
                                    DestinationRate = burren;
                                    DestinationNameDisplayLabel.Text = "Burren";
                                    break;
                                case 5:
                                    DestinationRate = connemara;
                                    DestinationNameDisplayLabel.Text = "Connemara";
                                    break;
                                default:
                                    break;
                            }
            //switch statement for Time Selection
                            switch (Time_ListBox.SelectedIndex)
                            {
                                case 0:
                                    TripDiscountPercentageBySelectedTime = sevenAMdiscount;
                                    TotalTripCost = (NumberOfGuests * DestinationRate) - ((NumberOfGuests * DestinationRate) * TripDiscountPercentageBySelectedTime);
                                    break;
                                case 1:
                                    TripDiscountPercentageBySelectedTime = eightAMdiscount;
                                    TotalTripCost = (NumberOfGuests * DestinationRate) - ((NumberOfGuests * DestinationRate) * TripDiscountPercentageBySelectedTime);
                                    break;
                                case 2:
                                    TripDiscountPercentageBySelectedTime = nineAMdiscount;
                                    TotalTripCost = (NumberOfGuests * DestinationRate) - ((NumberOfGuests * DestinationRate) * TripDiscountPercentageBySelectedTime);
                                    break;
                                case 5:
                                    TripDiscountPercentageBySelectedTime = onePMdiscount;
                                    TotalTripCost = (NumberOfGuests * DestinationRate) - ((NumberOfGuests * DestinationRate) * TripDiscountPercentageBySelectedTime);
                                    break;
                                default:
                                    TripDiscountPercentageBySelectedTime = noDiscount;
                                    TotalTripCost = (NumberOfGuests * DestinationRate);
                                    break;
                            }
            //Display Time in Booking Section
                            string Time = Time_ListBox.GetItemText(Time_ListBox.SelectedItem);
                            TimeDisplayLabel.Text = Time.Remove('\t');
            //Condition Statement for Hotels
                            if (Three_Star_Radio_Button.Checked)
                            {
                                hotelvaluerate = threestarhotelrate;
                                hotelSelected = "3-Star Hotel";
                                No_Thanks_Hotel__Radio_Button.Visible = true;
                            }
                            else if (Four_Star_Radio_Button.Checked)
                            {
                                hotelvaluerate = fourstarhotelrate;
                                hotelSelected = "4-Star Hotel";
                                No_Thanks_Hotel__Radio_Button.Visible = true;
                            }
                            else if (Five_Star_Hotel_Radio_Button.Checked)
                            {
                                hotelvaluerate = fivestarhotelrate;
                                hotelSelected = "5-Star Hotel";
                                No_Thanks_Hotel__Radio_Button.Visible = true;
                            }
                            else
                            {
                                hotelvaluerate = 0;
                                hotelSelected = "None";
                                No_Thanks_Hotel__Radio_Button.Visible = false;
                            }
            //Display Hotel in Booking Section
                            HotelDisplayLabel.Text = hotelSelected;
            //Condition statement for Food Option
                            if (Food_CheckBox.Checked)
                            {
                                TotalAddOnCost = (NumberOfGuests * hotelvaluerate) + (NumberOfGuests * foodrate);
                                LunchDisplayCheckBox.Enabled = false;
                                LunchDisplayCheckBox.Checked = true;
                            }
                            else
                            {
                                LunchDisplayCheckBox.Enabled = false;
                                TotalAddOnCost = (NumberOfGuests * hotelvaluerate);
                            }
            //Display items in booking section
                            TotalTripCostRateLabel.Text = (TotalTripCost).ToString("C2");
                            TotalAddOnCostsLabel.Text = (TotalAddOnCost).ToString("C2");
                            NoOfGuestsDisplayLabel.Text = NumberOfGuests.ToString("N0");
            //Condition statement for Overall Discount
                            if (GuestNumber > 2 && (Three_Star_Radio_Button.Checked || Four_Star_Radio_Button.Checked || Five_Star_Hotel_Radio_Button.Checked) && Food_CheckBox.Checked)
                            {
                                decimal overallcost = TotalTripCost + TotalAddOnCost;
                                TotalOverallCost.Text = (overallcost - (overallcost * OverAlldiscount)).ToString("C2");
                            }
                            else
                            {
                                TotalOverallCost.Text = (TotalTripCost + TotalAddOnCost).ToString("C2");
                            }
            //Hiding and unhiding Panels
                            BookingPanel.Visible = true;
                            BookingDetailsLabel.Visible = true;
                            AddOnsPanel.Visible = false;
                            MainPanel.Visible = false;
                            OverallBookingDiscount.Visible = false;
                            SummaryPanel.Visible = false;
                            SummaryPanelLabel.Visible = false;
            //Changing form Text
                            this.Text = "Booking Details";
            //Focus for Book Button
                            BookButton.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Select the time of Departure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Time_ListBox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select the Destination", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DestinationLabel.Focus();
                        DestinationLabel.Select();
                    } 
                }
                else
                {
                    MessageBox.Show("Enter Valid Positive Numeric Values for Number of Guests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guest_Number_TextBox.Focus();
                    Guest_Number_TextBox.SelectAll();
                }
            }
            catch
            {
                MessageBox.Show("Enter Valid Positive Numeric Values for Number of Guests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guest_Number_TextBox.Focus();
                Guest_Number_TextBox.SelectAll();
            }
        }

            //No Hotel Option in Booking Section
        private void No_Thanks_Hotel__Radio_Button_CheckedChanged(object sender, EventArgs e)
        {
            //Calculations for changing Values in Booking Section
            decimal NumberOfGuests = decimal.Parse(Guest_Number_TextBox.Text);
            TotalAddOnCostsLabel.Text = (TotalAddOnCost - (NumberOfGuests * hotelvaluerate)).ToString("C2");
            Five_Star_Hotel_Radio_Button.Checked = false;
            Four_Star_Radio_Button.Checked = false;
            Three_Star_Radio_Button.Checked = false;
            TotalOverallCost.Text = (TotalTripCost + (TotalAddOnCost - (NumberOfGuests * hotelvaluerate))).ToString("C2");
            hotelSelected = "None";
            HotelDisplayLabel.Text = hotelSelected;
        }
            //Previous Button if user wants to Make Changes in the trip
        private void MakeChangesButton_Click(object sender, EventArgs e)
        {
            //Hiding and unhiding Panels
            BookingPanel.Visible = false;
            BookingDetailsLabel.Visible = false;
            AddOnsPanel.Visible = true;
            MainPanel.Visible = true;
            OverallBookingDiscount.Visible = true;
            SummaryPanel.Visible = false;
            SummaryPanelLabel.Visible = false;
            No_Thanks_Hotel__Radio_Button.Checked = false;
            //Changing form Text
            this.Text = "Welcome to Mild Atlantic Bus Tours";
            //Focus for Guest Number Text Box
            Guest_Number_TextBox.Focus();
        }
        //Summary Global Variables
        int numberoftranscations;
        decimal SummaryAddOnCost;
        decimal SummaryTripCost;
            //Book Button Action
        private void BookButton_Click(object sender, EventArgs e)
        {
            //String values for Message Box -- Details of Booking
            String display = "Number of seat(s) Booked:\t" + Guest_Number_TextBox.Text + "\nLocation Selected:\t\t" + DestinationNameDisplayLabel.Text + "\nTime of Departure:\t" + TimeDisplayLabel.Text + "\nTotal Overall Cost:\t\t" + TotalOverallCost.Text;
            string hoteldisplay = "\nHotelSelected:\t\t" + hotelSelected;    
            //condition statement for Booking
                if (MessageBox.Show(display+hoteldisplay, "Are you sure you want to Book?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
            //Calculations for Summary 
                string TotalAddOnCost = TotalAddOnCostsLabel.Text.Remove(0, 1);
                    SummaryTripCost += TotalTripCost;
                SummaryAddOnCost += decimal.Parse(TotalAddOnCost);
                    numberoftranscations += 1;
            //Booking Confirmed
                    MessageBox.Show("Your Booking is Confirmed\nEnjoy your Tour!!", "CONGRAGULATIONS!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Hiding and Unhiding Panels
                    BookingPanel.Visible = false;
                    BookingDetailsLabel.Visible = false;
                    MainPanel.Visible = true;
                    AddOnsPanel.Visible = true;
                    OverallBookingDiscount.Visible = true;
                    SummaryPanel.Visible = false;
                    SummaryPanelLabel.Visible = false;
                    Date_Picker.Value = DateTime.Now.AddDays(1);
                    Destination_List_Box.SelectedIndex = -1;
                    Time_ListBox.SelectedIndex = -1;
                    Display_Button.Enabled = true;
                    Three_Star_Radio_Button.Checked = false;
                    Four_Star_Radio_Button.Checked = false;
                    Five_Star_Hotel_Radio_Button.Checked = false;
                    Food_CheckBox.Checked = false;
            //Guest Box Focus
                    Guest_Number_TextBox.Clear();
                    Guest_Number_TextBox.Focus();
                    Guest_Number_TextBox.SelectAll();
                //Changing form Text
                this.Text = "Weclome to Mild Atlantic Tours";
                }
                 else
                 {
            //Focus on Review/Make Changes Button
                    MakeChangesButton.Focus();
                 }
        }
        // Summary Button Action
        private void SummaryButton_Click(object sender, EventArgs e)
        {
        //Condition for Number of Transcations Not Null
            if (numberoftranscations != 0)
            {
                BookingPanel.Visible = false;
                BookingDetailsLabel.Visible = false;
                Display_Button.Enabled = false;
                AddOnsPanel.Visible = false;
                this.Text = "Summary Details";
                MainPanel.Visible = false;
                OverallBookingDiscount.Visible = false;
                SummaryPanelLabel.Visible = true;
                SummaryPanel.Visible = true;
                ClearButton.Focus();
                // decimal ValueOfOptions = decimal.Parse(TotalAddOnCostsLabel.Text);
                NumberOfTranscationsLabel.Text = numberoftranscations.ToString();
                SummaryTotalTripFees.Text = SummaryTripCost.ToString("C2");
                AverageRevenue.Text = (SummaryTripCost / numberoftranscations).ToString("C2");
                ValueOfOptionsChosenLabel.Text = SummaryAddOnCost.ToString("C2");

            }
            else
            {
                MessageBox.Show("No Bookings have been made","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Clear Button Action
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Display_Button.Enabled = true;
            BookingPanel.Visible = false;
            BookingDetailsLabel.Visible = false;
            MainPanel.Visible = true;
            AddOnsPanel.Visible = true;
            OverallBookingDiscount.Visible = true;
            SummaryPanel.Visible = false;
            SummaryPanelLabel.Visible = false;
            Guest_Number_TextBox.Focus();
            this.Text = "Welcome to Mild Atlantic Tours";
            Guest_Number_TextBox.SelectAll();
            Date_Picker.Value = DateTime.Now.AddDays(1);
            Destination_List_Box.SelectedIndex = -1;
            Time_ListBox.SelectedIndex = -1;
            Three_Star_Radio_Button.Checked = false;
            Four_Star_Radio_Button.Checked = false;
            Five_Star_Hotel_Radio_Button.Checked = false;
            Food_CheckBox.Checked = false;
            Guest_Number_TextBox.Clear();
            Guest_Number_TextBox.Focus();
            Guest_Number_TextBox.SelectAll();
        }
        //Exit Button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
