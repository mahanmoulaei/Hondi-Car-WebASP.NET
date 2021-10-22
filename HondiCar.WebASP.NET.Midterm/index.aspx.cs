//AUTHOR : MAHAN MOULAEI
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HondiCar.WebASP.NET.Midterm
{
    public partial class index : System.Web.UI.Page
    {
        int NumberOfCheckedAccessoryCheckBox;
        String accessorySelected;

        protected void Page_Load(object sender, EventArgs e)
        {
            PanelPrice.Visible = PanelFinal.Visible = false;

            if (!Page.IsPostBack)
            {
                //Hide Phone Number
                labelPhoneNumber.Visible = textPhoneNumber.Visible = false;

                //Adding Car Models To Drop Down List
                dropdownCarModel.Items.Add(new ListItem("Civoc (+ $25000)", "25000"));
                dropdownCarModel.Items.Add(new ListItem("DR-V (+ $30000)", "30000"));
                dropdownCarModel.Items.Add(new ListItem("Appord (+ $33000)", "33000"));
                dropdownCarModel.Items.Add(new ListItem("Cilot (+ $45000)", "45000"));
                dropdownCarModel.Items.Add(new ListItem("Odyrrey (+ $54000)", "54000"));
                dropdownCarModel.SelectedIndex = 0;

                //Adding Interior Colours
                listInteriorColour.Items.Add(new ListItem("White (Free)", "0"));
                listInteriorColour.Items.Add(new ListItem("Dark (+ $300)", "300"));
                listInteriorColour.Items.Add(new ListItem("Pearl (+ $900)", "900"));
                listInteriorColour.SelectedIndex = 0;

                //Adding Accessories
                checkboxAccessories.Items.Add(new ListItem("Aero Kit (+ $1300)", "1300"));
                checkboxAccessories.Items.Add(new ListItem("Film (+ $600)", "600"));
                checkboxAccessories.Items.Add(new ListItem("Cold Weather (+ $900)", "900"));
                checkboxAccessories.Items.Add(new ListItem("Hondi Emblem (+ $150)", "150"));
                checkboxAccessories.Items.Add(new ListItem("Snow Tire Package (+ $1800)", "1800"));

                //Adding Warranty
                radiobuttonWarranty.Items.Add(new ListItem("3 Years (Included)", "0"));
                radiobuttonWarranty.Items.Add(new ListItem("5 Years (+ $1000)", "1000"));
                radiobuttonWarranty.Items.Add(new ListItem("7 Years (+ $1500)", "1500"));
                radiobuttonWarranty.SelectedIndex = 0;
            }

            if (dropdownCarModel.SelectedIndex > 0)
            {
                CalculatePrice();
            }
        }

        private void CalculatePrice()
        {
            decimal carModelPrice = 0, interiorColourPrice = 0, accessoriesPrice = 0, warrantyPrice = 0, subTotal = 0, finalPrice = 0;

            carModelPrice = Convert.ToDecimal(dropdownCarModel.SelectedItem.Value);

            interiorColourPrice = Convert.ToDecimal(listInteriorColour.SelectedItem.Value);

            foreach (ListItem accessory in checkboxAccessories.Items)
            {
                accessoriesPrice += (accessory.Selected) ? Convert.ToDecimal(accessory.Value) : 0;
            }

            warrantyPrice = Convert.ToDecimal(radiobuttonWarranty.SelectedItem.Value);

            subTotal = carModelPrice + interiorColourPrice + accessoriesPrice + warrantyPrice;

            finalPrice = Math.Round(subTotal * Convert.ToDecimal(0.15), 0) + subTotal;

            literalPrice.Text = "Car Price: $" + carModelPrice.ToString() + "<br>" + 
                                "Interior Color: $" + interiorColourPrice + "<br>" +
                                "Accessories: $" + accessoriesPrice + "<br>" +
                                "Warranty: $" + warrantyPrice + "<br>" +
                                "<br>" +
                                "<br>" +
                                "<br>" + 
                                "Total Price Without Tax: $" + subTotal + "<br>" +
                                "Total Price With Tax(%15): $" + finalPrice + "<br>";

            PanelPrice.Visible = true;
        }

        protected void dropdownCarModel_Changed(object sender, EventArgs e)
        {

        }

        protected void listInteriorColour_Changed(object sender, EventArgs e)
        {

        }

        protected void checkboxAccessories_Changed(object sender, EventArgs e)
        {

        }

        protected void radiobuttonWarranty_Changed(object sender, EventArgs e)
        {

        }

        protected void checkboxShouldDealerContactYou_Changed(object sender, EventArgs e)
        {
            //Show/Hide Phone Number
            labelPhoneNumber.Visible = textPhoneNumber.Visible = checkboxShouldDealerContactYou.Checked;
        }

        protected void buttonConclude_Click(object sender, EventArgs e)
        {
            NumberOfCheckedAccessoryCheckBox = GetNumberOfCheckedAccessory();

            //Show Final Information Panel
            PanelFinal.Visible = true;

            //Car Model
            String carModelName = dropdownCarModel.SelectedItem.Text.Split('(')[0];

            //Car Interior Colour
            String carInteriorColour = listInteriorColour.SelectedItem.Text.Split('(')[0];

            literalFinalInformation.Text = "Congratulation In Obtaining Your New" + "<br>" +
                                            "Hondi " + carModelName + " In " + textCity.Text + ", " + textZipCode.Text + "." + "<br>" +
                                            "<br>" + 
                                            "Your Car Comes With " + carInteriorColour + " Interior Colour";

            //Car Accessories
            if (NumberOfCheckedAccessoryCheckBox == 0)
            {
                literalFinalInformation.Text += ".";
            } else
            {
                foreach (ListItem accessory in checkboxAccessories.Items)
                {
                    accessorySelected = (accessory.Selected) ? (accessory.Text.Split('(')[0]) : null;

                    if (accessorySelected != null)
                    {
                        accessorySelected = accessorySelected.Substring(0, accessorySelected.Length - 1);

                        if (NumberOfCheckedAccessoryCheckBox > 1)
                        {
                            literalFinalInformation.Text += ", " + accessorySelected;
                        }
                        else
                        {
                            literalFinalInformation.Text += ", And " + accessorySelected + " Accessory.";
                            break;
                        }
                        NumberOfCheckedAccessoryCheckBox --;
                    }
                }
            }

            //Car Warranty
            literalFinalInformation.Text += (checkboxShouldDealerContactYou.Checked) ?  "<br>" +
                                                                                        "<br>" +
                                                                                        "You Choosed " + radiobuttonWarranty.SelectedItem.Text.Split('(')[0] + "Of Warranty And Our Dealer Will Contact You By The Phone Number " + textPhoneNumber.Text + "." : "<br>" +
                                                                                                                                                                                                                                                "<br>" +
                                                                                                                                                                                                                                                "You Choosed " + radiobuttonWarranty.SelectedItem.Text.Split('(')[0] + "Of Warranty.";
        }

        private int GetNumberOfCheckedAccessory()
        {
            NumberOfCheckedAccessoryCheckBox = 0;
            foreach (ListItem accessory in checkboxAccessories.Items)
            {
                NumberOfCheckedAccessoryCheckBox += (accessory.Selected) ? 1 : 0;
            }
            return NumberOfCheckedAccessoryCheckBox;
        }
    }
}