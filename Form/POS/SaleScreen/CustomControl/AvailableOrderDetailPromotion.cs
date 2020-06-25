﻿using POS.CustomControl;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS.SaleScreen.CustomControl
{
    public partial class AvailableOrderDetailPromotion : Form
    {

        public PromotionEditViewModel Promotion { get; set; }
        //public PromotionInfoPanel2 PromotionInfoPanel { get; set; }

        public event Action<PromotionEditViewModel> TryApplyPromotionDetail;


        public AvailableOrderDetailPromotion(PromotionEditViewModel promotion)
        {
            InitializeComponent();
            this.Promotion = promotion;
            GenerateLayout();
        }
        public void GenerateLayout()
        {
            pnlHeader.BackgroudBootstrapColor = BootstrapColorEnum.Success;
            pnlAvailablePromotion.BackgroudBootstrapColor = BootstrapColorEnum.Success;

            lblPromotionTitle.Text = Promotion.Description;
            foreach (var button in pnlAvailablePromotion.Controls.Cast<BootstrapButton>())
            {
                button.Tag = null;
                button.Visible = false;
            }

            LoadPromotion();

            this.lblPromotionTitle.Text = MainForm.ResManager.GetString("Sys_Promotion", MainForm.CultureInfo);

        }
        public void LoadPromotion()
        {
            foreach (var promotionDetail in Promotion.PromotionDetailViewModels)
            {
                foreach (var button in pnlAvailablePromotion.Controls.Cast<BootstrapButton>())
                {
                    if (button.Tag == null)
                    {
                        LoadPromotionToButton(button, promotionDetail);
                        break;
                    }
                }
            }

        }
        private void LoadPromotionToButton(BootstrapButton button, PromotionDetailViewModel promotionDetail)
        {
            if (promotionDetail != null)
            {

                button.Tag = promotionDetail;
                button.ImageCss = Promotion.ImageCss;

                if (promotionDetail.DiscountRate != null)
                {
                    button.TextValue = promotionDetail.DiscountRate.ToString();
                }
                else
                {
                    button.TextValue = string.Format("{0:n0}", promotionDetail.DiscountAmount);
                }

                button.Visible = true;
                button.ActiveBackgroudColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

                button.Enabled = true;
                button.BackgroudBootstrapColor = BootstrapColorEnum.Default;

            }
        }

        private void AvailablePromotion_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PromotionButton_Click(object sender, EventArgs e)
        {
            //if (ApplyPromotion != null)
            //{
            //    ApplyPromotion(Promotion);
            //}

           
            
            var button = (BootstrapButton)sender;
            var promotionDetail =(PromotionDetailViewModel) button.Tag;

            var promotionDetails = new List<PromotionDetailViewModel> { promotionDetail };

            PromotionEditViewModel promotion = (PromotionEditViewModel)Promotion.Clone();
            promotion.PromotionDetailViewModels = promotionDetails;
            TryApplyPromotionDetail(promotion);
            this.Close();
        }
    }
}
